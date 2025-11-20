using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class ChamberBackgroundForm : Form
    {
        public ChamberBackgroundForm()
        {
            InitializeComponent();
            MethodOfButton();
            WindowState = FormWindowState.Maximized;
        }

        #region Кнопки перемещения
        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            KitchenBackgroundForm kitchenBackgroundForm = new KitchenBackgroundForm();
            kitchenBackgroundForm.ShowDialog();
        }

        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
            MainBackgroundForm mainBackgroundForm = new MainBackgroundForm();
            mainBackgroundForm.ShowDialog();
        }

        private void btn_GameRoomBackgroundForm_Click(object sender, EventArgs e)
        {
            GameRoomBackgroundForm gameRoomBackgroundForm = new GameRoomBackgroundForm();
            gameRoomBackgroundForm.ShowDialog();
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
        private void btnTreatment_Click(object sender, EventArgs e)
        {

        }
        private void MethodOfButton()
        {
            btn_ChamberBackgroundForm.Enabled = false;
            btnClean.Enabled = false;
            btnFeed.Enabled = false;
            btnSleep.Enabled = false;
            btnPlay.Enabled = false;
        }

        #endregion
    }
}
