using AnimationTest2;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class KitchenBackgroundForm : Form
    {
        private NeedSystem needSystem;
        private AgeSystem ageSystem;
        private Animator animator;
        private GameTime gameTime;

        public KitchenBackgroundForm(NeedSystem needSystem, AgeSystem ageSystem, GameTime gameTime)
        {
            InitializeComponent();
            this.needSystem = needSystem;
            this.ageSystem = ageSystem;
            this.gameTime = gameTime;

            MethodOfButton();
            WindowState = FormWindowState.Maximized;

            // Инициализируем аниматор для кухни
            animator = new Animator(pictureBoxKitchen);

            // Запускаем анимацию для кухни
            UpdateKitchenAnimation();

            // Подписываемся на события
            this.needSystem.OnStatusesChanged += OnStatusesChanged;
            this.ageSystem.OnAgeChanged += OnAgeChanged;
        }

        // Обновление анимации на кухне
        private void UpdateKitchenAnimation()
        {
            string ageStr = ageSystem.CurrentAge.ToString().ToLower();
            string statusStr = needSystem.GetPriorityStatus().ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);
        }

        private void OnStatusesChanged(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            UpdateKitchenAnimation();

            // Если голод решен - можно вернуться на главную
            if (!statuses.Contains(NeedSystem.Status.Hungry))
            {
                lblMessage.Text = "Питомец сыт! Можно вернуться на главную";
                lblMessage.ForeColor = Color.Green;
            }
        }

        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdateKitchenAnimation();
        }

        #region Кнопки перемещения
        private void btn_MainBackgroundForm_Click(object sender, EventArgs e)
        {
            this.Close(); // Просто закрываем форму, возвращаемся на главную
        }

        private void btn_GameRoomBackgroundForm_Click(object sender, EventArgs e)
        {
            //GameRoomBackgroundForm gameRoomForm = new GameRoomBackgroundForm(needSystem, ageSystem, gameTime);
            //gameRoomForm.ShowDialog();
        }

        private void btn_ChamberBackgroundForm_Click(object sender, EventArgs e)
        {
            //ChamberBackgroundForm chamberForm = new ChamberBackgroundForm(needSystem, ageSystem, gameTime);
            //chamberForm.ShowDialog();
        }

        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            //BedroomBackgroundForm bedroomForm = new BedroomBackgroundForm(needSystem, ageSystem, gameTime);
            //bedroomForm.ShowDialog();
        }

        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            //BathroomBackgroundForm bathroomForm = new BathroomBackgroundForm(needSystem, ageSystem, gameTime);
            //bathroomForm.ShowDialog();
        }
        #endregion

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }

        #region Кнопки действия на кухне
        private void btnFeed_Click(object sender, EventArgs e)
        {
            // Кормим питомца
            needSystem.Feed();
            ageSystem.AddProgress();

            // Обновляем сообщение
            lblMessage.Text = "Питомец кушает...";
            lblMessage.ForeColor = Color.Blue;
        }

        private void MethodOfButton()
        {
            btn_KitchenBackgroundForm.Enabled = false; // Текущая комната
            // На кухне доступно только кормление
            btnClean.Enabled = false;
            btnPlay.Enabled = false;
            btnSleep.Enabled = false;
            btnTreatment.Enabled = false;

            // Показываем подсказку
            lblMessage.Text = "Покормите питомца чтобы убрать голод";
            lblMessage.ForeColor = Color.Red;
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
