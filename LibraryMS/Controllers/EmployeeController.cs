using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    
    public class EmployeeController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var per = db.tblEmployee.ToList();
            return View(per);
        }
        public ActionResult DeleteEmployee(int id)
        {
            var per =db.tblEmployee.Find(id);
            db.tblEmployee.Remove(per);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(tblEmployee p)
        {
            //Model.state.isvalid yani method şartını sağlamadıysak
            if (!ModelState.IsValid)
            {
                
                return View("AddEmployee");
            }
            db.tblEmployee.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallEmployee(tblEmployee p)
        {
            var per = db.tblEmployee.Find(p.Id);
            return View("CallEmployee",per);
        }
        public ActionResult EditEmployee(tblEmployee p)
        {
            var per = db.tblEmployee.Find(p.Id);
            per.Name = p.Name;
            per.Surname = p.Surname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult EditEmployee(tblEmployee p)
        //{
        //    if (p != null && p.Id > 0)
        //    {
        //        var per = db.tblEmployee.Find(p.Id);
        //        if (per != null)
        //        {
        //            per.Name = p.Name;
        //            per.Surname = p.Surname;
        //            db.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

    }
}