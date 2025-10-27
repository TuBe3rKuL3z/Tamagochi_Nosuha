using System;
using System.Drawing;
using System.Windows.Forms;

namespace ОАиП_ПРН__7_Б_
{
    public partial class Form1 : Form
    {
        private Button btnAddLabel, btnAddTextBox, btnEnlargeLabels, btnShrinkTextboxes;
        private Panel controlPanel;
        private int controlCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            controlPanel = new Panel();
            controlPanel.Location = new Point(10, 50);
            controlPanel.Size = new Size(450, 300);
            controlPanel.BackColor = Color.LightBlue;
            controlPanel.AutoScroll = true;
            controlPanel.BorderStyle = BorderStyle.FixedSingle;
            controlPanel.Parent = this;

            btnAddLabel = new Button();
            btnAddLabel.Location = new Point(10, 10);
            btnAddLabel.Size = new Size(100, 30);
            btnAddLabel.Text = "Добавить метку";
            btnAddLabel.Parent = this;
            btnAddLabel.Click += BtnAddLabel_Click;

            btnAddTextBox = new Button();
            btnAddTextBox.Location = new Point(120, 10);
            btnAddTextBox.Size = new Size(100, 30);
            btnAddTextBox.Text = "Добавить поле";
            btnAddTextBox.Parent = this;
            btnAddTextBox.Click += BtnAddTextBox_Click;

            btnEnlargeLabels = new Button();
            btnEnlargeLabels.Location = new Point(230, 10);
            btnEnlargeLabels.Size = new Size(120, 30);
            btnEnlargeLabels.Text = "Увеличить метки";
            btnEnlargeLabels.Parent = this;
            btnEnlargeLabels.Click += BtnEnlargeLabels_Click;

            btnShrinkTextboxes = new Button();
            btnShrinkTextboxes.Location = new Point(360, 10);
            btnShrinkTextboxes.Size = new Size(120, 30);
            btnShrinkTextboxes.Text = "Уменьшить поля";
            btnShrinkTextboxes.Parent = this;
            btnShrinkTextboxes.Click += BtnShrinkTextboxes_Click;

            this.Size = new Size(500, 400);
            this.Text = "Динамическое создание элементов управления";
        }

        private void BtnAddLabel_Click(object sender, EventArgs e)
        {
            controlCount++;

            // Создаем новую метку
            Label newLabel = new Label();
            newLabel.Location = new Point(10, 10 + (controlCount - 1) * 30);
            newLabel.Size = new Size(150, 20);
            newLabel.Text = $"Метка {controlCount}";
            newLabel.BorderStyle = BorderStyle.FixedSingle;
            newLabel.BackColor = Color.White;
            newLabel.Parent = controlPanel;
        }

        private void BtnAddTextBox_Click(object sender, EventArgs e)
        {
            controlCount++;

            TextBox newTextBox = new TextBox();
            newTextBox.Location = new Point(170, 10 + (controlCount - 1) * 30);
            newTextBox.Size = new Size(150, 40);
            newTextBox.Text = $"Поле ввода {controlCount}";
            newTextBox.Parent = controlPanel;
        }

        private void BtnEnlargeLabels_Click(object sender, EventArgs e)
        {
            foreach (Control control in controlPanel.Controls)
            {
                //Является ли меткой
                if (control is Label)
                {
                    //Увеличиваем 2 раза
                    control.Size = new Size(control.Width * 2, control.Height);
                }
            }
        }

        private void BtnShrinkTextboxes_Click(object sender, EventArgs e)
        {
            foreach (Control control in controlPanel.Controls)
            {
                //Является ли текст боксом
                if (control is TextBox)
                {
                    //Уменьшаем в 2 раза (но не меньше 10 пикселей)
                    int newHeight = Math.Max(control.Height / 2, 10);
                    control.Size = new Size(control.Width, newHeight);
                }
            }
        }
    }
}
