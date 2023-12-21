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

        private Action<bool, string> successAction;
        private Action<string, int> errorAction;

        private ComObj com;
        public bool State { get; private set; }

        public LightstripConnect()
        {

        }
        public void SetCom(ComObj com)
        {
            if (this.com != null)
            {
                this.com.Dispose();
            }
            this.com = com;
            this.com.BaudRate = baudRate;
            this.com.DataBits = dataBits;
            this.com.StopBits = stopBits;
            this.com.Parity = parity;
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
            return true;
        }
        public void SetCallback(Action<bool, string> successAction, Action<string, int> errorAction)
        {
            this.successAction = successAction;
            this.errorAction = errorAction;
        }
        public void OpenLightStrip(bool isOpen, bool isShowError = true)
        {
            if (!Check(isShowError)) return;
            try
            {
                com.SendCom("set_power " + (isOpen ? "1" : "0"), (res) => successAction?.Invoke(isOpen, res), errorAction);
                State = isOpen;
            }
            catch (Exception e)
            {
                if (isShowError)
                {
                    MessageBox.Show((isOpen ? "开启" : "关闭") + "灯带失败: " + e.Message, "提示", MessageBoxButtons.OK);
                }
            }
        }
    }
}
