using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projecet2월
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cal_Click(object sender, EventArgs e)
        {
            double deg_x1 = Convert.ToDouble(textdeg_x1.Text);
            double min_x1 = Convert.ToDouble(textmin_x1.Text);
            double sec_x1 = Convert.ToDouble(textsec_x1.Text);//현재경도
            double deg_y1 = Convert.ToDouble(textdeg_y1.Text);
            double min_y1 = Convert.ToDouble(textmin_y1.Text);
            double sec_y1 = Convert.ToDouble(textsec_y1.Text);//현재위도
            double deg_x2 = Convert.ToDouble(textdeg_x2.Text);
            double min_x2 = Convert.ToDouble(textmin_x2.Text);
            double sec_x2 = Convert.ToDouble(textsec_x2.Text);//목표경도
            double deg_y2 = Convert.ToDouble(textdeg_y2.Text);
            double min_y2 = Convert.ToDouble(textmin_y2.Text);
            double sec_y2 = Convert.ToDouble(textsec_y2.Text);//목표위도

            double real_lon1 = deg_x1 + (min_x1 / 60) + (sec_x1 / 3600); //현재경도 '도'
            double lon1 = Math.PI * real_lon1 / 180; //sin, cos에 넣기 위해서는 라디안값으로 사용해야함
            double real_lat1 = deg_y1 + (min_y1 / 60) + (sec_y1 / 3600); //현재위도 '도'
            double lat1 = Math.PI * real_lat1 / 180;
            double real_lon2 = deg_x2 + (min_x2 / 60) + (sec_x2 / 3600); //목표경도 '도'
            double lon2 = Math.PI * real_lon2 / 180;
            double real_lat2 = deg_y2 + (min_y2 / 60) + (sec_y2 / 3600); //목표위도 '도'
            double lat2 = Math.PI * real_lat2 / 180;

            // 현재 경도와 위도, 목표 경도와 위도를 모두 '도'값으로 바꿈

            double rad_distance = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon1 - lon2));
            //라디안 거리 구하는 식
            radian_distance.Text = Convert.ToString(rad_distance);

            double NM = rad_distance * 3437.7387; //1NM(Nautical Miles)은 지구의 위도의 1분에 해당하는 호의 길이
            double M = NM * 1.852 * 1000; //1NM은 약 1.852KM에 해당(짧은거리의 m를 표시하기 위해 * 1000)

            real_distance.Text = Convert.ToString(M);// 실제거리

            double rad_bearing = Math.Acos((Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(rad_distance)) / (Math.Cos(lat1) * Math.Sin(rad_distance)));
            //라디안 방향 구하는 식, 진북을 기준으로 시계방향
            radian_bearing.Text = Convert.ToString(rad_bearing);

            double true_bearing = rad_bearing * (180 / Math.PI);

            //X1 > X2 보다 클 경우 180을 더해준다
            if (lon1 > lon2)
            {
                true_bearing = 180 + (180 - true_bearing);
            }
            real_bearing.Text = Convert.ToString(true_bearing);//실제 방향
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double deg_x1 = Convert.ToDouble(textdeg_x1.Text);
            double min_x1 = Convert.ToDouble(textmin_x1.Text);
            double sec_x1 = Convert.ToDouble(textsec_x1.Text);//현재경도
            double deg_y1 = Convert.ToDouble(textdeg_y1.Text);
            double min_y1 = Convert.ToDouble(textmin_y1.Text);
            double sec_y1 = Convert.ToDouble(textsec_y1.Text);//현재위도
            double deg_x2 = Convert.ToDouble(textdeg_x2.Text);
            double min_x2 = Convert.ToDouble(textmin_x2.Text);
            double sec_x2 = Convert.ToDouble(textsec_x2.Text);//목표경도
            double deg_y2 = Convert.ToDouble(textdeg_y2.Text);
            double min_y2 = Convert.ToDouble(textmin_y2.Text);
            double sec_y2 = Convert.ToDouble(textsec_y2.Text);//목표위도

            double real_lon1 = deg_x1 + (min_x1 / 60) + (sec_x1 / 3600); //현재경도 '도'            
            double real_lat1 = deg_y1 + (min_y1 / 60) + (sec_y1 / 3600); //현재위도 '도'
            double real_lon2 = deg_x2 + (min_x2 / 60) + (sec_x2 / 3600); //목표경도 '도'
            double real_lat2 = deg_y2 + (min_y2 / 60) + (sec_y2 / 3600); //목표위도 '도'

            //기울기
            double gradient = (real_lat2 - real_lat1) / (real_lon2 - real_lon1);
            double rad = Math.Atan(gradient);
            double deg = rad / ( Math.PI * 180 );
            txt_gradient.Text = deg.ToString();
        }
    }
}

