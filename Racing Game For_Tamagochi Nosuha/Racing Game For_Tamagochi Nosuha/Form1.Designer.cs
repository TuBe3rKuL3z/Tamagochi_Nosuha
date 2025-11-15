namespace Racing_Game_For_Tamagochi_Nosuha
{
    partial class RacingGame
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnAgain = new System.Windows.Forms.Button();
            this.labelLose = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.EnemyCar2 = new System.Windows.Forms.PictureBox();
            this.EnemyCar1 = new System.Windows.Forms.PictureBox();
            this.PlayerCar = new System.Windows.Forms.PictureBox();
            this.RoadPictureBox = new System.Windows.Forms.PictureBox();
            this.RoadPictureBox2 = new System.Windows.Forms.PictureBox();
            this.Coin = new System.Windows.Forms.PictureBox();
            this.labelCoins = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Coin)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnAgain
            // 
            this.btnAgain.BackColor = System.Drawing.Color.LightCoral;
            this.btnAgain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgain.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAgain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgain.Location = new System.Drawing.Point(220, 442);
            this.btnAgain.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(333, 42);
            this.btnAgain.TabIndex = 5;
            this.btnAgain.Text = "Начать занаво";
            this.btnAgain.UseVisualStyleBackColor = false;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // labelLose
            // 
            this.labelLose.AutoSize = true;
            this.labelLose.BackColor = System.Drawing.Color.LightCoral;
            this.labelLose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelLose.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelLose.Location = new System.Drawing.Point(211, 268);
            this.labelLose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLose.Name = "labelLose";
            this.labelLose.Size = new System.Drawing.Size(337, 52);
            this.labelLose.TabIndex = 6;
            this.labelLose.Text = "Вы проиграли!";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightCoral;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(220, 393);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(333, 42);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Вернутся к Носухе";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // EnemyCar2
            // 
            this.EnemyCar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnemyCar2.BackgroundImage = global::Racing_Game_For_Tamagochi_Nosuha.Properties.Resources.Car_3;
            this.EnemyCar2.ErrorImage = null;
            this.EnemyCar2.Location = new System.Drawing.Point(561, -295);
            this.EnemyCar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyCar2.Name = "EnemyCar2";
            this.EnemyCar2.Size = new System.Drawing.Size(133, 160);
            this.EnemyCar2.TabIndex = 4;
            this.EnemyCar2.TabStop = false;
            this.EnemyCar2.WaitOnLoad = true;
            // 
            // EnemyCar1
            // 
            this.EnemyCar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnemyCar1.BackgroundImage = global::Racing_Game_For_Tamagochi_Nosuha.Properties.Resources.Car_3;
            this.EnemyCar1.ErrorImage = null;
            this.EnemyCar1.Location = new System.Drawing.Point(40, -160);
            this.EnemyCar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyCar1.Name = "EnemyCar1";
            this.EnemyCar1.Size = new System.Drawing.Size(133, 160);
            this.EnemyCar1.TabIndex = 3;
            this.EnemyCar1.TabStop = false;
            this.EnemyCar1.WaitOnLoad = true;
            // 
            // PlayerCar
            // 
            this.PlayerCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PlayerCar.BackgroundImage = global::Racing_Game_For_Tamagochi_Nosuha.Properties.Resources.Car_2;
            this.PlayerCar.ErrorImage = null;
            this.PlayerCar.Location = new System.Drawing.Point(397, 610);
            this.PlayerCar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerCar.Name = "PlayerCar";
            this.PlayerCar.Size = new System.Drawing.Size(133, 160);
            this.PlayerCar.TabIndex = 1;
            this.PlayerCar.TabStop = false;
            this.PlayerCar.WaitOnLoad = true;
            // 
            // RoadPictureBox
            // 
            this.RoadPictureBox.BackgroundImage = global::Racing_Game_For_Tamagochi_Nosuha.Properties.Resources.Doroga_2;
            this.RoadPictureBox.ErrorImage = null;
            this.RoadPictureBox.InitialImage = null;
            this.RoadPictureBox.Location = new System.Drawing.Point(1, 0);
            this.RoadPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoadPictureBox.Name = "RoadPictureBox";
            this.RoadPictureBox.Size = new System.Drawing.Size(757, 800);
            this.RoadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RoadPictureBox.TabIndex = 0;
            this.RoadPictureBox.TabStop = false;
            // 
            // RoadPictureBox2
            // 
            this.RoadPictureBox2.BackgroundImage = global::Racing_Game_For_Tamagochi_Nosuha.Properties.Resources.Doroga_2;
            this.RoadPictureBox2.InitialImage = null;
            this.RoadPictureBox2.Location = new System.Drawing.Point(0, -800);
            this.RoadPictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoadPictureBox2.Name = "RoadPictureBox2";
            this.RoadPictureBox2.Size = new System.Drawing.Size(757, 800);
            this.RoadPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RoadPictureBox2.TabIndex = 2;
            this.RoadPictureBox2.TabStop = false;
            // 
            // Coin
            // 
            this.Coin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Coin.Image = global::Racing_Game_For_Tamagochi_Nosuha.Properties.Resources.money;
            this.Coin.Location = new System.Drawing.Point(360, 170);
            this.Coin.Margin = new System.Windows.Forms.Padding(4);
            this.Coin.Name = "Coin";
            this.Coin.Size = new System.Drawing.Size(43, 39);
            this.Coin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Coin.TabIndex = 8;
            this.Coin.TabStop = false;
            // 
            // labelCoins
            // 
            this.labelCoins.AutoSize = true;
            this.labelCoins.BackColor = System.Drawing.Color.LightCoral;
            this.labelCoins.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelCoins.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCoins.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCoins.Location = new System.Drawing.Point(16, 11);
            this.labelCoins.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCoins.Name = "labelCoins";
            this.labelCoins.Size = new System.Drawing.Size(147, 31);
            this.labelCoins.TabIndex = 9;
            this.labelCoins.Text = "Монеты: 0";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.LightCoral;
            this.labelScore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelScore.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelScore.Location = new System.Drawing.Point(16, 54);
            this.labelScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(100, 31);
            this.labelScore.TabIndex = 10;
            this.labelScore.Text = "Счет: 0";
            // 
            // RacingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(757, 800);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelCoins);
            this.Controls.Add(this.Coin);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.labelLose);
            this.Controls.Add(this.btnAgain);
            this.Controls.Add(this.EnemyCar2);
            this.Controls.Add(this.EnemyCar1);
            this.Controls.Add(this.PlayerCar);
            this.Controls.Add(this.RoadPictureBox);
            this.Controls.Add(this.RoadPictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RacingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RacingGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RacingGame_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RacingGame_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RacingGame_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Coin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RoadPictureBox;
        private System.Windows.Forms.PictureBox PlayerCar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox RoadPictureBox2;
        private System.Windows.Forms.PictureBox EnemyCar1;
        private System.Windows.Forms.PictureBox EnemyCar2;
        private System.Windows.Forms.Button btnAgain;
        private System.Windows.Forms.Label labelLose;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox Coin;
        private System.Windows.Forms.Label labelCoins;
        private System.Windows.Forms.Label labelScore;
    }
}

