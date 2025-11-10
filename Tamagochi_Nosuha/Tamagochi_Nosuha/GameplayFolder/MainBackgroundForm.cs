using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public partial class MainBackgroundForm : Form
    {
        private Image[] frames;
        private int currentFrame = 0;

        public MainBackgroundForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(MainBackgroundForm_Load);
        }
        private void MainBackgroundForm_Load(object sender, EventArgs e)
        {
            InitializeAnimation();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm();
            pauseForm.ShowDialog();
        }
        private void btn_KitchenBackgroundForm_Click(object sender, EventArgs e)
        {
            KitchenBackgroundForm kitchenBackgroundForm = new KitchenBackgroundForm();
            kitchenBackgroundForm.ShowDialog();
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
        private void btn_BathroomBackgroundForm_Click(object sender, EventArgs e)
        {
            BathroomBackgroundForm bathroomBackgroundForm = new BathroomBackgroundForm();
            bathroomBackgroundForm.ShowDialog();
            this.Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // Проверка на случай, если массив по какой-то причине не инициализирован
            if (frames == null || frames.Length == 0)
            {
                return;
            }

            currentFrame++;

            if (currentFrame >= frames.Length)
            {
                currentFrame = 0;
            }

            // Проверка, что PictureBox существует
            if (pictureBox1 != null)
            {
                pictureBox1.Image = frames[currentFrame];
            }
        }

        private void InitializeAnimation()
        {
            // Убедитесь, что PictureBox1 существует и имеет размер
            if (pictureBox1 == null)
            {
                // Можно добавить лог или сообщение об ошибке, если PictureBox не найден
                return;
            }

            // Загрузка изображений из ресурсов проекта
            frames = new Image[]
            {
            Properties.Resources.Ch1,
            Properties.Resources.Ch2,
            Properties.Resources.Ch3
            };

            // Установка первого кадра
            if (frames.Length > 0)
            {
                pictureBox1.Image = frames[currentFrame];
            }

            // Настройка PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Настройка таймера. Установите интервал в миллисекундах.
            // Например, 1000 мс = 1 секунда, 100 мс = 1/10 секунды.
            timer1.Interval = 100; // 10 кадров в секунду
            timer1.Start();
        }


    }
}
