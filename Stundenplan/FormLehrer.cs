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
    public partial class FormLehrer : Form
    {
        Stundenplan sp;

        public FormLehrer(ref Stundenplan sp)
        {
            InitializeComponent();

            this.sp = sp;

            Funktionen.CenterPanel(this, panel1);

            for (int i = 0; i < sp.teacher.Count; i++)
            {
                liLehrer.Items.Add(sp.teacher[i].name);
            }

            bnAdd.Enabled = false;
            bnRemove.Enabled = false;

            bnSubjectAdd.Enabled = false;
            bnSubjectRem.Enabled = false;
        }

        private void SubjectAdd(string subject)
        {
            if (subject.Trim() != "")
            {
                subject = subject.Trim();

                foreach (string fach in liFaecher.Items)
                {
                    if (fach.ToUpper() == subject.ToUpper())
                        return;
                }

                liFaecher.Items.Add(subject);
                tbFach.Text = string.Empty;
                CheckSaveState();
            }
        }

        //Fach hinzufügen
        private void tbFach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && tbFach.Text.Trim() != "")
            {
                SubjectAdd(tbFach.Text);
            }
        }

        //Entfernen des Beeptons beim Enterdrücken
        private void tbFach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
                e.Handled = true;
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Ungültiger Name", "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (liFaecher.Items.Count == 0)
            {
                MessageBox.Show(this, "Dem Lehrer sind noch keine Fächer zugeordnet", "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int index = -1;

            for (int i = 0; i < sp.teacher.Count; i++)
            {
                if (sp.teacher[i].name.ToUpper() == tbName.Text.Trim().ToUpper())
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                sp.teacher[index].fach.Clear();

                foreach (string f in liFaecher.Items)
                {
                    sp.teacher[index].fach.Add(f);
                }
            }
            else
            {
                Stundenplan.struct_teacher t = new Stundenplan.struct_teacher();
                
                t.name = tbName.Text.Trim();
                t.fach = new List<string>();
                
                for(int i = 0; i < liFaecher.Items.Count; i++)
                {
                    t.fach.Add(liFaecher.Items[i].ToString());
                }

                sp.teacher.Add(t);

                liLehrer.Items.Add(tbName.Text.Trim());
            }

            liLehrer.SelectedIndex = -1;
            tbName.Text = string.Empty;
            tbFach.Text = string.Empty;
            liFaecher.Items.Clear();
            CheckSaveState();
        }

        //Lehrerauswahl anzeigen
        private void liLehrer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = -1;

            if (liLehrer.SelectedIndex >= 0)
            {
                for (int i = 0; i < sp.teacher.Count; i++)
                {
                    if (sp.teacher[i].name == liLehrer.SelectedItem.ToString())
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index >= 0)
            {
                tbName.Text = sp.teacher[index].name;

                liFaecher.Items.Clear();
                for (int i = 0; i < sp.teacher[index].fach.Count; i++)
                {
                    liFaecher.Items.Add(sp.teacher[index].fach[i]);
                }

                tbFach.Text = "";

                bnRemove.Enabled = true;
                CheckSaveState();
            }
            else
            {
                bnRemove.Enabled = false;
            }
        }

        private void CheckSaveState()
        {
            bool enable = true;

            if (tbName.Text.Trim() == "")
                enable = false;

            if (liFaecher.Items.Count == 0)
                enable = false;

            bnAdd.Enabled = enable;
        }

        private void bnRemove_Click(object sender, EventArgs e)
        {
            int index = -1;

            if (liLehrer.SelectedIndex > -1)
            {
                for (int i = 0; i < sp.teacher.Count; i++)
                {
                    if (sp.teacher[i].name == liLehrer.SelectedItem.ToString())
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index > -1)
            {
                if (MessageBox.Show(this, string.Format("Möchten Sie {0} wirklich entfernen?", sp.teacher[index].name), "Lehrer Entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    sp.teacher.RemoveAt(index);
                    liLehrer.Items.RemoveAt(liLehrer.SelectedIndex);

                    tbName.Text = "";
                    liFaecher.Items.Clear();
                    tbFach.Text = "";
                    CheckSaveState();
                }                

            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            CheckSaveState();
        }

        private void liFaecher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liFaecher.SelectedIndex >= 0)
                tbFach.Text = liFaecher.SelectedItem.ToString();

            bnSubjectRem.Enabled = (liFaecher.SelectedIndex >= 0);
        }

        private void liFaecher_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && liFaecher.SelectedIndex != -1)
            {
                liFaecher.Items.RemoveAt(liFaecher.SelectedIndex);
                tbFach.Text = string.Empty;
            }
        }

        private void FormLehrer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {                
                liLehrer.SelectedIndex = -1;
                tbName.Text = "";
                liFaecher.Items.Clear();
                tbFach.Text = "";
                CheckSaveState();
            }
        }

        private void tbFach_TextChanged(object sender, EventArgs e)
        {
            bnSubjectAdd.Enabled = (tbFach.Text.Trim() != "");
        }

        private void bnSubjectAdd_Click(object sender, EventArgs e)
        {
            if (tbFach.Text.Trim() != "")
                SubjectAdd(tbFach.Text);
        }

        private void bnSubjectRem_Click(object sender, EventArgs e)
        {
            if (liFaecher.SelectedIndex != -1)
            {
                liFaecher.Items.RemoveAt(liFaecher.SelectedIndex);
                tbFach.Text = string.Empty;
            }
        }
    }
}
