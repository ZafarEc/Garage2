namespace Garage2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationVehicleReceipt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleReceipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        ParkTime = c.DateTime(nullable: false),
                        NowTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleReceipts");
        }
    }
}
