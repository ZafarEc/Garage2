﻿using Garage2Mvc.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class ParkedVehicle
    {
       

        public int Id { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "You have to have a vehicle Type")]
       //public VehicleType  VehicleType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have a registration number")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "A name must be between 4 and 8 letters long")]
        public string RegistrationNumber { get; set; }

        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "plese enter upper case lower case alphabet only ")]
        public string Color { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have a vehicle Brand")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "A name must be between 2 and 15 letters long")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "plese enter upper case lower case alphabet only ")]
        public string Brand { get; set; }
        public string Model { get; set; }
        [Range(2,12, ErrorMessage = "plese enter a valid wheel number")]
        public int NumberOfWheels { get; set; }

        //public DateTime Time { get; }
        [Display(Name = "CheckIn")]
        public  DateTime ParkTime  { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        [ForeignKey("VehicleType")]
        public int VTId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
      
    }
   //public enum VehicleType
   // {
   //     Bus,
   //     Car,
   //     MotorCycle
        

   // }
} 