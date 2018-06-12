﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }

        public static implicit operator Member(string v)
        {
            throw new NotImplementedException();
        }
    }
}