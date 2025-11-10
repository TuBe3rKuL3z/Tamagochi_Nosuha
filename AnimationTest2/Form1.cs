using System;
using System.Windows.Forms;

namespace AnimationTest2
{
    public partial class Form1 : Form
    {
        private Animator animator;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            if (pictureBox1 != null)
            {
                animator = new Animator(pictureBox1);
            }
            else
            {
                MessageBox.Show("PictureBox1 не найден!");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            animator.PlayAnimation("baby", "hungry");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            animator.PlayAnimation("baby", "hungry");
        }
    }
}
