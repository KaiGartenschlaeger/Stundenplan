using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace StundenplanApplication
{
    public partial class FormMain : Form
    {
        Stundenplan sp = new Stundenplan();
        FormTracker tracker = null;
        DesktopEdge trackerpos = DesktopEdge.TopRight;
        MyConfig cfg = new MyConfig();

        public FormMain()
        {
            InitializeComponent();

            Funktionen.CenterPanel(this, pnMain);

            this.Opacity = 0;
            timerFadeIn.Enabled = true;
            
            sp.Init(10);

            LoadPreferences();
        }

        private void LoadPreferences()
        {
            cfg.Open(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\config.xml", MyConfigFormat.XML);

            this.Left = cfg["MainX", 0];
            this.Top = cfg["MainY", 0];

            if (cfg["MainM", false] == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            Funktionen.CheckFormLocation(this);

            if (cfg["TrackerV", false] == true)
            {
                tracker = new FormTracker(cfg);

                if (cfg["TrackerX", -1] != -1 && cfg["TrackerY", -2] != -2)
                {
                    tracker.Left = cfg["TrackerX", 0];
                    tracker.Top = cfg["TrackerY", 0];
                    tracker.Width = cfg["TrackerW", 0];
                }
                else
                {
                    Funktionen.SnapWindow(tracker, trackerpos, 5);
                }

                Funktionen.CheckFormLocation(tracker);

                tracker.TopMost = cfg["TrackerOnTop", true];
                immerImVordergrundToolStripMenuItem.Checked = cfg["TrackerOnTop", true];

                tracker.Show();

                trackerToolStripMenuItem.Checked = true;
            }

            //Stundenplan
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\stundenplan.xml") == true)
            {
                XmlSerializer serialIn = new XmlSerializer(typeof(Stundenplan));
                StreamReader streamIn = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\stundenplan.xml");

                sp = (Stundenplan)serialIn.Deserialize(streamIn);
                streamIn.Close();
            }
        }

        private void ApplicationExit()
        {
            //Ordner überprüfen und ggf. erstellem
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\");
            }

            //Einstellungen speichern
            cfg["MainM"] = (this.WindowState == FormWindowState.Minimized);

            if (tracker != null)
            {
                cfg["TrackerV"] = (tracker != null);
                cfg["TrackerX"] = tracker.Left;
                cfg["TrackerY"] = tracker.Top;
                cfg["TrackerW"] = tracker.Width;
            }

            cfg.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\config.xml", MyConfigFormat.XML);

            //Stunenplan speichern
            XmlSerializer serialOut = new XmlSerializer(typeof(Stundenplan));
            StreamWriter streamOut = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stundenplan\\stundenplan.xml");
            serialOut.Serialize(streamOut, sp);
            streamOut.Close();
        }

        private void lehrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLehrer dialog = new FormLehrer(ref sp);
            Funktionen.CenterForm(this, dialog);
            dialog.ShowDialog();
        }

        private void zeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZeiten dialog = new FormZeiten(ref sp);
            Funktionen.CenterForm(this, dialog);
            dialog.ShowDialog();
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sp.teacher.Count <= 0)
                MessageBox.Show("Tragen Sie bitte erst Lehrer ein");
            else
            {
                FormStundenplan dialog = new FormStundenplan(ref sp);
                Funktionen.CenterForm(this, dialog);
                dialog.ShowDialog();
            }
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sp = new Stundenplan();
            sp.Init(10);
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Title = "Stundenplan Speichern";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "XML-Datei|*.xml|Alle Dateien|*.*||";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serialOut = new XmlSerializer(typeof(Stundenplan));
                StreamWriter streamOut = new StreamWriter(dialog.FileName);

                serialOut.Serialize(streamOut, sp);

                streamOut.Close();
            }
        }

        private void öffnenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Stunenplan Öffnen";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "XML-Datei|*.xml|Alle Dateien|*.*||";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer serialIn = new XmlSerializer(typeof(Stundenplan));
                    StreamReader streamIn = new StreamReader(dialog.FileName);

                    sp = (Stundenplan)serialIn.Deserialize(streamIn);
                    streamIn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format("Ungültie Datei \n\n {0}", ex.Message), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void informationenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

            MessageBox.Show(this, string.Format("{0} Version {1}\n{2}\n\n{3}", version.ProductName, version.FileVersion, version.Comments, version.LegalCopyright), "Informationen", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshCurrDay(int currhour)
        {
            DateTime D = DateTime.Today;

            if (D.DayOfWeek == DayOfWeek.Sunday)
            {
                Funktionen.RefreshLabel(lbLehrer1, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer2, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer3, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer4, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer5, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer6, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer7, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer8, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer9, null, Color.White);
                Funktionen.RefreshLabel(lbLehrer10, null, Color.White);
            }
            else
            {
                Stundenplan.struct_stunde[] stunden = null;

                switch (D.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        stunden = sp.week.Monday;
                        break;
                    case DayOfWeek.Tuesday:
                        stunden = sp.week.Tuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        stunden = sp.week.Wednesday;
                        break;
                    case DayOfWeek.Thursday:
                        stunden = sp.week.Thursday;
                        break;
                    case DayOfWeek.Friday:
                        stunden = sp.week.Friday;
                        break;
                    case DayOfWeek.Saturday:
                        stunden = sp.week.Saturday;
                        break;
                }

                if (stunden != null)
                {
                    if (currhour == 0)
                        Funktionen.RefreshLabel(lbLehrer1, stunden[0].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer1, stunden[0].fach, Color.White);

                    if (currhour == 1)
                        Funktionen.RefreshLabel(lbLehrer2, stunden[1].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer2, stunden[1].fach, Color.White);

                    if (currhour == 2)
                        Funktionen.RefreshLabel(lbLehrer3, stunden[2].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer3, stunden[2].fach, Color.White);

                    if (currhour == 3)
                        Funktionen.RefreshLabel(lbLehrer4, stunden[3].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer4, stunden[3].fach, Color.White);

                    if (currhour == 4)
                        Funktionen.RefreshLabel(lbLehrer5, stunden[4].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer5, stunden[4].fach, Color.White);

                    if (currhour == 5)
                        Funktionen.RefreshLabel(lbLehrer6, stunden[5].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer6, stunden[5].fach, Color.White);

                    if (currhour == 6)
                        Funktionen.RefreshLabel(lbLehrer7, stunden[6].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer7, stunden[6].fach, Color.White);

                    if (currhour == 7)
                        Funktionen.RefreshLabel(lbLehrer8, stunden[7].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer8, stunden[7].fach, Color.White);

                    if (currhour == 8)
                        Funktionen.RefreshLabel(lbLehrer9, stunden[8].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer9, stunden[8].fach, Color.White);

                    if (currhour == 9)
                        Funktionen.RefreshLabel(lbLehrer10, stunden[9].fach, Color.FromArgb(244, 244, 159));
                    else
                        Funktionen.RefreshLabel(lbLehrer10, stunden[9].fach, Color.White);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            //Außerhalb der Schulzeit
            if (now.DayOfWeek == DayOfWeek.Sunday || now.Hour < sp.zeit[0].start.Hour || now.Hour > sp.zeit[9].end.Hour)
            {
                if (lbAktuellerLehrer.Text != "")
                    lbAktuellerLehrer.Text = "";
                if (lbAktuelleStunde.Text != "")
                    lbAktuelleStunde.Text = "";
                if (lbAktuelleZeitVerbleibend.Text != "")
                    lbAktuelleZeitVerbleibend.Text = "";

                if (lbInfo.Text != "Außerhalb der Schulzeit")
                    lbInfo.Text = "Außerhalb der Schulzeit";
                if (lbInfo.Visible == false)
                    lbInfo.Visible = true;

                RefreshCurrDay(-1);
            }
            //Schulzeit
            else
            {
                int hour = -1;

                string lehrer = string.Empty;
                string fach = string.Empty;
                string zeit = string.Empty;

                switch (now.DayOfWeek)
                {
                    //Montag
                    case DayOfWeek.Monday:
                        for (int i = 0; i < sp.week.Monday.Length; i++)
                        {
                            if (Funktionen.InTimeRange(now, sp.zeit[i].start, sp.zeit[i].end))
                            {
                                if (sp.week.Monday[i].lehrer != null && sp.week.Monday[i].fach != null)
                                {
                                    if (sp.week.Monday[i].lehrer != "")
                                    {
                                        lehrer = sp.week.Monday[i].lehrer;
                                        fach = sp.week.Monday[i].fach;
                                        zeit = Funktionen.TimeSpanString(now, sp.zeit[i].end);
                                        hour = i;
                                    }

                                    break;
                                }
                            }
                        }

                        RefreshCurrDay(hour);

                        break;

                    //Dienstag
                    case DayOfWeek.Tuesday:
                        for (int i = 0; i < sp.week.Tuesday.Length; i++)
                        {
                            if (Funktionen.InTimeRange(now, sp.zeit[i].start, sp.zeit[i].end))
                            {
                                if (sp.week.Tuesday[i].lehrer != null && sp.week.Tuesday[i].fach != null)
                                {
                                    if (sp.week.Tuesday[i].lehrer != "")
                                    {
                                        lehrer = sp.week.Tuesday[i].lehrer;
                                        fach = sp.week.Tuesday[i].fach;
                                        zeit = Funktionen.TimeSpanString(now, sp.zeit[i].end);
                                        hour = i;
                                    }

                                    break;
                                }
                            }
                        }

                        RefreshCurrDay(hour);

                        break;


                    //Mittwoch
                    case DayOfWeek.Wednesday:
                        for (int i = 0; i < sp.week.Wednesday.Length; i++)
                        {
                            if (Funktionen.InTimeRange(now, sp.zeit[i].start, sp.zeit[i].end))
                            {
                                if (sp.week.Wednesday[i].lehrer != null && sp.week.Wednesday[i].fach != null)
                                {
                                    if (sp.week.Wednesday[i].lehrer != "")
                                    {
                                        lehrer = sp.week.Wednesday[i].lehrer;
                                        fach = sp.week.Wednesday[i].fach;
                                        zeit = Funktionen.TimeSpanString(now, sp.zeit[i].end);
                                        hour = i;
                                    }

                                    break;
                                }
                            }
                        }

                        RefreshCurrDay(hour);

                        break;


                    //Donnerstag
                    case DayOfWeek.Thursday:
                        for (int i = 0; i < sp.week.Thursday.Length; i++)
                        {
                            if (Funktionen.InTimeRange(now, sp.zeit[i].start, sp.zeit[i].end))
                            {
                                if (sp.week.Thursday[i].lehrer != null && sp.week.Thursday[i].fach != null)
                                {
                                    if (sp.week.Thursday[i].lehrer != "")
                                    {
                                        lehrer = sp.week.Thursday[i].lehrer;
                                        fach = sp.week.Thursday[i].fach;
                                        zeit = Funktionen.TimeSpanString(now, sp.zeit[i].end);
                                        hour = i;
                                    }

                                    break;
                                }
                            }
                        }

                        RefreshCurrDay(hour);

                        break;


                    //Freitag
                    case DayOfWeek.Friday:
                        for (int i = 0; i < sp.week.Friday.Length; i++)
                        {
                            if (Funktionen.InTimeRange(now, sp.zeit[i].start, sp.zeit[i].end))
                            {
                                if (sp.week.Friday[i].lehrer != null && sp.week.Friday[i].fach != null)
                                {
                                    if (sp.week.Friday[i].lehrer != "")
                                    {
                                        lehrer = sp.week.Friday[i].lehrer;
                                        fach = sp.week.Friday[i].fach;
                                        zeit = Funktionen.TimeSpanString(now, sp.zeit[i].end);
                                        hour = i;
                                    }

                                    break;
                                }
                            }
                        }

                        RefreshCurrDay(hour);

                        break;


                    //Samstag
                    case DayOfWeek.Saturday:
                        for (int i = 0; i < sp.week.Saturday.Length; i++)
                        {
                            if (Funktionen.InTimeRange(now, sp.zeit[i].start, sp.zeit[i].end))
                            {
                                if (sp.week.Saturday[i].lehrer != null && sp.week.Saturday[i].fach != null)
                                {
                                    if (sp.week.Saturday[i].lehrer != "")
                                    {
                                        lehrer = sp.week.Saturday[i].lehrer;
                                        fach = sp.week.Saturday[i].fach;
                                        zeit = Funktionen.TimeSpanString(now, sp.zeit[i].end);
                                        hour = i;
                                    }

                                    break;
                                }
                            }
                        }

                        RefreshCurrDay(hour);

                        break;

                }

                if (hour == -1)
                {
                    //Pause
                    if (lbAktuellerLehrer.Text != "")
                        lbAktuellerLehrer.Text = "";
                    if (lbAktuelleStunde.Text != "")
                        lbAktuelleStunde.Text = "";
                    if (lbAktuelleZeitVerbleibend.Text != "")
                        lbAktuelleZeitVerbleibend.Text = "";

                    if (lbInfo.Text != "Pause")
                        lbInfo.Text = "Pause";
                    if (lbInfo.Visible == false)
                        lbInfo.Visible = true;

                    //Tracker
                    if (tracker != null)
                        tracker.SetData("Pause", "", "");
                }
                else
                {
                    //Unterricht
                    if (lbAktuellerLehrer.Text != lehrer)
                        lbAktuellerLehrer.Text = lehrer;
                    if (lbAktuelleStunde.Text != fach)
                        lbAktuelleStunde.Text = fach;
                    if (lbAktuelleZeitVerbleibend.Text != zeit)
                        lbAktuelleZeitVerbleibend.Text = zeit;

                    if (lbInfo.Visible)
                        lbInfo.Visible = false;

                    //Tracker
                    if (tracker != null)
                        tracker.SetData(lehrer, fach, zeit);
                }
            }
        }

        private void timerFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.05;
            if (this.Opacity >= 1)
            {
                this.Opacity = 1;
                timerFadeIn.Enabled = false;
            }
        }

        private void trackerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (tracker == null)
            {
                tracker = new FormTracker(cfg);

                if (cfg["TrackerX", -1] != -1 && cfg["TrackerY", -2] != -2)
                {
                    tracker.Left = cfg["TrackerX", 0];
                    tracker.Top = cfg["TrackerY", 0];
                    tracker.Width = cfg["TrackerW", 0];
                }
                else
                {
                    Funktionen.SnapWindow(tracker, trackerpos, 5);
                }

                Funktionen.CheckFormLocation(tracker);

                tracker.Show();

                tracker.TopMost = cfg["TrackerOnTop", true];

                trackerToolStripMenuItem.Checked = true;
            }
            else
            {
                tracker.Close();
                tracker = null;

                trackerToolStripMenuItem.Checked = false;
            }
        }

        private void SetTrackerPos(DesktopEdge pos)
        {
            if (tracker != null)
            {
                Funktionen.SnapWindow(tracker, pos, 5);
            }

            trackerpos = pos;
        }

        private void linksObenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTrackerPos(DesktopEdge.TopLeft);
        }

        private void rechtsObenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTrackerPos(DesktopEdge.TopRight);
        }

        private void untenLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTrackerPos(DesktopEdge.BottomLeft);
        }

        private void untenRechtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTrackerPos(DesktopEdge.BottomRight);
        }

        private void positionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            linksObenToolStripMenuItem.Checked = (trackerpos == DesktopEdge.TopLeft);
            rechtsObenToolStripMenuItem.Checked = (trackerpos == DesktopEdge.TopRight);
            untenLinksToolStripMenuItem.Checked = (trackerpos == DesktopEdge.BottomLeft);
            untenRechtsToolStripMenuItem.Checked = (trackerpos == DesktopEdge.BottomRight);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationExit();
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            cfg["MainX"] = this.Left;
            cfg["MainY"] = this.Top;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 90;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 80;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 70;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 60;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 50;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 40;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 30;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 20;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 10;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cfg["TrackerOpacity"] = 100;
        }

        private void immerImVordergrundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cfg["TrackerOnTop"] = immerImVordergrundToolStripMenuItem.Checked;

            if (tracker != null)
            {
                tracker.TopMost = immerImVordergrundToolStripMenuItem.Checked;
            }
        }
    }
}
