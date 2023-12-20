using mi_lightstrip_controller.src.Com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Window
{
    public partial class SelectComListWindow : Form
    {
        private static Dictionary<string, ComObj> coms;
        private static ComObj select;
        private static bool isConfirm;
        public SelectComListWindow()
        {
            InitializeComponent();
            RefreshComList();
        }
        private void RefreshComList()
        {
            coms = ComUtility.GetComs();
            var comList = coms.Keys.ToList();
            comList.Sort((a, b) => string.Compare(b, a));
            comListDropdown.Items.Clear();
            comListDropdown.Items.AddRange(comList.ToArray());
            comListDropdown.Text = comList != null && comList.Count > 0 ? comList[0] : "";
        }
        public static ComObj GetSelectCom()
        {
            select = null;
            isConfirm = false;
            var w = new SelectComListWindow();
            w.ShowDialog();
            return isConfirm ? select : null;
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
            string key = comListDropdown.Text;
            select = (!string.IsNullOrEmpty(key) && coms != null && coms.ContainsKey(key)) ? coms[key] : null;
            isConfirm = true;
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
