using AnimationTest2;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class BathroomBackgroundForm : Form
    {
        private AgeProgressManager ageProgressManager;

        private NeedSystem needSystem;
        private AgeSystem ageSystem;
        private Animator animator;
        private GameTime gameTime;
        public BathroomBackgroundForm(NeedSystem needSystem, AgeSystem ageSystem, GameTime gameTime)
        {
            InitializeComponent();
            this.needSystem = needSystem;
            this.ageSystem = ageSystem;
            this.gameTime = gameTime;

            MethodOfButton();
            WindowState = FormWindowState.Maximized;

            // Инициализируем аниматор для кухни
            animator = new Animator(pictureBoxBathRoom);

            // Запускаем анимацию для кухни
            UpdateBathRoomAnimation();

            // Подписываемся на события
            this.needSystem.OnStatusesChanged += OnStatusesChanged;
            this.ageSystem.OnAgeChanged += OnAgeChanged;

            ageProgressManager = new AgeProgressManager(
            ageSystem,
            pictureBoxProgressBar,
            labelAgeStatus
        );
        }



        // Обновление анимации на кухне
        private void UpdateBathRoomAnimation()
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
            btn_BathroomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Dirty) ? Color.LightBlue : Color.LightGray;

            // Спальня - красная если сонный
            btn_BedroomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sleepy) ? Color.Red : Color.LightGray;

            //Больница - красная если болен
            btn_ChamberBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sick) ? Color.Red : Color.LightGray;

            //// Игровая - красная если скучно
            //btn_GameRoomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Bored) ? Color.Red : Color.LightGray;
        }

        private void OnStatusesChanged(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            UpdateButtonColors(statuses);
            UpdateBathRoomAnimation();

            // Если голод решен - можно вернуться на главную
            if (!statuses.Contains(NeedSystem.Status.Dirty))
            {
                lblMessage.Text = "Питомец чист! Можно вернуться на главную";
                lblMessage.ForeColor = Color.Green;
            }
        }

        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdateBathRoomAnimation();
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
            try
            {
                string appDirectory = Application.StartupPath;
                string exeFileName = "Racing Game For_Tamagochi Nosuha.exe";

                string fullPath = Path.Combine(appDirectory, exeFileName);

                if (File.Exists(fullPath))
                {
                    Process.Start(fullPath);
                }
                else
                {
                    MessageBox.Show($"Файл не найден по пути: {fullPath}", "Ошибка запуска", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при попытке запуска: {ex.Message}", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ChamberBackgroundForm_Click(object sender, EventArgs e)
        {
            ChamberBackgroundForm chamberForm = new ChamberBackgroundForm(needSystem, ageSystem, gameTime);
            chamberForm.ShowDialog();
            this.Close();
        }

        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BedroomBackgroundForm bedroomForm = new BedroomBackgroundForm(needSystem, ageSystem, gameTime);
            bedroomForm.ShowDialog();
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
            // Кормим питомца
            needSystem.Clean();
            ageSystem.AddProgress();

            // Обновляем сообщение
            lblMessage.Text = "Питомец моется...";
            lblMessage.ForeColor = Color.Blue;
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

        // При закрытии формы отписываемся от событий
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ageProgressManager?.Cleanup();
            base.OnFormClosed(e);
        }

    }
}
