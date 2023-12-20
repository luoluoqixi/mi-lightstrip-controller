using mi_lightstrip_controller.src.Com;
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
            closeBtn.Checked = true;
            openBtn.Checked = false;

            if (string.IsNullOrEmpty(Setting.Instance.Com))
            {
                AutoSelectCom();
            }
            else
            {
                var com = ComUtility.FindCom(Setting.Instance.Com);
                if (com != null)
                {
                    SetCom(com);
                    if (Setting.Instance.AutoOpenLightStrip)
                    {
                        connect.OpenLightStrip(true);
                        UpdateState();
                    }
                }
                else
                {
                    MessageBox.Show("保存的串口未找到: " + Setting.Instance.Com, "错误", MessageBoxButtons.OK);
                }
            }
            if (Setting.Instance.AutoMinimize)
            {
                ShowInTaskbar = false;
                Opacity = 0;
            }
        }
        private void SetCom(ComObj com)
        {
            Setting.Instance.Com = com.name;
            currentComText.Text = com.GetShowText();
            connect.SetCom(com);
        }
        private ComObj AutoSelectCom()
        {
            var coms = ComUtility.GetComs();
            foreach (var com in coms)
            {
                if (com.Key.ToLower().Contains("ch340"))
                {
                    SetCom(com.Value);
                    return com.Value;
                }
            }
            MessageBox.Show("未找到灯带串口，请手动选择", "提示", MessageBoxButtons.OK);
            return null;
        }
        private void UpdateState()
        {
            openBtn.Checked = connect.State;
            closeBtn.Checked = !connect.State;
        }
        private void OpenBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (connect.State != openBtn.Checked)
            {
                connect.OpenLightStrip(openBtn.Checked);
            }
        }
        private void CloseBtn_CheckedChanged(object sender, EventArgs e)
        {
            // 状态改变时open与close都会自动执行，只需要写在一个监听中即可
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
            var com = SelectComListWindow.GetSelectCom();
            if (com != null)
            {
                SetCom(com);
            }
        }
        private void AutoSelectBtn_Click(object sender, EventArgs e)
        {
            var com = AutoSelectCom();
            if (com != null)
            {
                MessageBox.Show("找到串口: " + com.GetShowText(), "提示", MessageBoxButtons.OK);
            }
        }
        private void AutoClose()
        {
            if (Setting.Instance.AutoCloseLightStrip)
            {
                if (connect != null)
                    connect.OpenLightStrip(false, false);
            }
            if (connect != null)
            {
                connect.Close();
            }
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
