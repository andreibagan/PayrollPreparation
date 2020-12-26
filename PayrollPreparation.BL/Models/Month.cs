using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollPreparation.BL.Models
{
    public class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }

        public virtual ICollection<WorkingTime> WorkingTimes { get; set; }
    }
}
