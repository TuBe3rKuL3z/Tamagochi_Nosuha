using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
                    return new List<Image> { Properties.Resources.Ch1, Properties.Resources.Ch2, Properties.Resources.Ch3 };
               /* case "baby_bored":
                    return new List<Image> { Properties.Resources.baby_bored_1, Properties.Resources.baby_bored_2, Properties.Resources.baby_bored_3 };
                case "baby_dirty":
                    return new List<Image> { Properties.Resources.baby_dirty_1, Properties.Resources.baby_dirty_2, Properties.Resources.baby_dirty_3 };
                case "baby_sleepy":
                    return new List<Image> { Properties.Resources.baby_sleepy_1, Properties.Resources.baby_sleepy_2, Properties.Resources.baby_sleepy_3 };
                case "baby_sick":
                    return new List<Image> { Properties.Resources.baby_sick_1, Properties.Resources.baby_sick_2, Properties.Resources.baby_sick_3 };
                case "baby_normal":
                    return new List<Image> { Properties.Resources.baby_normal_1, Properties.Resources.baby_normal_2, Properties.Resources.baby_normal_3 };

                // TEEN состояния
                case "teen_hungry":
                    return new List<Image> { Properties.Resources.teen_hungry_1, Properties.Resources.teen_hungry_2, Properties.Resources.teen_hungry_3 };
                case "teen_bored":
                    return new List<Image> { Properties.Resources.teen_bored_1, Properties.Resources.teen_bored_2, Properties.Resources.teen_bored_3 };
                case "teen_dirty":
                    return new List<Image> { Properties.Resources.teen_dirty_1, Properties.Resources.teen_dirty_2, Properties.Resources.teen_dirty_3 };
                case "teen_sleepy":
                    return new List<Image> { Properties.Resources.teen_sleepy_1, Properties.Resources.teen_sleepy_2, Properties.Resources.teen_sleepy_3 };
                case "teen_sick":
                    return new List<Image> { Properties.Resources.teen_sick_1, Properties.Resources.teen_sick_2, Properties.Resources.teen_sick_3 };
                case "teen_normal":
                    return new List<Image> { Properties.Resources.teen_normal_1, Properties.Resources.teen_normal_2, Properties.Resources.teen_normal_3 };

                // ADULT состояния
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
                    return new List<Image> { Properties.Resources.old_normal_1, Properties.Resources.old_normal_2, Properties.Resources.old_normal_3 };*/

                case "dead_dead":
                    return new List<Image> { Properties.Resources.dead_1, Properties.Resources.dead_2, Properties.Resources.dead_3 };

                default:
                    return new List<Image> { Properties.Resources.Ch1, Properties.Resources.Ch1, Properties.Resources.Ch1 };
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
