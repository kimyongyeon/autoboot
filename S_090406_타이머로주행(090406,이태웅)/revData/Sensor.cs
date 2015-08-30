using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace revData
{
    public class Sensor : IRs232, revData.ISensor
    {
        public delegate void DataReceiveHandler(string recvData);
        public event DataReceiveHandler DataReceived;
        private SerialPort serialPort = null;

        public Sensor(string portName, int dataBit)
        {
            serialPort = new SerialPort();

            serialPort.PortName = portName;
            serialPort.BaudRate = 57600;
            serialPort.DataBits = dataBit;           
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        public void Connect()
        {
            if (!serialPort.IsOpen)
              serialPort.Open();           
        }

        public void Dispose()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }

        public void Write(byte[] sendData, int count)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Write(sendData, 0, count);
            }
        }

        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting();

            DataReceived(data);
            //센서 데이터 수신부

        }

    }
}
