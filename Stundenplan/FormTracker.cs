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
    public partial class FormTracker : Form
    {
        MyConfig cfg;
        bool opacity = true;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0201)
                Funktionen.SendMessage(Handle.ToInt32(), 0xA1, 0x02, 0);
            else
                base.WndProc(ref m);
        }

        public FormTracker(MyConfig cfg)
        {
            InitializeComponent();

            this.cfg = cfg;

            this.ClientSize = new Size(this.ClientSize.Width, lbAktuelleZeitVerbleibend.Bottom + 10);
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width + 500, this.Size.Height);
        }

        public void SetData(string lehrer, string fach, string verbleibendezeit)
        {
            lbAktuellerLehrer.Text = lehrer;
            lbAktuelleStunde.Text = fach;
            lbAktuelleZeitVerbleibend.Text = verbleibendezeit;
        }

        public void SetOpacity(bool enabled)
        {
            this.opacity = enabled;

            if (opacity)
                this.Opacity = 0.60;
            else
                this.Opacity = 1.00;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(cfg["TrackerOpacity", 100] < 100)
            {
                int opacity = cfg["TrackerOpacity", 100];

                if (opacity < 10)
                {
                    opacity = 10;
                }

                if (MousePosition.X >= this.Left && MousePosition.X <= this.Right && MousePosition.Y >= this.Top && MousePosition.Y <= this.Bottom)
                {
                    if (this.Opacity != 1.00)
                        this.Opacity = 1.00;
                }
                else
                {
                    double opa = (double)opacity / 100;

                    if (this.Opacity != opa)
                        this.Opacity = opa;
                }
            }
            else
            {
                if (this.Opacity != 1.00)
                    this.Opacity = 1.00;
            }
        }

        private void FormTracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            cfg["TrackerX"] = this.Left;
            cfg["TrackerY"] = this.Top;
            cfg["TrackerW"] = this.Width;
        }
    }
}
