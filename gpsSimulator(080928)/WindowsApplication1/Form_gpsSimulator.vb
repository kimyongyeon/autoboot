Option Explicit On
Imports System.Windows.Forms
Imports System.IO


Public Class Form_Main

    Dim sr As StreamReader
    Dim sPreTime As String    ' Previous Time
    Dim sPreBuffer As String  ' Previous Buffer


    Private Sub Button_FileLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_FileLoad.Click
        'Dim myStream As Stream
        'Dim openFileDialog1 As New OpenFileDialog()

        OpenFileDialog.InitialDirectory = "c:\"
        OpenFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 2
        OpenFileDialog.RestoreDirectory = True

        If OpenFileDialog.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            MsgBox("Open Error")
            Exit Sub
        End If

        TextBox_FileName.Text = OpenFileDialog.FileName

        'If sr null Then
        'sr.Close()
        'End If

        sr = New StreamReader(TextBox_FileName.Text)
    End Sub

    Private Sub Button_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Start.Click
        Timer.Enabled = True
        disp_msg("Simulation start!! Interval=" & NumericUpDown_Interval.Value)
    End Sub


    Private Sub Button_End_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_End.Click
        End
    End Sub

    Private Sub Button_PortOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_PortOpen.Click
        Try
            '------ Serial Port Setting -----------------------------------------------------------
            With SerialPort

                .PortName = TextBox_PortNo.Text
                .BaudRate = ComboBox_Baud.Text
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                '.Encoding = System.Text.Encoding.GetEncoding(0)

            End With
            '------ Port Open ---------------------------------------------------------------------
            If SerialPort.IsOpen = True Then
                SerialPort.Close()
            Else
                SerialPort.Open()
                disp_msg("Port Open Ok!!")
            End If

        Catch ex As Exception
            disp_msg("Port Open Error" & ex.ToString)
        End Try
    End Sub

    Sub disp_msg(ByVal AsMsg As String)
        TextBox_Disp.Text = AsMsg & vbCrLf & TextBox_Disp.Text
    End Sub
    Sub disp_list(ByVal AsMsg As String)
        TextBox_List.Text = AsMsg & vbCrLf & TextBox_List.Text
    End Sub

    Sub send_data()
        Dim sLine As String                 ' Read Buffer
        Dim sBuffer As String               ' Send Buffer
        Dim sCurTime As String              ' Previous Time and Curren Time

        Try
            sBuffer = sPreBuffer
            sCurTime = ""
            Do
                sLine = sr.ReadLine()
                If (InStr(sLine, "$") > 0) Then   ' 새로운 문장 출현
                    If (sBuffer <> "") Then       ' 기존 문장 있음
                        Console.WriteLine(sBuffer)
                        disp_list(sBuffer)
                        SerialPort.WriteLine(sBuffer)

                        sPreBuffer = sLine
                        'Timer.Interval = 200
                        Exit Sub
                    Else                          ' 기존 문장 없음  
                        If (Len(sLine) > 0) Then
                            sBuffer = sBuffer & sLine
                        End If
                    End If
                Else                              '새로운 문장이 아님
                    If (Len(sLine) > 0) Then
                        sBuffer = sBuffer & sLine
                    End If
                End If
            Loop Until sLine Is Nothing
        Catch ex As Exception
            disp_msg("Sending Data Error" & ex.ToString)
            Timer.Enabled = False
        End Try
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Call send_data()
    End Sub

    Private Sub Button_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer.Enabled = False
    End Sub

    Private Sub Button_Pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pause.Click
        Timer.Enabled = False
        disp_msg("Simulation paused!!")
    End Sub

    Private Sub ComboBox_Baud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Baud.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    
    Private Sub NumericUpDown_Interval_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown_Interval.ValueChanged
        Timer.Interval = NumericUpDown_Interval.Value
    End Sub

    Private Sub Form_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer.Interval = NumericUpDown_Interval.Value
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Me.Height > Panel_Main.Height + 30) Then
            Me.Height = Me.Height - 1
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Button_PortClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_PortClose.Click
        If SerialPort.IsOpen Then
            SerialPort.Close()
            disp_msg("Port closed Ok!!")
        End If
    End Sub
End Class
