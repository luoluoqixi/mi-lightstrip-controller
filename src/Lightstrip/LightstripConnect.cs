using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Lightstrip
{
    public class LightstripConnect
    {
        private const int baudRate = 230400;
        private const int dataBits = 8;
        private const StopBits stopBits = StopBits.One;
        private const Parity parity = Parity.None;

        private string comText;
        private string com;
        public bool State { get; private set; }
        public LightstripConnect()
        {

        }
        public void SetCom(string comText)
        {
            this.comText = comText;
            int leftIndex = this.comText.ToUpper().LastIndexOf('(');
            int rightIndex = this.comText.ToUpper().LastIndexOf(')');
            if (leftIndex < 0 || rightIndex < 0)
            {
                MessageBox.Show("串口解析失败: " + this.comText, "错误", MessageBoxButtons.OK);
                return;
            }
            com = comText.Substring(leftIndex + 1, rightIndex - leftIndex - 1);
        }
        private bool Check(bool isShowError = true)
        {
            if (string.IsNullOrEmpty(com))
            {
                if (isShowError)
                {
                    MessageBox.Show("请选择串口", "提示", MessageBoxButtons.OK);
                }
                return false;
            }
            return true;
        }
        public void OpenLightStrip(bool isOpen, bool isShowError = true)
        {
            if (!Check(isShowError)) return;
            try
            {
                string error = SendCom(com, "set_power " + (isOpen ? "1" : "0"));
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
                State = isOpen;
            }
            catch (Exception e)
            {
                if (isShowError)
                {
                    MessageBox.Show((State ? "开启" : "关闭") + "灯带失败: " + e.Message, "提示", MessageBoxButtons.OK);
                }
            }
        }
        //public void ToggleLightStrip()
        //{
        //    OpenLightStrip(!State);
        //}

        private static string SendCom(string com, string command)
        {
            // 创建一个SerialPort对象
            var serialPort = new SerialPort();
            try
            {
                // 设置串口的一些属性
                serialPort.PortName = com;        // 串口名称
                serialPort.BaudRate = baudRate;   // 波特率
                serialPort.DataBits = dataBits;   // 数据位
                serialPort.StopBits = stopBits;   // 停止位
                serialPort.Parity = parity;       // 校验位
                serialPort.NewLine = "\r\n";
                // 打开串口
                serialPort.Open();
                // byte[] data = Encoding.ASCII.GetBytes(command);
                // serialPort.Write(data, 0, data.Length);
                // 向串口发送命令
                serialPort.WriteLine(command);
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (serialPort.IsOpen) // 关闭串口
                    serialPort.Close();
            }
        }
    }
}
