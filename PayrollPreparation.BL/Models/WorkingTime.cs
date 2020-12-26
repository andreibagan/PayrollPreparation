using PayrollPreparation.BL.Models;
using System;

namespace PayrollPreparation.BL
{
    public class WorkingTime
    {
        public int WorkingTimeId { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public string Count { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int MonthId { get; set; }
        public virtual Month Month { get; set; }
    }
}
