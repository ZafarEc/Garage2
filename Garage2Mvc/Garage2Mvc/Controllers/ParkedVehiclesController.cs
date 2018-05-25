using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        public ActionResult Index(string searchString)
        {
            var parkedVehicles = from s in db.ParkedVehicles
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                 parkedVehicles = parkedVehicles.Where(s => s.RegistrationNumber.Contains(searchString)
                                       || s.Model.Contains(searchString));
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


            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind(Include = "Id,VehicleType,RegistrationNumber,Color,Brand,Model,NumberOfWheels,ParkTime")]
        //ParkedVehicle parkedVehicle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleType VehicleType, string RegistrationNumber,  string Color, string Brand, string Model, int NumberOfWheels)
        {
            ParkedVehicle parkedVehicle = new ParkedVehicle()
            {
                VehicleType = VehicleType,
                RegistrationNumber = RegistrationNumber,
                Color = Color,
                Brand = Brand,
                Model = Model,
                NumberOfWheels = NumberOfWheels,
                ParkTime = DateTime.Now

            };

            if (ModelState.IsValid)
            {
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

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
        public ActionResult Edit([Bind(Include = "Id,Type,RegistrationNumber,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("CheckOut")] // Delete
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
