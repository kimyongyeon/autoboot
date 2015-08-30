using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Drawing.Printing;
using System.Diagnostics;
using revData.Properties;


namespace revData
{
    public partial class mainForm : Form
    {
        Direction CurrentDirection;
        Gps gps;
        Bluetooth bluetooth;
        //Sensor sensor;

        #region 변수 선언
  
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

        //임의값
        int i = 0;
        double ladian = 30;
        

        int nowPath = 0;                                // 현재 목표지점 패스(0~3) #3은 출발지점
        int accessRange = 20;                           // 인식범위
        int datacount = 0;                              // 읽어들인 데이터 갯수 임시 변수
        string[] path_latitude = new string[50];        // 목표 위치(위도) 저장
        string[] path_longitude = new string[50];       // 목표 위치(경도) 저장
        bool is_revData = false;                         // 현재 위치 GPS인식 체크
        bool is_SaveHomePosition = false;                // 처음 시작 좌표 저장 체크
        bool is_completePG = false;                     // 데이터전송이 완료 되었는지 체크
        string nowLatitude = "";                        // 경도위치값        
        string nowLongitude = "";                       // 위도위치값        
        string homeBaseLatitude = "";                   // 홈 베이스 경도값
        string homeBaseLongitude = "";                  // 홈 베이스 위도값

        string debugPower = "200";                      // 파워 값
        string afterPower = "200";                      // 방향 전환후 값
        string modifyAnglePower = "200";
        
        private delegate void SetTextCallback(string strMessage);
        private delegate void PrintPositionDataCallback(string strMessage, int no);

        public mainForm()
        {
            InitializeComponent();            
        }

        private void mainForm_Load(object sender, EventArgs e)
        { 
            CurrentDirection = Direction.Forward;
            gps = new Gps(Settings.Default.COM6, 8);
            gps.DataReceived += new Gps.DataReceiveHandler(gps_DataReceived);
            bluetooth = new Bluetooth(Settings.Default.COM7, 8);
            //sensor = new Sensor("COM15", 8);
            //sensor.DataReceived += new Sensor.DataReceiveHandler(sensor_DataReceived);
            //sensor.Connect();            
        }

        #region 센서 데이터 수신부
        void sensor_DataReceived(string strMessage)
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
        
        private int HexToDecimal(string str)
        {
            return Convert.ToInt32(str, 16);
        }

        private byte[] DataEncoding(string strMessage)
        {
            return System.Text.Encoding.GetEncoding(0).GetBytes(strMessage);
        }
        #endregion

        /// <summary>
        /// GPS 데이터 수신
        /// </summary>
        /// <param name="recvData"></param>
        void gps_DataReceived(string recvData)
        {
            string[] token = recvData.Split('\n');        //메세지를 한줄 단위로 잘라서 배열로
            int len = token.Length;

            for (int i = 0; i < len; i++)
            {
                string[] token2 = token[i].Split(',');      // 메시지를 n 단위로 나누어 데이터를 분할            
                if (token2[0] == "$GPRMC")                  // $GPRMC 로 시작하는 데이터만을 추출한다.
                {
                    if (token2.Length > 7)
                    {
                        if (token2[2] != "V")               // GPS의 올바른 정보만을 갖는다.
                        {
                            nowLatitude = token2[3];
                            nowLongitude = token2[5];

                            PrintPositionData(nowLatitude, 1);
                            PrintPositionData(nowLongitude, 2);
                            is_revData = true;
                            if (is_SaveHomePosition == false)
                            {
                                path_latitude[datacount] = nowLatitude;
                                path_longitude[datacount] = nowLongitude;
                                homeBaseLatitude = nowLatitude;
                                PrintPositionData(homeBaseLatitude, 3);
                                homeBaseLongitude = nowLongitude;
                                PrintPositionData(homeBaseLongitude, 4);
                                is_SaveHomePosition = true;
                            }

                        }
                        else
                        {
                            SetTextMessage("현재위치 확인중");
                        }
                    }
                }
            }
        }

        private void PG_Start()
        {

            SetTextMessage("프로그램 구동시작을 시작합니다.");
            
            //파일 열기
            file_open();
            SetTextMessage("HomeBase로부터 목적지 수신완료");
      
            // 컴포트 오픈
            SetTextMessage("GPS 데이터 수신 시작");
     
            gps.Connect();
            bluetooth.Connect();            

            SetTextMessage("주행을 시작합니다"); 
            Start_Autobot();

           
        }

        private void Start_Autobot()
        {
            int second = 100;

            if (is_SaveHomePosition)
            {

                string nowLongitude, nowLatitude, goalLongitude, goalLatitude;          //경도(longitude),위도(latitude)
                double temp;                                                            // 스트링형 더블형 변환 임시 변수
                string bothPower;

                /*
                temp = Convert.ToDouble(double.Parse(lbl_t1.Text) * 100.00);
                nowLatitude = temp.ToString("0.00");
                                
                temp = Convert.ToDouble(double.Parse(lbl_t2.Text) * 100.00);
                nowLongitude = temp.ToString("0.00");

                
                goalLatitude = txt_latitude1.Text;
                goalLatitude = Convert.ToString(Convert.ToDouble(path_latitude[nowPath]) / 100.00);
                goalLongitude = txt_longitude1.Text;
                goalLongitude = Convert.ToString(Convert.ToDouble(path_longitude[nowPath]) / 100.00);
                */

                //ladian = gps.gpsRequest(nowLongitude, nowLatitude, goalLongitude, goalLatitude);
                /*
                if (ladian > 360)
                {
                    SetTextMessage(ladian.ToString());
                    second = 50;                    
                    CurrentDirection = Direction.Forward;
                    bothPower = afterPower;   
                }
                else if (ladian > 355)
                {
                    SetTextMessage(ladian.ToString());
                    second = 150;                    
                    CurrentDirection = Direction.Left;
                    bothPower = modifyAnglePower;                    
                }
                else if (ladian > 345)
                {
                    SetTextMessage(ladian.ToString());
                    second = 200;                    
                    CurrentDirection = Direction.Left;
                    bothPower = modifyAnglePower;
                }                   
                else if (ladian > 330)
                {
                    SetTextMessage(ladian.ToString());
                    second = 300;
                    CurrentDirection = Direction.Left;
                    bothPower = modifyAnglePower;
                }
                else if (ladian > 300)
                {
                    SetTextMessage(ladian.ToString());
                    second = 400;
                    CurrentDirection = Direction.Left;
                    bothPower = modifyAnglePower;
                }
                else if (ladian > 270)
                {
                    SetTextMessage(ladian.ToString());
                    second = 500;
                    CurrentDirection = Direction.Left;
                    bothPower = modifyAnglePower;
                }                
                else if (ladian > 90)
                {
                    SetTextMessage(ladian.ToString());
                    second = 500;
                    CurrentDirection = Direction.Right;
                    bothPower = modifyAnglePower;
                }
                else if (ladian > 60)
                {
                    SetTextMessage(ladian.ToString());
                    second = 400;
                    CurrentDirection = Direction.Right;
                    bothPower = modifyAnglePower;
                }
                    
                else if (ladian > 30)
                {
                    SetTextMessage(ladian.ToString());
                    second = 300;
                    CurrentDirection = Direction.Right;
                    bothPower = modifyAnglePower;
                }                    
                else if (ladian > 15)
                {
                    SetTextMessage(ladian.ToString());
                    second = 150;
                    CurrentDirection = Direction.Right;
                    bothPower = modifyAnglePower;
                }                    
                else if (ladian > 5)
                {
                    SetTextMessage(ladian.ToString());
                    second = 120;
                    CurrentDirection = Direction.Right;
                    bothPower = modifyAnglePower;
                }
                else
                {
                    SetTextMessage(ladian.ToString());
                    second = 90;
                    CurrentDirection = Direction.Forward;
                    bothPower = afterPower;
                }
                */
                if (i == 0)
                {
                    bothPower = modifyAnglePower;
                    CurrentDirection = Direction.Right;
                    second = 400;
                    SetTextMessage("우");
                }
                else if (i == 1)
                {
                    bothPower = modifyAnglePower;
                    CurrentDirection = Direction.Right;
                    second = 800;
                    SetTextMessage("좌");
                }
                else if (i < 4)
                {
                    bothPower = modifyAnglePower;
                    CurrentDirection = Direction.Left;
                    second = 600;
                    SetTextMessage("좌");
                }
                else
                {
                    bothPower = "100";
                    CurrentDirection = Direction.Forward;
                }
                i++;
                ModifyAngle(bothPower, CurrentDirection);  // 각틀기
                //타이머 작동
                count_timer.Interval = second;
                count_timer.Start();               
            }
            else
            {
                SetTextMessage("데이터수신중");
            }
            if (!is_completePG)
            {
                Start_Timer(); //데이터 수신타이머                                 
            }

        }
        
        #region 로봇 움직임 제어
        private void ModifyAngle(string bothPower, Direction CurrentDirection)
        {
            string command = Command.MakeCovers(bothPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);
        }

        private void MoveFoward(string afterPower, Direction CurrentDirection)
        {

            string command = Command.MakeCovers(afterPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);

        }

        private void MoveStop()
        {
            afterPower = "000";
            CurrentDirection = Direction.Stop;
            string command = Command.MakeCovers(afterPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);            
            timer.Stop();
            count_timer.Stop();
            //SetTextMessage("다음 목적지 수신");
            //다음
        }
        #endregion

        #region 인보크 처리

        private void SetTextMessage(string strMessage)
        {
            if (this.txt_msgbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextMessage);
                this.Invoke(d, new object[] { strMessage });
            }

            else
            {
                txt_msgbox.AppendText(strMessage + Environment.NewLine);
                txt_msgbox.ScrollToCaret();
            }
        }

        private void PrintPositionData(string strMessage, int no)
        {

            if (lbl_t1.InvokeRequired)
            {
                PrintPositionDataCallback d = new PrintPositionDataCallback(PrintPositionData);
                this.Invoke(d, new object[] { strMessage, no });
            }

            else
            {
                switch(no)                                       
                {
                case 1:
                    lbl_t1.Text = strMessage;
                    break;
                case 2:
                    lbl_t2.Text = strMessage;
                    break;
                case 3:
                    txt_StartLatitude.Text = strMessage;
                    break;
                case 4:
                    txt_StartLongitude.Text = strMessage;
                    break;
                default:
                    break;
                }                
            }
        }

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

        #endregion

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
                    if (cm.chk_capture == 0)
                    {
                        cm.chk_capture = 1;
                        cm.Capture_video();
                    }

                    string path = dirpath + "\\message.txt";

                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(file);

                    int i;

                    for (i = 0; i <= value.Length - 17; i += 17)
                    {
                        sw.Write(value.Substring(i, 17) + Environment.NewLine);
                    }                    
                    sw.Close();
                    file.Close();

                    //GPS 실행
                    PG_Start();
                    
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

        private void Start_Timer()
        {
                this.timer = new Timer(this.components);
                this.timer.Enabled = true;
                this.timer.Interval = 12000;
                this.timer.Tick += new System.EventHandler(this.timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;                  // 타이머를 잠시 중지시켜서 다음 타이머와 충돌 나지 않게 함.
            if (is_revData)
            {
                /*
                double nowLatitudeValue = Convert.ToDouble(nowLatitude.Substring(2, 7)) * 10000;
                double nowLongitudeValue = Convert.ToDouble(nowLongitude.Substring(3, 7)) * 10000;
                double goallatitudeValue = Convert.ToDouble(path_latitude[nowPath].Substring(2, 6));
                double goalLongitudeValue = Convert.ToDouble(path_longitude[nowPath].Substring(3, 6));
                double nowtemp1 = goallatitudeValue - nowLatitudeValue;
                double nowtemp2 = goalLongitudeValue - nowLongitudeValue;

                if (Math.Abs(nowtemp1) < accessRange && Math.Abs(nowtemp2) < accessRange)                 
                */
                //SetTextMessage(path_latitude[nowPath].ToString());
                
                if (i < 6)
                {                    
                    if (nowPath > datacount)
                    {
                        is_completePG = true;
                        SetTextMessage("Home_Base 도착");
                        MoveStop();
                        //Get_Sensorvalue();  //데이터 전송
                        DataClear();

                    }
                    else
                    {                        
                        Start_Autobot();
                    }
                    nowPath++;  
                }
                else
                {
                    SetTextMessage("위치조정");
                    //위치 조정 함수                    
                    Start_Autobot();
                    //i++;
                    //ladian = ladian + 30;
                }
            }
            if(!is_completePG)
            {
                System.Threading.Thread.Sleep(200); 
                timer.Enabled = true;
            }
        }

        #region 센서데이터 수신 
        /// <summary>
        /// 센서 데이터 읽기
        /// </summary>        
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
                if (cm.chk_capture == 1)
                {
                    cm.Capture_video();
                    cm.chk_capture = 0;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("지정한 파일이 없습니다");
            }
        }
        #endregion

        private void DataClear()
        {
            for (int i = 0; i < 4; i++)
            {
                path_latitude[i] = "";
                path_longitude[i] = "";
            }
            datacount = 0;
            nowPath = 0;

        }

        private void Send_MSG(string MSG)
        {
            int count;
            seqno++;

            CreateRFMessages m = new CreateRFMessages();

            byte[] sendMsg = m.create_framed_packet(System.Convert.ToByte(seqno), 0x04, MSG);

            count = System.Convert.ToInt32(sendMsg[7]) + 10;      // 왜 +10 ???

            //sensor.Write(sendMsg, count);
        }

        private void count_timer_Tick(object sender, EventArgs e)
        {
            count_timer.Enabled = false;
            MoveFoward(afterPower, Direction.Forward);
            System.Threading.Thread.Sleep(200);
            count_timer.Enabled = true;
            count_timer.Stop();
        }

        private void file_open()
        {
            StreamReader readFile = null;            
            readFile = new StreamReader(Settings.Default.filename);

            string str;
            while ((str = readFile.ReadLine()) != null)
            { // 파일 줄 끝까지 읽어오기
                string latitudeTemp = str.Substring(0, 8);
                string longitudeTemp = str.Substring(8, 9);
                
                //배열에 저장
                path_latitude[datacount] = latitudeTemp;
                path_longitude[datacount] = longitudeTemp;
                
                
                switch (++datacount)
                {
                    case 1:
                        txt_latitude1.Text = latitudeTemp;
                        txt_longitude1.Text = longitudeTemp;
                        break;

                    case 2:
                        txt_latitude2.Text = latitudeTemp;
                        txt_longitude2.Text = longitudeTemp;
                        break;

                    case 3:
                        txt_latitude3.Text = latitudeTemp;
                        txt_longitude3.Text = longitudeTemp;
                        break;

                    default:
                        break;
                }                               
            }
            readFile.Close();
        }
    
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gps.Dispose();
            bluetooth.Dispose();
            //sensor.Dispose();
            System.Threading.Thread.Sleep(1000);
        }

        #region 디버깅 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            PG_Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            count_timer.Stop();
            btn_stop_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int powerValue = Convert.ToInt32(debugPower) + 10;
            debugPower = powerValue.ToString();
            lbl_power.Text = debugPower;
        }

        private void btn_forword_Click(object sender, EventArgs e)
        {
            CurrentDirection = Direction.Forward;
            string command = Command.MakeCovers(debugPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);
        }

        private void btn_powerdown_Click(object sender, EventArgs e)
        {
            int powerValue = Convert.ToInt32(debugPower) - 10;
            debugPower = powerValue.ToString();
            lbl_power.Text = debugPower;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            string stopPower = "000";
            CurrentDirection = Direction.Stop;
            string command = Command.MakeCovers(stopPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            CurrentDirection = Direction.Left;
            string command = Command.MakeCovers(debugPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            CurrentDirection = Direction.Right;
            string command = Command.MakeCovers(debugPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            CurrentDirection = Direction.Back;
            string command = Command.MakeCovers(debugPower, CurrentDirection);
            bluetooth.Write(command);
            SetTextMessage(command);
        }
        #endregion
    }
}
