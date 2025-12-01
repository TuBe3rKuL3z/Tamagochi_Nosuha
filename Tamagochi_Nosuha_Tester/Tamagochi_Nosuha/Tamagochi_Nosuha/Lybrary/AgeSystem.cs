using System;

namespace Tamagochi_Nosuha
{
    public class AgeSystem
    {
        public enum Age { Baby, Adult, Old, Dead }

        public Age CurrentAge { get; private set; }
        public int Progress { get; private set; }
        public int MaxProgress => 10;

        public event Action<Age> OnAgeChanged;

        public AgeSystem()
        {
            CurrentAge = Age.Baby;
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
                case Age.Baby:
                    CurrentAge = Age.Adult;
                    break;
                case Age.Adult:
                    CurrentAge = Age.Old;
                    break;
                case Age.Old:
                    CurrentAge = Age.Dead;
                    // Вызываем событие смерти от старости
                    OnAgeChanged?.Invoke(CurrentAge);
                    return; // Прерываем, чтобы не вызывать OnAgeChanged второй раз
            }

            OnAgeChanged?.Invoke(CurrentAge);
        }

        // Метод для принудительной установки смерти (от болезни)
        public void SetDead()
        {
            if (CurrentAge != Age.Dead)
            {
                CurrentAge = Age.Dead;
                // НЕ вызываем OnAgeChanged здесь - это сделает MainBackgroundForm
            }
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