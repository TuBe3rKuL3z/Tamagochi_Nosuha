namespace Tamagochi_Nosuha
{
    partial class GameRoomBackgroundForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_BathroomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_BedroomBackgroundForm = new System.Windows.Forms.Button();
            this.btn_ChamberBackgroundForm = new System.Windows.Forms.Button();
            this.btn_KitchenBackgroundForm = new System.Windows.Forms.Button();
            this.btn_MainBackgroundForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(12, 12);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(58, 45);
            this.btn_Pause.TabIndex = 3;
            this.btn_Pause.Text = "Пауза";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "GameRoomBackgroundForm";
            // 
            // btn_BathroomBackgroundForm
            // 
            this.btn_BathroomBackgroundForm.Location = new System.Drawing.Point(12, 408);
            this.btn_BathroomBackgroundForm.Name = "btn_BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_BathroomBackgroundForm.TabIndex = 13;
            this.btn_BathroomBackgroundForm.Text = "BathroomBackgroundForm";
            this.btn_BathroomBackgroundForm.UseVisualStyleBackColor = true;
            // 
            // btn_BedroomBackgroundForm
            // 
            this.btn_BedroomBackgroundForm.Location = new System.Drawing.Point(12, 372);
            this.btn_BedroomBackgroundForm.Name = "btn_BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_BedroomBackgroundForm.TabIndex = 12;
            this.btn_BedroomBackgroundForm.Text = "BedroomBackgroundForm";
            this.btn_BedroomBackgroundForm.UseVisualStyleBackColor = true;
            // 
            // btn_ChamberBackgroundForm
            // 
            this.btn_ChamberBackgroundForm.Location = new System.Drawing.Point(12, 336);
            this.btn_ChamberBackgroundForm.Name = "btn_ChamberBackgroundForm";
            this.btn_ChamberBackgroundForm.Size = new System.Drawing.Size(163, 30);
            this.btn_ChamberBackgroundForm.TabIndex = 11;
            this.btn_ChamberBackgroundForm.Text = "ChamberBackgroundForm";
            this.btn_ChamberBackgroundForm.UseVisualStyleBackColor = true;
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
            // GameRoomBackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_BathroomBackgroundForm);
            this.Controls.Add(this.btn_BedroomBackgroundForm);
            this.Controls.Add(this.btn_ChamberBackgroundForm);
            this.Controls.Add(this.btn_KitchenBackgroundForm);
            this.Controls.Add(this.btn_MainBackgroundForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Pause);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameRoomBackgroundForm";
            this.Text = "GameRoomBackgroundForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_BathroomBackgroundForm;
        private System.Windows.Forms.Button btn_BedroomBackgroundForm;
        private System.Windows.Forms.Button btn_ChamberBackgroundForm;
        private System.Windows.Forms.Button btn_KitchenBackgroundForm;
        private System.Windows.Forms.Button btn_MainBackgroundForm;
    }
}