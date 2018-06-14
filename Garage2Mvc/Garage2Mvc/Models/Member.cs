using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class Member
    {
                
          
            public int MemberId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have first name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "plese enter upper case lower case alphabet only ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to have last name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "plese enter upper case lower case alphabet only ")]
         public string LastName { get; set; }

        //[Range(0, 12, ErrorMessage = "plese enter a valid Phone number")]
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
          



            public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }


    }
}