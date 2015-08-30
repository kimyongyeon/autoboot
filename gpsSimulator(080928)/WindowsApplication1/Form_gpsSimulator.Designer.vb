<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel_Main = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox_Disp = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.NumericUpDown_Interval = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button_End = New System.Windows.Forms.Button
        Me.Button_Pause = New System.Windows.Forms.Button
        Me.Button_Start = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button_PortClose = New System.Windows.Forms.Button
        Me.ComboBox_Baud = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button_PortOpen = New System.Windows.Forms.Button
        Me.TextBox_PortNo = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button_FileLoad = New System.Windows.Forms.Button
        Me.TextBox_FileName = New System.Windows.Forms.TextBox
        Me.TextBox_List = New System.Windows.Forms.TextBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_Main.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Main
        '
        Me.Panel_Main.Controls.Add(Me.Label1)
        Me.Panel_Main.Controls.Add(Me.TextBox_Disp)
        Me.Panel_Main.Controls.Add(Me.GroupBox3)
        Me.Panel_Main.Controls.Add(Me.GroupBox2)
        Me.Panel_Main.Controls.Add(Me.GroupBox1)
        Me.Panel_Main.Controls.Add(Me.TextBox_List)
        Me.Panel_Main.Location = New System.Drawing.Point(2, 2)
        Me.Panel_Main.Name = "Panel_Main"
        Me.Panel_Main.Size = New System.Drawing.Size(730, 363)
        Me.Panel_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "GPS NEMA-0183 Protocol"
        '
        'TextBox_Disp
        '
        Me.TextBox_Disp.Font = New System.Drawing.Font("Gulim", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox_Disp.ForeColor = System.Drawing.Color.Red
        Me.TextBox_Disp.Location = New System.Drawing.Point(440, 295)
        Me.TextBox_Disp.Multiline = True
        Me.TextBox_Disp.Name = "TextBox_Disp"
        Me.TextBox_Disp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Disp.Size = New System.Drawing.Size(276, 59)
        Me.TextBox_Disp.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericUpDown_Interval)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Button_End)
        Me.GroupBox3.Controls.Add(Me.Button_Pause)
        Me.GroupBox3.Controls.Add(Me.Button_Start)
        Me.GroupBox3.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 291)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(425, 63)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Command"
        '
        'NumericUpDown_Interval
        '
        Me.NumericUpDown_Interval.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown_Interval.Location = New System.Drawing.Point(13, 28)
        Me.NumericUpDown_Interval.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_Interval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_Interval.Name = "NumericUpDown_Interval"
        Me.NumericUpDown_Interval.Size = New System.Drawing.Size(104, 21)
        Me.NumericUpDown_Interval.TabIndex = 15
        Me.NumericUpDown_Interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown_Interval.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Interval(ms)"
        '
        'Button_End
        '
        Me.Button_End.Location = New System.Drawing.Point(317, 20)
        Me.Button_End.Name = "Button_End"
        Me.Button_End.Size = New System.Drawing.Size(91, 33)
        Me.Button_End.TabIndex = 13
        Me.Button_End.Text = "End"
        Me.Button_End.UseVisualStyleBackColor = True
        '
        'Button_Pause
        '
        Me.Button_Pause.Location = New System.Drawing.Point(220, 20)
        Me.Button_Pause.Name = "Button_Pause"
        Me.Button_Pause.Size = New System.Drawing.Size(91, 33)
        Me.Button_Pause.TabIndex = 11
        Me.Button_Pause.Text = "Pause"
        Me.Button_Pause.UseVisualStyleBackColor = True
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(123, 20)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(91, 33)
        Me.Button_Start.TabIndex = 10
        Me.Button_Start.Text = "Start"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button_PortClose)
        Me.GroupBox2.Controls.Add(Me.ComboBox_Baud)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Button_PortOpen)
        Me.GroupBox2.Controls.Add(Me.TextBox_PortNo)
        Me.GroupBox2.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(434, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(286, 64)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Output Port"
        '
        'Button_PortClose
        '
        Me.Button_PortClose.Location = New System.Drawing.Point(215, 14)
        Me.Button_PortClose.Name = "Button_PortClose"
        Me.Button_PortClose.Size = New System.Drawing.Size(64, 38)
        Me.Button_PortClose.TabIndex = 13
        Me.Button_PortClose.Text = "Close"
        Me.Button_PortClose.UseVisualStyleBackColor = True
        '
        'ComboBox_Baud
        '
        Me.ComboBox_Baud.FormattingEnabled = True
        Me.ComboBox_Baud.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600", "15200"})
        Me.ComboBox_Baud.Location = New System.Drawing.Point(70, 34)
        Me.ComboBox_Baud.Name = "ComboBox_Baud"
        Me.ComboBox_Baud.Size = New System.Drawing.Size(69, 20)
        Me.ComboBox_Baud.TabIndex = 12
        Me.ComboBox_Baud.Text = "9600"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(78, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Baud"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Port No."
        '
        'Button_PortOpen
        '
        Me.Button_PortOpen.Location = New System.Drawing.Point(145, 14)
        Me.Button_PortOpen.Name = "Button_PortOpen"
        Me.Button_PortOpen.Size = New System.Drawing.Size(64, 38)
        Me.Button_PortOpen.TabIndex = 8
        Me.Button_PortOpen.Text = "Open"
        Me.Button_PortOpen.UseVisualStyleBackColor = True
        '
        'TextBox_PortNo
        '
        Me.TextBox_PortNo.Location = New System.Drawing.Point(6, 33)
        Me.TextBox_PortNo.Name = "TextBox_PortNo"
        Me.TextBox_PortNo.Size = New System.Drawing.Size(56, 21)
        Me.TextBox_PortNo.TabIndex = 7
        Me.TextBox_PortNo.Text = "COM1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button_FileLoad)
        Me.GroupBox1.Controls.Add(Me.TextBox_FileName)
        Me.GroupBox1.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 64)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input File"
        '
        'Button_FileLoad
        '
        Me.Button_FileLoad.Location = New System.Drawing.Point(342, 14)
        Me.Button_FileLoad.Name = "Button_FileLoad"
        Me.Button_FileLoad.Size = New System.Drawing.Size(70, 38)
        Me.Button_FileLoad.TabIndex = 8
        Me.Button_FileLoad.Text = "Load"
        Me.Button_FileLoad.UseVisualStyleBackColor = True
        '
        'TextBox_FileName
        '
        Me.TextBox_FileName.Font = New System.Drawing.Font("Gulim", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox_FileName.Location = New System.Drawing.Point(6, 20)
        Me.TextBox_FileName.Name = "TextBox_FileName"
        Me.TextBox_FileName.Size = New System.Drawing.Size(330, 26)
        Me.TextBox_FileName.TabIndex = 7
        '
        'TextBox_List
        '
        Me.TextBox_List.Font = New System.Drawing.Font("Gulim", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox_List.ForeColor = System.Drawing.Color.DarkGreen
        Me.TextBox_List.Location = New System.Drawing.Point(10, 103)
        Me.TextBox_List.Multiline = True
        Me.TextBox_List.Name = "TextBox_List"
        Me.TextBox_List.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_List.Size = New System.Drawing.Size(706, 182)
        Me.TextBox_List.TabIndex = 0
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "D:\src\client\vb2005\gpsUTIL\20060812_공대3-고속버스터미널.txt"
        '
        'Timer
        '
        Me.Timer.Interval = 250
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "http://www.ketri.re.kr"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(607, 373)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "한국공학기술원구원"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 397)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel_Main)
        Me.Name = "Form_Main"
        Me.Text = "GPS Simulator V1.1"
        Me.Panel_Main.ResumeLayout(False)
        Me.Panel_Main.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_Main As System.Windows.Forms.Panel
    Friend WithEvents TextBox_List As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_FileLoad As System.Windows.Forms.Button
    Friend WithEvents TextBox_FileName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_End As System.Windows.Forms.Button
    Friend WithEvents Button_Pause As System.Windows.Forms.Button
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox_Baud As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_PortOpen As System.Windows.Forms.Button
    Friend WithEvents TextBox_PortNo As System.Windows.Forms.TextBox
    Friend WithEvents Button_PortClose As System.Windows.Forms.Button
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents TextBox_Disp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown_Interval As System.Windows.Forms.NumericUpDown
    Public WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
