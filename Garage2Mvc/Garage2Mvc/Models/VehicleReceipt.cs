using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2Mvc.Models
{
    public class VehicleReceipt
    {

        public VehicleReceipt(int id,string registrationNumber,DateTime parkTime, DateTime nowTime, TimeSpan totalTime )

        {

            Id = id;
            RegistrationNumber = registrationNumber;
            ParkTime = parkTime;
            NowTime = nowTime;
            TotalTime = totalTime;

        }

        public int Id { get; set; }
        public string  RegistrationNumber { get; set; }
        public DateTime ParkTime { get; set; }
        public DateTime NowTime { get; set; }
        public TimeSpan TotalTime { get; set; }



    }
}