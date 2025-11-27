using AnimationTest2;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class MainBackgroundForm : Form
    {
        private GameTime gameTime;
        private AgeSystem ageSystem;
        private NeedSystem needSystem;
        private Animator animator;

        public MainBackgroundForm()
        {
            InitializeComponent();
            MethodOfButton();
            this.WindowState = FormWindowState.Maximized;

            // Создаем системы
            gameTime = new GameTime();
            ageSystem = new AgeSystem();
            needSystem = new NeedSystem();
            animator = new Animator(pictureBox1);

            // Подписываемся на события
            gameTime.OnTimeChanged += UpdateTimeDisplay;
            ageSystem.OnAgeChanged += OnAgeChanged;
            needSystem.OnStatusesChanged += OnStatusesChanged;
            needSystem.OnDeathFromSickness += OnDeathFromSickness;

            // Запускаем первую анимацию
            UpdateAnimation();

            // Запускаем системы
            gameTime.StartTime();
            needSystem.StartNeeds();
        }

        // Время
        private void UpdateTimeDisplay(string time, string timeOfDay)
        {
            lblGameTime.Text = $"{time} ({timeOfDay})";
            lblGameDay.Text = $"День: {gameTime.GetCurrentDay()}";

            if (timeOfDay == "Ночь")
            {
                needSystem.SetSleepyFromNight(); // вместо needSystem.AddStatus(NeedSystem.Status.Sleepy)
            }
        }

        // Обработчик смерти от болезни
        private void OnDeathFromSickness()
        {
            // Останавливаем все таймеры
            gameTime.StopTime();
            needSystem.StopAllTimers();

            // Устанавливаем смерть в AgeSystem
            ageSystem.SetDead();

            // Обновляем анимацию на смерть
            UpdateAnimation();

            // Блокируем все кнопки
            BlockAllButtons();

            // Показываем сообщение о смерти
            MessageBox.Show("Питомец умер от болезни! Игра окончена.", "Смерть",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BlockAllButtons()
        {
            btn_KitchenBackgroundForm.Enabled = false;
            btn_BathroomBackgroundForm.Enabled = false;
            btn_BedroomBackgroundForm.Enabled = false;
            btn_ChamberBackgroundForm.Enabled = false;
            btn_GameRoomBackgroundForm.Enabled = false;

            // Блокируем кнопки действий
            btnFeed.Enabled = false;
            btnClean.Enabled = false;
            btnPlay.Enabled = false;
            btnSleep.Enabled = false;
            btnTreatment.Enabled = false;
        }


        // Меняем анимацию при смене возраста
        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdateAnimation();
        }

        // Обработчик изменения состояний
        private void OnStatusesChanged(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            UpdateButtonColors(statuses);
            UpdateAnimation();
        }

        // Обновление анимации на основе приоритетного состояния
        private void UpdateAnimation()
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
            btn_ChamberBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sick) ? Color.Red : Color.LightGray;

            //// Игровая - красная если скучно
            //btn_GameRoomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Bored) ? Color.Red : Color.LightGray;
        }

        #region Кнопки для перехода
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }

        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            KitchenBackgroundForm kitchenForm = new KitchenBackgroundForm(needSystem, ageSystem, gameTime);
            kitchenForm.ShowDialog();
        }

        private void btn_GameRoomBackgroundForm_Click(object sender, EventArgs e)
        {
            //GameRoomBackgroundForm gameRoomForm = new GameRoomBackgroundForm(needSystem, ageSystem);
            //gameRoomForm.ShowDialog();
        }

        private void btn_ChamberBackgroundForm_Click(object sender, EventArgs e)
        {
            ChamberBackgroundForm chamberForm = new ChamberBackgroundForm(needSystem, ageSystem, gameTime);
            chamberForm.ShowDialog();
        }

        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BedroomBackgroundForm bedroomForm = new BedroomBackgroundForm(needSystem, ageSystem, gameTime);
            bedroomForm.ShowDialog();
        }

        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BathroomBackgroundForm bathroomForm = new BathroomBackgroundForm(needSystem, ageSystem, gameTime);
            bathroomForm.ShowDialog();
        }
        #endregion

        #region Кнопки действия (можно оставить для быстрых действий)
        private void btnFeed_Click(object sender, EventArgs e)
        {
            if (ageSystem.CurrentAge != AgeSystem.Age.Dead)
            {
                needSystem.Feed();
                ageSystem.AddProgress();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            if (ageSystem.CurrentAge != AgeSystem.Age.Dead)
            {
                needSystem.Clean();
                ageSystem.AddProgress();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (ageSystem.CurrentAge != AgeSystem.Age.Dead)
            {
                needSystem.Play();
                ageSystem.AddProgress();
            }
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            if (ageSystem.CurrentAge != AgeSystem.Age.Dead)
            {
                needSystem.Sleep();
                ageSystem.AddProgress();
            }
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            if (ageSystem.CurrentAge != AgeSystem.Age.Dead)
            {
                needSystem.Heal();
                ageSystem.AddProgress();
            }
        }

        private void MethodOfButton()
        {
            btn_MainBackgroundForm.Enabled = false;
        }
        #endregion
    }
}