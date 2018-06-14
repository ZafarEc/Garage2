using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class VehicleType
    {
        [Key]
        public int VTId { get; set; }
        public string VTName { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}