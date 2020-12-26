using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollPreparation.BL.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
