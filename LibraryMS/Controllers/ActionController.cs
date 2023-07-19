using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    
    public class ActionController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Action
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LendBook()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult LendBook(tblAction p)
        {
            
            db.tblAction.Add(p);
            db.SaveChanges();
            return RedirectToAction("LendBook");
        }
        public ActionResult BorrowBook()
        {
            return View();
        }
    }
}