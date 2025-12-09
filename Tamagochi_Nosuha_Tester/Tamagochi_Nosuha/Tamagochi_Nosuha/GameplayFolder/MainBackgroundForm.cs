using AnimationTest2;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class MainBackgroundForm : Form
    {
        private GameTime gameTime;
        private AgeSystem ageSystem;
        private NeedSystem needSystem;
        private Animator animator;
        private AgeProgressManager ageProgressManager;
        private bool isPetDead = false;

        private bool isUICelebrationLocked = false;


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

            // Создаем менеджер прогресса
            // Предполагается, что на форме есть:
            // - pictureBoxProgressBar (для прогресс-бара)
            // - lblAgeStatus (для текста возраста)
            ageProgressManager = new AgeProgressManager(
                ageSystem,
                pictureBoxProgressBar,
                lblAgeStatus,
                animator,
                pictureBox1
            );

            // Подписываемся на события
            gameTime.OnTimeChanged += UpdateTimeDisplay;
            ageSystem.OnAgeChanged += OnAgeChanged;
            needSystem.OnStatusesChanged += OnStatusesChanged;
            needSystem.OnDeathFromSickness += OnDeathFromSickness;
            needSystem.OnActionCompleted += OnNeedSystemActionCompleted;

            // Запускаем первую анимацию
            UpdateAnimation();

            // Запускаем системы
            gameTime.StartTime();
            needSystem.StartNeeds();

        }

        //Обновление блокировки UI

        private void UpdateUILockState()
        {
            bool shouldLock = isPetDead || isUICelebrationLocked || ageSystem.IsCelebrating;

            // Блокируем/разблокируем кнопки
            SetButtonsEnabled(!shouldLock);
        }

        private void SetButtonsEnabled(bool enabled)
        {
            // Кнопки перехода
            btn_KitchenBackgroundForm.Enabled = enabled;
            btn_BathroomBackgroundForm.Enabled = enabled;
            btn_BedroomBackgroundForm.Enabled = enabled;
            btn_ChamberBackgroundForm.Enabled = enabled;
            btn_GameRoomBackgroundForm.Enabled = enabled;

            // Кнопки действий
            btnFeed.Enabled = enabled;
            btnClean.Enabled = enabled;
            btnPlay.Enabled = enabled;
            btnSleep.Enabled = enabled;
            btnTreatment.Enabled = enabled;

            // Кнопка паузы
            btn_Pause.Enabled = enabled;
        }


        //Завершение действий
        private void OnNeedSystemActionCompleted()
        {
            ageSystem.AddProgress(); // Прогресс ТОЛЬКО после завершения действия
        }

        // Время
        private void UpdateTimeDisplay(string time, string timeOfDay)
        {
            if (isPetDead) return;

            lblGameTime.Text = $"{time} ({timeOfDay})";
            lblGameDay.Text = $"День: {gameTime.GetCurrentDay()}";

            if (timeOfDay == "Ночь")
            {
                needSystem.SetSleepyFromNight();
            }
        }

        // Меняем анимацию при смене возраста
        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            if (isPetDead) return;

            if (newAge == AgeSystem.Age.Dead)
            {
                ProcessDeath("от старости");
            }
            else
            {
                UpdateAnimation();
            }
        }

        // Обработчик изменения состояний
        private void OnStatusesChanged(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            if (isPetDead) return;

            UpdateButtonColors(statuses);
            UpdateAnimation();
        }

        // Обновление анимации на основе приоритетного состояния
        private void UpdateAnimation()
        {
            if (isPetDead) return;

            string ageStr = ageSystem.CurrentAge.ToString().ToLower();
            string statusStr = needSystem.GetPriorityStatus().ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);
        }

        // Обновление цветов кнопок на основе активных состояний
        private void UpdateButtonColors(System.Collections.Generic.List<NeedSystem.Status> statuses)
        {
            if (isPetDead) return;

            // Кухня - красная если голоден
            btn_KitchenBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Hungry) ? Color.Red : Color.LightGray;

            // Ванная - красная если грязный
            btn_BathroomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Dirty) ? Color.Red : Color.LightGray;

            // Спальня - красная если сонный
            btn_BedroomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sleepy) ? Color.Red : Color.LightGray;

            // Больница - красная если болен
            btn_ChamberBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Sick) ? Color.Red : Color.LightGray;

            // Игровая - красная если скучно
            btn_GameRoomBackgroundForm.BackColor = statuses.Contains(NeedSystem.Status.Bored) ? Color.Red : Color.LightGray;
        }

        // Обработчик смерти от болезни
        private void OnDeathFromSickness()
        {
            // Проверяем, нужно ли вызывать Invoke
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnDeathFromSickness));
                return;
            }

            if (isPetDead) return;
            isPetDead = true;

            // 1. Останавливаем ВСЁ
            gameTime.StopTime();
            needSystem.StopAllTimers();

            // 2. Блокируем ВСЁ
            BlockAllButtons();

            // 3. Анимация смерти
            animator.PlayAnimation("dead", "dead");

            // 4. Сообщение
            MessageBox.Show("Питомец умер от болезни! Игра окончена.",
                           "Смерть", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Универсальный метод обработки смерти
        private void ProcessDeath(string reason)
        {
            if (isPetDead) return; // Защита от повторного вызова

            isPetDead = true;

            // 1. Немедленно блокируем все кнопки
            BlockAllButtons();

            // 2. Останавливаем все системы
            gameTime.StopTime();
            needSystem.StopAllTimers();

            // 3. Устанавливаем смерть в AgeSystem
            ageSystem.SetDead();

            // 4. Прямая анимация смерти (не через UpdateAnimation)
            animator.PlayAnimation("dead", "dead");

            // 5. Отписываемся от событий, чтобы избежать дальнейших обновлений
            gameTime.OnTimeChanged -= UpdateTimeDisplay;
            ageSystem.OnAgeChanged -= OnAgeChanged;
            needSystem.OnStatusesChanged -= OnStatusesChanged;
            needSystem.OnDeathFromSickness -= OnDeathFromSickness;

            // 6. Показываем сообщение
            MessageBox.Show($"Питомец умер {reason}! Игра окончена.", "Смерть",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BlockAllButtons()
        {
            // Кнопки перехода
            btn_KitchenBackgroundForm.Enabled = false;
            btn_BathroomBackgroundForm.Enabled = false;
            btn_BedroomBackgroundForm.Enabled = false;
            btn_ChamberBackgroundForm.Enabled = false;
            btn_GameRoomBackgroundForm.Enabled = false;
            btn_MainBackgroundForm.Enabled = false;

            // Кнопки действий
            btnFeed.Enabled = false;
            btnClean.Enabled = false;
            btnPlay.Enabled = false;
            btnSleep.Enabled = false;
            btnTreatment.Enabled = false;

            // Кнопка паузы
            btn_Pause.Enabled = false;
        }

        #region Кнопки для перехода
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (isPetDead) return;
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }

        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            if (isPetDead) return;
            KitchenBackgroundForm kitchenForm = new KitchenBackgroundForm(needSystem, ageSystem, gameTime);
            kitchenForm.ShowDialog();
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
            if (isPetDead) return;
            ChamberBackgroundForm chamberForm = new ChamberBackgroundForm(needSystem, ageSystem, gameTime);
            chamberForm.ShowDialog();
        }

        private void btn_BedroomBackgroundForm_Click(object sender, EventArgs e)
        {
            if (isPetDead) return;
            BedroomBackgroundForm bedroomForm = new BedroomBackgroundForm(needSystem, ageSystem, gameTime);
            bedroomForm.ShowDialog();
        }

        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            if (isPetDead) return;
            BathroomBackgroundForm bathroomForm = new BathroomBackgroundForm(needSystem, ageSystem, gameTime);
            bathroomForm.ShowDialog();
        }
        #endregion

        #region Кнопки действия (можно оставить для быстрых действий)
        private void btnFeed_Click(object sender, EventArgs e)
        {
            if (isPetDead || ageSystem.IsCelebrating) return;
            needSystem.Feed();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            if (isPetDead || ageSystem.IsCelebrating) return;
            needSystem.Clean();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            if (isPetDead || ageSystem.IsCelebrating) return;
            needSystem.Sleep();
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            if (isPetDead || ageSystem.IsCelebrating) return;
            needSystem.Heal();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (isPetDead) return;
            needSystem.Play();
        }

        private void MethodOfButton()
        {
            btn_MainBackgroundForm.Enabled = false;
        }
        #endregion
    }
}