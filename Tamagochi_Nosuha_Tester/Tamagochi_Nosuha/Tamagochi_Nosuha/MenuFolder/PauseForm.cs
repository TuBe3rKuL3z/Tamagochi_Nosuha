using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class PauseForm : Form
    {
        public PauseForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
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

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.ShowDialog();
            this.Close();
        }
    }
}
