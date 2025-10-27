using System;
using System.Drawing;
using System.Windows.Forms;

namespace ОАиП_ПРН__7
{
    public partial class Form1 : Form
    {
        private TextBox txtX, txtY, txtWidth, txtHeight, txtText;
        private Button btnAddLabel;
        private Label lblInfo;
        private int smallLabels = 0;
        private int bigLabels = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            txtX = new TextBox();
            txtX.Location = new Point(10, 10);
            txtX.Size = new Size(50, 20);
            txtX.Text = "10";
            txtX.Parent = this;

            txtY = new TextBox();
            txtY.Location = new Point(70, 10);
            txtY.Size = new Size(50, 20);
            txtY.Text = "40";
            txtY.Parent = this;

            txtWidth = new TextBox();
            txtWidth.Location = new Point(130, 10);
            txtWidth.Size = new Size(50, 20);
            txtWidth.Text = "100";
            txtWidth.Parent = this;

            txtHeight = new TextBox();
            txtHeight.Location = new Point(190, 10);
            txtHeight.Size = new Size(50, 20);
            txtHeight.Text = "30";
            txtHeight.Parent = this;

            txtText = new TextBox();
            txtText.Location = new Point(250, 10);
            txtText.Size = new Size(100, 20);
            txtText.Text = "Метка";
            txtText.Parent = this;

            btnAddLabel = new Button();
            btnAddLabel.Location = new Point(360, 10);
            btnAddLabel.Size = new Size(100, 23);
            btnAddLabel.Text = "Добавить метку";
            btnAddLabel.Parent = this;
            btnAddLabel.Click += BtnAddLabel_Click;

            lblInfo = new Label();
            lblInfo.Location = new Point(10, 40);
            lblInfo.Size = new Size(300, 20);
            lblInfo.Text = "Введите параметры и нажмите кнопку";
            lblInfo.Parent = this;

            this.Size = new Size(500, 400);
        }

        private void BtnAddLabel_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtX.Text);
                int y = int.Parse(txtY.Text);
                int width = int.Parse(txtWidth.Text);
                int height = int.Parse(txtHeight.Text);
                string text = txtText.Text;

                Label newLabel = new Label();
                newLabel.Location = new Point(x, y);
                newLabel.Size = new Size(width, height);
                newLabel.Text = text;
                newLabel.BorderStyle = BorderStyle.FixedSingle;
                newLabel.Parent = this;

                if (width < 50 && height < 50)
                {
                    smallLabels++;
                }
                else
                {
                    bigLabels++;
                }
                UpdateWindowTitle();

                lblInfo.Text = $"Добавлена метка: {text} ({width}x{height})";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения!");
            }
        }

        private void UpdateWindowTitle()
        {
            this.Text = $"Маленьких меток: {smallLabels}, Больших меток: {bigLabels}";
        }


    }
}
