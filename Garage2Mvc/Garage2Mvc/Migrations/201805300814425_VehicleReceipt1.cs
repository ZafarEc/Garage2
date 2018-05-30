namespace Garage2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleReceipt1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VehicleReceipts", "NowTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleReceipts", "NowTime", c => c.DateTime(nullable: false));
        }
    }
}
