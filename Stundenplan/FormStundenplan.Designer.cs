namespace StundenplanApplication
{
    partial class FormStundenplan
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
            this.label2 = new System.Windows.Forms.Label();
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.bnRemove = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.cbFach = new System.Windows.Forms.ComboBox();
            this.cbTeacher = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMontag = new System.Windows.Forms.RadioButton();
            this.rbMittwoch = new System.Windows.Forms.RadioButton();
            this.rbSamstag = new System.Windows.Forms.RadioButton();
            this.rbDonnerstag = new System.Windows.Forms.RadioButton();
            this.rbFreitag = new System.Windows.Forms.RadioButton();
            this.rbDienstag = new System.Windows.Forms.RadioButton();
            this.lvStundenplan = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(216)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nudHour);
            this.panel1.Controls.Add(this.bnRemove);
            this.panel1.Controls.Add(this.bnAdd);
            this.panel1.Controls.Add(this.cbFach);
            this.panel1.Controls.Add(this.cbTeacher);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lvStundenplan);
            this.panel1.Location = new System.Drawing.Point(30, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 339);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Stunde";
            // 
            // nudHour
            // 
            this.nudHour.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHour.Location = new System.Drawing.Point(211, 293);
            this.nudHour.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(83, 23);
            this.nudHour.TabIndex = 15;
            this.nudHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHour.ValueChanged += new System.EventHandler(this.nudHour_ValueChanged);
            // 
            // bnRemove
            // 
            this.bnRemove.BackColor = System.Drawing.SystemColors.Control;
            this.bnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bnRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnRemove.Location = new System.Drawing.Point(321, 287);
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.Size = new System.Drawing.Size(92, 32);
            this.bnRemove.TabIndex = 14;
            this.bnRemove.Text = "Entfernen";
            this.bnRemove.UseVisualStyleBackColor = false;
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            // 
            // bnAdd
            // 
            this.bnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.bnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bnAdd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnAdd.Location = new System.Drawing.Point(419, 287);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(92, 32);
            this.bnAdd.TabIndex = 13;
            this.bnAdd.Text = "Setzen";
            this.bnAdd.UseVisualStyleBackColor = false;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // cbFach
            // 
            this.cbFach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFach.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFach.FormattingEnabled = true;
            this.cbFach.Location = new System.Drawing.Point(13, 300);
            this.cbFach.Name = "cbFach";
            this.cbFach.Size = new System.Drawing.Size(187, 23);
            this.cbFach.TabIndex = 12;
            this.cbFach.SelectedIndexChanged += new System.EventHandler(this.cbFach_SelectedIndexChanged);
            // 
            // cbTeacher
            // 
            this.cbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeacher.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTeacher.FormattingEnabled = true;
            this.cbTeacher.Location = new System.Drawing.Point(13, 271);
            this.cbTeacher.Name = "cbTeacher";
            this.cbTeacher.Size = new System.Drawing.Size(187, 23);
            this.cbTeacher.Sorted = true;
            this.cbTeacher.TabIndex = 11;
            this.cbTeacher.SelectedIndexChanged += new System.EventHandler(this.cbTeacher_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lehrer";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbMontag);
            this.panel2.Controls.Add(this.rbMittwoch);
            this.panel2.Controls.Add(this.rbSamstag);
            this.panel2.Controls.Add(this.rbDonnerstag);
            this.panel2.Controls.Add(this.rbFreitag);
            this.panel2.Controls.Add(this.rbDienstag);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(96, 235);
            this.panel2.TabIndex = 9;
            // 
            // rbMontag
            // 
            this.rbMontag.AutoSize = true;
            this.rbMontag.Checked = true;
            this.rbMontag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMontag.Location = new System.Drawing.Point(3, 3);
            this.rbMontag.Name = "rbMontag";
            this.rbMontag.Size = new System.Drawing.Size(67, 19);
            this.rbMontag.TabIndex = 1;
            this.rbMontag.TabStop = true;
            this.rbMontag.Text = "Montag";
            this.rbMontag.UseVisualStyleBackColor = true;
            this.rbMontag.CheckedChanged += new System.EventHandler(this.rbMontag_CheckedChanged);
            // 
            // rbMittwoch
            // 
            this.rbMittwoch.AutoSize = true;
            this.rbMittwoch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMittwoch.Location = new System.Drawing.Point(3, 53);
            this.rbMittwoch.Name = "rbMittwoch";
            this.rbMittwoch.Size = new System.Drawing.Size(77, 19);
            this.rbMittwoch.TabIndex = 3;
            this.rbMittwoch.Text = "Mittwoch";
            this.rbMittwoch.UseVisualStyleBackColor = true;
            this.rbMittwoch.CheckedChanged += new System.EventHandler(this.rbMittwoch_CheckedChanged);
            // 
            // rbSamstag
            // 
            this.rbSamstag.AutoSize = true;
            this.rbSamstag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSamstag.Location = new System.Drawing.Point(3, 128);
            this.rbSamstag.Name = "rbSamstag";
            this.rbSamstag.Size = new System.Drawing.Size(71, 19);
            this.rbSamstag.TabIndex = 6;
            this.rbSamstag.Text = "Samstag";
            this.rbSamstag.UseVisualStyleBackColor = true;
            this.rbSamstag.CheckedChanged += new System.EventHandler(this.rbSamstag_CheckedChanged);
            // 
            // rbDonnerstag
            // 
            this.rbDonnerstag.AutoSize = true;
            this.rbDonnerstag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDonnerstag.Location = new System.Drawing.Point(3, 78);
            this.rbDonnerstag.Name = "rbDonnerstag";
            this.rbDonnerstag.Size = new System.Drawing.Size(88, 19);
            this.rbDonnerstag.TabIndex = 4;
            this.rbDonnerstag.Text = "Donnerstag";
            this.rbDonnerstag.UseVisualStyleBackColor = true;
            this.rbDonnerstag.CheckedChanged += new System.EventHandler(this.rbDonnerstag_CheckedChanged);
            // 
            // rbFreitag
            // 
            this.rbFreitag.AutoSize = true;
            this.rbFreitag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFreitag.Location = new System.Drawing.Point(3, 103);
            this.rbFreitag.Name = "rbFreitag";
            this.rbFreitag.Size = new System.Drawing.Size(63, 19);
            this.rbFreitag.TabIndex = 5;
            this.rbFreitag.Text = "Freitag";
            this.rbFreitag.UseVisualStyleBackColor = true;
            this.rbFreitag.CheckedChanged += new System.EventHandler(this.rbFreitag_CheckedChanged);
            // 
            // rbDienstag
            // 
            this.rbDienstag.AutoSize = true;
            this.rbDienstag.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDienstag.Location = new System.Drawing.Point(3, 28);
            this.rbDienstag.Name = "rbDienstag";
            this.rbDienstag.Size = new System.Drawing.Size(73, 19);
            this.rbDienstag.TabIndex = 2;
            this.rbDienstag.Text = "Dienstag";
            this.rbDienstag.UseVisualStyleBackColor = true;
            this.rbDienstag.CheckedChanged += new System.EventHandler(this.rbDienstag_CheckedChanged);
            // 
            // lvStundenplan
            // 
            this.lvStundenplan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStundenplan.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvStundenplan.FullRowSelect = true;
            this.lvStundenplan.GridLines = true;
            this.lvStundenplan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvStundenplan.Location = new System.Drawing.Point(115, 12);
            this.lvStundenplan.Name = "lvStundenplan";
            this.lvStundenplan.ShowItemToolTips = true;
            this.lvStundenplan.Size = new System.Drawing.Size(396, 235);
            this.lvStundenplan.TabIndex = 8;
            this.lvStundenplan.UseCompatibleStateImageBehavior = false;
            this.lvStundenplan.View = System.Windows.Forms.View.Details;
            this.lvStundenplan.SelectedIndexChanged += new System.EventHandler(this.lvStundenplan_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stunde";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lehrer";
            this.columnHeader4.Width = 85;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Fach";
            this.columnHeader5.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Beginn";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ende";
            // 
            // FormStundenplan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StundenplanApplication.Properties.Resources.bg_win;
            this.ClientSize = new System.Drawing.Size(591, 411);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStundenplan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stundenplan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbMontag;
        private System.Windows.Forms.RadioButton rbSamstag;
        private System.Windows.Forms.RadioButton rbDienstag;
        private System.Windows.Forms.RadioButton rbFreitag;
        private System.Windows.Forms.RadioButton rbMittwoch;
        private System.Windows.Forms.RadioButton rbDonnerstag;
        private System.Windows.Forms.ListView lvStundenplan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbFach;
        private System.Windows.Forms.ComboBox cbTeacher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}