namespace Garage2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleReceipts", "TotalTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleReceipts", "TotalTime");
        }
    }
}
