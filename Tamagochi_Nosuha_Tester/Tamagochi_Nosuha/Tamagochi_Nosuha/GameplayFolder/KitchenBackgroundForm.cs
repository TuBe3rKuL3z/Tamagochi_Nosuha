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
            MethodOfButton();
            WindowState = FormWindowState.Maximized;
        }

        #region Кнопки перемещения
        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
            MainBackgroundForm mainBackgroundForm = new MainBackgroundForm();
            mainBackgroundForm.ShowDialog();
            this.Close();
        }
        private void btn_GameRoomBackgroundForm_Click(object sender, EventArgs e)
        {
            GameRoomBackgroundForm gameRoomBackgroundForm = new GameRoomBackgroundForm();
            gameRoomBackgroundForm.ShowDialog();
            this.Close();
        }
        private void btn_ChamberBackgroundForm_Click(object sender, EventArgs e)
        {
            ChamberBackgroundForm chamberBackgroundForm = new ChamberBackgroundForm();
            chamberBackgroundForm.ShowDialog();
            this.Close();
        }
        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BedroomBackgroundForm bedroomBackgroundForm = new BedroomBackgroundForm();
            bedroomBackgroundForm.ShowDialog();
            this.Close();
        }
        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BathroomBackgroundForm bathroomBackgroundForm = new BathroomBackgroundForm();
            bathroomBackgroundForm.ShowDialog();
            this.Close();
        }
        #endregion

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }

        #region Кнопки действия
        private void btnFeed_Click(object sender, EventArgs e)
        {
            //
        }

        private void MethodOfButton()
        {
            btn_KitchenBackgroundForm.Enabled = false;
            btnClean.Enabled = false;
            btnPlay.Enabled = false;
            btnSleep.Enabled = false;
            btnTreatment.Enabled = false;
        }
        #endregion
    }
}
