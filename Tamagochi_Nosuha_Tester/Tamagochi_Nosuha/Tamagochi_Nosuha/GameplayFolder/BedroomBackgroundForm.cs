using AnimationTest2;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class BedroomBackgroundForm : Form
    {
        private NeedSystem needSystem;
        private AgeSystem ageSystem;
        private Animator animator;
        private GameTime gameTime;
        public BedroomBackgroundForm(NeedSystem needSystem, AgeSystem ageSystem, GameTime gameTime)
        {
            InitializeComponent();
            this.needSystem = needSystem;
            this.ageSystem = ageSystem;
            this.gameTime = gameTime;

            MethodOfButton();
            WindowState = FormWindowState.Maximized;

            // Инициализируем аниматор для кухни
            animator = new Animator(pictureBoxBedRoom);

            // Запускаем анимацию для кухни
            UpdatebBedRoomAnimation();

            // Подписываемся на события
            this.needSystem.OnStatusesChanged += OnStatusesChanged;
            this.ageSystem.OnAgeChanged += OnAgeChanged;
        }

        // Обновление анимации на кухне
        private void UpdatebBedRoomAnimation()
        {
            string ageStr = ageSystem.CurrentAge.ToString().ToLower();
            string statusStr = needSystem.GetPriorityStatus().ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);
        }

        private void OnStatusesChanged(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            UpdatebBedRoomAnimation();

            // Если голод решен - можно вернуться на главную
            if (!statuses.Contains(NeedSystem.Status.Sleepy))
            {
                lblMessage.Text = "Питомец выспался! Можно вернуться на главную";
                lblMessage.ForeColor = Color.Green;
            }
        }

        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdatebBedRoomAnimation();
        }

        #region Кнопки перемещения
        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            //KitchenBackgroundForm kitchenBackgroundForm = new KitchenBackgroundForm();
            //kitchenBackgroundForm.ShowDialog();
            //this.Close();
        }

        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
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
        private void btnSleep_Click(object sender, EventArgs e)
        {
            // Кормим питомца
            needSystem.Sleep();
            ageSystem.AddProgress();

            // Обновляем сообщение
            lblMessage.Text = "Питомец спит...";
            lblMessage.ForeColor = Color.Blue;
        }

        private void MethodOfButton()
        {
            btn_BedroomBackgroundForm.Enabled = false;
            btnClean.Enabled = false;
            btnFeed.Enabled = false;
            btnTreatment.Enabled = false;
            btnPlay.Enabled = false;
        }

        #endregion


        // При закрытии формы отписываемся от событий
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            needSystem.OnStatusesChanged -= OnStatusesChanged;
            ageSystem.OnAgeChanged -= OnAgeChanged;
            base.OnFormClosed(e);
        }
    }
}
