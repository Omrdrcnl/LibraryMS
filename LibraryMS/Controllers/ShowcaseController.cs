using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;
using LibraryMS.Models.Classes;
using Microsoft.Ajax.Utilities;

namespace LibraryMS.Controllers
{
    public class ShowcaseController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();

        // GET: Showcase
        [HttpGet]
        public ActionResult Index()
        {
            //Asagıda ki 3 satırda about ve books degerlerini indexe gönderiyoruz. Oradada modele atama yapıyoruz.
            Class1 cs = new Class1();
            
            cs.about = db.tblAbout.ToList();
            cs.books = db.tblBook.ToList();

            //var values = db.tblBook.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(tblContact c)
        {
            db.tblContact.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}