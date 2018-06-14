using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2Mvc.DataAccesslayer;
using Garage2Mvc.Models;

namespace Garage2Mvc.Controllers
{
    public class MembersController : Controller
    {
        private StorageContext db = new StorageContext();

        // GET: Members
        public ActionResult Index()
        {
            //DropDown membli = new DropDown();
            //membli.MemberList = PopulateMemberList();
            //return View(membli);
            return View(db.Members.ToList());
        }
        //[HttpPost]
        //public ActionResult Index(DropDown membli)
        //{
        //    membli.MemberList = PopulateMemberList();
        //    var selectedList = membli.MemberList.Find(p => p.Value == membli.FirstName.ToString());
        //    if (selectedList != null)
        //    {
        //        selectedList.Selected = true;
        //        ViewBag.Message = "MemberName: " + selectedList.Text;
        //    }
        //    return View(membli);
        //}

        //private List<SelectListItem> PopulateMemberList()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
          
        //        string query = " SELECT FruitName, FruitId FROM Fruits";
               
         

        //    return items;

        //}

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        //// GET: Members/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Search(string search)
        {
           
            var member = db.Members.Where(s => s.PhoneNo.Contains(search));

            return View("Index", member);
            
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PhoneNo,Email,Address")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNo,Email,Address")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
