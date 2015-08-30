using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;         //파일 실행

//using System.Collections.Generic;
//using System.ComponentModel;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        #region 변수 선언

        private delegate void SetTextCallback(string strMessage);   // 수신 관련 
        private static int seqno = 37;
        cam cm = new cam();

        //전문관련 변수
        private const byte STX = 0x7E;                               // 전문 시작/종료 신호
        private const byte ETX = 0x7E;                               // 전문 시작/종료 신호
        byte[] readMsg = new byte[50];                              // 정리된 메세지
        string strReadMsg = string.Empty;                           // 
        private const byte unUsed = 0x40;                           // 7E 40 으로 시작하는 전문
        int read_msg_count = 0;                                     // 읽은 메세지 카운트       
        bool chkFlagData = false;                                   // ???        
        bool chkFlagStx = false;                                    // 첫번째 7E ?? true 첫번째 아님 false 첫번째
        bool chkFlagNeed = true;                                    // 필요전문인지 아닌지 판단, false 불필요

        //받은 데이터 관련 변수
        string address_Data = string.Empty;
        static string msg_Data = string.Empty;
        string comp_Data = string.Empty;
        string msg_bufferData1;                                     // 임시기억장소 데이터값 
        string msg_bufferData2;                                     // 임시기억장소 데이터값
        string datavalue = string.Empty;                            // 데이터값 
        string datatime = string.Empty;                             // 현재시간 체크
        int Node_num;                                               // 노드 번호

        //위치좌표 관련 변수
        string Msg_Temp = string.Empty;                             // 공백 없앤 메세지
        string point = string.Empty;                                // 좌표 변수 

        string dirpath = "c:\\temp\\autobot7";

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
                    state.Text = "상태 : 포트 열림";
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
                            SetText_recieve(strReadMsg);

                            //데이터 형식(0부터 시작)
                            //7E 42 3F 3F 0A 7D 5D 1A 01 00 3C 00 01 00 5C 01 5A 01 5A 01 
                            //5B 01 5C 01 5B 01 59 01 58 01 59 01 5B 01 3F 3F 7E
                            address_Data = string.Format("{0:X2} ", readMsg[8]).Trim();
                            Node_num = HexToDecimal(address_Data);
                            msg_bufferData1 = string.Format("{0:X2} ", readMsg[14]).Trim();
                            msg_bufferData2 = string.Format("{0:X2} ", readMsg[15]).Trim();

                            Msg_Temp = strReadMsg.Replace(" ", "");

                            datavalue = msg_bufferData2 + msg_bufferData1;

                            //온도
                            //datavalue = HexToDecimal(datavalue);
                            //cel = ((datavalue * 2.8) / 1024) * 1000;
                            //cel = (cel - 500) / 10.0;
                            //string celbuffer = string.Format("{0:##.00}", cel);
                            //datavalue = Convert.ToDouble(celbuffer);
                            //조도 : 855 - HexToDecimal(datavalue1); break;
                            //진동 : HexToDecimal(datavalue1); timer++; break;

                            if (Node_num == 4)
                            {
                                SetText_change(Msg_Temp);
                            }
                            else
                            {
                                SetText_change(datavalue);
                            }
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
        private void SetText_recieve(string strLine)
        {
            if (this.txtMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_recieve);
                this.Invoke(d, new object[] { strLine });
            }
            else
            {
                txtMessage.AppendText("MSG : " + strLine + Environment.NewLine);
                txtMessage.SelectionStart = txtMessage.Text.Length;
                txtMessage.ScrollToCaret();
            }
        }

        /// <summary> TextBox Invoke 
        /// 
        /// </summary>
        /// <param name="strMessage">수신 전문</param>
        /// 
        private void SetText_send(string strLine)
        {
            if (this.textBox5.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_send);
                this.Invoke(d, new object[] { strLine });
            }
            else
            {
                textBox5.AppendText("MSG :  " + strLine + Environment.NewLine);
                textBox5.SelectionStart = textBox5.Text.Length;
                textBox5.ScrollToCaret();
            }
        }

        private void SetText_change(string MSG)
        {
            if (this.textBox_recieve.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_change);
                this.Invoke(d, new object[] { MSG });
            }
            else
            {
                textBox_recieve.AppendText("MSG : " + MSG + Environment.NewLine);
                textBox_recieve.SelectionStart = textBox_recieve.Text.Length;
                textBox_recieve.ScrollToCaret();

                if (Node_num == 4)                  // 토스 베이스 끼리 통신일때
                {
                    string MSG_Num = MSG.Substring(27, 1);
                    string MSG_Count = MSG.Substring(31, 1);
                    string address = MSG.Substring(32, 34);

                    int i;
                    for (i = 1; i <= 33; i++)
                    {
                        point += address.Substring(i, 1);
                        i++;
                    }

                    if (MSG_Num == MSG_Count)
                    {
                        Save_Data(point, Node_num);
                        point = string.Empty;
                    }
                }
                else if ((Node_num != 0))            // 센서에서 값을 받을 때
                {
                    Save_Data(MSG, Node_num);
                }
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
            //SetText(System.Convert.ToString(_count));
            SetText_send(str);
        }

        private int HexToDecimal(string str)
        {
            return Convert.ToInt32(str, 16);
        }

        private void Send_MSG(string MSG)
        {
            int count;
            seqno++;

            CreateRFMessages m = new CreateRFMessages();

            byte[] sendMsg = m.create_framed_packet(System.Convert.ToByte(seqno), 0x04, MSG);

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
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region 버튼 이벤트

        private void button_connect_Click(object sender, EventArgs e)
        {
            RS232_Open();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            RS232_Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Get_Sensorvalue();
        }

        #endregion

        //데이터 저장
        private void Save_Data(string value, int Num)
        {
            try
            {
                if (Directory.Exists(dirpath) == false)
                {
                    Directory.CreateDirectory(dirpath);
                }

                if (Num == 4)
                {
                    //캠 시작
                    //if (cm.chk_capture == 0)
                    //{
                    //    cm.chk_capture = 1;
                    //    cm.Capture_video();
                    //}

                    string path = dirpath + "\\message.txt";

                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(file);

                    int i;

                    for (i = 0; i <= value.Length - 17; i += 17)
                    {
                        sw.Write(value.Substring(i, 17) + Environment.NewLine);
                    }
                    //sw.Write("*");
                    sw.Close();
                    file.Close();

                    //GPS 실행
                    Dos_cmd();
                }
                else if (Num != 0)
                {
                    string path = dirpath + "\\" + Num + ".txt";

                    FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(file);

                    sw.Write(value);
                    sw.Close();
                    file.Close();
                }
            }
            catch (IOException ioe)
            {
                Save_Data(ioe.Message, 0);
            }
        }

        //데이터 읽기
        private void Get_Sensorvalue()
        {
            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    char[] data = new char[1024];

                    string path = dirpath + "\\" + i + ".txt";

                    if (File.Exists(path) == true)
                    {
                        StreamReader sr = new StreamReader(path);

                        int ret;
                        string message = "";

                        message += i;
                        while (true)
                        {
                            ret = sr.Read(data, 0, 24);
                            message += new string(data, 0, 24);
                            if (ret < 1024) break;
                        }
                        sr.Close();
                        Send_MSG(message);
                        message = "";
                        File.Delete(path);
                    }
                }

                //캠 종료
                //if (cm.chk_capture == 1)
                //{
                //    cm.Capture_video();
                //    cm.chk_capture = 0;
                //}
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("지정한 파일이 없습니다");
            }
        }

        //GPS 실행
        private void Dos_cmd()
        {
            //Network 변수
            StreamWriter DosWriter;
            StreamReader DosRedaer;
            StreamReader ErrorReader;

            //프로세스 생성및 초기화
            Process DosPr = new Process();
            ProcessStartInfo psI = new ProcessStartInfo("cmd", "/c revData.exe");          
            psI.UseShellExecute = false;
            psI.RedirectStandardInput = true;
            psI.RedirectStandardOutput = true;
            psI.RedirectStandardError = true;
            psI.CreateNoWindow = false;
            
            //명령 실행
            DosPr.StartInfo = psI;
            DosPr.Start();
            DosWriter = DosPr.StandardInput;
            DosRedaer = DosPr.StandardOutput;
            ErrorReader = DosPr.StandardError;

            DosWriter.AutoFlush = true;            
            DosWriter.Close();
        }                
    }        
}