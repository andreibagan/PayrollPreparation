using System.Data.Entity;

namespace PayrollPreparation.BL.Models
{
    public class PayrollContext : DbContext
    {
        public PayrollContext() : base("PayrollConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Kindred> Kindreds { get; set; }
        public DbSet<TariffScale> TariffScales { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<Month> Months { get; set; }
    }
}
