Imports System.IO

Public Class Form_GPS_Logger
    Dim bLogging As Boolean             ' flag for logging

    Private Sub Button_FileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_FileSave.Click

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox_FileName.Text = saveFileDialog1.FileName
        End If

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
                .Encoding = System.Text.Encoding.GetEncoding(1252)

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

    Private Sub Button_PortClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_PortClose.Click
        If SerialPort.IsOpen = True Then
            SerialPort.Close()
            disp_msg("Port Close Ok !!")
        End If
    End Sub

    Sub disp_msg(ByVal AsMsg As String)
        TextBox_Disp.Text = AsMsg & vbCrLf & TextBox_Disp.Text
    End Sub
    Sub disp_list(ByVal AsMsg As String)
        TextBox_List.Text = AsMsg & vbCrLf & TextBox_List.Text
    End Sub
    Sub log_msg(ByVal AsMsg As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(TextBox_FileName.Text, True)
        file.WriteLine(AsMsg)
        file.Close()
    End Sub

    Private Sub Button_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Start.Click
        bLogging = True
        disp_msg("Logging starts!!!")
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        TextBox_List.Invoke(New myDelegate(AddressOf updateTextBox), New Object() {})
    End Sub

    Public Delegate Sub myDelegate()
    Public Sub updateTextBox()
        Dim inBuffer As String

        With TextBox_List
            'inBuffer = SerialPort.ReadExisting
            inBuffer = SerialPort.ReadLine
            disp_list(inBuffer)
            If (bLogging) Then log_msg(inBuffer)
        End With
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Button_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Stop.Click
        bLogging = False
        disp_msg("Logging stpped!!!")
    End Sub

    Private Sub Button_End_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_End.Click
        End
    End Sub

    Private Sub SaveFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub Button_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_View.Click
        Shell("notepad " & TextBox_FileName.Text, AppWinStyle.NormalFocus, False)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Me.Height > (Me.Panel_Main.Height + 20)) Then
            Me.Height = Me.Height - 1
        Else
            Timer1.Enabled = False
        End If

    End Sub
End Class
