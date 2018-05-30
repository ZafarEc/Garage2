namespace Garage2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleReceipt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleReceipts", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleReceipts", "Price");
        }
    }
}
