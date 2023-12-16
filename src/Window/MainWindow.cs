using mi_lightstrip_controller.src.Lightstrip;
using mi_lightstrip_controller.src.Setting;
using mi_lightstrip_controller.src.Window;
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
            Init();
        }
        private void Init()
        {
            connect = new LightstripConnect();
            isAutoStarup.Checked = Setting.Instance.AutoStartup;
            autoOpenLightStrip.Checked = Setting.Instance.AutoOpenLightStrip;
            autoCloseLightStrip.Checked = Setting.Instance.AutoCloseLightStrip;
            closeHideWindow.Checked = Setting.Instance.ClickCloseMinimize;
        }

        private void ToggleLightStrip_CheckedChanged(object sender, EventArgs e)
        {
            connect.ToggleLightStrip();
        }
        private void QuitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainNotifyIcon.Visible = false;
            Dispose();
            Application.Exit();
        }
        private void CloseLightStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connect.OpenLightStrip(false);
        }
        private void OpenLightStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connect.OpenLightStrip(true);
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
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
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
                currentComText.Text = com;
            }
        }
    }
}
