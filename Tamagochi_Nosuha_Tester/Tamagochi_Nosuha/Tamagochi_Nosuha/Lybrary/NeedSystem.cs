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
        private Queue<Status> pendingStatuses = new Queue<Status>();

        // Событие при изменении списка состояний
        public event Action<List<Status>> OnStatusesChanged;

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
                if (!isInAnimation)
                    AddStatus(Status.Hungry);
                else
                    pendingStatuses.Enqueue(Status.Hungry);
            };

            // Таймер грязи
            dirtTimer = new Timer();
            dirtTimer.Interval = dirtInterval;
            dirtTimer.Tick += (s, e) => {
                if (!isInAnimation)
                    AddStatus(Status.Dirty);
                else
                    pendingStatuses.Enqueue(Status.Dirty);
            };

            // Таймер сонливости
            sleepyTimer = new Timer();
            sleepyTimer.Interval = sleepyInterval;
            sleepyTimer.Tick += (s, e) => {
                if (!isInAnimation)
                    AddStatus(Status.Sleepy);
                else
                    pendingStatuses.Enqueue(Status.Sleepy);
            };

            // Таймер болезни (случайная болезнь)
            sickTimer = new Timer();
            sickTimer.Interval = sickInterval;
            sickTimer.Tick += (s, e) => {
                if (new Random().Next(0, 100) < 30) // 30% шанс заболеть
                {
                    if (!isInAnimation)
                        AddStatus(Status.Sick);
                    else
                        pendingStatuses.Enqueue(Status.Sick);
                }
            };
        }

        // Добавление состояния в список
        public void AddStatus(Status status)
        {
            if (!ActiveStatuses.Contains(status) && !isInAnimation)
            {
                ActiveStatuses.Add(status);
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        // Удаление состояния из списка
        private void RemoveStatus(Status status)
        {
            if (ActiveStatuses.Contains(status))
            {
                ActiveStatuses.Remove(status);
                OnStatusesChanged?.Invoke(ActiveStatuses);
            }
        }

        // Обработка отложенных состояний после анимации
        private void ProcessPendingStatuses()
        {
            while (pendingStatuses.Count > 0)
            {
                var status = pendingStatuses.Dequeue();
                if (!ActiveStatuses.Contains(status))
                {
                    ActiveStatuses.Add(status);
                }
            }
            OnStatusesChanged?.Invoke(ActiveStatuses);
        }

        #region Методы действий

        public void Feed()
        {
            if (ActiveStatuses.Contains(Status.Hungry) && !isInAnimation)
            {
                isInAnimation = true;

                // Временно показываем анимацию еды
                var tempStatus = ActiveStatuses.ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Eat);
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var eatTimer = new Timer();
                eatTimer.Interval = eatAnimationTime;
                eatTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Eat);
                    RemoveStatus(Status.Hungry);
                    ResetTimer(hungerTimer);
                    eatTimer.Stop();

                    // Разблокируем и обрабатываем отложенные состояния
                    isInAnimation = false;
                    ProcessPendingStatuses();
                };
                eatTimer.Start();
            }
        }

        public void Clean()
        {
            if (ActiveStatuses.Contains(Status.Dirty) && !isInAnimation)
            {
                isInAnimation = true;

                var tempStatus = ActiveStatuses.ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Washes);
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var washTimer = new Timer();
                washTimer.Interval = washAnimationTime;
                washTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Washes);
                    RemoveStatus(Status.Dirty);
                    ResetTimer(dirtTimer);
                    washTimer.Stop();

                    isInAnimation = false;
                    ProcessPendingStatuses();
                };
                washTimer.Start();
            }
        }

        public void Sleep()
        {
            if (ActiveStatuses.Contains(Status.Sleepy) && !isInAnimation)
            {
                isInAnimation = true;

                var tempStatus = ActiveStatuses.ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Sleep);
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var sleepTimer = new Timer();
                sleepTimer.Interval = sleepAnimationTime;
                sleepTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Sleep);
                    RemoveStatus(Status.Sleepy);
                    ResetTimer(sleepyTimer);
                    sleepTimer.Stop();

                    isInAnimation = false;
                    ProcessPendingStatuses();
                };
                sleepTimer.Start();
            }
        }

        public void Heal()
        {
            if (ActiveStatuses.Contains(Status.Sick) && !isInAnimation)
            {
                isInAnimation = true;

                var tempStatus = ActiveStatuses.ToList();
                ActiveStatuses.Clear();
                ActiveStatuses.Add(Status.Treatment);
                OnStatusesChanged?.Invoke(ActiveStatuses);

                var treatmentTimer = new Timer();
                treatmentTimer.Interval = treatmentAnimationTime;
                treatmentTimer.Tick += (s, e) => {
                    RemoveStatus(Status.Treatment);
                    RemoveStatus(Status.Sick);
                    ResetTimer(sickTimer);
                    treatmentTimer.Stop();

                    isInAnimation = false;
                    ProcessPendingStatuses();
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

        // Получение приоритетного состояния для анимации
        public Status GetPriorityStatus()
        {
            if (ActiveStatuses.Contains(Status.Sick)) return Status.Sick;
            if (ActiveStatuses.Contains(Status.Hungry)) return Status.Hungry;
            if (ActiveStatuses.Contains(Status.Dirty)) return Status.Dirty;
            if (ActiveStatuses.Contains(Status.Sleepy)) return Status.Sleepy;
            if (ActiveStatuses.Contains(Status.Bored)) return Status.Bored;
            if (ActiveStatuses.Contains(Status.Eat)) return Status.Eat;
            if (ActiveStatuses.Contains(Status.Washes)) return Status.Washes;
            if (ActiveStatuses.Contains(Status.Sleep)) return Status.Sleep;
            if (ActiveStatuses.Contains(Status.Treatment)) return Status.Treatment;
            return Status.Normal;
        }

        public void SetSleepyFromNight()
        {
            if (!isInAnimation)
                AddStatus(Status.Sleepy);
            else
                pendingStatuses.Enqueue(Status.Sleepy);
        }
    }
}