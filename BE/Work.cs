using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 namespace BE
{
    public class Work
    {
        public double MoneyPerHour { get; set; }
        public List<WorkHours> WorkHours { get; set; }
        
        public Work()
        {
            WorkHours = new List<WorkHours>();
        }
        public double GetTotalHours()
        {
            double allHours = 0;
            foreach (var time in WorkHours)
            {
                allHours += (time.End - time.Start).TotalHours;
            }
            return allHours;
        }
        public double GetTotalSalary()
        {
            return GetTotalHours() * MoneyPerHour;
        }
        public void addTime(DateTime start, DateTime end)
        {
            WorkHours.Add(new WorkHours() { Start = start, End = end });
        }
        public void deleteTime(IEnumerable<WorkHours> workHoursToDelete)
        {
            foreach (var workHour in workHoursToDelete)
            {
                WorkHours.RemoveAll(wh => wh.Id == workHour.Id);
            }
        }
    }
}
