namespace revData
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.txt_msgbox = new System.Windows.Forms.TextBox();
            this.txt_StartLatitude = new System.Windows.Forms.TextBox();
            this.txt_StartLongitude = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_t1 = new System.Windows.Forms.Label();
            this.lbl_t2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_longitude3 = new System.Windows.Forms.TextBox();
            this.txt_latitude3 = new System.Windows.Forms.TextBox();
            this.txt_longitude2 = new System.Windows.Forms.TextBox();
            this.txt_latitude2 = new System.Windows.Forms.TextBox();
            this.txt_longitude1 = new System.Windows.Forms.TextBox();
            this.txt_latitude1 = new System.Windows.Forms.TextBox();
            this.count_timer = new System.Windows.Forms.Timer(this.components);
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.textBox_recieve = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_power = new System.Windows.Forms.Label();
            this.btn_powerup = new System.Windows.Forms.Button();
            this.btn_powerdown = new System.Windows.Forms.Button();
            this.btn_forword = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_msgbox
            // 
            this.txt_msgbox.Location = new System.Drawing.Point(228, 39);
            this.txt_msgbox.Multiline = true;
            this.txt_msgbox.Name = "txt_msgbox";
            this.txt_msgbox.Size = new System.Drawing.Size(165, 201);
            this.txt_msgbox.TabIndex = 1;
            // 
            // txt_StartLatitude
            // 
            this.txt_StartLatitude.Location = new System.Drawing.Point(70, 40);
            this.txt_StartLatitude.MaxLength = 8;
            this.txt_StartLatitude.Name = "txt_StartLatitude";
            this.txt_StartLatitude.Size = new System.Drawing.Size(60, 21);
            this.txt_StartLatitude.TabIndex = 3;
            // 
            // txt_StartLongitude
            // 
            this.txt_StartLongitude.Location = new System.Drawing.Point(136, 40);
            this.txt_StartLongitude.MaxLength = 9;
            this.txt_StartLongitude.Name = "txt_StartLongitude";
            this.txt_StartLongitude.Size = new System.Drawing.Size(60, 21);
            this.txt_StartLongitude.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "현재 위도 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "현재 경도 :";
            // 
            // lbl_t1
            // 
            this.lbl_t1.AutoSize = true;
            this.lbl_t1.Location = new System.Drawing.Point(89, 24);
            this.lbl_t1.Name = "lbl_t1";
            this.lbl_t1.Size = new System.Drawing.Size(0, 12);
            this.lbl_t1.TabIndex = 7;
            // 
            // lbl_t2
            // 
            this.lbl_t2.AutoSize = true;
            this.lbl_t2.Location = new System.Drawing.Point(89, 43);
            this.lbl_t2.Name = "lbl_t2";
            this.lbl_t2.Size = new System.Drawing.Size(0, 12);
            this.lbl_t2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbl_t2);
            this.groupBox2.Controls.Add(this.lbl_t1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 66);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "현재위치";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_longitude3);
            this.groupBox3.Controls.Add(this.txt_latitude3);
            this.groupBox3.Controls.Add(this.txt_longitude2);
            this.groupBox3.Controls.Add(this.txt_latitude2);
            this.groupBox3.Controls.Add(this.txt_longitude1);
            this.groupBox3.Controls.Add(this.txt_latitude1);
            this.groupBox3.Controls.Add(this.txt_StartLatitude);
            this.groupBox3.Controls.Add(this.txt_StartLongitude);
            this.groupBox3.Location = new System.Drawing.Point(10, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 154);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "목표위치";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "Path 3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Path 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Path 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "시작점";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "경도";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "위도";
            // 
            // txt_longitude3
            // 
            this.txt_longitude3.Location = new System.Drawing.Point(137, 123);
            this.txt_longitude3.MaxLength = 9;
            this.txt_longitude3.Name = "txt_longitude3";
            this.txt_longitude3.Size = new System.Drawing.Size(59, 21);
            this.txt_longitude3.TabIndex = 10;
            // 
            // txt_latitude3
            // 
            this.txt_latitude3.Location = new System.Drawing.Point(70, 123);
            this.txt_latitude3.MaxLength = 8;
            this.txt_latitude3.Name = "txt_latitude3";
            this.txt_latitude3.Size = new System.Drawing.Size(60, 21);
            this.txt_latitude3.TabIndex = 9;
            // 
            // txt_longitude2
            // 
            this.txt_longitude2.Location = new System.Drawing.Point(136, 96);
            this.txt_longitude2.MaxLength = 9;
            this.txt_longitude2.Name = "txt_longitude2";
            this.txt_longitude2.Size = new System.Drawing.Size(60, 21);
            this.txt_longitude2.TabIndex = 8;
            // 
            // txt_latitude2
            // 
            this.txt_latitude2.Location = new System.Drawing.Point(70, 96);
            this.txt_latitude2.MaxLength = 8;
            this.txt_latitude2.Name = "txt_latitude2";
            this.txt_latitude2.Size = new System.Drawing.Size(60, 21);
            this.txt_latitude2.TabIndex = 7;
            // 
            // txt_longitude1
            // 
            this.txt_longitude1.Location = new System.Drawing.Point(136, 69);
            this.txt_longitude1.MaxLength = 9;
            this.txt_longitude1.Name = "txt_longitude1";
            this.txt_longitude1.Size = new System.Drawing.Size(60, 21);
            this.txt_longitude1.TabIndex = 6;
            // 
            // txt_latitude1
            // 
            this.txt_latitude1.Location = new System.Drawing.Point(70, 69);
            this.txt_latitude1.MaxLength = 8;
            this.txt_latitude1.Name = "txt_latitude1";
            this.txt_latitude1.Size = new System.Drawing.Size(60, 21);
            this.txt_latitude1.TabIndex = 5;
            // 
            // count_timer
            // 
            this.count_timer.Tick += new System.EventHandler(this.count_timer_Tick);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(47, 317);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(346, 65);
            this.txtMessage.TabIndex = 12;
            // 
            // textBox_recieve
            // 
            this.textBox_recieve.Location = new System.Drawing.Point(47, 246);
            this.textBox_recieve.Multiline = true;
            this.textBox_recieve.Name = "textBox_recieve";
            this.textBox_recieve.Size = new System.Drawing.Size(346, 65);
            this.textBox_recieve.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "수신";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "변환";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(228, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "GPS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "시작";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_right);
            this.groupBox1.Controls.Add(this.btn_back);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Controls.Add(this.btn_left);
            this.groupBox1.Controls.Add(this.btn_forword);
            this.groupBox1.Controls.Add(this.btn_powerdown);
            this.groupBox1.Controls.Add(this.btn_powerup);
            this.groupBox1.Controls.Add(this.lbl_power);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(407, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 217);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "디버깅";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "정지";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "파워";
            // 
            // lbl_power
            // 
            this.lbl_power.AutoSize = true;
            this.lbl_power.Location = new System.Drawing.Point(42, 23);
            this.lbl_power.Name = "lbl_power";
            this.lbl_power.Size = new System.Drawing.Size(23, 12);
            this.lbl_power.TabIndex = 1;
            this.lbl_power.Text = "200";
            // 
            // btn_powerup
            // 
            this.btn_powerup.Location = new System.Drawing.Point(6, 39);
            this.btn_powerup.Name = "btn_powerup";
            this.btn_powerup.Size = new System.Drawing.Size(75, 23);
            this.btn_powerup.TabIndex = 2;
            this.btn_powerup.Text = "++";
            this.btn_powerup.UseVisualStyleBackColor = true;
            this.btn_powerup.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_powerdown
            // 
            this.btn_powerdown.Location = new System.Drawing.Point(7, 69);
            this.btn_powerdown.Name = "btn_powerdown";
            this.btn_powerdown.Size = new System.Drawing.Size(75, 23);
            this.btn_powerdown.TabIndex = 3;
            this.btn_powerdown.Text = "--";
            this.btn_powerdown.UseVisualStyleBackColor = true;
            this.btn_powerdown.Click += new System.EventHandler(this.btn_powerdown_Click);
            // 
            // btn_forword
            // 
            this.btn_forword.Location = new System.Drawing.Point(71, 126);
            this.btn_forword.Name = "btn_forword";
            this.btn_forword.Size = new System.Drawing.Size(53, 23);
            this.btn_forword.TabIndex = 4;
            this.btn_forword.Text = "전진";
            this.btn_forword.UseVisualStyleBackColor = true;
            this.btn_forword.Click += new System.EventHandler(this.btn_forword_Click);
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(9, 155);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(56, 23);
            this.btn_left.TabIndex = 5;
            this.btn_left.Text = "좌로";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(71, 155);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(53, 23);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.Text = "정지";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(71, 184);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(53, 23);
            this.btn_back.TabIndex = 7;
            this.btn_back.Text = "후진";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(131, 154);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(54, 23);
            this.btn_right.TabIndex = 8;
            this.btn_right.Text = "우로";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 387);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_recieve);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_msgbox);
            this.Name = "mainForm";
            this.Text = "수신기";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_msgbox;
        private System.Windows.Forms.TextBox txt_StartLatitude;
        private System.Windows.Forms.TextBox txt_StartLongitude;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_t1;
        private System.Windows.Forms.Label lbl_t2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_longitude3;
        private System.Windows.Forms.TextBox txt_latitude3;
        private System.Windows.Forms.TextBox txt_longitude2;
        private System.Windows.Forms.TextBox txt_latitude2;
        private System.Windows.Forms.TextBox txt_longitude1;
        private System.Windows.Forms.TextBox txt_latitude1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer count_timer;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox textBox_recieve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_powerup;
        private System.Windows.Forms.Label lbl_power;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_powerdown;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_forword;
    }
}

