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
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__9_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Hungry__11_ };
                case "baby_eat":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__8_ };
                case "baby_dirty":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Dirty__9_ };
                case "baby_washes":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__9_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__11_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__12_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__13_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__14_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__15_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__16_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__17_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__18_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Washes__19_ };

                case "baby_sleepy":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleepy__9_ };
                case "baby_sleep":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__9_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__15_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__15_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__15_,
                                                Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__16_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__17_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__18_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sleep__19_,  };

                case "baby_sick":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__9_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__11_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Sick__12_ };
                case "baby_treatment":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha_Eat__8_ };

                case "baby_normal":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__1_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__2_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__3_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__4_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__5_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__6_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__7_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__8_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__9_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__10_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__11_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__12_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__13_, Tamagochi_Nosuha.Properties.Resources.Baby_Nosuha__14_ };
                case "baby_bored":
                     return new List<Image> {  };
                case "baby_happy":
                    return new List<Image> {  };

                // ADULT состояния ------------------------------------------------------------------------------------------
                case "adult_hungry":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Hungry__10_};
                case "adult_eat":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__7_ };
                
                
                case "adult_dirty":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Dirty__10_ };
                case "adult_washes":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__10_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__11_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__12_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__13_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__14_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__15_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__16_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__17_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__18_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__19_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__20_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__21_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Washes__22_ };


                case "adult_sleepy":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleepy__10_ };
                case "adult_sleep":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__15_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__15_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sleep__15_ };


                case "adult_sick":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Sick__10_ };
                case "adult_treatment":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha_Eat__7_ };


                case "adult_normal":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__1_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__2_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__3_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__4_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__5_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__6_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__7_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__8_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__9_, Tamagochi_Nosuha.Properties.Resources.Standart_Nosuha__10_ };

                //case "adult_bored":
                //    return new List<Image> { Properties.Resources.adult_bored_1, Properties.Resources.adult_bored_2, Properties.Resources.adult_bored_3 };
                //case "adult_happy":
                //return new List<Image> { Resources.baby_happy_1, ... };



                // OLD состояния -------------------------------------------------------------------------------------------------
                case "old_hungry":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Hungry__10_ };
                case "old_eat":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__7_ };

                case "old_dirty":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Dirty__10_ };
                case "old_washes":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__10_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__11_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__12_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__13_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__14_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__15_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__16_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__17_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__18_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__19_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__20_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__21_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Washes__22_ };

                case "old_sleepy":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleepy__10_ };
                case "old_sleep":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__15_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__15_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__10_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__11_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__12_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__13_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__14_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sleep__15_ };

                case "old_sick":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Sick__10_ };
                case "old_treatment":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha_Eat__7_ };

                case "old_normal":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__1_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__2_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__3_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__4_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__5_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__6_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__7_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__8_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__9_, Tamagochi_Nosuha.Properties.Resources.Old_Nosuha__10_ };
                
                case "old_bored":
                    return new List<Image> { };
                case "old_happy":
                    return new List<Image> { };

                case "dead_dead":
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Grave__1_, Tamagochi_Nosuha.Properties.Resources.Grave__2_, Tamagochi_Nosuha.Properties.Resources.Grave__3_, Tamagochi_Nosuha.Properties.Resources.Grave__4_, Tamagochi_Nosuha.Properties.Resources.Grave__5_, Tamagochi_Nosuha.Properties.Resources.Grave__6_ };

                default:
                    return new List<Image> { Tamagochi_Nosuha.Properties.Resources.Grave__1_, Tamagochi_Nosuha.Properties.Resources.Grave__2_, Tamagochi_Nosuha.Properties.Resources.Grave__3_, Tamagochi_Nosuha.Properties.Resources.Grave__4_, Tamagochi_Nosuha.Properties.Resources.Grave__5_, Tamagochi_Nosuha.Properties.Resources.Grave__6_ };
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
