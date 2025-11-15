using System;
using System.Windows.Forms;

namespace Racing_Game_For_Tamagochi_Nosuha
{
    public partial class RacingGame : Form
    {
        private Random random = new Random();
        private bool lose = false;
        private bool _isLeftKeyPressed = false;
        private bool _isRightKeyPressed = false;
        private int countCoins = 0;
        private int countScore = 0;

        public RacingGame()
        {
            InitializeComponent();

            labelLose.Visible = false;
            btnAgain.Visible = false;
            btnBack.Visible = false;
            KeyPreview = true;
        }

        //Обработчик кнопки ESC
        private void RacingGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Изменение трассы
            int speed = 10;
            RoadPictureBox.Top += speed;
            RoadPictureBox2.Top += speed;

            if (RoadPictureBox.Top >= 650)
            {
                RoadPictureBox.Top = 0;
                RoadPictureBox2.Top = -650;
            }


            //Машинка противника
            int carSpeed = 7;
            EnemyCar1.Top += speed;
            EnemyCar2.Top += speed;

            if (EnemyCar1.Top >= 650)
            {
                EnemyCar1.Top = random.Next(-800, -10);
                EnemyCar1.Left = random.Next(-10, 550);
            }

            if (EnemyCar2.Top >= 650)
            {
                EnemyCar2.Top = random.Next(-800, -10);
                EnemyCar2.Left = random.Next(-10, 550);
            }


            //Коины
            Coin.Top += speed;
    
            if (Coin.Top >= 650)
            {
                Coin.Top = random.Next(-70, -10);
                Coin.Left = random.Next(-10, 550);
            }

            //Проверка на сбор монет, и на столкновение с машиной
            if (PlayerCar.Bounds.IntersectsWith(EnemyCar1.Bounds) 
                || PlayerCar.Bounds.IntersectsWith(EnemyCar2.Bounds))
            {
                timer.Enabled = false;
                labelLose.Visible = true;
                btnAgain.Visible = true;
                btnBack.Visible = true;
                lose = true;
            }

            if (PlayerCar.Bounds.IntersectsWith(Coin.Bounds))
            {
                countCoins++;
                labelCoins.Text = "Монеты: " + countCoins.ToString();
                Coin.Top = random.Next(-70, -10);
                Coin.Left = random.Next(-10, 550);
            }


            //Движение машинки
            if (!lose)
            {
                int speed2 = 10;

                // Движение влево
                if (_isLeftKeyPressed && PlayerCar.Left > -10)
                {
                    PlayerCar.Left -= speed;
                }

                // Движение вправо
                if (_isRightKeyPressed && PlayerCar.Right < 550)
                {
                    PlayerCar.Left += speed;
                }
            }
        }

        //Обработчик нажатия клавиш для движения машинки
        private void RacingGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (lose) return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                _isLeftKeyPressed = true;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                _isRightKeyPressed = true;
            }
        }
        //Обработчик опускания клавиш для движения машинки
        private void RacingGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                _isLeftKeyPressed = false;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                _isRightKeyPressed = false;
            }
        }

        //Обработчик кнопки начать игру заново
        private void btnAgain_Click(object sender, EventArgs e)
        {
            EnemyCar1.Top = random.Next(-800, -10);
            EnemyCar1.Left = random.Next(-10, 550);
            EnemyCar2.Top = random.Next(-800, -10);
            EnemyCar2.Left = random.Next(-10, 550);
            labelLose.Visible = false;
            btnAgain.Visible = false;
            btnBack.Visible = false;
            timer.Enabled = true;
            lose = false;
            countCoins = 0;
            countScore = 0;
            labelCoins.Text = "Монеты: 0";
            labelCoins.Text = "Счет: 0";
            Coin.Top = random.Next(-800, -10);
            Coin.Left = random.Next(-10, 550);

            _isLeftKeyPressed = false;
            _isRightKeyPressed = false;
        }

    }
}
