using AnimationTest2;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tamagochi_Nosuha.Properties;

namespace Tamagochi_Nosuha
{
    public class AgeProgressManager
    {
        private AgeSystem ageSystem;
        private PictureBox progressPictureBox;
        private Label ageLabel;
        private Label actionLabel; // Для отображения действий (1/3, 2/3, 3/3)
        private Timer celebrationTimer;

        // Для анимации счастья
        private Animator animator;
        private PictureBox petPictureBox;
        private Timer happinessAnimationTimer;

        // Изображения прогресс-баров (0-10)
        private Image[] progressBarImages;

        public AgeProgressManager(AgeSystem ageSystem, PictureBox progressBox, Label label,
                                  Label actionLabel = null, Animator animator = null,
                                  PictureBox petBox = null)
        {
            this.ageSystem = ageSystem;
            this.progressPictureBox = progressBox;
            this.ageLabel = label;
            this.actionLabel = actionLabel;
            this.animator = animator;
            this.petPictureBox = petBox;

            Initialize();
            LoadProgressBarImagesFromResources();

            // Подписываемся на события
            ageSystem.OnProgressChanged += OnProgressChanged;
            ageSystem.OnActionCounterChanged += OnActionCounterChanged;
            ageSystem.OnProgressMaxReached += OnProgressMaxReached;
            ageSystem.OnAgeChanged += OnAgeChanged;
        }

        private void Initialize()
        {
            celebrationTimer = new Timer();
            celebrationTimer.Interval = 2000; // 2 секунды
            celebrationTimer.Tick += OnCelebrationTimerTick;

            happinessAnimationTimer = new Timer();
            happinessAnimationTimer.Interval = 3000; // 3 секунды анимации
            happinessAnimationTimer.Tick += OnHappinessAnimationComplete;

            UpdateProgressDisplay();
            UpdateActionCounterDisplay();
        }

        private void LoadProgressBarImagesFromResources()
        {
            progressBarImages = new Image[11]; // 0-10
            try
            {
                // Загружаем изображения по вашим именам
                // Progress_Bar__1_, Progress_Bar__2_, и т.д.
                progressBarImages[1] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__1_ ?? CreateFallbackImage(1, 10);
                progressBarImages[2] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__2_ ?? CreateFallbackImage(2, 10);
                progressBarImages[3] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__3_ ?? CreateFallbackImage(3, 10); 
                progressBarImages[4] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__4_ ?? CreateFallbackImage(4, 10);
                progressBarImages[5] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__5_ ?? CreateFallbackImage(5, 10);
                progressBarImages[6] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__6_ ?? CreateFallbackImage(6, 10);
                progressBarImages[7] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__7_ ?? CreateFallbackImage(7, 10);
                progressBarImages[8] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__8_ ?? CreateFallbackImage(8, 10);
                progressBarImages[9] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__9_ ?? CreateFallbackImage(9, 10);
                progressBarImages[10] = Tamagochi_Nosuha.Properties.Resources.Progress_Bar__10_ ?? CreateFallbackImage(10, 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки прогресс-баров: {ex.Message}");

                for (int i = 0; i <= 10; i++)
                {
                    progressBarImages[i] = CreateFallbackImage(i, 10);
                }
            }
        }

        private Image CreateFallbackImage(int progress, int max)
        {
            Bitmap bmp = new Bitmap(200, 30);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);

                int width = (int)(200 * (progress / (float)max));
                g.FillRectangle(Brushes.Blue, 0, 0, width, 30);
                g.DrawRectangle(Pens.Black, 0, 0, 199, 29);
                g.DrawString($"{progress}/{max}", SystemFonts.DefaultFont, Brushes.Black, 80, 8);
            }
            return bmp;
        }

        private void UpdateProgressDisplay()
        {
            if (progressPictureBox != null && progressPictureBox.InvokeRequired)
            {
                progressPictureBox.Invoke(new Action(UpdateProgressDisplay));
                return;
            }

            // Обновляем PictureBox с прогресс-баром (0-10)
            if (progressPictureBox != null && progressBarImages != null)
            {
                int progress = ageSystem.Progress;
                if (progress >= 0 && progress <= 10 && progressBarImages[progress] != null)
                {
                    progressPictureBox.Image = progressBarImages[progress];
                    progressPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            // Обновляем Label с текстом возраста
            if (ageLabel != null)
            {
                string ageText = ageSystem.GetAgeText();
                ageLabel.Text = $"{ageText} ({ageSystem.Progress}/{ageSystem.MaxProgress})";
                ageLabel.ForeColor = ageSystem.IsCelebrating ? Color.Green : Color.Black;
                ageLabel.Font = new Font(ageLabel.Font,
                    ageSystem.IsCelebrating ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        private void UpdateActionCounterDisplay()
        {
            if (actionLabel != null && actionLabel.InvokeRequired)
            {
                actionLabel.Invoke(new Action(UpdateActionCounterDisplay));
                return;
            }

            if (actionLabel != null)
            {
                if (ageSystem.CurrentAge == AgeSystem.Age.Dead || ageSystem.IsCelebrating)
                {
                    actionLabel.Text = "";
                    actionLabel.Visible = false;
                }
                else
                {
                    actionLabel.Text = $"Действия: {ageSystem.ActionCounter}/{ageSystem.ActionsNeeded}";
                    actionLabel.Visible = true;

                    // Меняем цвет в зависимости от заполнения
                    if (ageSystem.ActionCounter == 0)
                        actionLabel.ForeColor = Color.Gray;
                    else if (ageSystem.ActionCounter == 1)
                        actionLabel.ForeColor = Color.Orange;
                    else if (ageSystem.ActionCounter == 2)
                        actionLabel.ForeColor = Color.OrangeRed;
                    else
                        actionLabel.ForeColor = Color.Green;
                }
            }
        }

        private void OnProgressChanged(int progress)
        {
            UpdateProgressDisplay();
        }

        private void OnActionCounterChanged(int current, int needed)
        {
            UpdateActionCounterDisplay();
        }

        private void OnProgressMaxReached()
        {
            if (ageSystem.Progress != 10) return;

            UpdateProgressDisplay();

            // Запускаем таймер 2 секунды
            celebrationTimer.Start();

            // Звуковой эффект
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void OnCelebrationTimerTick(object sender, EventArgs e)
        {
            celebrationTimer.Stop();
            PlayHappinessAnimation();
        }

        private void PlayHappinessAnimation()
        {
            if (animator != null && petPictureBox != null)
            {
                string ageStr = ageSystem.CurrentAge.ToString().ToLower();
                animator.PlayAnimation(ageStr, "happy");

                // Эффект мигания для actionLabel
                if (actionLabel != null)
                {
                    Timer blinkTimer = new Timer();
                    blinkTimer.Interval = 200;
                    int blinkCount = 0;

                    blinkTimer.Tick += (s, e) => {
                        blinkCount++;
                        actionLabel.ForeColor = blinkCount % 2 == 0 ? Color.Green : Color.Gold;

                        if (blinkCount >= 6)
                        {
                            blinkTimer.Stop();
                            blinkTimer.Dispose();
                            happinessAnimationTimer.Start();
                        }
                    };
                    blinkTimer.Start();
                }
                else
                {
                    happinessAnimationTimer.Start();
                }
            }
            else
            {
                happinessAnimationTimer.Start();
            }
        }

        private void OnHappinessAnimationComplete(object sender, EventArgs e)
        {
            happinessAnimationTimer.Stop();

            // Переходим к следующему возрасту
            ageSystem.AdvanceToNextAge();

            UpdateProgressDisplay();
            UpdateActionCounterDisplay();

            ShowNewAgeMessage();
        }

        private void ShowNewAgeMessage()
        {
            if (ageLabel == null) return;

            string message;

            if (ageSystem.CurrentAge == AgeSystem.Age.Adult)
            {
                message = "Питомец вырос! Теперь он Взрослый!";
            }
            else if (ageSystem.CurrentAge == AgeSystem.Age.Old)
            {
                message = "Питомец стал Пожилым. Будьте внимательнее!";
            }
            else
            {
                message = "Возраст изменен!";
            }

            string originalText = ageLabel.Text;
            ageLabel.Text = message;
            ageLabel.ForeColor = Color.DarkBlue;

            Timer messageTimer = new Timer();
            messageTimer.Interval = 2000;
            messageTimer.Tick += (s, e) => {
                messageTimer.Stop();
                messageTimer.Dispose();
                UpdateProgressDisplay();
            };
            messageTimer.Start();
        }

        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdateProgressDisplay();
            UpdateActionCounterDisplay();
        }

        public void Cleanup()
        {
            if (ageSystem != null)
            {
                ageSystem.OnProgressChanged -= OnProgressChanged;
                ageSystem.OnActionCounterChanged -= OnActionCounterChanged;
                ageSystem.OnProgressMaxReached -= OnProgressMaxReached;
                ageSystem.OnAgeChanged -= OnAgeChanged;
            }

            celebrationTimer?.Stop();
            happinessAnimationTimer?.Stop();

            celebrationTimer?.Dispose();
            happinessAnimationTimer?.Dispose();
        }
    }
}