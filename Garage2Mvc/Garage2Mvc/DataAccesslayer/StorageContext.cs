using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Garage2Mvc.DataAccesslayer
{
    public class StorageContext : DbContext
    {
        public StorageContext() : base ("ZafarCathy")
        {

        }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }

        public DbSet<Garage2Mvc.Models.Member> Members { get; set; }
    }
}