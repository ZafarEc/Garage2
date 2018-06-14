namespace Garage2Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(nullable: false, maxLength: 8),
                        Color = c.String(),
                        Brand = c.String(nullable: false, maxLength: 15),
                        Model = c.String(),
                        NumberOfWheels = c.Int(nullable: false),
                        ParkTime = c.DateTime(nullable: false),
                        MemberId = c.Int(nullable: false),
                        VTId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VTId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.VTId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VTId = c.Int(nullable: false, identity: true),
                        VTName = c.String(),
                    })
                .PrimaryKey(t => t.VTId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "VTId", "dbo.VehicleTypes");
            DropForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "VTId" });
            DropIndex("dbo.ParkedVehicles", new[] { "MemberId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.ParkedVehicles");
            DropTable("dbo.Members");
        }
    }
}
