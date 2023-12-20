using mi_lightstrip_controller.src.Com;
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

        private ComObj com;
        public bool State { get; private set; }
        public LightstripConnect()
        {

        }
        public void SetCom(ComObj com)
        {
            if (this.com != null)
            {
                this.com.IsOpen = false;
            }
            this.com = com;
            this.com.BaudRate = baudRate;
            this.com.DataBits = dataBits;
            this.com.StopBits = stopBits;
            this.com.Parity = parity;
            try
            {
                this.com.IsOpen = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK);
            }
        }
        public void Close()
        {
            if (com != null)
            {
                com.IsOpen = false;
            }
        }
        private bool Check(bool isShowError = true)
        {
            if (com == null)
            {
                if (isShowError)
                {
                    MessageBox.Show("请选择串口", "提示", MessageBoxButtons.OK);
                }
                return false;
            }
            if (!com.IsOpen)
            {
                try
                {
                    com.IsOpen = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK);
                    return false;
                }
            }
            return true;
        }
        public void OpenLightStrip(bool isOpen, bool isShowError = true)
        {
            if (!Check(isShowError)) return;
            try
            {
                string error = com.SendCom("set_power " + (isOpen ? "1" : "0"));
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
    }
}
