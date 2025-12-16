using System;

namespace Tamagochi_Nosuha
{
    public class AgeSystem
    {
        public enum Age { Baby, Adult, Old, Dead }

        public Age CurrentAge { get; private set; }
        public int Progress { get; private set; }
        public int MaxProgress => 10; // 10 прогресс-баров

        // Для подсчета действий
        public int ActionCounter { get; private set; }
        public int ActionsNeeded => 3; // 3 действия = 1 прогресс

        public bool IsCelebrating { get; private set; }

        // События
        public event Action<Age> OnAgeChanged;
        public event Action<int> OnProgressChanged;
        public event Action<int, int> OnActionCounterChanged; // 1/3, 2/3, 3/3
        public event Action OnProgressMaxReached;

        public AgeSystem()
        {
            CurrentAge = Age.Baby;
            Progress = 0;
            ActionCounter = 0;
            IsCelebrating = false;
        }

        /// <summary>
        /// Добавляет одно действие (3 действия = 1 прогресс)
        /// </summary>
        public void AddAction()
        {
            if (CurrentAge == Age.Dead || IsCelebrating) return;

            ActionCounter++;
            OnActionCounterChanged?.Invoke(ActionCounter, ActionsNeeded);

            if (ActionCounter >= ActionsNeeded)
            {
                ActionCounter = 0;
                AddProgress(1);
                OnActionCounterChanged?.Invoke(ActionCounter, ActionsNeeded); // Сбрасываем счетчик в UI
            }
        }

        /// <summary>
        /// Прямое добавление прогресса (использовать осторожно)
        /// </summary>
        public void AddProgress(int amount = 1)
        {
            if (CurrentAge == Age.Dead || IsCelebrating) return;

            int oldProgress = Progress;
            Progress += amount;

            OnProgressChanged?.Invoke(Progress);

            if (Progress >= MaxProgress)
            {
                Progress = MaxProgress;
                IsCelebrating = true;
                OnProgressMaxReached?.Invoke();
            }
        }

        /// <summary>
        /// Переход к следующему возрасту (после празднования)
        /// </summary>
        public void AdvanceToNextAge()
        {
            if (!IsCelebrating || CurrentAge == Age.Dead) return;

            Progress = 0;
            ActionCounter = 0;
            IsCelebrating = false;

            NextAge();
            OnActionCounterChanged?.Invoke(ActionCounter, ActionsNeeded); // Обновляем UI
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
                    OnAgeChanged?.Invoke(CurrentAge);
                    return;
            }

            OnAgeChanged?.Invoke(CurrentAge);
        }

        public void SetDead()
        {
            if (CurrentAge != Age.Dead)
            {
                CurrentAge = Age.Dead;
                IsCelebrating = false;
                OnProgressChanged?.Invoke(Progress);
                OnActionCounterChanged?.Invoke(ActionCounter, ActionsNeeded);
            }
        }

        public void CancelCelebration()
        {
            IsCelebrating = false;
        }

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

        // Старый метод для обратной совместимости
        public void AddRandomProgress()
        {
            Random rnd = new Random();
            int actions = rnd.Next(3, 6);

            for (int i = 0; i < actions; i++)
            {
                AddAction();
            }
        }
    }
}