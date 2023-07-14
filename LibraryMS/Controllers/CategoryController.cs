using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Models.Entity;
using LibraryMS.Controllers;

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
        public ActionResult AddCategory(tblCategory c)
        {
            db.tblCategory.Add(c);
            db.SaveChanges();
            return View();
        }
    }
}