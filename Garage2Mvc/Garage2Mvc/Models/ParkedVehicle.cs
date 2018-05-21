﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class ParkedVehicle
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have a vehicle Type")]
        [StringLength (15, MinimumLength = 2, ErrorMessage = "A name must be between 2 and 15 letters long")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have a registration number")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "A name must be between 4 and 8 letters long")]
        public string RegistrationNumber { get; set; }


        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Range(2,12, ErrorMessage = "This not a valid wheel number")]
        public int NumberOfWheels { get; set; }


    }
}