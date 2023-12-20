using System.IO.Ports;
using System;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Com
{
    public class ComObj
    {
        public int BaudRate { get; set; } = 230400;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Parity Parity { get; set; } = Parity.None;

        public string name;
        public string description;

        private SerialPort serialPort;

        ~ComObj()
        {
            IsOpen = false;
        }

        public bool IsOpen
        {
            get { return serialPort != null ? serialPort.IsOpen : false; }
            set 
            {
                if (!value)
                {
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    serialPort = null;
                }
                else
                {
                    if (serialPort == null)
                    {
                        serialPort = new SerialPort();
                        serialPort.PortName = name;        // 串口名称
                        serialPort.BaudRate = BaudRate;   // 波特率
                        serialPort.DataBits = DataBits;   // 数据位
                        serialPort.StopBits = StopBits;   // 停止位
                        serialPort.Parity = Parity;       // 校验位
                        serialPort.NewLine = "\r\n";
                    }
                    if (!serialPort.IsOpen)
                    {
                        try
                        {
                            serialPort.Open();
                        }
                        catch (UnauthorizedAccessException)
                        {
                            throw new UnauthorizedAccessException("串口被占用: " + name);
                        }
                    }
                }
            }
        }
        public string GetShowText()
        {
            return $"{description} ({name})";
        }
        public string SendCom(string command)
        {
            try
            {
                if (!IsOpen)
                    IsOpen = true;
                serialPort.WriteLine(command);
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
