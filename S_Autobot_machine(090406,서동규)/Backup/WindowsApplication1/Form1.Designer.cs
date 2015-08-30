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
            this.connect = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.state = new System.Windows.Forms.Label();
            this.textBox_recieve = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RS232
            // 
            this.RS232.BaudRate = 57600;
            this.RS232.PortName = "COM15";
            this.RS232.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RS232_DataReceived);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(4, 13);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(39, 26);
            this.connect.TabIndex = 0;
            this.connect.Text = "연결";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(49, 13);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(39, 26);
            this.close.TabIndex = 1;
            this.close.Text = "종료";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(4, 67);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(310, 66);
            this.txtMessage.TabIndex = 2;
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(94, 20);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(29, 12);
            this.state.TabIndex = 4;
            this.state.Text = "상태";
            // 
            // textBox_recieve
            // 
            this.textBox_recieve.Location = new System.Drawing.Point(4, 233);
            this.textBox_recieve.Multiline = true;
            this.textBox_recieve.Name = "textBox_recieve";
            this.textBox_recieve.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_recieve.Size = new System.Drawing.Size(310, 65);
            this.textBox_recieve.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(4, 151);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(310, 64);
            this.textBox5.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "변환값";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "받은값";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "보낸값";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "수신값전송";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 311);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox_recieve);
            this.Controls.Add(this.state);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.close);
            this.Controls.Add(this.connect);
            this.Name = "Form1";
            this.Text = "Autobot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort RS232;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.TextBox textBox_recieve;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

