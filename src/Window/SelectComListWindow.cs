using System;
using System.Windows.Forms;

namespace mi_lightstrip_controller.src.Window
{
    public partial class SelectComListWindow : Form
    {
        private static string selectText;
        public SelectComListWindow()
        {
            InitializeComponent();
            selectText = comListDropdown.Text;
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
            selectText = comListDropdown.Text;
        }
        private void RefreshBtn_Click(object sender, EventArgs e)
        {

        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            selectText = null;
            Close();
        }
    }
}
