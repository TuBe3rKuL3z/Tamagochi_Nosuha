namespace Tamagochi_Nosuha
{
    partial class ChamberBackgroundForm
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
            this.btn_Pause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_BathroomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_BedroomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_GameRoomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_KitchenBackgroundForm = new System.Windows.Forms.Button();
            this.btn_MainBackgroundForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(12, 12);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(58, 45);
            this.btn_Pause.TabIndex = 6;
            this.btn_Pause.Text = "Пауза";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ChamberBackgroundForm";
            // 
            // btn_BathroomBackgroundForm
            // 
            this.btn_BathroomBackgroundForm.Location = new System.Drawing.Point(12, 408);
            this.btn_BathroomBackgroundForm.Name = "btn_BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_BathroomBackgroundForm.TabIndex = 13;
            this.btn_BathroomBackgroundForm.Text = "BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_BathroomBackgroundForm.Click += new System.EventHandler(this.btn_BathroomBackgroundForm_Click);
            // 
            // btn_BedroomBackgroundForm
            // 
            this.btn_BedroomBackgroundForm.Location = new System.Drawing.Point(12, 372);
            this.btn_BedroomBackgroundForm.Name = "btn_BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_BedroomBackgroundForm.TabIndex = 12;
            this.btn_BedroomBackgroundForm.Text = "BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_BedroomBackgroundForm.Click += new System.EventHandler(this.btn_BedroomBackgroundForm_Click);
            // 
            // btn_GameRoomBackgroundForm
            // 
            this.btn_GameRoomBackgroundForm.Location = new System.Drawing.Point(12, 336);
            this.btn_GameRoomBackgroundForm.Name = "btn_GameRoomBackgroundForm";
            this.btn_GameRoomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_GameRoomBackgroundForm.TabIndex = 10;
            this.btn_GameRoomBackgroundForm.Text = "GameRoomBackgroundForm";
            this.btn_GameRoomBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_GameRoomBackgroundForm.Click += new System.EventHandler(this.btn_GameRoomBackgroundForm_Click);
            // 
            // btn_KitchenBackgroundForm
            // 
            this.btn_KitchenBackgroundForm.Location = new System.Drawing.Point(12, 300);
            this.btn_KitchenBackgroundForm.Name = "btn_KitchenBackgroundForm";
            this.btn_KitchenBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_KitchenBackgroundForm.TabIndex = 9;
            this.btn_KitchenBackgroundForm.Text = "KitchenBackgroundForm";
            this.btn_KitchenBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_KitchenBackgroundForm.Click += new System.EventHandler(this.btn_KitchenBackgroundForm_Click);
            // 
            // btn_MainBackgroundForm
            // 
            this.btn_MainBackgroundForm.Location = new System.Drawing.Point(12, 264);
            this.btn_MainBackgroundForm.Name = "btn_MainBackgroundForm";
            this.btn_MainBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_MainBackgroundForm.TabIndex = 8;
            this.btn_MainBackgroundForm.Text = "MainBackgroundForm";
            this.btn_MainBackgroundForm.UseVisualStyleBackColor = true;
            this.btn_MainBackgroundForm.Click += new System.EventHandler(this.btn_MainBackgroundForm_Click);
            // 
            // ChamberBackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_BathroomBackgroundForm);
            this.Controls.Add(this.btn_BedroomBackgroundForm);
            this.Controls.Add(this.btn_GameRoomBackgroundForm);
            this.Controls.Add(this.btn_KitchenBackgroundForm);
            this.Controls.Add(this.btn_MainBackgroundForm);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChamberBackgroundForm";
            this.Text = "ChamberBackgroundForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_BathroomBackgroundForm;
        private System.Windows.Forms.Button btn_BedroomBackgroundForm;
        private System.Windows.Forms.Button btn_GameRoomBackgroundForm;
        private System.Windows.Forms.Button btn_KitchenBackgroundForm;
        private System.Windows.Forms.Button btn_MainBackgroundForm;
    }
}