using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class BathroomBackgroundForm : Form
    {
        public BathroomBackgroundForm()
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
            this.Close();
        }

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
        #endregion
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }

        #region Кнопки действия
        private void btnClean_Click(object sender, EventArgs e)
        {

        }

        private void MethodOfButton()
        {
            btn_BathroomBackgroundForm.Enabled = false;
            btnSleep.Enabled = false;
            btnFeed.Enabled = false;
            btnTreatment.Enabled = false;
            btnPlay.Enabled = false;
        }

        #endregion
    }
}
