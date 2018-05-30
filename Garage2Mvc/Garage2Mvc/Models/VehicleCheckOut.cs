using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class VehicleCheckOut
    {
        public VehicleCheckOut(int id, string registrationNumber, DateTime parkTime, DateTime nowTime)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            ParkTime = parkTime;
            NowTime = nowTime;
        }
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ParkTime { get; set; }
        public DateTime NowTime { get; set; }

    }
}