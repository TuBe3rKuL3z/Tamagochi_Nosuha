using System;

namespace Tamagochi_Nosuha
{
    public class AgeSystem
    {
        public enum Age { Baby, Adult, Old, Dead }

        public Age CurrentAge { get; private set; }
        public int Progress { get; private set; }
        public int MaxProgress => 10;

        // Флаг празднования (блокирует добавление прогресса)
        public bool IsCelebrating { get; private set; }

        // Существующие события
        public event Action<Age> OnAgeChanged;
        public event Action<int> OnProgressChanged;

        // НОВОЕ: Событие достижения максимума прогресса
        public event Action OnProgressMaxReached;

        public AgeSystem()
        {
            CurrentAge = Age.Baby;
            Progress = 0;
            IsCelebrating = false;
        }

        public void AddProgress(int amount = 1)
        {
            if (CurrentAge == Age.Dead || IsCelebrating) return;

            int oldProgress = Progress;
            Progress += amount;

            // Уведомляем об изменении прогресса
            OnProgressChanged?.Invoke(Progress);

            // Проверяем, достигли ли максимума
            if (Progress >= MaxProgress)
            {
                Progress = MaxProgress; // Фиксируем на максимуме
                IsCelebrating = true;   // Начинаем празднование
                OnProgressMaxReached?.Invoke(); // Уведомляем
            }
        }

        // НОВЫЙ МЕТОД: Переход к следующему возрасту (после празднования)
        public void AdvanceToNextAge()
        {
            if (!IsCelebrating || CurrentAge == Age.Dead) return;

            Progress = 0; // Сбрасываем прогресс
            IsCelebrating = false; // Заканчиваем празднование

            NextAge(); // Переходим к следующему возрасту
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
                    return; // Прерываем
            }

            OnAgeChanged?.Invoke(CurrentAge);
        }

        // Метод для принудительной установки смерти (от болезни)
        public void SetDead()
        {
            if (CurrentAge != Age.Dead)
            {
                CurrentAge = Age.Dead;
                IsCelebrating = false;
                OnProgressChanged?.Invoke(Progress);
            }
        }

        // НОВЫЙ МЕТОД: Принудительно закончить празднование (на случай багов)
        public void CancelCelebration()
        {
            IsCelebrating = false;
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

        // НОВЫЙ МЕТОД: Получение текста возраста
        public string GetAgeText()
        {
            switch (CurrentAge)
            {
                case Age.Baby: return "Ребенок";
                case Age.Adult: return "Взрослый";
                case Age.Old: return "Пожилой";
                case Age.Dead: return "Мертв";
                default: return "Неизвестно";
            }
        }
    }
}