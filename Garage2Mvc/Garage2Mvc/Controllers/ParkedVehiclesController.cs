using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2Mvc.DataAccesslayer;
using Garage2Mvc.Models;


namespace Garage2Mvc.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private StorageContext db = new StorageContext();

        // GET: ParkedVehicles
        public ActionResult Index(string sortOrder,string searchString)
        {
            ViewBag.DateSortVehicle = sortOrder == "Date" ? "date_desc" : "Date";
            var parkedVehicles = from s in db.ParkedVehicles
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                 parkedVehicles = parkedVehicles.Where(s => s.RegistrationNumber.Contains(searchString)
                                       || s.Model.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "Date":
                    parkedVehicles = parkedVehicles.OrderBy(s => s.ParkTime);
                    break;
                case "date_desc":
                    parkedVehicles = parkedVehicles.OrderByDescending(s => s.ParkTime);
                    break;
                default:
                    parkedVehicles = parkedVehicles.OrderBy(s => s.VehicleType.VTName);
                    break;
            }
            return View(parkedVehicles.ToList());
        }
        public ActionResult Vehicles()
        {
            var model = db.ParkedVehicles.ToList();
            return View(model);

        }
        //public ActionResult CheckOut()
        //{
        //    return View();
        //}

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            var model = new ParkedVehicleViewModel()
            {
                Members = db.Members,
                ValidVehicleTypes = db.VehicleTypes
            };
          
            return View(model);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind(Include = "Id,VehicleType,RegistrationNumber,Color,Brand,Model,NumberOfWheels,ParkTime")]
        //ParkedVehicle parkedVehicle
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Create( string RegistrationNumber,  string Color, string Brand, string Model, int NumberOfWheels)
        // {
        //     ParkedVehicle parkedVehicle = new ParkedVehicle()
        //     {
        //         MemberId = 4,
        //         //VehicleType = VehicleType,
        //         RegistrationNumber = RegistrationNumber,
        //         Color = Color,
        //         Brand = Brand,
        //         Model = Model,
        //         NumberOfWheels = NumberOfWheels,
        //         ParkTime = DateTime.Now,
        //         VTId = 1


        //     };

        //     if (ModelState.IsValid)
        //     {
        //         db.ParkedVehicles.Add(parkedVehicle);
        //         db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }

        //     return View(parkedVehicle);
        // }
        //upon old

      //  POST: ParkedVehicles/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,Color,Brand,Model,VTId,NumberOfWheels,MemberID")] ParkedVehicleViewModel pVModel)
        {
            //DateTime CheckIn = DateTime.Now;

            var parkedVehicle = new ParkedVehicle()
            {
                ParkTime = DateTime.Now,
                Brand = pVModel.Brand,
                RegistrationNumber = pVModel.RegistrationNumber,
                Model = pVModel.Model,
                NumberOfWheels = pVModel.NumberOfWheels,
                Color = pVModel.Color,
                MemberId = pVModel.MemberId,
                VTId = pVModel.VTId              

            };
            //db.Vehicles.Any(p => p.RegNumber == c);
            //var no = db.Vehicles.FirstOrDefault(w => w.Id == );
            //if (no == null)

            try
            {


                if (ModelState.IsValid)
                {
                    db.ParkedVehicles.Add(parkedVehicle);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }







            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateMembersDropDownList(parkedVehicle.MemberId);

            return View(parkedVehicle);
        }


        private void PopulateMembersDropDownList(object selectedMember = null)
        {
            var membersQuery = from d in db.Members
                               orderby d.FirstName
                               select d;
            ViewBag.MemberId = new SelectList(membersQuery, "MemberID", "FirstName", selectedMember);
        }










        //End
        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleType,RegistrationNumber,Color,Brand,Model,NumberOfWheels,ParkTime")] ParkedVehicle parkedVehicle)
        {
            //ParkedVehicle temVehicle = db.ParkedVehicles.Find(parkedVehicle.Id);
            //parkedVehicle.ParkTime = temVehicle.ParkTime;
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult CheckOut(int? id)// Delete
        {
            if (id == null)
            {
                return RedirectToAction("Index");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            ParkedVehicle p = db.ParkedVehicles.Find(id);
            VehicleCheckOut parkedVehicle = new VehicleCheckOut(p.Id, p.RegistrationNumber, p.ParkTime, DateTime.Now);

            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }




// POST: ParkedVehicles/Delete/5
        [HttpPost] // Delete
        [ValidateAntiForgeryToken]
        public ActionResult Receipt(int id)
        {
            var t = DateTime.Now - db.ParkedVehicles.Find(id).ParkTime;
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            VehicleReceipt vehicleReceipt = new VehicleReceipt(parkedVehicle.Id, parkedVehicle.RegistrationNumber,parkedVehicle.ParkTime,/* DateTime.Now,*/t);
          
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return View(vehicleReceipt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
