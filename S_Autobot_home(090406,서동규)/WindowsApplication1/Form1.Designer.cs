namespace WindowsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.RS232 = new System.IO.Ports.SerialPort(this.components);
            this.text_del_send = new System.Windows.Forms.Button();
            this.text_del_rev = new System.Windows.Forms.Button();
            this.txtMessage_rev = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_Loc3 = new System.Windows.Forms.ComboBox();
            this.combo_Loc2 = new System.Windows.Forms.ComboBox();
            this.combo_Loc1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lati_3 = new System.Windows.Forms.TextBox();
            this.lati_2 = new System.Windows.Forms.TextBox();
            this.lati_1 = new System.Windows.Forms.TextBox();
            this.grad_3 = new System.Windows.Forms.TextBox();
            this.grad_2 = new System.Windows.Forms.TextBox();
            this.grad_1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.Label();
            this.txtMessage_send = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RS232
            // 
            this.RS232.BaudRate = 57600;
            this.RS232.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RS232_DataReceived);
            // 
            // text_del_send
            // 
            this.text_del_send.Location = new System.Drawing.Point(330, 252);
            this.text_del_send.Name = "text_del_send";
            this.text_del_send.Size = new System.Drawing.Size(54, 54);
            this.text_del_send.TabIndex = 12;
            this.text_del_send.Text = "지우기";
            this.text_del_send.UseVisualStyleBackColor = true;
            this.text_del_send.Click += new System.EventHandler(this.text_del_send_Click);
            // 
            // text_del_rev
            // 
            this.text_del_rev.Location = new System.Drawing.Point(330, 178);
            this.text_del_rev.Name = "text_del_rev";
            this.text_del_rev.Size = new System.Drawing.Size(54, 54);
            this.text_del_rev.TabIndex = 11;
            this.text_del_rev.Text = "지우기";
            this.text_del_rev.UseVisualStyleBackColor = true;
            this.text_del_rev.Click += new System.EventHandler(this.text_del_Click);
            // 
            // txtMessage_rev
            // 
            this.txtMessage_rev.Location = new System.Drawing.Point(12, 178);
            this.txtMessage_rev.Multiline = true;
            this.txtMessage_rev.Name = "txtMessage_rev";
            this.txtMessage_rev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage_rev.Size = new System.Drawing.Size(308, 54);
            this.txtMessage_rev.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_Loc3);
            this.groupBox1.Controls.Add(this.combo_Loc2);
            this.groupBox1.Controls.Add(this.combo_Loc1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lati_3);
            this.groupBox1.Controls.Add(this.state);
            this.groupBox1.Controls.Add(this.lati_2);
            this.groupBox1.Controls.Add(this.lati_1);
            this.groupBox1.Controls.Add(this.grad_3);
            this.groupBox1.Controls.Add(this.grad_2);
            this.groupBox1.Controls.Add(this.grad_1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.send);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 148);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "경로 지정";
            // 
            // combo_Loc3
            // 
            this.combo_Loc3.FormattingEnabled = true;
            this.combo_Loc3.Items.AddRange(new object[] {
            "선    택"});
            this.combo_Loc3.Location = new System.Drawing.Point(38, 88);
            this.combo_Loc3.Name = "combo_Loc3";
            this.combo_Loc3.Size = new System.Drawing.Size(108, 20);
            this.combo_Loc3.TabIndex = 33;
            this.combo_Loc3.SelectedIndexChanged += new System.EventHandler(this.combo_Loc3_SelectedIndexChanged);
            // 
            // combo_Loc2
            // 
            this.combo_Loc2.FormattingEnabled = true;
            this.combo_Loc2.Items.AddRange(new object[] {
            "선    택"});
            this.combo_Loc2.Location = new System.Drawing.Point(38, 60);
            this.combo_Loc2.Name = "combo_Loc2";
            this.combo_Loc2.Size = new System.Drawing.Size(108, 20);
            this.combo_Loc2.TabIndex = 32;
            this.combo_Loc2.SelectedIndexChanged += new System.EventHandler(this.combo_Loc2_SelectedIndexChanged);
            // 
            // combo_Loc1
            // 
            this.combo_Loc1.FormattingEnabled = true;
            this.combo_Loc1.Items.AddRange(new object[] {
            "선    택"});
            this.combo_Loc1.Location = new System.Drawing.Point(38, 35);
            this.combo_Loc1.Name = "combo_Loc1";
            this.combo_Loc1.Size = new System.Drawing.Size(108, 20);
            this.combo_Loc1.TabIndex = 31;
            this.combo_Loc1.SelectedIndexChanged += new System.EventHandler(this.combo_Loc1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "경로";
            // 
            // lati_3
            // 
            this.lati_3.Location = new System.Drawing.Point(162, 88);
            this.lati_3.Name = "lati_3";
            this.lati_3.ReadOnly = true;
            this.lati_3.Size = new System.Drawing.Size(100, 21);
            this.lati_3.TabIndex = 11;
            this.lati_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lati_2
            // 
            this.lati_2.Location = new System.Drawing.Point(162, 61);
            this.lati_2.Name = "lati_2";
            this.lati_2.ReadOnly = true;
            this.lati_2.Size = new System.Drawing.Size(100, 21);
            this.lati_2.TabIndex = 6;
            this.lati_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lati_1
            // 
            this.lati_1.Location = new System.Drawing.Point(162, 34);
            this.lati_1.Name = "lati_1";
            this.lati_1.ReadOnly = true;
            this.lati_1.Size = new System.Drawing.Size(100, 21);
            this.lati_1.TabIndex = 1;
            this.lati_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grad_3
            // 
            this.grad_3.Location = new System.Drawing.Point(264, 88);
            this.grad_3.Name = "grad_3";
            this.grad_3.ReadOnly = true;
            this.grad_3.Size = new System.Drawing.Size(100, 21);
            this.grad_3.TabIndex = 13;
            this.grad_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grad_2
            // 
            this.grad_2.Location = new System.Drawing.Point(264, 61);
            this.grad_2.Name = "grad_2";
            this.grad_2.ReadOnly = true;
            this.grad_2.Size = new System.Drawing.Size(100, 21);
            this.grad_2.TabIndex = 8;
            this.grad_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grad_1
            // 
            this.grad_1.Location = new System.Drawing.Point(264, 34);
            this.grad_1.Name = "grad_1";
            this.grad_1.ReadOnly = true;
            this.grad_1.Size = new System.Drawing.Size(100, 21);
            this.grad_1.TabIndex = 3;
            this.grad_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "순서";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "경도";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "위도";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(289, 115);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 24);
            this.send.TabIndex = 26;
            this.send.Text = "전송 / 저장";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-2, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "3.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-2, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "2.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-2, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "1.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(25, 121);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(29, 12);
            this.state.TabIndex = 16;
            this.state.Text = "상태";
            // 
            // txtMessage_send
            // 
            this.txtMessage_send.Location = new System.Drawing.Point(12, 252);
            this.txtMessage_send.Multiline = true;
            this.txtMessage_send.Name = "txtMessage_send";
            this.txtMessage_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage_send.Size = new System.Drawing.Size(308, 54);
            this.txtMessage_send.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "수신";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 235);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 21;
            this.label18.Text = "송신";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 482);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 12);
            this.label19.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 313);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMessage_send);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.text_del_send);
            this.Controls.Add(this.text_del_rev);
            this.Controls.Add(this.txtMessage_rev);
            this.Name = "Form1";
            this.Text = "오토봇 제어장치";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort RS232;
        private System.Windows.Forms.Button text_del_send;
        private System.Windows.Forms.Button text_del_rev;
        private System.Windows.Forms.TextBox txtMessage_rev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combo_Loc3;
        private System.Windows.Forms.ComboBox combo_Loc2;
        private System.Windows.Forms.ComboBox combo_Loc1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lati_3;
        private System.Windows.Forms.TextBox lati_2;
        private System.Windows.Forms.TextBox lati_1;
        private System.Windows.Forms.TextBox grad_3;
        private System.Windows.Forms.TextBox grad_2;
        private System.Windows.Forms.TextBox grad_1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.TextBox txtMessage_send;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}

