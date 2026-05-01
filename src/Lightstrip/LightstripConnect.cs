using mi_lightstrip_controller.src.Com;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Lightstrip
{
    public class LightstripConnect
    {
        private ComObj com;
        
        private const int baudRate = 230400;
        private const int dataBits = 8;
        private const StopBits stopBits = StopBits.One;
        private const Parity parity = Parity.None;
        private const int powerOnSettleMilliseconds = 200;

        private Action<string, int> errorAction;
        private Action<string, string> successAction;

        public float Intensity { get; private set; }
        public LightstripMode Mode { get; private set; }
        public Color PureColor { get; private set; }
        
        public bool State { get; private set; }
        public int Length { get; private set; }

        public LightstripConnect()
        {

        }

        #region Public
        async public Task InitCom(ComObj com)
        {
            this.com?.Dispose();
            this.com = com;
            this.com.BaudRate = baudRate;
            this.com.DataBits = dataBits;
            this.com.StopBits = stopBits;
            this.com.Parity = parity;
            await Update();
        }
        async public Task<bool> OpenLightStrip(bool isOpen, bool isShowError = true)
        {
            string toState = isOpen ? "开启" : "关闭";
            var res = await SendCommand("set_power " + (isOpen ? "1" : "0"), isShowError ? (toState + "灯带失败") : null);
            if (res == null) return false;
            if (!res.IsError)
            {
                State = isOpen;
                if (isOpen)
                {
                    // 设备刚上电时立即切模式，偶发不会立刻生效；稍等后重放当前模式/颜色更稳定。
                    await Task.Delay(powerOnSettleMilliseconds);
                    await ApplyCurrentMode();
                }
                successAction?.Invoke(toState + "灯带成功", res.res);
                return true;
            }
            return false;
        }
        public void SetCallback(Action<string, string> successAction, Action<string, int> errorAction)
        {
            this.successAction = successAction;
            this.errorAction = errorAction;
        }
        async public Task UpdateState()
        {
            var res = await SendCommand("get_power");
            if (res != null && !res.IsError)
            {
                if (TryParseResponseInt(res.res, out int state))
                {
                    State = state == 1;
                    successAction?.Invoke("获取灯带状态成功", res.res);
                }
                else
                {
                    errorAction?.Invoke("解析灯带状态失败: " + (string.IsNullOrEmpty(res.res) ? "null" : res.res), 1);
                }
            }
        }
        async public Task SetRGBPC(float intensity, Color color)
        {
            int maxColor = 5;
            var colors = new Color[maxColor];
            for (int i = 0; i < colors.Length; i++)
                colors[i] = color;
            await SetRGBPC(intensity, colors);
        }
        async public Task SetRGBPC(float intensity, Color[] colors)
        {
            /** $"{(c.ToArgb() & 0x00FFFFFF).ToString("X6")}" */
            var colors16 = colors.Select(c => $"{c.ToArgb() & 0x00FFFFFF:X6}").ToArray();
            await SetRGBPC(intensity, colors16);
        }
        async public Task SetRGBPC(float intensity, string[] colors)
        {
            intensity = Math.Min(intensity, 1);
            string arg1 = "005a";
            string arg2 = "00";
            string intensity16 = string.Format("{0:X2}", (int)((intensity * 100) * 64 / 100));
            string colorsStr = string.Join(" ", colors.Select(color => color + " " + "4").ToArray());
            string c = $"set_rgb_pc {arg1} {arg2} {intensity16} {colorsStr}";
            var res = await SendCommand(c, null, false);
            if (res != null && !res.IsError)
                successAction?.Invoke(c, res.res);
        }
        public void SetMode(LightstripMode mode)
        {
            Mode = mode;
        }
        public void SetIntensity(float intensity)
        {
            Intensity = intensity;
        }
        public void SetPureColor(Color color)
        {
            PureColor = color;
        }
        async public Task UpdateMode()
        {
            if (com == null) return;
            if (Mode == LightstripMode.Normal)
            {
                await SetPCLinkage(false);
                await SetPCAvailable(false);
            }
            else
            {
                await SetPCAvailable(true);
                await SetPCLinkage(true);
            }
        }
        async public Task UpdateRGBA()
        {
            if (Mode == LightstripMode.PureColor)
            {
                await SetRGBPC(Intensity, PureColor);
            }
        }

        async public Task ApplyCurrentMode()
        {
            await UpdateMode();
            if (Mode == LightstripMode.PureColor)
            {
                await Task.Delay(powerOnSettleMilliseconds);
                await UpdateRGBA();
            }
        }
        #endregion

        #region Private
        async private Task SetPCAvailable(bool available)
        {
            var c = "set_pc_available " + (available ? "1" : "0");
            var res = await SendCommand(c);
            if (res != null && !res.IsError)
            {
                successAction?.Invoke(c, res.res);
            }
        }
        async private Task SetPCLinkage(bool linkage)
        {
            string c = "set_pc_linkage " + (linkage ? "1" : "0");
            var res = await SendCommand(c);
            if (res != null && !res.IsError)
            {
                successAction?.Invoke(c, res.res);
            }
        }
        async private Task<int> GetLength()
        {
            string c = "get_length";
            var res = await SendCommand(c);
            if (res != null && !res.IsError)
            {
                if (TryParseResponseInt(res.res, out int count))
                {
                    successAction?.Invoke("获取灯带长度", res.res);
                    return count;
                }
                else
                {
                    errorAction?.Invoke("解析灯带长度失败: " + (string.IsNullOrEmpty(res.res) ? "null" : res.res), 1);
                }
            }
            return 0;
        }
        async private Task Update()
        {
            await SetPCAvailable(true);
            await UpdateState();
            Length = await GetLength();
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
        async private Task<ComObj.SendReponse> SendCommand(string command, string showError = null, bool hasResponse = true)
        {
            if (!Check(!string.IsNullOrEmpty(showError))) return null;
            try
            {
                return await com.SendCom(command, hasResponse, errorAction);
            }
            catch (Exception e)
            {
                string error = string.IsNullOrEmpty(showError) ? e.Message : (showError + ": " + e.Message);
                errorAction?.Invoke(error, 1);
                if (!string.IsNullOrEmpty(showError))
                {
                    MessageBox.Show(error, "提示", MessageBoxButtons.OK);
                }
                return new ComObj.SendReponse { errCount = 1, error = error, };
            }
        }

        private static bool TryParseResponseInt(string response, out int value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(response))
            {
                return false;
            }

            var parts = response
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = parts.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(parts[i], out value))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
