﻿namespace Recipe_13_01
{
    partial class Form1
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
            this.btnOpenModeless = new System.Windows.Forms.Button();
            this.btnOpenModal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenModeless
            // 
            this.btnOpenModeless.Location = new System.Drawing.Point(12, 38);
            this.btnOpenModeless.Name = "btnOpenModeless";
            this.btnOpenModeless.Size = new System.Drawing.Size(177, 33);
            this.btnOpenModeless.TabIndex = 0;
            this.btnOpenModeless.Text = "Open Modeless Window";
            this.btnOpenModeless.UseVisualStyleBackColor = true;
            this.btnOpenModeless.Click += new System.EventHandler(this.OpenModeless_Click);
            // 
            // btnOpenModal
            // 
            this.btnOpenModal.Location = new System.Drawing.Point(207, 38);
            this.btnOpenModal.Name = "btnOpenModal";
            this.btnOpenModal.Size = new System.Drawing.Size(150, 33);
            this.btnOpenModal.TabIndex = 1;
            this.btnOpenModal.Text = "Open Modal Window";
            this.btnOpenModal.UseVisualStyleBackColor = true;
            this.btnOpenModal.Click += new System.EventHandler(this.OpenModal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 116);
            this.Controls.Add(this.btnOpenModal);
            this.Controls.Add(this.btnOpenModeless);
            this.Name = "Form1";
            this.Text = "WPF Recipes 13_01";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenModeless;
        private System.Windows.Forms.Button btnOpenModal;
    }
}

