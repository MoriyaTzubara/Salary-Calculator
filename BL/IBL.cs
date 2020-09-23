using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
    {
        Work getWork();
        void setWork(Work _work);
        double GetTotalHours();
        double GetTotalSalary();
        void addTime(DateTime start, DateTime end);
        void deleteTime(IEnumerable<WorkHours> workHoursToDelete);
    }
}
