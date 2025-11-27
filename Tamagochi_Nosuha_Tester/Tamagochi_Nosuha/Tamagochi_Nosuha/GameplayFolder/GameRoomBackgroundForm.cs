using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class GameRoomBackgroundForm : Form
    {

        public GameRoomBackgroundForm()
        {
            InitializeComponent();
            MethodOfButton();
            WindowState = FormWindowState.Maximized;
        }

        #region Кнопки перемещения
        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            //KitchenBackgroundForm kitchenForm = new KitchenBackgroundForm(needSystem, ageSystem, gameTime);
            //kitchenForm.ShowDialog();
            //this.Close();
        }

        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
            //KitchenBackgroundForm kitchenBackgroundForm = new KitchenBackgroundForm();
            //kitchenBackgroundForm.ShowDialog();
            //this.Close();
        }

        private void btn_ChamberBackgroundForm_Click(object sender, EventArgs e)
        {
            //ChamberBackgroundForm chamberForm = new ChamberBackgroundForm(needSystem, ageSystem, gameTime);
            //chamberForm.ShowDialog();
            //this.Close();
        }

        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            //BedroomBackgroundForm bedroomBackgroundForm = new BedroomBackgroundForm();
            //bedroomBackgroundForm.ShowDialog();
            //this.Close();
        }

        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            //BathroomBackgroundForm bathroomBackgroundForm = new BathroomBackgroundForm();
            //bathroomBackgroundForm.ShowDialog();
            //this.Close();
        }
        #endregion

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }

        #region Кнопки действия
        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void MethodOfButton()
        {
            btn_GameRoomBackgroundForm.Enabled = false;
            btnClean.Enabled = false;
            btnFeed.Enabled = false;
            btnSleep.Enabled = false;
            btnTreatment.Enabled = false;
        }

        #endregion
    }
}
