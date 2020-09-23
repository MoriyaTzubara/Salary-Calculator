using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BL : IBL
    {
        IDAL DAL = new DAL.DAL();
        Work work;
        public void addTime(DateTime start, DateTime end)
        {
            work = DAL.getWork();
            work.WorkHours.Add(new WorkHours() { Start = start, End = end });
            DAL.setWork(work);
        }

        public void deleteTime(IEnumerable<WorkHours> workHoursToDelete)
        {
            work = DAL.getWork();
            foreach (var workHour in workHoursToDelete)
            {
                work.WorkHours.RemoveAll(wh => wh.Id == workHour.Id);
            }
            DAL.setWork(work);
        }

        public double GetTotalHours()
        {
            return DAL.getWork().GetTotalHours();
        }

        public double GetTotalSalary()
        {
            return DAL.getWork().GetTotalSalary();
        }

        public Work getWork()
        {
            return DAL.getWork();
        }

        public void setWork(Work _work)
        {
            DAL.setWork(_work);
        }
    }
}
