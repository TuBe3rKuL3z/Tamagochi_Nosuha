using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class MainBackgroundForm : Form
    {
        public MainBackgroundForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.Show();
        }
    }
}
