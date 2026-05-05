using mi_lightstrip_controller.src.Com;
using mi_lightstrip_controller.src.Lightstrip;
using mi_lightstrip_controller.src.Setting;
using mi_lightstrip_controller.src.Window;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mi_lightstrip_controller
{
    public partial class MainWindow : Form
    {
        private const int WM_QUERYENDSESSION = 0x11;
        private const int WM_ENDSESSION = 0x16;

        public LightstripConnect connect;
        private bool isSyncingPowerState;
        private bool isSystemShutdownClosing;
        private readonly SemaphoreSlim operationLock = new SemaphoreSlim(1, 1);

        public MainWindow()
        {
            InitializeComponent();
            FormClosing += MainWindow_FormClosing;
            Shown += MainWindow_FormShown;
            Init();
        }
        async private void Init()
        {
            switch (Setting.Instance.Mode)
            {
                case LightstripMode.Normal:
                    normalModeToggle.Checked = true;
                    break;
                case LightstripMode.PureColor:
                    pureModeToggle.Checked = true;
                    break;
                default:
                    normalModeToggle.Checked = true;
                    break;
            }
            selectColorBtn.BackColor = Setting.Instance.PureColor;
            connect = new LightstripConnect();
            connect.SetMode(Setting.Instance.Mode);
            connect.SetPureColor(Setting.Instance.PureColor);
            connect.SetIntensity(Setting.Instance.Intensity);

            isAutoStarup.Checked = Setting.Instance.AutoStartup;
            autoOpenLightStrip.Checked = Setting.Instance.AutoOpenLightStrip;
            autoCloseLightStrip.Checked = Setting.Instance.AutoCloseLightStrip;
            closeHideWindow.Checked = Setting.Instance.ClickCloseMinimize;
            autoMinimize.Checked = Setting.Instance.AutoMinimize;
            currentComText.Text = Setting.Instance.Com;
            closeBtn.Checked = true;
            openBtn.Checked = false;
            UpdateModeToggleEnabled();

            if (string.IsNullOrEmpty(Setting.Instance.Com))
            {
                await AutoSelectCom();
            }
            else
            {
                var com = ComUtility.FindCom(Setting.Instance.Com);
                if (com != null)
                {
                    await SetCom(com);
                    if (Setting.Instance.AutoOpenLightStrip)
                    {
                        await SetState(true);
                    }
                }
                else
                {
                    MessageBox.Show("保存的串口未找到: " + Setting.Instance.Com, "错误", MessageBoxButtons.OK);
                }
            }
        }
        private async Task SetCom(ComObj com)
        {
            Setting.Instance.Com = com.name;
            currentComText.Text = com.GetShowText();
            connect.SetCallback(ExecuteCommandSuccess, ExecuteCommandError);
            await connect.InitCom(com);
            UpdateState();
        }
        private async Task<ComObj> AutoSelectCom()
        {
            var coms = ComUtility.GetComs();
            foreach (var com in coms)
            {
                if (com.Key.ToLower().Contains("ch340"))
                {
                    await SetCom(com.Value);
                    return com.Value;
                }
            }
            MessageBox.Show("未找到灯带串口，请手动选择", "提示", MessageBoxButtons.OK);
            return null;
        }
        private void UpdateState()
        {
            isSyncingPowerState = true;
            if (connect != null)
            {
                openBtn.Checked = connect.State;
                closeBtn.Checked = !connect.State;
            }
            isSyncingPowerState = false;
            UpdateModeToggleEnabled();
        }
        private void UpdateModeToggleEnabled()
        {
            bool isPowerOn = connect != null && connect.State;
            normalModeToggle.Enabled = isPowerOn;
            pureModeToggle.Enabled = isPowerOn;
        }
        private async Task SetMode(LightstripMode mode)
        {
            if (Setting.Instance.Mode != mode)
                Setting.Instance.Mode = mode;
            if (connect != null)
            {
                await operationLock.WaitAsync();
                try
                {
                    connect.SetMode(mode);
                    await connect.UpdateMode();
                    if (mode == LightstripMode.PureColor)
                    {
                        await UpdateRGBAInternal();
                    }
                }
                finally
                {
                    operationLock.Release();
                }
            }
        }
        private async Task UpdateRGBA()
        {
            await operationLock.WaitAsync();
            try
            {
                await UpdateRGBAInternal();
            }
            finally
            {
                operationLock.Release();
            }
        }
        private async Task UpdateRGBAInternal()
        {
            var intensity = Setting.Instance.Intensity;
            var pureColor = Setting.Instance.PureColor;
            connect.SetIntensity(intensity);
            connect.SetPureColor(pureColor);
            await SetRGBA(intensity, pureColor);
        }
        private async Task SetRGBA(int intensity, Color c)
        {
            if (Setting.Instance.Intensity != intensity)
                Setting.Instance.Intensity = intensity;
            if (Setting.Instance.PureColor != c)
                Setting.Instance.PureColor = c;
            await connect.SetRGBPC(intensity / 100f, c);
        }
        private async Task SetState(bool state)
        {
            if (connect == null) return;
            await operationLock.WaitAsync();
            try
            {
                if (await connect.OpenLightStrip(state))
                {
                    UpdateState();
                }
            }
            finally
            {
                operationLock.Release();
            }
        }
        private async void OpenBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isSyncingPowerState || !openBtn.Checked || connect == null)
            {
                return;
            }
            if (!connect.State)
            {
                await SetState(true);
            }
        }
        private async void CloseBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isSyncingPowerState || !closeBtn.Checked || connect == null)
            {
                return;
            }
            if (connect.State)
            {
                await SetState(false);
            }
        }
        private void QuitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoClose();
            mainNotifyIcon.Visible = false;
            Dispose();
            Application.Exit();
        }
        private async void CloseLightStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SetState(false);
        }
        private async void OpenLightStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SetState(true);
        }
        private void IsAutoStarup_CheckedChanged(object sender, EventArgs e)
        {
            if (isAutoStarup.Checked != Setting.Instance.AutoStartup)
            {
                Setting.Instance.AutoStartup = isAutoStarup.Checked;
                if (Setting.Instance.AutoStartup != isAutoStarup.Checked)
                {
                    // 如果设置开机启动失败，则还原
                    isAutoStarup.Checked = Setting.Instance.AutoStartup;
                }
            }
        }
        private void AutoOpenLightStrip_CheckedChanged(object sender, EventArgs e)
        {
            if (autoOpenLightStrip.Checked != Setting.Instance.AutoOpenLightStrip)
                Setting.Instance.AutoOpenLightStrip = autoOpenLightStrip.Checked;
        }
        private void AutoCloseLightStrip_CheckedChanged(object sender, EventArgs e)
        {
            if (autoCloseLightStrip.Checked != Setting.Instance.AutoCloseLightStrip)
                Setting.Instance.AutoCloseLightStrip = autoCloseLightStrip.Checked;
        }
        private void CloseHideWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (closeHideWindow.Checked != Setting.Instance.ClickCloseMinimize)
                Setting.Instance.ClickCloseMinimize = closeHideWindow.Checked;
        }
        private void AutoMinimize_CheckedChanged(object sender, EventArgs e)
        {
            if (autoMinimize.Checked != Setting.Instance.AutoMinimize)
                Setting.Instance.AutoMinimize = autoMinimize.Checked;
            
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || isSystemShutdownClosing)
            {
                AutoCloseForSystemShutdown();
                return;
            }

            if (Setting.Instance.ClickCloseMinimize)
            {
                e.Cancel = true;
                Visible = false;
            }
            else
            {
                AutoClose();
            }
        }
        private void MainWindow_FormShown(object sender, EventArgs e)
        {
            if (Setting.Instance.AutoMinimize)
            {
                Hide();
            }
        }
        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
        }
        private void MainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Visible = true;
            }
        }
        private async void ManualSelectBtn_Click(object sender, EventArgs e)
        {
            var com = SelectComListWindow.GetSelectCom();
            if (com != null)
            {
                await SetCom(com);
            }
        }
        private async void AutoSelectBtn_Click(object sender, EventArgs e)
        {
            var com = await AutoSelectCom();
            if (com != null)
            {
                MessageBox.Show("找到串口: " + com.GetShowText(), "提示", MessageBoxButtons.OK);
            }
        }
        private async void AutoClose()
        {
            if (Setting.Instance.AutoCloseLightStrip)
            {
                await connect?.OpenLightStrip(false, false);
            }
        }
        private void AutoCloseForSystemShutdown()
        {
            if (isSystemShutdownClosing)
            {
                return;
            }

            isSystemShutdownClosing = true;
            if (Setting.Instance.AutoCloseLightStrip)
            {
                connect?.TryOpenLightStripForShutdown(false);
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
            {
                AutoCloseForSystemShutdown();
            }
            base.WndProc(ref m);
        }
        private void ExecuteCommandError(string error, int reNumber)
        {
            if (InvokeRequired)
            {
                // 如果不在UI线程上，通过委托在UI线程上执行
                try
                {
                    Invoke(new Action(() => ExecuteCommandError(error, reNumber)));
                }
                catch { }
            }
            else
            {
                AppendLog(error + ", 重试: " + reNumber);
            }
        }
        private void ExecuteCommandSuccess(string text, string response)
        {
            if (InvokeRequired)
            {
                // 如果不在UI线程上，通过委托在UI线程上执行
                try
                {
                    Invoke(new Action(() => ExecuteCommandSuccess(text, response)));
                }
                catch { }
            }
            else
            {
                AppendLog(text + "\r\n" + response);
            }
        }
        private void AppendLog(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            string line = $"[{DateTime.Now:HH:mm:ss}] {text}";
            if (!string.IsNullOrWhiteSpace(logText.Text))
            {
                logText.AppendText("\r\n\r\n");
            }
            logText.AppendText(line);
        }
        private async void NormalModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            normalPanel.Visible = normalModeToggle.Checked;
            if (normalModeToggle.Checked)
                await SetMode(LightstripMode.Normal);
        }
        private async void PureModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            purePanel.Visible = pureModeToggle.Checked;
            if (pureModeToggle.Checked)
                await SetMode(LightstripMode.PureColor);
        }
        private async void IntensityTrackBar_Scroll(object sender, EventArgs e)
        {
            int v = intensityTrackBar.Value;
            Setting.Instance.Intensity = v;
            await UpdateRGBA();
        }
        private async void SelectColorBtn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = Setting.Instance.PureColor;
            colorDialog.AllowFullOpen = true;
            var r = colorDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                Setting.Instance.PureColor = colorDialog.Color;
                selectColorBtn.BackColor = Setting.Instance.PureColor;
                await UpdateRGBA();
            }
        }
    }
}
