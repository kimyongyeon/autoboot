using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace revData
{
    public class Bluetooth : IRs232
    {
        private SerialPort serialPort = null;
        public Bluetooth(string portName, int dataBit)
        {
            serialPort = new SerialPort();

            serialPort.PortName = portName;
            serialPort.DataBits = dataBit;
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

        public void Write(string sendData)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(sendData);
            }
        }
    }
}
