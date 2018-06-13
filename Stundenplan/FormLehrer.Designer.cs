namespace StundenplanApplication
{
    partial class FormLehrer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnSubjectRem = new System.Windows.Forms.Button();
            this.bnSubjectAdd = new System.Windows.Forms.Button();
            this.tbFach = new System.Windows.Forms.TextBox();
            this.liFaecher = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bnRemove = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.liLehrer = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(216)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bnSubjectRem);
            this.panel1.Controls.Add(this.bnSubjectAdd);
            this.panel1.Controls.Add(this.tbFach);
            this.panel1.Controls.Add(this.liFaecher);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.bnRemove);
            this.panel1.Controls.Add(this.bnAdd);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.liLehrer);
            this.panel1.Location = new System.Drawing.Point(25, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 274);
            this.panel1.TabIndex = 0;
            // 
            // bnSubjectRem
            // 
            this.bnSubjectRem.BackColor = System.Drawing.SystemColors.Control;
            this.bnSubjectRem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bnSubjectRem.Image = global::StundenplanApplication.Properties.Resources.remove;
            this.bnSubjectRem.Location = new System.Drawing.Point(357, 185);
            this.bnSubjectRem.Name = "bnSubjectRem";
            this.bnSubjectRem.Size = new System.Drawing.Size(28, 23);
            this.bnSubjectRem.TabIndex = 10;
            this.bnSubjectRem.UseVisualStyleBackColor = false;
            this.bnSubjectRem.Click += new System.EventHandler(this.bnSubjectRem_Click);
            // 
            // bnSubjectAdd
            // 
            this.bnSubjectAdd.BackColor = System.Drawing.SystemColors.Control;
            this.bnSubjectAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bnSubjectAdd.Image = global::StundenplanApplication.Properties.Resources.apply;
            this.bnSubjectAdd.Location = new System.Drawing.Point(326, 185);
            this.bnSubjectAdd.Name = "bnSubjectAdd";
            this.bnSubjectAdd.Size = new System.Drawing.Size(28, 23);
            this.bnSubjectAdd.TabIndex = 9;
            this.bnSubjectAdd.UseVisualStyleBackColor = false;
            this.bnSubjectAdd.Click += new System.EventHandler(this.bnSubjectAdd_Click);
            // 
            // tbFach
            // 
            this.tbFach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFach.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFach.Location = new System.Drawing.Point(188, 185);
            this.tbFach.Name = "tbFach";
            this.tbFach.Size = new System.Drawing.Size(135, 23);
            this.tbFach.TabIndex = 8;
            this.tbFach.TextChanged += new System.EventHandler(this.tbFach_TextChanged);
            this.tbFach.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFach_KeyUp);
            this.tbFach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFach_KeyPress);
            // 
            // liFaecher
            // 
            this.liFaecher.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liFaecher.FormattingEnabled = true;
            this.liFaecher.IntegralHeight = false;
            this.liFaecher.ItemHeight = 15;
            this.liFaecher.Location = new System.Drawing.Point(188, 84);
            this.liFaecher.Name = "liFaecher";
            this.liFaecher.Size = new System.Drawing.Size(197, 95);
            this.liFaecher.Sorted = true;
            this.liFaecher.TabIndex = 7;
            this.liFaecher.SelectedIndexChanged += new System.EventHandler(this.liFaecher_SelectedIndexChanged);
            this.liFaecher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.liFaecher_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fächer";
            // 
            // bnRemove
            // 
            this.bnRemove.BackColor = System.Drawing.SystemColors.Control;
            this.bnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bnRemove.Location = new System.Drawing.Point(188, 228);
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.Size = new System.Drawing.Size(81, 27);
            this.bnRemove.TabIndex = 5;
            this.bnRemove.Text = "&Entfernen";
            this.bnRemove.UseVisualStyleBackColor = false;
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            // 
            // bnAdd
            // 
            this.bnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.bnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bnAdd.Location = new System.Drawing.Point(304, 228);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(81, 27);
            this.bnAdd.TabIndex = 4;
            this.bnAdd.Text = "&Hinzufügen";
            this.bnAdd.UseVisualStyleBackColor = false;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(188, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(197, 23);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lehrer";
            // 
            // liLehrer
            // 
            this.liLehrer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liLehrer.FormattingEnabled = true;
            this.liLehrer.IntegralHeight = false;
            this.liLehrer.ItemHeight = 15;
            this.liLehrer.Location = new System.Drawing.Point(16, 31);
            this.liLehrer.Name = "liLehrer";
            this.liLehrer.Size = new System.Drawing.Size(155, 224);
            this.liLehrer.Sorted = true;
            this.liLehrer.TabIndex = 0;
            this.liLehrer.SelectedIndexChanged += new System.EventHandler(this.liLehrer_SelectedIndexChanged);
            // 
            // FormLehrer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StundenplanApplication.Properties.Resources.bg_win;
            this.ClientSize = new System.Drawing.Size(454, 336);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLehrer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lehrer-Verwaltung";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormLehrer_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox liLehrer;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.ListBox liFaecher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFach;
        private System.Windows.Forms.Button bnSubjectRem;
        private System.Windows.Forms.Button bnSubjectAdd;
    }
}