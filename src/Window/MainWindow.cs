using mi_lightstrip_controller.src.Lightstrip;
using mi_lightstrip_controller.src.Setting;
using mi_lightstrip_controller.src.Window;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace mi_lightstrip_controller
{
    public partial class MainWindow : Form
    {
        public LightstripConnect connect;

        public MainWindow()
        {
            InitializeComponent();
            FormClosing += MainWindow_FormClosing;
            Shown += MainWindow_FormShown;
            Init();
        }
        private void Init()
        {
            connect = new LightstripConnect();
            isAutoStarup.Checked = Setting.Instance.AutoStartup;
            autoOpenLightStrip.Checked = Setting.Instance.AutoOpenLightStrip;
            autoCloseLightStrip.Checked = Setting.Instance.AutoCloseLightStrip;
            closeHideWindow.Checked = Setting.Instance.ClickCloseMinimize;
            autoMinimize.Checked = Setting.Instance.AutoMinimize;
            currentComText.Text = Setting.Instance.Com;
            toggleLightStrip.Checked = false;

            if (string.IsNullOrEmpty(Setting.Instance.Com))
            {
                AutoSelectCom();
            }
            else
            {
                SetComText(Setting.Instance.Com);
                if (Setting.Instance.AutoOpenLightStrip)
                {
                    connect.OpenLightStrip(true);
                    UpdateState();
                }
            }
            if (Setting.Instance.AutoMinimize)
            {
                ShowInTaskbar = false;
                Opacity = 0;
            }
        }
        private void SetComText(string comText)
        {
            Setting.Instance.Com = comText;
            currentComText.Text = comText;
            connect.SetCom(comText);
        }
        private string AutoSelectCom()
        {
            var comList = SelectComListWindow.GetComList();
            int findIndex = comList.FindIndex(com => com.ToLower().Contains("ch340"));
            if (findIndex < 0)
            {
                MessageBox.Show("未找到灯带串口，请手动选择", "提示", MessageBoxButtons.OK);
                return null;
            }
            else
            {
                string comText = comList[findIndex];
                SetComText(comText);
                return comText;
            }
        }
        private void UpdateState()
        {
            toggleLightStrip.Checked = connect.State;
        }
        private void ToggleLightStrip_CheckedChanged(object sender, EventArgs e)
        {
            connect.OpenLightStrip(toggleLightStrip.Checked);
            if (connect.State != toggleLightStrip.Checked)
            {
                UpdateState();
            }
        }
        private void QuitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoClose();
            mainNotifyIcon.Visible = false;
            Dispose();
            Application.Exit();
        }
        private void CloseLightStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connect.OpenLightStrip(false);
            UpdateState();
        }
        private void OpenLightStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connect.OpenLightStrip(true);
            UpdateState();
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
                ShowInTaskbar = true;
                Opacity = 1;
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
        private void ManualSelectBtn_Click(object sender, EventArgs e)
        {
            string com = SelectComListWindow.GetSelectCom();
            if (!string.IsNullOrEmpty(com))
            {
                SetComText(com);
            }
        }
        private void AutoSelectBtn_Click(object sender, EventArgs e)
        {
            string comText = AutoSelectCom();
            if (!string.IsNullOrEmpty(comText))
            {
                MessageBox.Show("找到串口: " + comText, "提示", MessageBoxButtons.OK);
            }
        }
        private void AutoClose()
        {
            if (!Setting.Instance.AutoCloseLightStrip) return;
            if (connect != null)
                connect.OpenLightStrip(false, false);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x11) // 关机
            {
                AutoClose();
            }
            base.WndProc(ref m);
        }
    }
}
