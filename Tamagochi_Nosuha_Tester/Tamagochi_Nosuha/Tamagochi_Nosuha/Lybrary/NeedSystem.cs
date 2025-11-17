using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public class NeedSystem
    {
        public enum Status { Normal, Hungry, Bored, Dirty, Sleepy, Sick, Happy, Washes, Eat, Sleep, Treatment }

        public Status CurrentStatus { get; private set; }

        private Timer hungerTimer;
        private Timer boredomTimer;
        private Timer dirtTimer;

        public event Action<Status> OnStatusChanged;

        public NeedSystem()
        {
            CurrentStatus = Status.Normal;

            hungerTimer = new Timer();
            hungerTimer.Interval = 2000; // | 300000 - 5 мин
            hungerTimer.Tick += (s, e) => SetStatus(Status.Hungry);

            boredomTimer = new Timer();
            boredomTimer.Interval = 180000; // | 180000 - 3 мин
            boredomTimer.Tick += (s, e) => SetStatus(Status.Bored);

            dirtTimer = new Timer();
            dirtTimer.Interval = 80000; // | 420000 - 7 мин
            dirtTimer.Tick += (s, e) => SetStatus(Status.Dirty);
        }

        public void StartNeeds()
        {
            hungerTimer.Start();
            boredomTimer.Start();
            dirtTimer.Start();
        }

        public void SetStatus(Status newStatus)
        {
            CurrentStatus = newStatus;
            OnStatusChanged?.Invoke(newStatus);
        }

        public void Feed()
        {
            hungerTimer.Stop();

            SetStatus(Status.Eat);

            var eatTimer = new Timer();
            eatTimer.Interval = 3000; 
            eatTimer.Tick += (s, e) => {
                SetStatus(Status.Normal);
                ResetTimer(hungerTimer);
                eatTimer.Stop();
            };
            eatTimer.Start();;
        }

        public void Play()
        {
            if (CurrentStatus == Status.Bored)
                SetStatus(Status.Normal);
            ResetTimer(boredomTimer);
        }

        public void Clean()
        {
            dirtTimer.Stop();

            SetStatus(Status.Washes);

            var washTimer = new Timer();
            washTimer.Interval = 4400;
            washTimer.Tick += (s, e) => {
                SetStatus(Status.Normal);
                ResetTimer(dirtTimer);
                washTimer.Stop();
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
            };
            happyTimer.Start();
        }

        
    }

}
