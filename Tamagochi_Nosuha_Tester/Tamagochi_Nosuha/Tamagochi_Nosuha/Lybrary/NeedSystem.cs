using System;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public class NeedSystem
    {
        public enum Status { Normal, Hungry, Bored, Dirty, Sleepy, Sick, Happy }

        public Status CurrentStatus { get; private set; }

        private Timer hungerTimer;
        private Timer boredomTimer;
        private Timer dirtTimer;

        public event Action<Status> OnStatusChanged;

        public NeedSystem()
        {
            CurrentStatus = Status.Normal;

            hungerTimer = new Timer();
            hungerTimer.Interval = 15000; // 30 сек | 300000 - 5 мин
            hungerTimer.Tick += (s, e) => SetStatus(Status.Hungry);

            boredomTimer = new Timer();
            boredomTimer.Interval = 180000; // 30 сек | 180000 - 3 мин
            boredomTimer.Tick += (s, e) => SetStatus(Status.Bored);

            dirtTimer = new Timer();
            dirtTimer.Interval = 420000; // 30 сек | 420000 - 7 мин
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
            if (CurrentStatus == Status.Hungry)
                SetStatus(Status.Normal);
            ResetTimer(hungerTimer);
        }

        public void Play()
        {
            if (CurrentStatus == Status.Bored)
                SetStatus(Status.Normal);
            ResetTimer(boredomTimer);
        }

        public void Clean()
        {
            if (CurrentStatus == Status.Dirty)
                SetStatus(Status.Normal);
            ResetTimer(dirtTimer);
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
