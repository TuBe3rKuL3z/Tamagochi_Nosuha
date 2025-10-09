using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            MainBackgroundForm mainBackgroundForm = new MainBackgroundForm();
            mainBackgroundForm.ShowDialog();
            this.Close();
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
