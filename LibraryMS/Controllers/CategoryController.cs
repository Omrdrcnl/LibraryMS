using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Models.Entity;
using LibraryMS.Controllers;
using System.Diagnostics.Contracts;

namespace LibraryMS.Controllers
{
    public class CategoryController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Category
        public ActionResult Index()
        {
            var d = db.tblCategory.ToList();

            return View(d);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(tblCategory c)
        {
            db.tblCategory.Add(c);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = db.tblCategory.Find(id);
            db.tblCategory.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult CallCategory()
        //{      
        //    return View();
        //}
        //[HttpPost]
        public ActionResult CallCategory(int id)
        {
            var ctg = db.tblCategory.Find(id);

            return View("CallCategory",ctg);
        }


        //[HttpGet]
        //public ActionResult EditCategory()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult EditCategory(tblCategory c)
        {
            var ktg = db.tblCategory.Find(c.Id);
            ktg.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}