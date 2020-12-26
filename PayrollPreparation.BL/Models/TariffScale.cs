using System.Collections;
using System.Collections.Generic;

namespace PayrollPreparation.BL
{
    public class TariffScale
    {
        public int TariffScaleId { get; set; }
        public int TariffRate { get; set; }
        public double Сoefficient { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
