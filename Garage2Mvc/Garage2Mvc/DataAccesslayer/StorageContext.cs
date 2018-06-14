using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Garage2Mvc.DataAccesslayer
{
    public class StorageContext : DbContext
    {
        public StorageContext() : base ("ZafarCathy1 ")
        {

        }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }

         public System.Data.Entity.DbSet<Garage2Mvc.Models.Member> Members { get; set; }

        

        public System.Data.Entity.DbSet<Garage2Mvc.Models.VehicleType> VehicleTypes { get; set; }

      //public System.Data.Entity.DbSet<Garage2Mvc.Models.VehicleReceipt> VehicleReceipts { get; set; }


    }
}