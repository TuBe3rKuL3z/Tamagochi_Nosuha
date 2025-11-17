using AnimationTest2;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
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
            this.WindowState = FormWindowState.Maximized;

            gameTime = new GameTime();
            ageSystem = new AgeSystem();
            needSystem = new NeedSystem();
            animator = new Animator(pictureBox1);

            gameTime.OnTimeChanged += UpdateTimeDisplay;
            ageSystem.OnAgeChanged += OnAgeChanged;
            needSystem.OnStatusChanged += OnStatusChanged;

            string ageStr = ageSystem.CurrentAge.ToString().ToLower();
            string statusStr = needSystem.CurrentStatus.ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);


            //Запуск
            gameTime.StartTime();
            needSystem.StartNeeds();

        }



        //Время
        private void UpdateTimeDisplay(string time, string timeOfDay)
        {
            lblGameTime.Text = $"{time} ({timeOfDay})";
            lblGameDay.Text = $"День: {gameTime.GetCurrentDay()}";

            if (timeOfDay == "Ночь")
            {
                needSystem.SetStatus(NeedSystem.Status.Sleepy);
            }
        }

        //Меняем анимацию при смене возраста
        private void OnAgeChanged(AgeSystem.Age newAge)
        {
            string ageStr = newAge.ToString().ToLower();
            string statusStr = needSystem.CurrentStatus.ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);
        }

        private void OnStatusChanged(NeedSystem.Status newStatus)
        {
            //Обновляем анимацию при смене статуса
            string ageStr = ageSystem.CurrentAge.ToString().ToLower();
            string statusStr = newStatus.ToString().ToLower();
            animator.PlayAnimation(ageStr, statusStr);
        }


        #region Кнопки для перехода меж комнат
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

        #endregion


        //кормить
        private void btnFeed_Click(object sender, EventArgs e)
        {
            needSystem.Feed();
            ageSystem.AddProgress();
        }

        //МЫть
        private void btnClean_Click(object sender, EventArgs e)
        {
            needSystem.Clean();
            ageSystem.AddProgress();

        }

        //Играть
        private void btnPlay_Click(object sender, EventArgs e)
        {
            needSystem.Play();
            ageSystem.AddProgress();

        }
    }
}
