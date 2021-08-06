
namespace finger_biometrics_suprema
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCapture = new System.Windows.Forms.Button();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.pictureBoxFinger = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(449, 321);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(75, 23);
            this.buttonCapture.TabIndex = 0;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Location = new System.Drawing.Point(12, 376);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxLogs.Size = new System.Drawing.Size(539, 169);
            this.textBoxLogs.TabIndex = 1;
            // 
            // pictureBoxFinger
            // 
            this.pictureBoxFinger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFinger.Location = new System.Drawing.Point(124, 70);
            this.pictureBoxFinger.Name = "pictureBoxFinger";
            this.pictureBoxFinger.Size = new System.Drawing.Size(299, 289);
            this.pictureBoxFinger.TabIndex = 2;
            this.pictureBoxFinger.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 572);
            this.Controls.Add(this.pictureBoxFinger);
            this.Controls.Add(this.textBoxLogs);
            this.Controls.Add(this.buttonCapture);
            this.Name = "Main";
            this.Text = "Finger Biometrics Suprema";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.PictureBox pictureBoxFinger;
    }
}

