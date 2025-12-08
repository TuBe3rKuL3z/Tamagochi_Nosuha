using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tamagochi_Nosuha
{
    public class NeedSystem
    {
        public enum Status { Normal, Hungry, Dirty, Sleepy, Sick, Bored, Happy, Washes, Eat, Sleep, Treatment }

        // Список активных состояний вместо одного CurrentStatus
        public List<Status> ActiveStatuses { get; private set; } = new List<Status>();

        // Таймеры основных потребностей
        private Timer hungerTimer;
        private Timer dirtTimer;
        private Timer sleepyTimer;
        private Timer boredTimer;

        // Интервалы состояний (в миллисекундах)
        private int hungerInterval = 6000;
        private int dirtInterval = 10000;
        private int sleepyInterval = 15000;
        private int boredInterval = 12000;

        // Интервалы анимаций (в миллисекундах)
        private int eatAnimationTime = 2800;
        private int washAnimationTime = 4400;
        private int sleepAnimationTime = 5000;
        private int treatmentAnimationTime = 3500;

        // Флаг блокировки для анимаций
        private bool isInAnimation = false;

        // ========== НОВАЯ ЛОГИКА БОЛЕЗНИ И СМЕРТИ ==========

        // Таймер смерти от болезни
        private Timer sicknessDeathTimer;
        private const int SICKNESS_DEATH_TIME = 60000; // 1 минута = 60000 мс

        // Время начала последней болезни
        private DateTime? lastSicknessStartTime = null;

        // Флаг, что лечение началось (таймер смерти остановлен)
        private bool isHealingInProgress = false;

        // Флаг, что питомец умер (для защиты от повторных вызовов)
        private bool isDeadFromSickness = false;

        // Событие при изменении списка состояний
        public event Action<List<Status>> OnStatusesChanged;

        // Событие смерти от болезни
        public event Action OnDeathFromSickness;

        //Событие для завершения действия
        public event Action OnActionCompleted;

        public NeedSystem()
        {
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            // Таймер голода
            hungerTimer = new Timer();
            hungerTimer.Interval = hungerInterval;
            hungerTimer.Tick += (s, e) => {
                if (!isInAnimation && !ActiveStatuses.Contains(Status.Eat))
                    AddStatus(Status.Hungry);
            };

            // Таймер грязи
            dirtTimer = new Timer();
            dirtTimer.Interval = dirtInterval;
            dirtTimer.Tick += (s, e) => {
                if (!isInAnimation && !ActiveStatuses.Contains(Status.Washes))
                    AddStatus(Status.Dirty);
            };

            // Таймер сонливости
            sleepyTimer = new Timer();
            sleepyTimer.Interval = sleepyInterval;
            sleepyTimer.Tick += (s, e) => {
                if (!isInAnimation && !ActiveStatuses.Contains(Status.Sleep))
                    AddStatus(Status.Sleepy);
            };

            // Таймер скуки
            boredTimer = new Timer();
            boredTimer.Interval = boredInterval;
            boredTimer.Tick += (s, e) => {
                if (!isInAnimation)
                    AddStatus(Status.Bored);
            };
        }

        // ========== НОВЫЕ МЕТОДЫ БОЛЕЗНИ ==========

        /// <summary>
        /// Проверка болезни после сна (20% шанс)
        /// </summary>
        public void CheckForSicknessAfterSleep()
        {
            // Нельзя заболеть, если уже болеет или умер
            if (!ActiveStatuses.Contains(Status.Sick) && !isDeadFromSickness && !isHealingInProgress)
            {
                Random rnd = new Random();
                if (rnd.Next(0, 100) < 80) // 20% шанс
                {
                    AddSickness();
                }
            }
        }

        /// <summary>
        /// Добавление болезни и запуск таймера смерти
        /// </summary>
        private void AddSickness()
        {
            if (!ActiveStatuses.Contains(Status.Sick))
            {
                ActiveStatuses.Add(Status.Sick);
                StartSicknessDeathTimer(); // Запускаем/перезапускаем таймер
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        /// <summary>
        /// Запуск/перезапуск таймера смерти от болезни
        /// </summary>
        private void StartSicknessDeathTimer()
        {
            // Если таймер уже существует, останавливаем и перезапускаем
            if (sicknessDeathTimer != null)
            {
                sicknessDeathTimer.Stop();
            }
            else
            {
                // Создаем новый таймер смерти
                sicknessDeathTimer = new Timer();
                sicknessDeathTimer.Interval = SICKNESS_DEATH_TIME;
                sicknessDeathTimer.Tick += OnSicknessDeathTimerTick;
            }

            // Запоминаем время начала болезни
            lastSicknessStartTime = DateTime.Now;

            // Запускаем таймер
            sicknessDeathTimer.Start();
        }

        /// <summary>
        /// Обработчик таймера смерти от болезни
        /// </summary>
        private void OnSicknessDeathTimerTick(object sender, EventArgs e)
        {
            // Останавливаем таймер
            sicknessDeathTimer.Stop();

            // Если лечение не началось - смерть
            if (!isHealingInProgress && !isDeadFromSickness)
            {
                isDeadFromSickness = true;
                OnDeathFromSickness?.Invoke();
            }
        }

        /// <summary>
        /// Остановка таймера смерти (при начале лечения)
        /// </summary>
        private void StopSicknessDeathTimer()
        {
            if (sicknessDeathTimer != null)
            {
                sicknessDeathTimer.Stop();
            }
        }

        // ========== ОСНОВНЫЕ МЕТОДЫ ДЕЙСТВИЙ ==========

        /// Кормление
        public void Feed()
        {
            if (ActiveStatuses.Contains(Status.Hungry) && !isInAnimation && !isDeadFromSickness)
            {
                isInAnimation = true;

                // Сохраняем другие активные состояния кроме голода
                var previousStatuses = ActiveStatuses.Where(s => s != Status.Hungry).ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Eat);
                // Сохраняем другие активные состояния
                foreach (var status in previousStatuses)
                {
                    ActiveStatuses.Add(status);
                }
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var eatTimer = new Timer();
                eatTimer.Interval = eatAnimationTime;
                eatTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Eat);
                    RemoveStatus(Status.Hungry);
                    ResetTimer(hungerTimer);
                    eatTimer.Stop();

                    isInAnimation = false;

                    OnActionCompleted?.Invoke();
                };
                eatTimer.Start();
            }
        }

        /// <summary>
        /// Мытье
        /// </summary>
        public void Clean()
        {
            if (ActiveStatuses.Contains(Status.Dirty) && !isInAnimation && !isDeadFromSickness)
            {
                isInAnimation = true;

                // Сохраняем другие активные состояния кроме грязи
                var previousStatuses = ActiveStatuses.Where(s => s != Status.Dirty).ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Washes);
                // Сохраняем другие активные состояния
                foreach (var status in previousStatuses)
                {
                    ActiveStatuses.Add(status);
                }
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var washTimer = new Timer();
                washTimer.Interval = washAnimationTime;
                washTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Washes);
                    RemoveStatus(Status.Dirty);
                    ResetTimer(dirtTimer);
                    washTimer.Stop();

                    isInAnimation = false;

                    OnActionCompleted?.Invoke();
                };
                washTimer.Start();
            }
        }

        /// <summary>
        /// Сон
        /// </summary>
        public void Sleep()
        {
            if (ActiveStatuses.Contains(Status.Sleepy) && !isInAnimation && !isDeadFromSickness)
            {
                isInAnimation = true;

                // Сохраняем другие активные состояния кроме сонливости
                var previousStatuses = ActiveStatuses.Where(s => s != Status.Sleepy).ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Sleep);
                // Сохраняем другие активные состояния
                foreach (var status in previousStatuses)
                {
                    ActiveStatuses.Add(status);
                }
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var sleepTimer = new Timer();
                sleepTimer.Interval = sleepAnimationTime;
                sleepTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Sleep);
                    RemoveStatus(Status.Sleepy);
                    ResetTimer(sleepyTimer);
                    sleepTimer.Stop();

                    isInAnimation = false;

                    // ПОСЛЕ СНА: проверяем болезнь (20% шанс)
                    CheckForSicknessAfterSleep();

                    OnActionCompleted?.Invoke();
                };
                sleepTimer.Start();
            }
        }

        /// <summary>
        /// Лечение (НАЧАЛО лечения)
        /// </summary>
        public void Heal()
        {
            if (ActiveStatuses.Contains(Status.Sick) && !isInAnimation && !isDeadFromSickness)
            {
                isInAnimation = true;
                isHealingInProgress = true; // Лечение началось
                StopSicknessDeathTimer();   // Останавливаем таймер смерти

                // Сохраняем другие активные состояния кроме болезни
                var previousStatuses = ActiveStatuses.Where(s => s != Status.Sick).ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Treatment);
                // Сохраняем другие активные состояния
                foreach (var status in previousStatuses)
                {
                    ActiveStatuses.Add(status);
                }
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var treatmentTimer = new Timer();
                treatmentTimer.Interval = treatmentAnimationTime;
                treatmentTimer.Tick += (s, e) => {
                    // Завершение лечения
                    RemoveStatus(Status.Treatment);
                    RemoveStatus(Status.Sick); // Удаляем болезнь
                    treatmentTimer.Stop();

                    isInAnimation = false;
                    isHealingInProgress = false;
                    lastSicknessStartTime = null; // Сбрасываем время болезни

                    OnActionCompleted?.Invoke();
                };
                treatmentTimer.Start();
            }
        }

        /// <summary>
        /// Игра (убирает скуку)
        /// </summary>
        public void Play()
        {
            if (!isInAnimation && ActiveStatuses.Contains(Status.Bored) && !isDeadFromSickness)
            {
                RemoveStatus(Status.Bored);
                ResetTimer(boredTimer);
            }
        }

        // ========== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ==========

        /// <summary>
        /// Добавление состояния
        /// </summary>
        public void AddStatus(Status status)
        {
            if (!ActiveStatuses.Contains(status) && !isDeadFromSickness)
            {
                ActiveStatuses.Add(status);
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        /// <summary>
        /// Удаление состояния
        /// </summary>
        private void RemoveStatus(Status status)
        {
            if (ActiveStatuses.Contains(status))
            {
                ActiveStatuses.Remove(status);
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        /// <summary>
        /// Перезапуск таймера
        /// </summary>
        private void ResetTimer(Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

        /// <summary>
        /// Запуск всех таймеров потребностей
        /// </summary>
        public void StartNeeds()
        {
            hungerTimer.Start();
            dirtTimer.Start();
            sleepyTimer.Start();
            boredTimer.Start();
        }

        /// <summary>
        /// Остановка ВСЕХ таймеров (при смерти)
        /// </summary>
        public void StopAllTimers()
        {
            hungerTimer.Stop();
            dirtTimer.Stop();
            sleepyTimer.Stop();
            boredTimer.Stop();

            // Останавливаем таймер смерти
            StopSicknessDeathTimer();
        }

        /// <summary>
        /// Получение приоритетного состояния для анимации
        /// </summary>
        public Status GetPriorityStatus()
        {
            // Сначала анимационные статусы
            if (ActiveStatuses.Contains(Status.Eat)) return Status.Eat;
            if (ActiveStatuses.Contains(Status.Washes)) return Status.Washes;
            if (ActiveStatuses.Contains(Status.Sleep)) return Status.Sleep;
            if (ActiveStatuses.Contains(Status.Treatment)) return Status.Treatment;

            // Затем проблемные статусы
            if (ActiveStatuses.Contains(Status.Sick)) return Status.Sick;
            if (ActiveStatuses.Contains(Status.Hungry)) return Status.Hungry;
            if (ActiveStatuses.Contains(Status.Dirty)) return Status.Dirty;
            if (ActiveStatuses.Contains(Status.Sleepy)) return Status.Sleepy;
            if (ActiveStatuses.Contains(Status.Bored)) return Status.Bored;

            return Status.Normal;
        }

        /// <summary>
        /// Установка сонливости ночью
        /// </summary>
        public void SetSleepyFromNight()
        {
            if (!isInAnimation && !ActiveStatuses.Contains(Status.Sleep) && !isDeadFromSickness)
                AddStatus(Status.Sleepy);
        }
    }
}