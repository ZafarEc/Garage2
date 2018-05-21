using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Garage2Mvc.DataAccesslayer
{
    public class StorageContext : DbContext
    {
        public StorageContext() : base ("DefaultConnection1")
        {

        }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }

    }
}