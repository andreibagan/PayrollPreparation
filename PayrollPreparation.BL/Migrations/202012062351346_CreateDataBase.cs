namespace PayrollPreparation.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkingTimes", "Count", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkingTimes", "Count", c => c.Int(nullable: false));
        }
    }
}
