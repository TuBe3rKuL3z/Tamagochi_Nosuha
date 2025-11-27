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

        // Таймеры состояний
        private Timer hungerTimer;
        private Timer dirtTimer;
        private Timer sleepyTimer;
        private Timer sickTimer;

        // Интервалы состояний (для теста)
        private int hungerInterval = 6000;
        private int dirtInterval = 10000;
        private int sleepyInterval = 15000;
        private int sickInterval = 20000;

        // Интервалы анимаций
        private int eatAnimationTime = 2800;
        private int washAnimationTime = 4400;
        private int sleepAnimationTime = 5000;
        private int treatmentAnimationTime = 3500;

        // Флаг блокировки для анимаций
        private bool isInAnimation = false;

        // Добавляем новые поля для отслеживания болезни
        private DateTime? sicknessStartTime = null;
        private Timer deathFromSicknessTimer;
        private int sicknessDeathTime = 15000; // 30 секунд

        // Событие при изменении списка состояний
        public event Action<List<Status>> OnStatusesChanged;
        
        // Добавляем событие смерти от болезни
        public event Action OnDeathFromSickness;

        public NeedSystem()
        {
            InitializeTimers();
            InitializeDeathTimer();
        }

        private void InitializeTimers()
        {
            // Таймер голода - управляет ТОЛЬКО голодом
            hungerTimer = new Timer();
            hungerTimer.Interval = hungerInterval;
            hungerTimer.Tick += (s, e) => {
                if (!isInAnimation && !ActiveStatuses.Contains(Status.Eat))
                    AddStatus(Status.Hungry);
            };

            // Таймер грязи - управляет ТОЛЬКО грязью
            dirtTimer = new Timer();
            dirtTimer.Interval = dirtInterval;
            dirtTimer.Tick += (s, e) => {
                if (!isInAnimation && !ActiveStatuses.Contains(Status.Washes))
                    AddStatus(Status.Dirty);
            };

            // Таймер сонливости - управляет ТОЛЬКО сонливостью
            sleepyTimer = new Timer();
            sleepyTimer.Interval = sleepyInterval;
            sleepyTimer.Tick += (s, e) => {
                if (!isInAnimation && !ActiveStatuses.Contains(Status.Sleep))
                    AddStatus(Status.Sleepy);
            };

            // Таймер болезни (случайная болезнь) - управляет ТОЛЬКО болезнью
            sickTimer = new Timer();
            sickTimer.Interval = sickInterval;
            sickTimer.Tick += (s, e) => {
                if (new Random().Next(0, 100) < 100 && !isInAnimation && !ActiveStatuses.Contains(Status.Treatment)) // 30% шанс заболеть
                {
                    AddStatus(Status.Sick);
                }
            };
        }

        private void InitializeDeathTimer()
        {
            deathFromSicknessTimer = new Timer();
            deathFromSicknessTimer.Interval = 1000; // Проверяем каждую секунду
            deathFromSicknessTimer.Tick += (s, e) => CheckSicknessDeath();
        }

        private void CheckSicknessDeath()
        {
            if (ActiveStatuses.Contains(Status.Sick) && sicknessStartTime.HasValue)
            {
                // Проверяем, прошло ли 30 секунд с начала болезни
                if ((DateTime.Now - sicknessStartTime.Value).TotalMilliseconds >= sicknessDeathTime)
                {
                    deathFromSicknessTimer.Stop();
                    OnDeathFromSickness?.Invoke();
                }
            }
        }

        // Добавление состояния в список
        public void AddStatus(Status status)
        {
            if (!ActiveStatuses.Contains(status))
            {
                ActiveStatuses.Add(status);
                
                // Если добавили болезнь - запоминаем время начала
                if (status == Status.Sick && !sicknessStartTime.HasValue)
                {
                    sicknessStartTime = DateTime.Now;
                    deathFromSicknessTimer.Start();
                }
                
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        // Удаление состояния из списка
        private void RemoveStatus(Status status)
        {
            if (ActiveStatuses.Contains(status))
            {
                ActiveStatuses.Remove(status);
                
                // Если вылечили болезнь - сбрасываем таймер смерти
                if (status == Status.Sick)
                {
                    sicknessStartTime = null;
                    deathFromSicknessTimer.Stop();
                }
                
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        #region Методы действий

        public void Feed()
        {
            if (ActiveStatuses.Contains(Status.Hungry) && !isInAnimation)
            {
                isInAnimation = true;

                // Временно показываем анимацию еды
                var previousStatuses = ActiveStatuses.Where(s => s != Status.Hungry).ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Eat);
                // Сохраняем другие активные состояния кроме голода
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
                    ResetTimer(hungerTimer); // Сбрасываем ТОЛЬКО таймер голода
                    eatTimer.Stop();

                    // Разблокируем
                    isInAnimation = false;
                };
                eatTimer.Start();
            }
        }

        public void Clean()
        {
            if (ActiveStatuses.Contains(Status.Dirty) && !isInAnimation)
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
                    ResetTimer(dirtTimer); // Сбрасываем ТОЛЬКО таймер грязи
                    washTimer.Stop();

                    isInAnimation = false;
                };
                washTimer.Start();
            }
        }

        public void Sleep()
        {
            if (ActiveStatuses.Contains(Status.Sleepy) && !isInAnimation)
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
                    ResetTimer(sleepyTimer); // Сбрасываем ТОЛЬКО таймер сонливости
                    sleepTimer.Stop();

                    isInAnimation = false;
                };
                sleepTimer.Start();
            }
        }

        public void Heal()
        {
            if (ActiveStatuses.Contains(Status.Sick) && !isInAnimation)
            {
                isInAnimation = true;

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
                    RemoveStatus(Status.Treatment);
                    RemoveStatus(Status.Sick);
                    ResetTimer(sickTimer); // Сбрасываем ТОЛЬКО таймер болезни
                    treatmentTimer.Stop();

                    isInAnimation = false;
                };
                treatmentTimer.Start();
            }
        }

        public void Play()
        {
            if (!isInAnimation)
            {
                RemoveStatus(Status.Bored);
            }
        }

        private void ResetTimer(Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

        #endregion

        public void StartNeeds()
        {
            hungerTimer.Start();
            dirtTimer.Start();
            sleepyTimer.Start();
            sickTimer.Start();
        }

        // Добавляем метод остановки всех таймеров
        public void StopAllTimers()
        {
            hungerTimer.Stop();
            dirtTimer.Stop();
            sleepyTimer.Stop();
            sickTimer.Stop();
            deathFromSicknessTimer.Stop();
        }

        // Получение приоритетного состояния для анимации
        public Status GetPriorityStatus()
        {
            // Сначала проверяем анимационные статусы
            if (ActiveStatuses.Contains(Status.Eat)) return Status.Eat;
            if (ActiveStatuses.Contains(Status.Washes)) return Status.Washes;
            if (ActiveStatuses.Contains(Status.Sleep)) return Status.Sleep;
            if (ActiveStatuses.Contains(Status.Treatment)) return Status.Treatment;
            
            // Затем проверяем проблемные статусы
            if (ActiveStatuses.Contains(Status.Sick)) return Status.Sick;
            if (ActiveStatuses.Contains(Status.Hungry)) return Status.Hungry;
            if (ActiveStatuses.Contains(Status.Dirty)) return Status.Dirty;
            if (ActiveStatuses.Contains(Status.Sleepy)) return Status.Sleepy;
            if (ActiveStatuses.Contains(Status.Bored)) return Status.Bored;
            
            return Status.Normal;
        }

        public void SetSleepyFromNight()
        {
            if (!isInAnimation && !ActiveStatuses.Contains(Status.Sleep))
                AddStatus(Status.Sleepy);
        }
    }
}