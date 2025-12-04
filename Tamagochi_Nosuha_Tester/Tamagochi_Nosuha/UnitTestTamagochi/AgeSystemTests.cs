using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Tamagochi_Nosuha;

namespace UnitTestTamagochi
{
    [TestClass]
    public class AgeSystemTests
    {
        //Проверяет начальный возраст Носухи ребенка и что прогресс 0
        [TestMethod] 
        public void AgeSystem_InitialState_ReturnBaby()
        {
            var ageSystem = new AgeSystem();

            Assert.AreEqual(AgeSystem.Age.Baby, ageSystem.CurrentAge);
            Assert.AreEqual(0, ageSystem.Progress);
        }

        //Проверяет увеличение прогресса
        [TestMethod]
        public void AddProgress_ShouldIncreaseProgress_Return5()
        {
            var ageSystem = new AgeSystem();

            ageSystem.AddProgress(5);

            Assert.AreEqual(5, ageSystem.Progress);
        }

        //Проверяет увеличение прогресса
        [TestMethod] 
        public void AddProgress_ShouldIncreaseProgress()
        {
            var ageSystem = new AgeSystem();

            ageSystem.AddProgress(3);

            Assert.AreEqual(3, ageSystem.Progress);
        }

        //Проверяет переход во взрослый возраст при максимальном прогрессе
        [TestMethod]
        public void AgeSystem_AddProgressToMax_ShouldChangeAgeToAdult()
        {
            var ageSystem = new AgeSystem();
            bool ageChangedEventFired = false;
            ageSystem.OnAgeChanged += (age) => ageChangedEventFired = true;

            for (int i = 0; i < ageSystem.MaxProgress; i++)
            {
                ageSystem.AddProgress();
            }

            Assert.AreEqual(AgeSystem.Age.Adult, ageSystem.CurrentAge);
            Assert.AreEqual(0, ageSystem.Progress);
            Assert.IsTrue(ageChangedEventFired);
        }

        //Проверяет установку смерти
        [TestMethod]
        public void AgeSystem_SetDead_ShouldSetDeadStatus()
        {
            var ageSystem = new AgeSystem();

            ageSystem.SetDead();

            Assert.AreEqual(AgeSystem.Age.Dead, ageSystem.CurrentAge);
        }


        //Проверяет что мертвый не получает прогресс
        [TestMethod]
        public void AgeSystem_AddProgressWhenDead_ShouldNotIncreaseProgress()
        {
            var ageSystem = new AgeSystem();
            ageSystem.SetDead();

            ageSystem.AddProgress(5);

            Assert.AreEqual(0, ageSystem.Progress);
        }
    }
    [TestClass]
    public class NeedSystemTests
    {
        //Проверяет начальный нормальный статус
        [TestMethod]
        public void NeedSystem_InitialState_ShouldHaveNoActiveStatuses()
        {
            var needSystem = new NeedSystem();


            Assert.AreEqual(0, needSystem.ActiveStatuses.Count);
            Assert.AreEqual(NeedSystem.Status.Normal, needSystem.GetPriorityStatus());
        }

        //Проверяет что кормление убирает голод
        [TestMethod]
        public void NeedSystem_AddProgress_ReturnFeedStatus()
        {
            var needSystem = new NeedSystem();

            needSystem.AddStatus(NeedSystem.Status.Hungry);
            needSystem.Feed();

            Thread.Sleep(2800);

            Assert.IsFalse(needSystem.ActiveStatuses.Contains(NeedSystem.Status.Normal));

        }
        //Проверяет что сон убирает сонливость
        [TestMethod]
        public void NeedSystem_AddProgress_ReturnSleepStatus()
        {
            var needSystem = new NeedSystem();

            needSystem.AddStatus(NeedSystem.Status.Sleepy);
            needSystem.Sleep();

            Thread.Sleep(5000);

            Assert.IsFalse(needSystem.ActiveStatuses.Contains(NeedSystem.Status.Normal));

        }
        //Проверяет что мытье убирает грязь
        [TestMethod]
        public void NeedSystem_AddProgress_ReturnWashStatus()
        {
            var needSystem = new NeedSystem();

            needSystem.AddStatus(NeedSystem.Status.Dirty);
            needSystem.Clean();

            Thread.Sleep(4400);

            Assert.IsFalse(needSystem.ActiveStatuses.Contains(NeedSystem.Status.Normal));

        }
        //Проверяет что мытье убирает грязь
        [TestMethod]
        public void NeedSystem_AddProgress_ReturnThreamentStatus()
        {
            var needSystem = new NeedSystem();

            needSystem.AddStatus(NeedSystem.Status.Bored);
            needSystem.Heal();

            Thread.Sleep(3500);

            Assert.IsFalse(needSystem.ActiveStatuses.Contains(NeedSystem.Status.Normal));

        }
    }
}
