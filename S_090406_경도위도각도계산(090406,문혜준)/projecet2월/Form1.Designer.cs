namespace projecet2월
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textsec_y1 = new System.Windows.Forms.TextBox();
            this.textmin_y1 = new System.Windows.Forms.TextBox();
            this.textmin_x1 = new System.Windows.Forms.TextBox();
            this.textsec_x1 = new System.Windows.Forms.TextBox();
            this.textdeg_y1 = new System.Windows.Forms.TextBox();
            this.textdeg_x1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.real_distance = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.real_bearing = new System.Windows.Forms.TextBox();
            this.radian_bearing = new System.Windows.Forms.TextBox();
            this.radian_distance = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cal = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textsec_y2 = new System.Windows.Forms.TextBox();
            this.textmin_y2 = new System.Windows.Forms.TextBox();
            this.textmin_x2 = new System.Windows.Forms.TextBox();
            this.textsec_x2 = new System.Windows.Forms.TextBox();
            this.textdeg_y2 = new System.Windows.Forms.TextBox();
            this.textdeg_x2 = new System.Windows.Forms.TextBox();
            this.txt_gradient = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textsec_y1);
            this.groupBox1.Controls.Add(this.textmin_y1);
            this.groupBox1.Controls.Add(this.textmin_x1);
            this.groupBox1.Controls.Add(this.textsec_x1);
            this.groupBox1.Controls.Add(this.textdeg_y1);
            this.groupBox1.Controls.Add(this.textdeg_x1);
            this.groupBox1.Font = new System.Drawing.Font("바탕체", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "현재좌표";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "도";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "분";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "초";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "위도";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "경도";
            // 
            // textsec_y1
            // 
            this.textsec_y1.Location = new System.Drawing.Point(217, 89);
            this.textsec_y1.Name = "textsec_y1";
            this.textsec_y1.Size = new System.Drawing.Size(57, 25);
            this.textsec_y1.TabIndex = 5;
            this.textsec_y1.Text = "06.45";
            // 
            // textmin_y1
            // 
            this.textmin_y1.Location = new System.Drawing.Point(154, 89);
            this.textmin_y1.Name = "textmin_y1";
            this.textmin_y1.Size = new System.Drawing.Size(57, 25);
            this.textmin_y1.TabIndex = 4;
            this.textmin_y1.Text = "58";
            // 
            // textmin_x1
            // 
            this.textmin_x1.Location = new System.Drawing.Point(154, 58);
            this.textmin_x1.Name = "textmin_x1";
            this.textmin_x1.Size = new System.Drawing.Size(57, 25);
            this.textmin_x1.TabIndex = 3;
            this.textmin_x1.Text = "28";
            // 
            // textsec_x1
            // 
            this.textsec_x1.Location = new System.Drawing.Point(217, 58);
            this.textsec_x1.Name = "textsec_x1";
            this.textsec_x1.Size = new System.Drawing.Size(57, 25);
            this.textsec_x1.TabIndex = 2;
            this.textsec_x1.Text = "56.91";
            // 
            // textdeg_y1
            // 
            this.textdeg_y1.Location = new System.Drawing.Point(91, 89);
            this.textdeg_y1.Name = "textdeg_y1";
            this.textdeg_y1.Size = new System.Drawing.Size(57, 25);
            this.textdeg_y1.TabIndex = 1;
            this.textdeg_y1.Text = "34";
            // 
            // textdeg_x1
            // 
            this.textdeg_x1.Location = new System.Drawing.Point(91, 58);
            this.textdeg_x1.Name = "textdeg_x1";
            this.textdeg_x1.Size = new System.Drawing.Size(57, 25);
            this.textdeg_x1.TabIndex = 0;
            this.textdeg_x1.Text = "127";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.txt_gradient);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.real_distance);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.real_bearing);
            this.panel3.Controls.Add(this.radian_bearing);
            this.panel3.Controls.Add(this.radian_distance);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(75, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(587, 105);
            this.panel3.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(421, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "m";
            // 
            // real_distance
            // 
            this.real_distance.Location = new System.Drawing.Point(309, 12);
            this.real_distance.Name = "real_distance";
            this.real_distance.Size = new System.Drawing.Size(106, 21);
            this.real_distance.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(273, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "거리";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(167, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "rad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(167, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "rad";
            // 
            // real_bearing
            // 
            this.real_bearing.Location = new System.Drawing.Point(309, 43);
            this.real_bearing.Name = "real_bearing";
            this.real_bearing.Size = new System.Drawing.Size(106, 21);
            this.real_bearing.TabIndex = 9;
            // 
            // radian_bearing
            // 
            this.radian_bearing.Location = new System.Drawing.Point(55, 44);
            this.radian_bearing.Name = "radian_bearing";
            this.radian_bearing.Size = new System.Drawing.Size(106, 21);
            this.radian_bearing.TabIndex = 8;
            // 
            // radian_distance
            // 
            this.radian_distance.Location = new System.Drawing.Point(55, 12);
            this.radian_distance.Name = "radian_distance";
            this.radian_distance.Size = new System.Drawing.Size(106, 21);
            this.radian_distance.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "방향";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "방향";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "거리";
            // 
            // cal
            // 
            this.cal.Location = new System.Drawing.Point(12, 175);
            this.cal.Name = "cal";
            this.cal.Size = new System.Drawing.Size(57, 106);
            this.cal.TabIndex = 14;
            this.cal.Text = "계산";
            this.cal.UseVisualStyleBackColor = true;
            this.cal.Click += new System.EventHandler(this.cal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textsec_y2);
            this.groupBox2.Controls.Add(this.textmin_y2);
            this.groupBox2.Controls.Add(this.textmin_x2);
            this.groupBox2.Controls.Add(this.textsec_x2);
            this.groupBox2.Controls.Add(this.textdeg_y2);
            this.groupBox2.Controls.Add(this.textdeg_x2);
            this.groupBox2.Font = new System.Drawing.Font("바탕체", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(342, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 157);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "목표좌표";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "도";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "분";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "초";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "위도";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "경도";
            // 
            // textsec_y2
            // 
            this.textsec_y2.Location = new System.Drawing.Point(217, 89);
            this.textsec_y2.Name = "textsec_y2";
            this.textsec_y2.Size = new System.Drawing.Size(57, 25);
            this.textsec_y2.TabIndex = 5;
            this.textsec_y2.Text = "01.65";
            // 
            // textmin_y2
            // 
            this.textmin_y2.Location = new System.Drawing.Point(154, 89);
            this.textmin_y2.Name = "textmin_y2";
            this.textmin_y2.Size = new System.Drawing.Size(57, 25);
            this.textmin_y2.TabIndex = 4;
            this.textmin_y2.Text = "58";
            // 
            // textmin_x2
            // 
            this.textmin_x2.Location = new System.Drawing.Point(154, 58);
            this.textmin_x2.Name = "textmin_x2";
            this.textmin_x2.Size = new System.Drawing.Size(57, 25);
            this.textmin_x2.TabIndex = 3;
            this.textmin_x2.Text = "28";
            // 
            // textsec_x2
            // 
            this.textsec_x2.Location = new System.Drawing.Point(217, 58);
            this.textsec_x2.Name = "textsec_x2";
            this.textsec_x2.Size = new System.Drawing.Size(57, 25);
            this.textsec_x2.TabIndex = 2;
            this.textsec_x2.Text = "55.63";
            // 
            // textdeg_y2
            // 
            this.textdeg_y2.Location = new System.Drawing.Point(91, 89);
            this.textdeg_y2.Name = "textdeg_y2";
            this.textdeg_y2.Size = new System.Drawing.Size(57, 25);
            this.textdeg_y2.TabIndex = 1;
            this.textdeg_y2.Text = "34";
            // 
            // textdeg_x2
            // 
            this.textdeg_x2.Location = new System.Drawing.Point(91, 58);
            this.textdeg_x2.Name = "textdeg_x2";
            this.textdeg_x2.Size = new System.Drawing.Size(57, 25);
            this.textdeg_x2.TabIndex = 0;
            this.textdeg_x2.Text = "127";
            // 
            // txt_gradient
            // 
            this.txt_gradient.Location = new System.Drawing.Point(145, 73);
            this.txt_gradient.Name = "txt_gradient";
            this.txt_gradient.Size = new System.Drawing.Size(106, 21);
            this.txt_gradient.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cal);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textsec_y1;
        private System.Windows.Forms.TextBox textmin_y1;
        private System.Windows.Forms.TextBox textmin_x1;
        private System.Windows.Forms.TextBox textsec_x1;
        private System.Windows.Forms.TextBox textdeg_y1;
        private System.Windows.Forms.TextBox textdeg_x1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox real_bearing;
        private System.Windows.Forms.TextBox radian_bearing;
        private System.Windows.Forms.TextBox radian_distance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textsec_y2;
        private System.Windows.Forms.TextBox textmin_y2;
        private System.Windows.Forms.TextBox textmin_x2;
        private System.Windows.Forms.TextBox textsec_x2;
        private System.Windows.Forms.TextBox textdeg_y2;
        private System.Windows.Forms.TextBox textdeg_x2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox real_distance;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_gradient;
        private System.Windows.Forms.Button button1;
    }
}

