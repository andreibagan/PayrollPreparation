using PayrollPreparation.BL.Models;
using System;
using System.Collections.Generic;

namespace PayrollPreparation.BL
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfHiring { get; set; }
        public string SickOfChaes { get; set; }
        public string LiquidatorChaes { get; set; }
        public string Hero { get; set; }
        public string GPW { get; set; }
        public string Invalid { get; set; }
        public string PassportCode { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportDateFrom { get; set; }
        public DateTime PassportDateTo { get; set; }
        public string PassportGave { get; set; }

        public int TariffScaleId { get; set; }
        public virtual TariffScale TariffScale { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int EducationId { get; set; }
        public virtual Education Education { get; set; }

        public virtual ICollection<Kindred> Kindreds { get; set; }
        public virtual ICollection<WorkingTime> WorkingTimes { get; set; }
    }
}
