using System;
using System.Windows.Forms;


namespace Tamagochi_Nosuha
{
    public class GameTime
    {
        private Timer gameTimer;
        private DateTime gameDateTime;
        private int gameDay;

        // Событие при изменении времени
        public event Action<string, string> OnTimeChanged;

        public GameTime()
        {
            gameDateTime = new DateTime(1, 1, 1, 6, 0, 0); //Начинаем в 6:00
            gameDay = 1;

            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 реальная секунда
            gameTimer.Tick += UpdateTime;
        }

        public void StartTime()
        {
            gameTimer.Start();
        }

        public void StopTime()
        {
            gameTimer.Stop();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            //1 реальная секунда = 1 игровая минута
            gameDateTime = gameDateTime.AddMinutes(1);

            // Проверяем смену дня
            if (gameDateTime.Hour == 0 && gameDateTime.Minute == 0)
            {
                gameDay++;
            }

            //Опр ремя суток
            string timeOfDay = GetTimeOfDay();

            OnTimeChanged?.Invoke(gameDateTime.ToString("HH:mm"), timeOfDay);
        }

        //Получение
        private string GetTimeOfDay()
        {
            int hour = gameDateTime.Hour;
            if (hour >= 6 && hour < 18) return "День";
            else return "Ночь";
        }

        public string GetCurrentTime() => gameDateTime.ToString("HH:mm");
        public string GetTimeOfDayString() => GetTimeOfDay();
        public int GetCurrentDay() => gameDay;
    }

}
