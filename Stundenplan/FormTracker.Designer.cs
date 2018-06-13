namespace StundenplanApplication
{
    partial class FormTracker
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
            this.lbAktuelleZeitVerbleibend = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAktuellerLehrer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAktuelleStunde = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerFading = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbAktuelleZeitVerbleibend
            // 
            this.lbAktuelleZeitVerbleibend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAktuelleZeitVerbleibend.BackColor = System.Drawing.Color.White;
            this.lbAktuelleZeitVerbleibend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAktuelleZeitVerbleibend.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAktuelleZeitVerbleibend.Location = new System.Drawing.Point(127, 61);
            this.lbAktuelleZeitVerbleibend.Name = "lbAktuelleZeitVerbleibend";
            this.lbAktuelleZeitVerbleibend.Size = new System.Drawing.Size(129, 21);
            this.lbAktuelleZeitVerbleibend.TabIndex = 12;
            this.lbAktuelleZeitVerbleibend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(171)))), ((int)(((byte)(225)))));
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Verbleibende Zeit";
            // 
            // lbAktuellerLehrer
            // 
            this.lbAktuellerLehrer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAktuellerLehrer.AutoEllipsis = true;
            this.lbAktuellerLehrer.BackColor = System.Drawing.Color.White;
            this.lbAktuellerLehrer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAktuellerLehrer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAktuellerLehrer.Location = new System.Drawing.Point(127, 35);
            this.lbAktuellerLehrer.Name = "lbAktuellerLehrer";
            this.lbAktuellerLehrer.Size = new System.Drawing.Size(129, 21);
            this.lbAktuellerLehrer.TabIndex = 10;
            this.lbAktuellerLehrer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(171)))), ((int)(((byte)(225)))));
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lehrer";
            // 
            // lbAktuelleStunde
            // 
            this.lbAktuelleStunde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAktuelleStunde.AutoEllipsis = true;
            this.lbAktuelleStunde.BackColor = System.Drawing.Color.White;
            this.lbAktuelleStunde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAktuelleStunde.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAktuelleStunde.Location = new System.Drawing.Point(127, 9);
            this.lbAktuelleStunde.Name = "lbAktuelleStunde";
            this.lbAktuelleStunde.Size = new System.Drawing.Size(129, 21);
            this.lbAktuelleStunde.TabIndex = 8;
            this.lbAktuelleStunde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(171)))), ((int)(((byte)(225)))));
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Stunde";
            // 
            // timerFading
            // 
            this.timerFading.Enabled = true;
            this.timerFading.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(171)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(268, 92);
            this.ControlBox = false;
            this.Controls.Add(this.lbAktuelleZeitVerbleibend);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbAktuelleStunde);
            this.Controls.Add(this.lbAktuellerLehrer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "FormTracker";
            this.Opacity = 0.6;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTracker_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAktuelleZeitVerbleibend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbAktuellerLehrer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbAktuelleStunde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerFading;
    }
}