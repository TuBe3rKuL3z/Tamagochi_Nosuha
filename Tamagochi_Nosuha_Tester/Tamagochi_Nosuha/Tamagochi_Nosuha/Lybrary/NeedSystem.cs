using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public class NeedSystem
    {
        public enum Status { Normal, Hungry, Bored, Dirty, Sleepy, Sick, Happy, Washes, Eat, Sleep, Treatment }

        public Status CurrentStatus { get; private set; }

        private Timer hungerTimer;
        private Timer dirtTimer;

        public event Action<Status> OnStatusChanged;

        // Для паузы
        private List<Timer> allTimers;
        private bool isPaused = false;
        private Dictionary<Timer, int> timerIntervals; //Сохраняем интервалы таймеров



        public NeedSystem()
        {
            CurrentStatus = Status.Normal;
            allTimers = new List<Timer>();
            timerIntervals = new Dictionary<Timer, int>();

            hungerTimer = new Timer();
            hungerTimer.Interval = 5000; // | 300000 - 5 мин
            hungerTimer.Tick += (s, e) => SetStatus(Status.Hungry);
            allTimers.Add(hungerTimer); //Добавление в лист таймеров
            timerIntervals[hungerTimer] = hungerTimer.Interval;

            dirtTimer = new Timer();
            dirtTimer.Interval = 2000; // | 420000 - 7 мин
            dirtTimer.Tick += (s, e) => SetStatus(Status.Dirty);
            //allTimers.Add(dirtTimer);
            //timerIntervals[dirtTimer] = dirtTimer.Interval;


        }



        #region Изменение состояний
        public void Feed()
        {
            PauseAllTimers();
            hungerTimer.Stop();

            SetStatus(Status.Eat);

            var eatTimer = new Timer();
            eatTimer.Interval = 2800; 
            eatTimer.Tick += (s, e) => {
                SetStatus(Status.Normal);
                //ResetTimer(hungerTimer);
                eatTimer.Stop();
                ResumeAllTimers();
            };
            eatTimer.Start();
        }

        public void Play()
        {
            //if (CurrentStatus == Status.Bored)
            //    SetStatus(Status.Normal);
            //ResetTimer(boredomTimer);
        }

        public void Clean()
        {
            PauseAllTimers();
            dirtTimer.Stop();

            SetStatus(Status.Washes);

            var washTimer = new Timer();
            washTimer.Interval = 4400;
            washTimer.Tick += (s, e) => {
                SetStatus(Status.Normal);
                //ResetTimer(dirtTimer);
                washTimer.Stop();
                ResumeAllTimers();
                
            };
            washTimer.Start();
        }

        public void Sleep()
        {
            if (CurrentStatus == Status.Sleepy)
                SetStatus(Status.Normal);
        }

        public void Heal()
        {
            if (CurrentStatus == Status.Sick)
                SetStatus(Status.Normal);
        }

        private void ResetTimer(Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

        public void SetHappy()
        {
            SetStatus(Status.Happy);

            var happyTimer = new Timer();
            happyTimer.Interval = 60000;
            happyTimer.Tick += (s, e) => {
                SetStatus(Status.Normal);
                happyTimer.Stop();
                ResumeAllTimers();
            };
            happyTimer.Start();
        }

        #endregion

        public void StartNeeds()
        {
            hungerTimer.Start();
            dirtTimer.Start();
        }

        public void SetStatus(Status newStatus)
        {
            CurrentStatus = newStatus;
            OnStatusChanged?.Invoke(newStatus);
        }

        //Метод для паузы
        private void PauseAllTimers()
        {
            if (isPaused) return; // Уже на паузе

            isPaused = true;
            foreach (var timer in allTimers)
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                }
            }
        }

        //Метод для возобновления
        private void ResumeAllTimers()
        {
            if (!isPaused) return;

            isPaused = false;
            foreach (var timer in allTimers)
            {
                timer.Start();
            }
        }
    }
}
