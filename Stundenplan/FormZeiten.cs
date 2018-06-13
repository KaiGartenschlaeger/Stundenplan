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
    public partial class FormZeiten : Form
    {
        Stundenplan sp;

        ListViewItem lvi;

        public FormZeiten(ref Stundenplan sp)
        {
            InitializeComponent();

            this.sp = sp;

            dtpBegin.Value = new DateTime(2000, 1, 1, 8, 0, 0);
            dtpEnd.Value = new DateTime(2000, 1, 1, 8, 45, 0);

            Funktionen.CenterPanel(this, pnMain);
            
            for (int i = 0; i < sp.zeit.Length; i++)
            {
                lvi = new ListViewItem();
                lvi.Text = (i + 1).ToString();
                lvi.SubItems.Add(sp.zeit[i].start.ToString("t"));
                lvi.SubItems.Add(sp.zeit[i].end.ToString("t"));
                lvZeiten.Items.Add(lvi);
            }
        }

        private void lvZeiten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvZeiten.SelectedIndices.Count > 0)
            {
                int index = lvZeiten.SelectedIndices[0];

                dtpBegin.Enabled = true;
                dtpEnd.Enabled = true;
                dtpBegin.Value = sp.zeit[index].start;
                dtpEnd.Value = sp.zeit[index].end;
                bnSave.Enabled = true;
            }
            else
            {
                dtpBegin.Enabled = false;
                dtpEnd.Enabled = false;
                dtpBegin.Value = new DateTime(2000, 1, 1, 8, 0, 0);
                dtpEnd.Value = new DateTime(2000, 1, 1, 8, 45, 0);
                bnSave.Enabled = false;
            }
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            if (lvZeiten.SelectedIndices.Count > 0)
            {
                int index = lvZeiten.SelectedIndices[0];

                sp.zeit[index].start = dtpBegin.Value;
                sp.zeit[index].end = dtpEnd.Value;

                lvZeiten.Items[index].SubItems[1].Text = dtpBegin.Value.ToString("t");
                lvZeiten.Items[index].SubItems[2].Text = dtpEnd.Value.ToString("t");

                lvZeiten.SelectedIndices.Clear();
            }
        }
    }
}
