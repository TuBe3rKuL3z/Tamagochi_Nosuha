namespace Tamagochi_Nosuha
{
    partial class MainBackgroundForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.btn_KitchenBackgroundForm = new System.Windows.Forms.Button();
            this.btn_GameRoomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_BathroomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_BedroomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_ChamberBackgroundForm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblGameTime = new System.Windows.Forms.Label();
            this.lblGameDay = new System.Windows.Forms.Label();
            this.btnFeed = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSleep = new System.Windows.Forms.Button();
            this.btnTreatment = new System.Windows.Forms.Button();
            this.btn_MainBackgroundForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MainBackgroundForm";
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(13, 13);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(58, 45);
            this.btn_Pause.TabIndex = 1;
            this.btn_Pause.Text = "Пауза";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_KitchenBackgroundForm
            // 
            this.btn_KitchenBackgroundForm.Location = new System.Drawing.Point(12, 117);
            this.btn_KitchenBackgroundForm.Name = "btn_KitchenBackgroundForm";
            this.btn_KitchenBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_KitchenBackgroundForm.TabIndex = 3;
            this.btn_KitchenBackgroundForm.Text = "KitchenBackgroundForm";
            this.btn_KitchenBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_KitchenBackgroundForm.Click += new System.EventHandler(this.btn_KitchenBackgroundForm_Click);
            // 
            // btn_GameRoomBackgroundForm
            // 
            this.btn_GameRoomBackgroundForm.Location = new System.Drawing.Point(12, 153);
            this.btn_GameRoomBackgroundForm.Name = "btn_GameRoomBackgroundForm";
            this.btn_GameRoomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_GameRoomBackgroundForm.TabIndex = 4;
            this.btn_GameRoomBackgroundForm.Text = "GameRoomBackgroundForm";
            this.btn_GameRoomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_GameRoomBackgroundForm.Click += new System.EventHandler(this.btn_GameRoomBackgroundForm_Click);
            // 
            // btn_BathroomBackgroundForm
            // 
            this.btn_BathroomBackgroundForm.Location = new System.Drawing.Point(13, 261);
            this.btn_BathroomBackgroundForm.Name = "btn_BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_BathroomBackgroundForm.TabIndex = 7;
            this.btn_BathroomBackgroundForm.Text = "BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_BathroomBackgroundForm.Click += new System.EventHandler(this.btn_BathroomBackgroundForm_Click);
            // 
            // btn_BedroomBackgroundForm
            // 
            this.btn_BedroomBackgroundForm.Location = new System.Drawing.Point(13, 225);
            this.btn_BedroomBackgroundForm.Name = "btn_BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_BedroomBackgroundForm.TabIndex = 6;
            this.btn_BedroomBackgroundForm.Text = "BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_BedroomBackgroundForm.Click += new System.EventHandler(this.btn_BedroomBackgroundForm_Click);
            // 
            // btn_ChamberBackgroundForm
            // 
            this.btn_ChamberBackgroundForm.Location = new System.Drawing.Point(13, 189);
            this.btn_ChamberBackgroundForm.Name = "btn_ChamberBackgroundForm";
            this.btn_ChamberBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_ChamberBackgroundForm.TabIndex = 5;
            this.btn_ChamberBackgroundForm.Text = "ChamberBackgroundForm";
            this.btn_ChamberBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_ChamberBackgroundForm.Click += new System.EventHandler(this.btn_ChamberBackgroundForm_Click);
            // 
            // lblGameTime
            // 
            this.lblGameTime.AutoSize = true;
            this.lblGameTime.Location = new System.Drawing.Point(624, 44);
            this.lblGameTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameTime.Name = "lblGameTime";
            this.lblGameTime.Size = new System.Drawing.Size(10, 13);
            this.lblGameTime.TabIndex = 9;
            this.lblGameTime.Text = " ";
            // 
            // lblGameDay
            // 
            this.lblGameDay.AutoSize = true;
            this.lblGameDay.Location = new System.Drawing.Point(624, 72);
            this.lblGameDay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameDay.Name = "lblGameDay";
            this.lblGameDay.Size = new System.Drawing.Size(10, 13);
            this.lblGameDay.TabIndex = 10;
            this.lblGameDay.Text = " ";
            // 
            // btnFeed
            // 
            this.btnFeed.Location = new System.Drawing.Point(58, 343);
            this.btnFeed.Margin = new System.Windows.Forms.Padding(2);
            this.btnFeed.Name = "btnFeed";
            this.btnFeed.Size = new System.Drawing.Size(128, 22);
            this.btnFeed.TabIndex = 11;
            this.btnFeed.Text = "Покормить";
            this.btnFeed.UseVisualStyleBackColor = true;
            this.btnFeed.Click += new System.EventHandler(this.btnFeed_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(587, 343);
            this.btnClean.Margin = new System.Windows.Forms.Padding(2);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(128, 22);
            this.btnClean.TabIndex = 12;
            this.btnClean.Text = "Помыть";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(190, 343);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(128, 22);
            this.btnPlay.TabIndex = 13;
            this.btnPlay.Text = "Поиграть";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(304, 92);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnSleep
            // 
            this.btnSleep.Location = new System.Drawing.Point(455, 343);
            this.btnSleep.Margin = new System.Windows.Forms.Padding(2);
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.Size = new System.Drawing.Size(128, 22);
            this.btnSleep.TabIndex = 16;
            this.btnSleep.Text = "Спать";
            this.btnSleep.UseVisualStyleBackColor = true;
            // 
            // btnTreatment
            // 
            this.btnTreatment.Location = new System.Drawing.Point(323, 343);
            this.btnTreatment.Margin = new System.Windows.Forms.Padding(2);
            this.btnTreatment.Name = "btnTreatment";
            this.btnTreatment.Size = new System.Drawing.Size(128, 22);
            this.btnTreatment.TabIndex = 15;
            this.btnTreatment.Text = "Вылечить";
            this.btnTreatment.UseVisualStyleBackColor = true;
            // 
            // btn_MainBackgroundForm
            // 
            this.btn_MainBackgroundForm.Location = new System.Drawing.Point(13, 81);
            this.btn_MainBackgroundForm.Name = "btn_MainBackgroundForm";
            this.btn_MainBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_MainBackgroundForm.TabIndex = 17;
            this.btn_MainBackgroundForm.Text = "MainBackgroundForm";
            this.btn_MainBackgroundForm.UseVisualStyleBackColor = true;
            // 
            // MainBackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_MainBackgroundForm);
            this.Controls.Add(this.btnSleep);
            this.Controls.Add(this.btnTreatment);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnFeed);
            this.Controls.Add(this.lblGameDay);
            this.Controls.Add(this.lblGameTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_BathroomBackgroundForm);
            this.Controls.Add(this.btn_BedroomBackgroundForm);
            this.Controls.Add(this.btn_ChamberBackgroundForm);
            this.Controls.Add(this.btn_GameRoomBackgroundForm);
            this.Controls.Add(this.btn_KitchenBackgroundForm);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainBackgroundForm";
            this.Text = "MainBackgroundForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Button btn_KitchenBackgroundForm;
        private System.Windows.Forms.Button btn_GameRoomBackgroundForm;
        private System.Windows.Forms.Button btn_BathroomBackgroundForm;
        private System.Windows.Forms.Button btn_BedroomBackgroundForm;
        private System.Windows.Forms.Button btn_ChamberBackgroundForm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGameTime;
        private System.Windows.Forms.Label lblGameDay;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSleep;
        private System.Windows.Forms.Button btnTreatment;
        private System.Windows.Forms.Button btn_MainBackgroundForm;
    }
}