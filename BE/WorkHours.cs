using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class WorkHours
    {
        static int workHoursStaticId = 1000;

        public int Id = workHoursStaticId++;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Date { get { return Start.ToShortDateString(); } }
        public string StartTime { get { return Start.ToShortTimeString(); } }
        public string EndTime { get { return End.ToShortTimeString(); } }
        public string TotalHours { get { return String.Format("{0:F2}", (End - Start).TotalHours); } }
    }
}
