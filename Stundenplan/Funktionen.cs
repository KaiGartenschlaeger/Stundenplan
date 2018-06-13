using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.Drawing;

namespace StundenplanApplication
{
    enum DesktopEdge
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    static class Funktionen
    {
        public static void CenterForm(Form Parent, Form Children)
        {
            Children.Left = Parent.Left + Parent.Width / 2 - Children.Width / 2;
            Children.Top = Parent.Top + Parent.Height / 2 - Children.Height / 2;
        }

        public static void CheckFormLocation(Form frm)
        {
            if (frm.Left < 0)
                frm.Left = 0;
            if (frm.Top < 0)
                frm.Top = 0;
            if (frm.Left + frm.Width > Screen.PrimaryScreen.WorkingArea.Width)
                frm.Left = Screen.PrimaryScreen.WorkingArea.Width - frm.Width;
            if (frm.Top + frm.Height > Screen.PrimaryScreen.WorkingArea.Height)
                frm.Top = Screen.PrimaryScreen.WorkingArea.Height - frm.Height;
        }

        public static void CenterPanel(Form F, Panel P)
        {
            P.Left = (F.ClientRectangle.Width - P.Width) / 2;
            P.Top = (F.ClientRectangle.Height - P.Height) / 2;
        }

        public static void SetDoubleBuffered(Control control, bool enable)
        {
            typeof(Control).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, control, new object[] { enable });
        }

        /// <summary>
        /// Ermittelt ob ein Zeitbereich innerhalb eines Start und End Bereiches liegt.
        /// </summary>
        public static bool InTimeRange(DateTime N, DateTime S, DateTime E)
        {
            DateTime n = new DateTime(2000, 1, 1, N.Hour, N.Minute, N.Second);
            DateTime s = new DateTime(2000, 1, 1, S.Hour, S.Minute, S.Second);
            DateTime e = new DateTime(2000, 1, 1, E.Hour, E.Minute, E.Second);

            if (n.Ticks >= s.Ticks && n.Ticks <= e.Ticks)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gibt einen Formatierten Zeitstring mit der Differenz von first und second zurück
        /// </summary>
        public static string TimeSpanString(DateTime first, DateTime second)
        {
            DateTime start = new DateTime(2000, 1, 1, first.Hour, first.Minute, first.Second);
            DateTime ende = new DateTime(2000, 1, 1, second.Hour, second.Minute, second.Second);

            string result;

            TimeSpan ts = ende - start;

            result = string.Format("{0:d2}:{1:d2}:{2:d2}", ts.Hours, ts.Minutes, ts.Seconds);

            return result;
        }

        /// <summary>
        /// Aktualisiert den Text eines Labels falls dieser anders ist als angegeben
        /// </summary>
        public static void RefreshLabel(Label L, string Text, Color background)
        {
            if (L.Text != Text)
                L.Text = Text;
            if (L.BackColor != background)
                L.BackColor = background;
        }


        /// <summary>
        /// Verschiebt ein Fenster an der angegebenen Desktopposition
        /// </summary>
        public static void SnapWindow(Form Frm, DesktopEdge Edge, int Spacing)
        {
            int posx = 0;
            int posy = 0;            

            switch (Edge)
            {
                case DesktopEdge.TopLeft:
                    posx = Spacing;
                    posy = Spacing;
                    break;
                case DesktopEdge.TopCenter:
                    posx = SystemInformation.WorkingArea.Width / 2 - Frm.Width / 2;
                    posy = Spacing;
                    break;
                case DesktopEdge.TopRight:
                    posx = SystemInformation.WorkingArea.Width - Frm.Width - Spacing;
                    posy = Spacing;
                    break;
                case DesktopEdge.CenterLeft:
                    posx = Spacing;
                    posy = SystemInformation.WorkingArea.Height / 2 - Frm.Height / 2;
                    break;
                case DesktopEdge.Center:
                    posx = SystemInformation.WorkingArea.Width / 2 - Frm.Width / 2;
                    posy = SystemInformation.WorkingArea.Height / 2 - Frm.Height / 2;
                    break;
                case DesktopEdge.CenterRight:
                    posx = SystemInformation.WorkingArea.Width - Frm.Width - Spacing;
                    posy = SystemInformation.WorkingArea.Height / 2 - Frm.Height / 2;
                    break;
                case DesktopEdge.BottomLeft:
                    posx = Spacing;
                    posy = SystemInformation.WorkingArea.Height - Frm.Height - Spacing;
                    break;
                case DesktopEdge.BottomCenter:
                    posx = SystemInformation.WorkingArea.Width / 2 - Frm.Width / 2;
                    posy = SystemInformation.WorkingArea.Height - Frm.Height - Spacing;
                    break;
                case DesktopEdge.BottomRight:
                    posx = SystemInformation.WorkingArea.Width - Frm.Width - Spacing;
                    posy = SystemInformation.WorkingArea.Height - Frm.Height - Spacing;
                    break;
            }

            Frm.Location = new System.Drawing.Point(posx, posy);
        }

        [DllImport("user32")]
        public static extern int SendMessage(int hwnd, int msg, int wparam, int lparam);
    }
}
