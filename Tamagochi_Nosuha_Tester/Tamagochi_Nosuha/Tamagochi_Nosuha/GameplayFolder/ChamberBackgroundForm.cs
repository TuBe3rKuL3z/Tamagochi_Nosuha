using AnimationTest2;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class ChamberBackgroundForm : Form
    {
        private NeedSystem needSystem;
        private AgeSystem ageSystem;
        private GameTime gameTime;
        private Animator animator;

        public ChamberBackgroundForm(NeedSystem needSystem, AgeSystem ageSystem, GameTime gameTime)
        {
            InitializeComponent();
            this.needSystem = needSystem;
            this.ageSystem = ageSystem;
            this.gameTime = gameTime;

            MethodOfButton();
            WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Tamagochi_Nosuha.Properties.Resources.Chamber_Background;

            // Инициализируем аниматор для комнаты лечения
            animator = new Animator(pictureBoxChamber);

            // Запускаем анимацию
            UpdateChamberAnimation();

            // Подписываемся на события
            this.needSystem.OnStatusesChanged += OnStatusesChanged;
            this.ageSystem.OnAgeChanged += OnAgeChanged;

            BackGroundPictureBox();
        }

        private void BackGroundPictureBox()
        {
            
        }

        // Обновление анимации в комнате лечения
        private void UpdateChamberAnimation()
        {
            string ageStr = ageSystem.CurrentAge.ToString().ToLower();
            string statusStr = needSystem.GetPriorityStatus().ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);
        }

        // Обновление цветов кнопок на основе активных состояний
        private void UpdateButtonColors(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            // Кухня - красная если голоден
            btn_KitchenBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Hungry) ? Color.Red : Color.LightGray;

            // Ванная - красная если грязный
            btn_BathroomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Dirty) ? Color.Red : Color.LightGray;

            // Спальня - красная если сонный
            btn_BedroomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sleepy) ? Color.Red : Color.LightGray;

            //Больница - красная если болен
            btn_ChamberBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sick) ? Color.LightBlue : Color.LightGray;

            //// Игровая - красная если скучно
            //btn_GameRoomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Bored) ? Color.Red : Color.LightGray;
        }

        private void OnStatusesChanged(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            UpdateButtonColors(statuses);
            UpdateChamberAnimation();

            // Если болезнь вылечена - можно вернуться на главную
            if (!statuses.Contains(NeedSystem.Status.Sick))
            {
                lblMessage.Text = "Питомец здоров! Можно вернуться на главную";
                lblMessage.ForeColor = Color.Green;
            }
        }

        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdateChamberAnimation();
        }

        #region Кнопки перемещения
        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            KitchenBackgroundForm kitchenForm = new KitchenBackgroundForm(needSystem, ageSystem, gameTime);
            kitchenForm.ShowDialog();
            this.Close();
        }

        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_GameRoomBackgroundForm_Click(object sender, EventArgs e)
        {
            //GameRoomBackgroundForm gameRoomBackgroundForm = new GameRoomBackgroundForm();
            //gameRoomBackgroundForm.ShowDialog();
            //this.Close();
        }

        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BedroomBackgroundForm bedroomForm = new BedroomBackgroundForm(needSystem, ageSystem, gameTime);
            bedroomForm.ShowDialog();
            this.Close();
        }

        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BathroomBackgroundForm bathroomForm = new BathroomBackgroundForm(needSystem, ageSystem, gameTime);
            bathroomForm.ShowDialog();
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
            // Лечение питомца
            needSystem.Heal();

            // Обновляем сообщение
            lblMessage.Text = "Лечение питомца...";
            lblMessage.ForeColor = Color.Blue;
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

        // При закрытии формы отписываемся от событий
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            needSystem.OnStatusesChanged -= OnStatusesChanged;
            ageSystem.OnAgeChanged -= OnAgeChanged;
            base.OnFormClosed(e);
        }
    }
}
