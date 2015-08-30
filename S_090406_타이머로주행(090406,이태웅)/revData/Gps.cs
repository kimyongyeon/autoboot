using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace revData
{
    public class Gps : IRs232
    {
        public delegate void DataReceiveHandler(string recvData);
        public event DataReceiveHandler DataReceived;
        public bool is_RightData;

        private SerialPort serialPort = null;

        public Gps(string portName, int dataBit)
        {
            serialPort = new SerialPort();

            serialPort.PortName = portName;
            serialPort.DataBits = dataBit;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        public void Connect()
        {
            if(!serialPort.IsOpen)
                serialPort.Open();
        }

        public void Dispose()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }

        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting();


            if (data.Equals("$"))
            {
                this.is_RightData = true;
            }

            if (is_RightData)
            {
                DataReceived(data);
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        // 함 수 명 : gpsRequest
        // 파라미터 : nowLongitude, nowLatitude, goalLongitude, goalLatitude
        // 반 환 값 : true_bearing 
        // 내    용 : 파라미터로 현재 경도, 위도값과 목표 경도, 위도 값을 받아 연산하면 각을 구할수 있음
        //--------------------------------------------------------------------------------------------------------------
        public double gpsRequest(string nowLongitude, string nowLatitude, string goalLongitude, string goalLatitude)
        {
            // 변수 선언
            double nowLongitudeDegree, nowLongitudeMinute, nowLongitudeSecond;                          // 현재경도의 도, 분, 초
            double nowLatitudeDegree, nowLatitudeMinute, nowLatitudeSecond;                             // 현재위도의 도, 분, 초
            double goalLongitudeDegree, goalLongitudeMinute, goalLongitudeSecond;                       // 목표경도의 도, 분, 초
            double goalLatitudeDegree, goalLatitudeMinute, goalLatitudeSecond;                          // 목표위도의 도, 분, 초
            double real_nowLongitude, real_nowLatitude, real_goalLongitude, real_goalLatitude;          // 현재(경도,위도) 목표(경도,위도)로 구한값
            double ladian_nowLongitude, ladian_nowLatitude, ladian_goalLongitude, ladian_goalLatitude;  // 라디언값으로 변환된 현재,목표 값
            double rad_distance;                                                                        // 실제 거리(라디언값)
            double NM, M;                                                                               // 실제 거리를 구하기 위한 변수
            double rad_bearing;                                                                         // 라디안값의 방향
            double true_bearing;                                                                        // 인간이 사용하는 각

            //           
            nowLongitudeDegree = Convert.ToDouble(nowLongitude.Substring(0, 3));
            nowLongitudeMinute = Convert.ToDouble(nowLongitude.Substring(3, 2));
            nowLongitudeSecond = Convert.ToDouble(nowLongitude.Substring(5, 5));                        //현재경도 도,분,초 나눔

            nowLatitudeDegree = Convert.ToDouble(nowLatitude.Substring(0, 2));
            nowLatitudeMinute = Convert.ToDouble(nowLatitude.Substring(2, 2));
            nowLatitudeSecond = Convert.ToDouble(nowLatitude.Substring(4, 5));                          //현재위도 도,분,초 나눔

            goalLongitudeDegree = Convert.ToDouble(goalLongitude.Substring(0, 3));
            goalLongitudeMinute = Convert.ToDouble(goalLongitude.Substring(3, 2));
            goalLongitudeSecond = Convert.ToDouble(goalLongitude.Substring(5, 5));                      //목표경도 도,분,초 나눔

            goalLatitudeDegree = Convert.ToDouble(goalLatitude.Substring(0, 2));
            goalLatitudeMinute = Convert.ToDouble(goalLatitude.Substring(2, 2));
            goalLatitudeSecond = Convert.ToDouble(goalLatitude.Substring(4, 5));                        //목표위도 도,분,초 나눔

            // 현재 경도값 '도'를 구하기 위해서 분과 초에 각각 연산
            real_nowLongitude = nowLongitudeDegree + (nowLongitudeMinute / 60) + (nowLongitudeSecond / 3600);    //현재경도 '도'
            real_nowLatitude = nowLatitudeDegree + (nowLatitudeMinute / 60) + (nowLatitudeSecond / 3600);       //현재위도 '도'
            real_goalLongitude = goalLongitudeDegree + (goalLongitudeMinute / 60) + (goalLongitudeSecond / 3600); //목표경도 '도'
            real_goalLatitude = goalLatitudeDegree + (goalLatitudeMinute / 60) + (goalLatitudeSecond / 3600);    //목표위도 '도'

            //sin, cos에 넣기 위해서는 라디안값으로 사용해야함                       
            ladian_nowLongitude = Math.PI * real_nowLongitude / 180;
            ladian_nowLatitude = Math.PI * real_nowLatitude / 180;
            ladian_goalLongitude = Math.PI * real_goalLongitude / 180;
            ladian_goalLatitude = Math.PI * real_goalLatitude / 180;

            // 라디언거리 = Acos(Sin(현재위도) * Sin(목표위도) + Cos(현재위도) * Cos(목표위도) * Cos(현재위도 - 목표위도))
            rad_distance = Math.Acos(Math.Sin(ladian_nowLatitude) * Math.Sin(ladian_goalLatitude) + Math.Cos(ladian_nowLatitude) * Math.Cos(ladian_goalLatitude) * Math.Cos(ladian_nowLongitude - ladian_goalLongitude));

            NM = rad_distance * 3437.7387;  // NM = 라디언 거리 * 3437.7387
            M = NM * 1.852 * 1000;          // 1NM은 약 1.852KM에 해당(짧은거리의 m를 표시하기 위해 * 1000)

            // 라디언 방향 (기준 : 진북) 
            // Acos(Math.Sin(목표위도) - Math.Sin(현재위도) * Cos(라디안거리)) / (Cos(현재위도) * Sin(라디안거리))
            rad_bearing = Math.Acos((Math.Sin(ladian_goalLatitude) - Math.Sin(ladian_nowLatitude) * Math.Cos(rad_distance)) / (Math.Cos(ladian_nowLatitude) * Math.Sin(rad_distance)));

            true_bearing = (rad_bearing * (180 / Math.PI));             // 사람이 인식하는 각
            int pc = Convert.ToInt32(Math.Ceiling(true_bearing));       // 반올림(소수점 첫째짜리에서 반올림)

            return Convert.ToDouble(pc);
        }
    }
}
