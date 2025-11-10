using System;

namespace AnimationTest2
{
    public class AgeSystem
    {
        public enum Age { Child, Adult, Old, Dead }

        public Age CurrentAge { get; private set; }
        public int Progress { get; private set; }
        public int MaxProgress => 10;

        public event Action<Age> OnAgeChanged;

        public AgeSystem()
        {
            CurrentAge = Age.Child;
            Progress = 0;
        }

        public void AddProgress(int amount = 1)
        {
            if (CurrentAge == Age.Dead) return;

            Progress += amount;

            if (Progress >= MaxProgress)
            {
                Progress = 0;
                NextAge();
            }
        }

        private void NextAge()
        {
            switch (CurrentAge)
            {
                case Age.Child:
                    CurrentAge = Age.Adult;
                    break;
                case Age.Adult:
                    CurrentAge = Age.Old;
                    break;
                case Age.Old:
                    CurrentAge = Age.Dead;
                    break;
            }

            OnAgeChanged?.Invoke(CurrentAge);
        }

        public void AddRandomProgress()
        {
            Random rnd = new Random();
            int actions = rnd.Next(3, 6); // 3-5 действий

            for (int i = 0; i < actions; i++)
            {
                AddProgress();
            }
        }
    }

}
