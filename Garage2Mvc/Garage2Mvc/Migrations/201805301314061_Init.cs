namespace Garage2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleType = c.Int(nullable: false),
                        RegistrationNumber = c.String(nullable: false, maxLength: 8),
                        Color = c.String(),
                        Brand = c.String(nullable: false, maxLength: 15),
                        Model = c.String(),
                        NumberOfWheels = c.Int(nullable: false),
                        ParkTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleReceipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        ParkTime = c.DateTime(nullable: false),
                        TotalTime = c.Time(nullable: false, precision: 7),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleReceipts");
            DropTable("dbo.ParkedVehicles");
        }
    }
}
