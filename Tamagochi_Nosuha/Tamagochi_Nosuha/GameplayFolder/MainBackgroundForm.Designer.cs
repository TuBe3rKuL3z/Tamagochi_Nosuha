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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "MainBackgroundForm";
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(17, 16);
            this.btn_Pause.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(77, 55);
            this.btn_Pause.TabIndex = 1;
            this.btn_Pause.Text = "Пауза";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_KitchenBackgroundForm
            // 
            this.btn_KitchenBackgroundForm.Location = new System.Drawing.Point(16, 327);
            this.btn_KitchenBackgroundForm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_KitchenBackgroundForm.Name = "btn_KitchenBackgroundForm";
            this.btn_KitchenBackgroundForm.Size = new System.Drawing.Size(217, 37);
            this.btn_KitchenBackgroundForm.TabIndex = 3;
            this.btn_KitchenBackgroundForm.Text = "KitchenBackgroundForm";
            this.btn_KitchenBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_KitchenBackgroundForm.Click += new System.EventHandler(this.btn_KitchenBackgroundForm_Click);
            // 
            // btn_GameRoomBackgroundForm
            // 
            this.btn_GameRoomBackgroundForm.Location = new System.Drawing.Point(16, 372);
            this.btn_GameRoomBackgroundForm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GameRoomBackgroundForm.Name = "btn_GameRoomBackgroundForm";
            this.btn_GameRoomBackgroundForm.Size = new System.Drawing.Size(217, 37);
            this.btn_GameRoomBackgroundForm.TabIndex = 4;
            this.btn_GameRoomBackgroundForm.Text = "GameRoomBackgroundForm";
            this.btn_GameRoomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_GameRoomBackgroundForm.Click += new System.EventHandler(this.btn_GameRoomBackgroundForm_Click);
            // 
            // btn_BathroomBackgroundForm
            // 
            this.btn_BathroomBackgroundForm.Location = new System.Drawing.Point(17, 505);
            this.btn_BathroomBackgroundForm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BathroomBackgroundForm.Name = "btn_BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.Size = new System.Drawing.Size(217, 37);
            this.btn_BathroomBackgroundForm.TabIndex = 7;
            this.btn_BathroomBackgroundForm.Text = "BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_BathroomBackgroundForm.Click += new System.EventHandler(this.btn_BathroomBackgroundForm_Click);
            // 
            // btn_BedroomBackgroundForm
            // 
            this.btn_BedroomBackgroundForm.Location = new System.Drawing.Point(17, 460);
            this.btn_BedroomBackgroundForm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BedroomBackgroundForm.Name = "btn_BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.Size = new System.Drawing.Size(217, 37);
            this.btn_BedroomBackgroundForm.TabIndex = 6;
            this.btn_BedroomBackgroundForm.Text = "BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_BedroomBackgroundForm.Click += new System.EventHandler(this.btn_BedroomBackgroundForm_Click);
            // 
            // btn_ChamberBackgroundForm
            // 
            this.btn_ChamberBackgroundForm.Location = new System.Drawing.Point(17, 416);
            this.btn_ChamberBackgroundForm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ChamberBackgroundForm.Name = "btn_ChamberBackgroundForm";
            this.btn_ChamberBackgroundForm.Size = new System.Drawing.Size(217, 37);
            this.btn_ChamberBackgroundForm.TabIndex = 5;
            this.btn_ChamberBackgroundForm.Text = "ChamberBackgroundForm";
            this.btn_ChamberBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_ChamberBackgroundForm.Click += new System.EventHandler(this.btn_ChamberBackgroundForm_Click);
            // 
            // timer1
            // 
            // 
            // MainBackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btn_BathroomBackgroundForm);
            this.Controls.Add(this.btn_BedroomBackgroundForm);
            this.Controls.Add(this.btn_ChamberBackgroundForm);
            this.Controls.Add(this.btn_GameRoomBackgroundForm);
            this.Controls.Add(this.btn_KitchenBackgroundForm);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainBackgroundForm";
            this.Text = "MainBackgroundForm";
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
    }
}