using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class KitchenBackgroundForm : Form
    {
        public KitchenBackgroundForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
            MainBackgroundForm mainBackgroundForm = new MainBackgroundForm();
            mainBackgroundForm.Show();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.Show();
        }

    }
}
