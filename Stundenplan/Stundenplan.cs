using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StundenplanApplication
{
    public class Stundenplan
    {
        //Zeiten
        public struct struct_zeit
        {
            public DateTime start;
            public DateTime end;
        }
        public struct_zeit[] zeit;

        public void Init(int hours)
        {
            zeit = new struct_zeit[hours];
            teacher = new List<struct_teacher>();

            week.Monday = new struct_stunde[hours];
            week.Tuesday = new struct_stunde[hours];
            week.Wednesday = new struct_stunde[hours];
            week.Thursday = new struct_stunde[hours];
            week.Friday = new struct_stunde[hours];
            week.Saturday = new struct_stunde[hours];

            InitTimes();
        }

        private void InitTimes()
        {
            if (zeit.Length > 9)
            {
                zeit[0].start = new DateTime(2000, 1, 1, 08, 00, 00);
                zeit[0].end = new DateTime(2000, 1, 1, 08, 45, 00);

                zeit[1].start = new DateTime(2000, 1, 1, 08, 50, 00);
                zeit[1].end = new DateTime(2000, 1, 1, 09, 35, 00);

                zeit[2].start = new DateTime(2000, 1, 1, 09, 55, 00);
                zeit[2].end = new DateTime(2000, 1, 1, 10, 40, 00);

                zeit[3].start = new DateTime(2000, 1, 1, 10, 45, 00);
                zeit[3].end = new DateTime(2000, 1, 1, 11, 30, 00);

                zeit[4].start = new DateTime(2000, 1, 1, 11, 50, 00);
                zeit[4].end = new DateTime(2000, 1, 1, 12, 35, 00);

                zeit[5].start = new DateTime(2000, 1, 1, 12, 40, 00);
                zeit[5].end = new DateTime(2000, 1, 1, 13, 25, 00);

                zeit[6].start = new DateTime(2000, 1, 1, 13, 30, 00);
                zeit[6].end = new DateTime(2000, 1, 1, 14, 15, 00);

                zeit[7].start = new DateTime(2000, 1, 1, 15, 00, 00);
                zeit[7].end = new DateTime(2000, 1, 1, 15, 45, 00);

                zeit[8].start = new DateTime(2000, 1, 1, 16, 00, 00);
                zeit[8].end = new DateTime(2000, 1, 1, 16, 45, 00);

                zeit[9].start = new DateTime(2000, 1, 1, 17, 00, 00);
                zeit[9].end = new DateTime(2000, 1, 1, 17, 45, 00);
            }
        }

        public DateTime GetHourTime(int hour, bool start)
        {
            if (hour >= 0 && hour <= zeit.Length)
            {
                if (start)
                    return zeit[hour].start;
                else
                    return zeit[hour].end;
            }

            return new DateTime(2000, 1, 1, 0, 0, 0);
        }

        //Lehrer
        public struct struct_teacher
        {
            public string name;
            public List<string> fach;
        }
        public List<struct_teacher> teacher;

        //Stunenplan
        public struct struct_stunde
        {
            public string lehrer;
            public string fach;
        }

        public struct struct_week
        {
            public struct_stunde[] Monday;
            public struct_stunde[] Tuesday;
            public struct_stunde[] Wednesday;
            public struct_stunde[] Thursday;
            public struct_stunde[] Friday;
            public struct_stunde[] Saturday;
        }
        public struct_week week;
    }
}
