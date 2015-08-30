using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        #region 변수 선언

        DataBase DB = new DataBase();
        private delegate void SetTextCallback(string strMessage);   // 수신 관련 
        private static int MSG_COUNT = 0;                           // 보낸 메세지 카운트
        private static int seqno = 37;
        private int Mcount = 0;                                     // 보낼 메세지 갯수
        private string RFMsg;                                       // 보낼 메세지
        private string HRR100, HRR200, HRR300;                      // 좌표 변수
        string datatime = string.Empty;                             // 현재시간 체크
        bool chk_usable = true;                                     // 좌표 전송 가능 체크 변수 true:가능
        
        //전문관련 변수
        private const byte STX = 0x7E;                              // 전문 시작/종료 신호
        private const byte ETX = 0x7E;                              // 전문 시작/종료 신호
        byte[] readMsg = new byte[50];                              // 정리된 메세지
        string strReadMsg = string.Empty;                           // 
        private const byte unUsed = 0x40;                           // 7E 40 으로 시작하는 전문
        int read_msg_count = 0;                                     // 읽은 메세지 카운트       
        bool chkFlagData = false;                                   // ???        
        bool chkFlagStx = false;                                    // 첫번째 7E ?? true 첫번째 아님 false 첫번째
        bool chkFlagNeed = true;                                    // 필요전문인지 아닌지 판단, false 불필요

        //받은 데이터 관련 변수
        string address_Data = string.Empty;                         // 노드번호 hex 값
        int Node_num;                                               // 노드 번호 변수
        string value = string.Empty;                                // 받은 값 변수
        double datavalue;                                           //데이터값  
        double cel;                                                 //온도계산
                          
        //위치좌표 관련 변수
        string Msg_Temp = string.Empty;                             // 공백 없앤 메세지
        string point = string.Empty;                                // 좌표 변수 

        //좌표관련
        string name1 = "";
        string name2 = "";
        string name3 = "";

        #endregion
                   
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                RS232_Open();
                combo_Loc1.SelectedIndex = 0;
                combo_Loc2.SelectedIndex = 0;
                combo_Loc3.SelectedIndex = 0;

                string TB_Name = "Fixed_set";
                string Field_Name = "Node_Num";

                DB.Open();

                MySqlDataReader M_Reader = DB.Search_Navilist(TB_Name, Field_Name);

                while (M_Reader.Read())
                {
                    combo_Loc1.Items.Add(M_Reader["Loca_Name"].ToString());
                    combo_Loc2.Items.Add(M_Reader["Loca_Name"].ToString());
                    combo_Loc3.Items.Add(M_Reader["Loca_Name"].ToString());
                }
                M_Reader.Close();

                DB.Dispose();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RS232_Close();
        }

        // 수신값 저장
        private void Save_Value(string MSG)
        {
            address_Data = string.Format("{0:X2} ", readMsg[8]).Trim();

            Node_num = HexToDecimal(address_Data);

            if (Node_num == 4)
            {
                Msg_Temp = strReadMsg.Replace(" ", "");

                int No = Convert.ToInt32(Msg_Temp.Substring(25, 1));              // 데이터를 보낸 노드 번호

                Msg_Temp = Msg_Temp.Substring(26, 48);

                //받은 데이터에서 메세지만 뽑아 헥사형식으로 변환
                for (int i = 0; i <= Msg_Temp.Length - 2; i += 2)
                {
                    int temp = Convert.ToInt32(Msg_Temp.Substring(i, 2)) - 30;

                    if (temp != -30)
                    {
                        switch (temp)
                        {
                            case 11: value += "A"; break;
                            case 12: value += "B"; break;
                            case 13: value += "C"; break;
                            case 14: value += "D"; break;
                            case 15: value += "E"; break;
                            case 16: value += "F"; break;
                            default: value += Convert.ToString(temp); break;
                        }
                    }
                }

                DB.Open();

                for (int i = 0; i <= value.Length - 4; i += 4)
                {
                    string msg = value.Substring(i, 4);

                    //데이터 변환
                    datavalue = HexToDecimal(msg);
                    cel = ((datavalue * 2.8) / 1024) * 1000;
                    cel = (cel - 500) / 10.0;
                    string celbuffer = string.Format("{0:##.00}", cel);
                    datavalue = Convert.ToDouble(celbuffer);

                    string val = Convert.ToString(datavalue);

                    datatime = DateTime.Now.ToString("g");

                    int Turn = DB.Search_Turn(No);

                    DB.Save_Data(No, datatime, val, Turn);                    
                }                
                value = string.Empty;
                
                chk_usable = true;                   // 수신가능 변환                
                DB.Del_Navi(No);                       // 경로 정보 삭제
                DB.Dispose();                        // DB 연결 끊기
            }            
        }

        #region Button_Event

        //메세지 전송
        private void button_send_Click(object sender, EventArgs e)
        {
            if (chk_usable == false)
            {
                MessageBox.Show("경로 정보를 수신할 장비가 없습니다.");
                return;
            }                   

            #region 보낼 메세지 수 정하기
            if (combo_Loc1.SelectedIndex == 0)
            {
                MessageBox.Show("첫번째 경로를 지정해 주십시오.");
                return;
            }
            if (combo_Loc2.SelectedIndex == 0)
            {
                Mcount = 1;                
            }
            else if (combo_Loc3.SelectedIndex == 0)
            {
                Mcount = 2;                
            }            
            else
            {
                Mcount = 3;                 
            }             
            #endregion                     

            #region 전문생성& 경로정보 저장

            DB.Open();

            string tmp = lati_1.Text;
            string tmp2 = grad_1.Text;

            string date = DateTime.Now.ToString("yyMMdd");
            string time = DateTime.Now.ToString("T");
            if (lati_1.Text != "")
            {
                DB.Save_Navi2(tmp, tmp2, 1);
                name1 = DB.Search_Name(tmp, tmp2);
                HRR100 = "010" + Mcount + tmp.Replace(".", "") + tmp2.Replace(".", "");
                if (lati_2.Text == "")
                {
                    DB.Save_Navi(date, time, name1, name2, name3);         //경로 정보 저장                    
                }              
            }           
            if (lati_2.Text != "")
            {
                tmp = lati_2.Text;
                tmp2 = grad_2.Text;
                name2 = DB.Search_Name(tmp, tmp2);
                DB.Save_Navi2(tmp, tmp2, 2);
                HRR200 = "020" + Mcount + tmp.Replace(".", "") + tmp2.Replace(".", "");
                if (lati_3.Text == "")
                {
                    DB.Save_Navi(date, time, name1, name2, name3);         //경로 정보 저장                    
                } 
            }
            if (lati_3.Text != "")
            {
                tmp = lati_3.Text;
                tmp2 = grad_3.Text;
                name3 = DB.Search_Name(tmp, tmp2);
                DB.Save_Navi2(tmp, tmp2, 3);
                DB.Save_Navi(date, time, name1, name2, name3);         //경로 정보 저장
                HRR300 = "030" + Mcount + tmp.Replace(".", "") + tmp2.Replace(".", "");
            }            
            DB.Dispose();

            #endregion

            int i;
            for (i = 1; i <= Mcount; i++)
            {
                int count;

                switch (i)
                {
                    case 1: RFMsg = HRR100; break;
                    case 2: RFMsg = HRR200; break;
                    case 3: RFMsg = HRR300; break;                                       
                }
                seqno++;

                CreateRFMessages m = new CreateRFMessages();

                byte[] sendMsg = m.create_framed_packet(System.Convert.ToByte(seqno), 0x04, RFMsg);

                count = System.Convert.ToInt32(sendMsg[7]) + 10;      // 왜 +10 ???

                if (RS232.IsOpen)
                {
                    lock (RS232)
                    {
                        RS232.Write(sendMsg, 0, count);
                    }
                }
                debugRFMsg(count, sendMsg);
            }            
            
            chk_usable = false;
        }

        private void text_del_Click(object sender, EventArgs e)
        {
            txtMessage_rev.Clear();
        }

        private void text_del_send_Click(object sender, EventArgs e)
        {
            txtMessage_send.Clear();
        }

        #endregion
       
        #region RS232 통신 함수

        // RS-232 Open        
        private void RS232_Open()
        {
            /* RS232 통신 */
            if (!RS232.IsOpen)
            {
                /* 통신 수동 설정 
                ConfigXML configXML = new ConfigXML(Application.StartupPath + "\\Config.xml");

                RS232.PortName = configXML.GetXmlData("USN_PRT_SYSTEM/CommSetting", "PortName");
                RS232.BaudRate = int.Parse(configXML.GetXmlData("USN_PRT_SYSTEM/CommSetting", "BaudRate"));
                RS232.DataBits = int.Parse(configXML.GetXmlData("USN_PRT_SYSTEM/CommSetting", "DataBits"));
                RS232.Parity = Common.GetParity(configXML.GetXmlData("USN_PRT_SYSTEM/CommSetting", "Parity"));
                RS232.StopBits = Common.GetStopBits(configXML.GetXmlData("USN_PRT_SYSTEM/CommSetting", "StopBits"));
                */
                try
                {
                    RS232.Open();
                    state.Text= "상태 : 포트 열림";
                }
                catch (Exception e)
                {
                    MessageBox.Show("msg -> " + e.StackTrace);
                }
            }
        }
        
        // 포트 접속 해제        
        private void RS232_Close()
        {
            if (RS232.IsOpen)
            {
                RS232.Close();
                state.Text = "상태 : 포트 닫힘";
            }
        }

        //시리얼 수신 데이터가 있을때
        private void RS232_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strMessage = RS232.ReadExisting();
            if (strMessage != string.Empty)
            {
                MessageRead(strMessage);
            }
        }

        /// <summary> 수신 전문 읽기
        /// 
        /// </summary>
        /// <param name="strMessage">수신 전문</param>
        private void MessageRead(string strMessage)
        {
            string strBuffer = string.Empty;
            byte[] bMsg = DataEncoding(strMessage);

            for (int i = 0; i < bMsg.GetLength(0); i++)
            {
                if (chkFlagData != true)             // 1. 첫데이터가 STX 인지 확인 플래그 체크
                {
                    if (bMsg[i] == STX)              // 1-1. 데이터가 STX?
                    {
                        if (read_msg_count <= 1)     // 1-1-1. STX가 첫번째 데이터
                        {
                            readMsg[0] = bMsg[i];
                            strReadMsg = String.Format("{0:X2} ", bMsg[i]);
                            read_msg_count = 1;
                            chkFlagStx = true;
                        }                       
                    }
                    else                             // 1-2. STX가 아닐경우
                    {                        
                        if (bMsg[i] == unUsed)
                        { chkFlagNeed = false; }
                        chkFlagData = true;
                        readMsg[read_msg_count++] = bMsg[i];
                        strReadMsg += String.Format("{0:X2} ", bMsg[i]);                        
                    }
                }
                else                                // 2. ETX 값이 올때까지 저장
                {
                    if (bMsg[i] == ETX)             // 2-1. ETX 가 들어왔는지?
                    {
                        readMsg[read_msg_count++] = bMsg[i];
                        strReadMsg += String.Format("{0:X2} ", bMsg[i]);

                        if (chkFlagNeed == true)
                        {
                            SetText_rev(strReadMsg);                          
                        }
                        // 값 초기화
                        chkFlagNeed = true;
                        chkFlagStx = false;
                        chkFlagData = false;
                        strReadMsg = string.Empty;
                        read_msg_count = 0;
                    }
                    else
                    {
                        readMsg[read_msg_count++] = bMsg[i];
                        strReadMsg += String.Format("{0:X2} ", bMsg[i]);
                    }
                }
            }
        }

        /// <summary> 바이트 배열로 인코딩
        /// 
        /// </summary>
        /// <param name="strMessage">수신 전문</param>
        private byte[] DataEncoding(string strMessage)
        {
            return System.Text.Encoding.GetEncoding(0).GetBytes(strMessage);
        }
   
        /// <summary> TextBox Invoke 
        /// 
        /// </summary>
        /// <param name="strMessage">수신 전문</param>
        /// 
        private void SetText_rev(string strLine)
        {
            if (this.txtMessage_rev.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_rev);
                this.Invoke(d, new object[] { strLine });
            }
            else
            {
                MSG_COUNT++;
                txtMessage_rev.AppendText(MSG_COUNT.ToString() + " : " + strLine + Environment.NewLine);
                txtMessage_rev.SelectionStart = txtMessage_rev.Text.Length;
                txtMessage_rev.ScrollToCaret();
                Save_Value(strLine);
            }
        }

        /// <summary> TextBox Invoke 
        /// 
        /// </summary>
        /// <param name="strMessage">수신 전문</param>
        /// 
        private void SetText_send(string strLine)
        {
            if (this.txtMessage_send.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_send);
                this.Invoke(d, new object[] { strLine });
            }
            else
            {
                MSG_COUNT++;
                txtMessage_send.AppendText(MSG_COUNT.ToString() + " : " + strLine + Environment.NewLine);
                txtMessage_send.SelectionStart = txtMessage_send.Text.Length;
                txtMessage_send.ScrollToCaret();                
            }
        }
       
        private void debugRFMsg(int _count, byte[] source)
        {
            int i;
            string str = string.Empty;

            for (i = 0; i < source.Length; i++)
            {
                str += System.Convert.ToString(source[i], 16) + " ";
            }
            //SetText_send(System.Convert.ToString(_count));
            SetText_send(str);
        }

        private int HexToDecimal(string str)
        {
            return Convert.ToInt32(str, 16);
        } 
                  
        #endregion
                
        #region ComboBox_SelectedInDexChanged
        
        private void combo_Loc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Loc1.SelectedIndex == 0)
            {
                lati_1.Text = "";
                grad_1.Text = "";
                return;
            }
            if (combo_Loc2.SelectedIndex == combo_Loc1.SelectedIndex)
            {
                MessageBox.Show("동일한 경로를 연속해서 지정할수 없습니다.");
                combo_Loc1.SelectedIndex = 0;
                return;
            }

            string Loc1_Name = combo_Loc1.Text;
            string TB_Name = "Fixed_set";

            DB.Open();

            MySqlDataReader M_Reader = DB.Search_Navi_Info(TB_Name, Loc1_Name);

            while (M_Reader.Read())
            {
                lati_1.Text = M_Reader["Latitude"].ToString();
                grad_1.Text = M_Reader["Gradient"].ToString();
            }
            M_Reader.Close();

            DB.Dispose();
        }

        private void combo_Loc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Loc2.SelectedIndex == 0)
            {
                lati_2.Text = "";
                grad_2.Text = "";
                return;
            }
            if (combo_Loc1.SelectedIndex == 0)
            {
                MessageBox.Show("첫번째 경로를 지정해 주십시오.");
                combo_Loc3.SelectedIndex = 0;
                return;
            }
            if (combo_Loc1.SelectedIndex == combo_Loc2.SelectedIndex)
            {
                MessageBox.Show("동일한 경로를 연속해서 지정할수 없습니다.");
                combo_Loc2.SelectedIndex = 0;
                return;
            }
            if (combo_Loc3.SelectedIndex == combo_Loc2.SelectedIndex)
            {
                MessageBox.Show("동일한 경로를 연속해서 지정할수 없습니다.");
                combo_Loc2.SelectedIndex = 0;
                return;
            }

            string Loc2_Name = combo_Loc2.Text;
            string TB_Name = "Fixed_set";

            DB.Open();

            MySqlDataReader M_Reader = DB.Search_Navi_Info(TB_Name, Loc2_Name);

            while (M_Reader.Read())
            {
                lati_2.Text = M_Reader["Latitude"].ToString();
                grad_2.Text = M_Reader["Gradient"].ToString();
            }
            M_Reader.Close();

            DB.Dispose();
        }

        private void combo_Loc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Loc3.SelectedIndex == 0)
            {
                lati_3.Text = "";
                grad_3.Text = "";
                return;
            }
            if (combo_Loc2.SelectedIndex == combo_Loc3.SelectedIndex)
            {
                MessageBox.Show("동일한 경로를 연속해서 지정할수 없습니다.");
                combo_Loc3.SelectedIndex = 0;
                return;
            }
            if (combo_Loc1.SelectedIndex == 0)
            {
                MessageBox.Show("첫번째 경로를 지정해 주십시오.");
                combo_Loc3.SelectedIndex = 0;
                return;
            } 
            if (combo_Loc2.SelectedIndex == 0)
            {
                MessageBox.Show("두번째 경로를 지정해 주십시오.");
                combo_Loc3.SelectedIndex = 0;
                return;
            } 

            string Loc3_Name = combo_Loc3.Text;
            string TB_Name = "Fixed_set";

            DB.Open();

            MySqlDataReader M_Reader = DB.Search_Navi_Info(TB_Name, Loc3_Name);

            while (M_Reader.Read())
            {
                lati_3.Text = M_Reader["Latitude"].ToString();
                grad_3.Text = M_Reader["Gradient"].ToString();
            }
            M_Reader.Close();

            DB.Dispose();
        }
       
        #endregion                               
    }
}