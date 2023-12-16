using mi_lightstrip_controller.src.Utility;
using Microsoft.Win32;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Setting
{
    public class Setting
    {
        private static string settingKey = "setting";
        private static string SavePath { get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"); } }

        private bool SetAutoStart(bool autoStart)
        {
            var starupPath = GetType().Assembly.Location;
            try
            {
                var fileName = starupPath;
                var shortFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                //打开子键节点
                var myReg = Registry.LocalMachine.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree,
                    RegistryRights.FullControl);
                if (myReg == null)
                {
                    //如果子键节点不存在，则创建之
                    myReg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                if (myReg != null)
                {
                    if (myReg.GetValue(shortFileName) != null)
                    {
                        myReg.DeleteValue(shortFileName);
                    }
                    if (autoStart)
                    {
                        myReg.SetValue(shortFileName, fileName);
                    }
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("设置开机启动失败, 可能需要以管理员权限重新启动", "错误", MessageBoxButtons.OK);
            }
            return false;
        }
        public bool AutoStartup
        {
            get { return GetValue("AutoStartup", false); }
            set
            {
                if (SetAutoStart(value))
                    SetValue("AutoStartup", value);
            }
        }
        public bool AutoOpenLightStrip
        {
            get { return GetValue("AutoOpenLightStrip", true); }
            set { SetValue("AutoOpenLightStrip", value); }
        }
        public bool AutoCloseLightStrip
        {
            get { return GetValue("AutoCloseLightStrip", true); }
            set { SetValue("AutoCloseLightStrip", value); }
        }
        public bool AutoMinimize
        {
            get { return GetValue("AutoMinimize", false); }
            set { SetValue("AutoMinimize", value); }
        }
        public bool ClickCloseMinimize
        {
            get { return GetValue("ClickCloseMinimize", true); }
            set { SetValue("ClickCloseMinimize", value); }
        }
        public string Com
        {
            get { return GetValue("Com", ""); }
            set { SetValue("Com", value); }
        }

        private static int GetValue(string key, int defaultValue = 0)
        {
            string value = IniUtility.Read(settingKey, key, defaultValue.ToString(), SavePath);
            if (!int.TryParse(value, out int v))
                v = defaultValue;
            return v;
        }
        private static bool GetValue(string key, bool defaultValue = false)
        {
            return IniUtility.Read(settingKey, key, defaultValue.ToString(), SavePath) == true.ToString();
        }
        private static string GetValue(string key, string defaultValue = "")
        {
            return IniUtility.Read(settingKey, key, defaultValue, SavePath);
        }
        private static void SetValue(string key, object value)
        {
            IniUtility.Write(settingKey, key, value.ToString(), SavePath);
        }

        private static Setting instance;
        public static Setting Instance
        {
            get
            {
                if (instance == null) instance = new Setting();
                return instance;
            }
        }
    }
}
