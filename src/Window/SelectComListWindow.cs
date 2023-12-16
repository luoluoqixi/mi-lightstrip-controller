using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Window
{
    public partial class SelectComListWindow : Form
    {
        private static string selectText;
        public SelectComListWindow()
        {
            InitializeComponent();
            RefreshComList();
        }
        private void RefreshComList()
        {
            var comList = GetComList();
            comList.Sort((a, b) => string.Compare(b, a));
            comListDropdown.Items.AddRange(comList.ToArray());
            selectText = comList != null && comList.Count > 0 ? comList[0] : "";
            comListDropdown.Text = selectText;
        }
        public static List<string> GetComList()
        {
            var comlist = new List<string>();
            try
            {
                using (var searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value != null && hardInfo.Properties["Name"].Value.ToString().Contains("(COM"))
                        {
                            var strComName = hardInfo.Properties["Name"].Value.ToString();
                            comlist.Add(strComName);
                        }
                    }
                }
            }
            catch { }
            return comlist;
        }
        public static string GetSelectCom()
        {
            selectText = "";
            var w = new SelectComListWindow();
            w.ShowDialog();
            return selectText;
        }
        private void ComListDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshComList();
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            selectText = comListDropdown.Text;
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            selectText = null;
            Close();
        }
    }
}
