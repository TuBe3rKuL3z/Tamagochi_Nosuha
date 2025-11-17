using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tamagochi_Nosuha.Properties;

namespace AnimationTest2
{
    public class Animator
    {
        private Timer animationTimer;
        private PictureBox targetPictureBox;
        private List<Image> currentFrames;
        private int currentFrameIndex;

        public Animator(PictureBox pictureBox)
        {
            targetPictureBox = pictureBox;
            animationTimer = new Timer();
            animationTimer.Interval = 200;
            animationTimer.Tick += AnimateFrame;
        }

        public void PlayAnimation(string age, string status)
        {
            if (targetPictureBox == null)
            {
                MessageBox.Show("PictureBox не установлен!");
                return;
            }

            currentFrames = GetFramesForState(age, status);
            currentFrameIndex = 0;

            if (currentFrames != null && currentFrames.Count > 0)
            {
                targetPictureBox.Image = currentFrames[0];
                animationTimer.Start();
            }
            else
            {
                MessageBox.Show("Нет кадров для анимации!");
            }
        }

        private List<Image> GetFramesForState(string age, string status)
        {
            string stateKey = $"{age}_{status}";

            switch (stateKey)
            {
                case "baby_hungry":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.dead_2, Tamagochi_Nosuha.Properties.Resources.dead_2, Tamagochi_Nosuha.Properties.Resources.dead_2,  };
                case "baby_eat":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.nos_eat__2_, Tamagochi_Nosuha.Properties.Resources.nos_eat__3_, Tamagochi_Nosuha.Properties.Resources.nos_eat__1_, };

                case "baby_bored":
                     return new List<Image> { Tamagochi_Nosuha.Properties.Resources.dead_3, Tamagochi_Nosuha.Properties.Resources.dead_3, Tamagochi_Nosuha.Properties.Resources.dead_3 };
                
                case "baby_dirty":
                     return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__10_};
                case "baby_washes":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__10_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__11_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__12_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__13_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__14_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__15_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__16_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__17_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__18_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__19_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__20_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__21_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__22_ };
                
                case "baby_sleepy":
                     return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Ch1, Tamagochi_Nosuha.Properties.Resources.Ch2, Tamagochi_Nosuha.Properties.Resources.Ch3 };
                case "baby_sleep":
                    return new List<Image> { };


                case "baby_sick":
                     return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Ch1, Tamagochi_Nosuha.Properties.Resources.Ch2, Tamagochi_Nosuha.Properties.Resources.Ch3 };
                case "baby_treatment":
                    return new List<Image> { };

                case "baby_normal":
                     return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Ch1, Tamagochi_Nosuha.Properties.Resources.Ch2, Tamagochi_Nosuha.Properties.Resources.Ch3 };
                case "baby_happy":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Ch1, Tamagochi_Nosuha.Properties.Resources.Ch2, Tamagochi_Nosuha.Properties.Resources.Ch3 };

                /*// ADULT состояния
                case "adult_hungry":
                    return new List<Image> { Properties.Resources.adult_hungry_1, Properties.Resources.adult_hungry_2, Properties.Resources.adult_hungry_3 };
                case "adult_bored":
                    return new List<Image> { Properties.Resources.adult_bored_1, Properties.Resources.adult_bored_2, Properties.Resources.adult_bored_3 };
                case "adult_dirty":
                    return new List<Image> { Properties.Resources.adult_dirty_1, Properties.Resources.adult_dirty_2, Properties.Resources.adult_dirty_3 };
                case "adult_sleepy":
                    return new List<Image> { Properties.Resources.adult_sleepy_1, Properties.Resources.adult_sleepy_2, Properties.Resources.adult_sleepy_3 };
                case "adult_sick":
                    return new List<Image> { Properties.Resources.adult_sick_1, Properties.Resources.adult_sick_2, Properties.Resources.adult_sick_3 };
                case "adult_normal":
                    return new List<Image> { Properties.Resources.adult_normal_1, Properties.Resources.adult_normal_2, Properties.Resources.adult_normal_3 };
                case "adult_eat":
                            return new List<Image> { Resources.baby_eat_1, Resources.baby_eat_2, ... };
                case "adult_washes":
                            return new List<Image> { Resources.baby_washes_1, Resources.baby_washes_2, ... };
                case "adult_sleep":
                            return new List<Image> { Resources.baby_sleep_1, Resources.baby_sleep_2, ... };
                case "adult_treatment":
                            return new List<Image> { Resources.baby_treatment_1, ... };
                case "adult_happy":
                             return new List<Image> { Resources.baby_happy_1, ... };



                // OLD состояния
                case "old_hungry":
                    return new List<Image> { Properties.Resources.old_hungry_1, Properties.Resources.old_hungry_2, Properties.Resources.old_hungry_3 };
                case "old_bored":
                    return new List<Image> { Properties.Resources.old_bored_1, Properties.Resources.old_bored_2, Properties.Resources.old_bored_3 };
                case "old_dirty":
                    return new List<Image> { Properties.Resources.old_dirty_1, Properties.Resources.old_dirty_2, Properties.Resources.old_dirty_3 };
                case "old_sleepy":
                    return new List<Image> { Properties.Resources.old_sleepy_1, Properties.Resources.old_sleepy_2, Properties.Resources.old_sleepy_3 };
                case "old_sick":
                    return new List<Image> { Properties.Resources.old_sick_1, Properties.Resources.old_sick_2, Properties.Resources.old_sick_3 };
                case "old_normal":
                    return new List<Image> { Properties.Resources.old_normal_1, Properties.Resources.old_normal_2, Properties.Resources.old_normal_3 };
                case "old_eat":
                    return new List<Image> { Resources.baby_eat_1, Resources.baby_eat_2, ... };
                case "old_washes":
                    return new List<Image> { Resources.baby_washes_1, Resources.baby_washes_2, ... };
                case "old_sleep":
                    return new List<Image> { Resources.baby_sleep_1, Resources.baby_sleep_2, ... };
                case "old_treatment":
                    return new List<Image> { Resources.baby_treatment_1, ... };
                case "old_happy":
                    return new List<Image> { Resources.baby_happy_1, ... };*/

                case "dead_dead":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.dead_1, Tamagochi_Nosuha.Properties.Resources.dead_2, Tamagochi_Nosuha.Properties.Resources.dead_3 };

                default:
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Ch1, Tamagochi_Nosuha.Properties.Resources.Ch1, Tamagochi_Nosuha.Properties.Resources.Ch1 };
            }


        }

        private void AnimateFrame(object sender, EventArgs e)
        {
            if (currentFrames == null || currentFrames.Count == 0) return;

            currentFrameIndex = (currentFrameIndex + 1) % currentFrames.Count;
            targetPictureBox.Image = currentFrames[currentFrameIndex];
        }

        public void StopAnimation()
        {
            animationTimer.Stop();
        }
    }

}
