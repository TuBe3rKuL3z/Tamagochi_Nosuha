using AnimationTest2;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public class AgeProgressManager
    {
        private AgeSystem ageSystem;
        private PictureBox progressPictureBox;
        private Label ageLabel;
        private Timer celebrationTimer;

        // Для анимации счастья
        private Animator animator;
        private PictureBox petPictureBox;
        private Timer happinessAnimationTimer;

        // Изображения прогресс-баров (добавятся в Resources)
        private Image[] progressBarImages;

        public AgeProgressManager(AgeSystem ageSystem, PictureBox progressBox, Label label,
                                  Animator animator = null, PictureBox petBox = null)
        {
            this.ageSystem = ageSystem;
            this.progressPictureBox = progressBox;
            this.ageLabel = label;
            this.animator = animator;
            this.petPictureBox = petBox;

            Initialize();
            LoadProgressBarImages();

            // Подписываемся на события
            ageSystem.OnProgressChanged += OnProgressChanged;
            ageSystem.OnProgressMaxReached += OnProgressMaxReached;
            ageSystem.OnAgeChanged += OnAgeChanged;
        }

        private void Initialize()
        {
            // Таймер для задержки 2 секунды перед анимацией счастья
            celebrationTimer = new Timer();
            celebrationTimer.Interval = 2000; // 2 секунды
            celebrationTimer.Tick += OnCelebrationTimerTick;

            // Таймер для анимации счастья
            happinessAnimationTimer = new Timer();
            happinessAnimationTimer.Interval = 3000; // 3 секунды анимации
            happinessAnimationTimer.Tick += OnHappinessAnimationComplete;

            // Обновляем начальное состояние
            UpdateProgressDisplay();
        }

        private void LoadProgressBarImages()
        {
            // Загружаем 10 изображений прогресс-баров из Resources
            progressBarImages = new Image[11]; // 0-10

            try
            {
                // Загружаем базовые изображения (замените на ваши имена)
                var resources = Properties.Resources.ResourceManager;

                for (int i = 0; i <= 10; i++)
                {
                    string resourceName = $"progress_bar_{i}";
                    var image = (Image)resources.GetObject(resourceName);

                    if (image != null)
                    {
                        progressBarImages[i] = image;
                    }
                    else
                    {
                        // Запасной вариант: создаем простой бар
                        progressBarImages[i] = CreateSimpleProgressBar(i);
                    }
                }
            }
            catch (Exception)
            {
                // Если не удалось загрузить, создаем простые бары
                for (int i = 0; i <= 10; i++)
                {
                    progressBarImages[i] = CreateSimpleProgressBar(i);
                }
            }
        }

        private Image CreateSimpleProgressBar(int progress)
        {
            Bitmap bmp = new Bitmap(200, 30);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Фон
                g.FillRectangle(Brushes.LightGray, 0, 0, 200, 30);

                // Прогресс
                int width = (int)(200 * (progress / 10.0));
                g.FillRectangle(Brushes.Blue, 0, 0, width, 30);

                // Рамка
                g.DrawRectangle(Pens.Black, 0, 0, 199, 29);

                // Текст прогресса
                g.DrawString($"{progress}/10", SystemFonts.DefaultFont, Brushes.Black, 80, 8);
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

            // Обновляем PictureBox с прогресс-баром
            if (progressPictureBox != null && progressBarImages != null)
            {
                int progress = ageSystem.Progress;
                if (progress >= 0 && progress <= 10)
                {
                    progressPictureBox.Image = progressBarImages[progress];
                }
            }

            // Обновляем Label с текстом возраста
            if (ageLabel != null)
            {
                string ageText = ageSystem.GetAgeText();
                ageLabel.Text = $"{ageText} ({ageSystem.Progress}/{ageSystem.MaxProgress})";

                // Меняем цвет текста при праздновании
                ageLabel.ForeColor = ageSystem.IsCelebrating ? Color.Green : Color.Black;
            }
        }

        private void OnProgressChanged(int progress)
        {
            UpdateProgressDisplay();
        }

        private void OnProgressMaxReached()
        {
            // Блокируем UI на время празднования
            SetUIEnabled(false);

            // Показываем полный бар 2 секунды
            celebrationTimer.Start();
        }

        private void OnCelebrationTimerTick(object sender, EventArgs e)
        {
            celebrationTimer.Stop();

            // Запускаем анимацию счастья
            PlayHappinessAnimation();
        }

        private void PlayHappinessAnimation()
        {
            if (animator != null && petPictureBox != null)
            {
                string ageStr = ageSystem.CurrentAge.ToString().ToLower();
                animator.PlayAnimation(ageStr, "happy");
            }

            // Запускаем таймер завершения анимации
            happinessAnimationTimer.Start();
        }

        private void OnHappinessAnimationComplete(object sender, EventArgs e)
        {
            happinessAnimationTimer.Stop();

            // Переходим к следующему возрасту
            ageSystem.AdvanceToNextAge();

            // Разблокируем UI
            SetUIEnabled(true);

            // Обновляем отображение (уже с новым возрастом)
            UpdateProgressDisplay();
        }

        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            UpdateProgressDisplay();
        }

        private void SetUIEnabled(bool enabled)
        {
            // Этот метод нужно будет доработать в MainBackgroundForm
            // Пока просто обновляем отображение
            UpdateProgressDisplay();
        }

        public void Cleanup()
        {
            // Отписываемся от событий
            if (ageSystem != null)
            {
                ageSystem.OnProgressChanged -= OnProgressChanged;
                ageSystem.OnProgressMaxReached -= OnProgressMaxReached;
                ageSystem.OnAgeChanged -= OnAgeChanged;
            }

            // Останавливаем таймеры
            celebrationTimer?.Stop();
            happinessAnimationTimer?.Stop();

            celebrationTimer?.Dispose();
            happinessAnimationTimer?.Dispose();
        }
    }
}