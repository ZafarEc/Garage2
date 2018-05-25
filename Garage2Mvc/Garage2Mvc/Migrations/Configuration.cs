namespace Garage2Mvc.Migrations
{
    using Garage2Mvc.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2Mvc.DataAccesslayer.StorageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2Mvc.DataAccesslayer.StorageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ParkedVehicle vhe = new ParkedVehicle() {VehicleType =VehicleType.Bus ,RegistrationNumber="ABC542",Color ="Black",Brand= "Volovo",Model="xc90",NumberOfWheels= 4, ParkTime = DateTime.Now};
            context.ParkedVehicles.AddOrUpdate(t => t.VehicleType, vhe);


        }
    }
}
