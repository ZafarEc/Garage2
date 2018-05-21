using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class ParkedVehicle
    {
        public string Type { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have a registration number")]
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }


    }
}