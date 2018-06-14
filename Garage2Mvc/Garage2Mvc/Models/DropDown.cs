using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2Mvc.Models
{
    public class DropDown
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have first name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "plese enter upper case lower case alphabet only ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have last name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "plese enter upper case lower case alphabet only ")]
        public string LastName { get; set; }

        [Range(2, 12, ErrorMessage = "plese enter a valid Phone number")]
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        //public string Address { get; set; }

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
        public int NumberOfWheels { get; set; }

        public List<SelectListItem> MemberList { get; set; }
        public List<SelectListItem> VehicleTypeList { get; set; }



    }
}