using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StundenplanApplication
{
    public partial class FormStundenplan : Form
    {
        Stundenplan sp;
        ListViewItem lvi;
        int currhour = 0;

        public FormStundenplan(ref Stundenplan sp)
        {
            InitializeComponent();

            this.sp = sp;

            Funktionen.SetDoubleBuffered(lvStundenplan, true);

            Funktionen.CenterPanel(this, panel1);

            if (sp.teacher.Count > 0)
            {
                for (int i = 0; i < sp.teacher.Count; i++)
                {
                    cbTeacher.Items.Add(sp.teacher[i].name);
                }
            }
            else
                cbTeacher.Enabled = false;

            cbFach.Enabled = false;

            bnAdd.Enabled = false;
            bnRemove.Enabled = false;

            lvStundenplan.Columns[lvStundenplan.Columns.Count - 1].Width = -2;

            RefreshDay(Day.Monday);
        }

        private void RefreshDay(Day d)
        {
            Stundenplan.struct_stunde[] stunden;

            switch (d)
            {
                case Day.Tuesday:
                    stunden = sp.week.Tuesday;
                    break;
                case Day.Wednesday:
                    stunden = sp.week.Wednesday;
                    break;
                case Day.Thursday:
                    stunden = sp.week.Thursday;
                    break;
                case Day.Friday:
                    stunden = sp.week.Friday;
                    break;
                case Day.Saturday:
                    stunden = sp.week.Saturday;
                    break;
                default:
                    stunden = sp.week.Monday;
                    break;
            }

            lvStundenplan.BeginUpdate();
            
            lvStundenplan.Items.Clear();
            for (int i = 0; i < stunden.Length; i++)
            {
                lvi = new ListViewItem((i + 1).ToString());

                if (stunden[i].lehrer == null || stunden[i].lehrer == "")
                    lvi.SubItems.Add("-");
                else
                    lvi.SubItems.Add(stunden[i].lehrer);

                if (stunden[i].fach == null || stunden[i].fach == "")
                    lvi.SubItems.Add("-");
                else
                    lvi.SubItems.Add(stunden[i].fach);

                lvi.SubItems.Add(sp.zeit[i].start.ToString("t"));
                lvi.SubItems.Add(sp.zeit[i].end.ToString("t"));
                
                lvStundenplan.Items.Add(lvi);
            }

            lvStundenplan.Columns[lvStundenplan.Columns.Count - 1].Width = -2;

            lvStundenplan.EndUpdate();

            nudHour.Value = 1;

            cbTeacher.SelectedIndex = -1;
            if (sp.teacher.Count == 0)
                cbTeacher.Enabled = false;
            cbFach.SelectedIndex = -1;
            cbFach.Enabled = false;
        }

        private void rbMontag_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDay(Day.Monday);
        }

        private void rbDienstag_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDay(Day.Tuesday);
        }

        private void rbMittwoch_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDay(Day.Wednesday);
        }

        private void rbDonnerstag_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDay(Day.Thursday);
        }

        private void rbFreitag_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDay(Day.Friday);
        }

        private void rbSamstag_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDay(Day.Saturday);
        }

        private void CheckAdd()
        {
            if (cbFach.SelectedIndex >= 0 && cbTeacher.SelectedIndex >= 0)
                bnAdd.Enabled = true;
            else
                bnAdd.Enabled = false;
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeacher.SelectedIndex > -1)
            {
                cbFach.Items.Clear();
                for (int i = 0; i < sp.teacher.Count; i++)
                {
                    if (cbTeacher.SelectedItem.ToString() == sp.teacher[i].name)
                    {
                        foreach (string fach in sp.teacher[i].fach)
                        {
                            cbFach.Items.Add(fach);
                        }
                    }
                }

                if (cbFach.Items.Count > 0)
                {
                    cbFach.Enabled = true;
                    cbFach.SelectedIndex = 0;
                }
                else
                    cbFach.Enabled = false;
            }
            
            CheckAdd();
        }

        private void cbFach_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAdd();
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            if (cbTeacher.SelectedIndex > -1 && cbFach.SelectedIndex > -1)
            {                
                if (rbMontag.Checked)
                {
                    sp.week.Monday[currhour].lehrer = cbTeacher.SelectedItem.ToString();
                    sp.week.Monday[currhour].fach = cbFach.SelectedItem.ToString();
                    RefreshDay(Day.Monday);
                }
                else if (rbDienstag.Checked)
                {
                    sp.week.Tuesday[currhour].lehrer = cbTeacher.SelectedItem.ToString();
                    sp.week.Tuesday[currhour].fach = cbFach.SelectedItem.ToString();
                    RefreshDay(Day.Tuesday);
                }
                else if (rbMittwoch.Checked)
                {
                    sp.week.Wednesday[currhour].lehrer = cbTeacher.SelectedItem.ToString();
                    sp.week.Wednesday[currhour].fach = cbFach.SelectedItem.ToString();
                    RefreshDay(Day.Wednesday);
                }
                else if (rbDonnerstag.Checked)
                {
                    sp.week.Thursday[currhour].lehrer = cbTeacher.SelectedItem.ToString();
                    sp.week.Thursday[currhour].fach = cbFach.SelectedItem.ToString();
                    RefreshDay(Day.Thursday);
                }
                else if (rbFreitag.Checked)
                {
                    sp.week.Friday[currhour].lehrer = cbTeacher.SelectedItem.ToString();
                    sp.week.Friday[currhour].fach = cbFach.SelectedItem.ToString();
                    RefreshDay(Day.Friday);
                }
                else if (rbSamstag.Checked)
                {
                    sp.week.Saturday[currhour].lehrer = cbTeacher.SelectedItem.ToString();
                    sp.week.Saturday[currhour].fach = cbFach.SelectedItem.ToString();
                    RefreshDay(Day.Saturday);
                }
            }
            else
            {
                MessageBox.Show("Wählen Sie bitte einen Lehrer und ein Fach aus");
            }
        }

        private void nudHour_ValueChanged(object sender, EventArgs e)
        {
            currhour = (int)nudHour.Value - 1;
        }

        private void lvStundenplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStundenplan.SelectedIndices.Count > 0)
            {
                int index = lvStundenplan.SelectedIndices[0];
                
                string lehrer = string.Empty;
                string fach = string.Empty;

                nudHour.Value = index + 1;

                if (rbMontag.Checked)
                {
                    lehrer = sp.week.Monday[index].lehrer;
                    fach = sp.week.Monday[index].fach;
                }
                else if (rbDienstag.Checked)
                {
                    lehrer = sp.week.Tuesday[index].lehrer;
                    fach = sp.week.Tuesday[index].fach;
                }
                else if (rbMittwoch.Checked)
                {
                    lehrer = sp.week.Wednesday[index].lehrer;
                    fach = sp.week.Wednesday[index].fach;
                }
                else if (rbDonnerstag.Checked)
                {
                    lehrer = sp.week.Thursday[index].lehrer;
                    fach = sp.week.Thursday[index].fach;
                }
                else if (rbFreitag.Checked)
                {
                    lehrer = sp.week.Friday[index].lehrer;
                    fach = sp.week.Friday[index].fach;
                }
                else if (rbSamstag.Checked)
                {
                    lehrer = sp.week.Saturday[index].lehrer;
                    fach = sp.week.Saturday[index].fach;
                }

                cbTeacher.SelectedItem = lehrer;
                cbFach.SelectedItem = fach;

                bnRemove.Enabled = true;
            }
            else
            {
                nudHour.Value = 1;
                cbTeacher.SelectedIndex = -1;
                if (sp.teacher.Count == 0)
                    cbTeacher.Enabled = false;
                cbFach.SelectedIndex = -1;
                cbFach.Enabled = false;

                bnRemove.Enabled = false;
            }
        }

        private void bnRemove_Click(object sender, EventArgs e)
        {
            if (lvStundenplan.SelectedIndices.Count > 0)
            {
                int index = lvStundenplan.SelectedIndices[0];

                if (rbMontag.Checked)
                {
                    sp.week.Monday[index].lehrer = string.Empty;
                    sp.week.Monday[index].fach = string.Empty;
                    RefreshDay(Day.Monday);
                }
                else if (rbDienstag.Checked)
                {
                    sp.week.Tuesday[index].lehrer = string.Empty;
                    sp.week.Tuesday[index].fach = string.Empty;
                    RefreshDay(Day.Tuesday);
                }
                else if (rbMittwoch.Checked)
                {
                    sp.week.Wednesday[index].lehrer = string.Empty;
                    sp.week.Wednesday[index].fach = string.Empty;
                    RefreshDay(Day.Wednesday);
                }
                else if (rbDonnerstag.Checked)
                {
                    sp.week.Thursday[index].lehrer = string.Empty;
                    sp.week.Thursday[index].fach = string.Empty;
                    RefreshDay(Day.Thursday);
                }
                else if (rbFreitag.Checked)
                {
                    sp.week.Friday[index].lehrer = string.Empty;
                    sp.week.Friday[index].fach = string.Empty;
                    RefreshDay(Day.Friday);
                }
                else if (rbSamstag.Checked)
                {
                    sp.week.Saturday[index].lehrer = string.Empty;
                    sp.week.Saturday[index].fach = string.Empty;
                    RefreshDay(Day.Saturday);
                }
            }
        }
    }
}
