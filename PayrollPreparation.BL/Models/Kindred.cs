using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollPreparation.BL.Models
{
    public class Kindred
    {
        public int KindredId { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string Kinsfolk { get; set; }
        public string Invalid { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
