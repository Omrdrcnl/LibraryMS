using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    
    public class AuthorController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Author
        public ActionResult Index()
        {
            var a = db.tblAuthor.ToList();
            return View(a);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            //List<SelectListItem> list = (from i in db.tblAuthor.ToList()
            //                             select new SelectListItem
            //                             {
            //                                 Text = i.Name,
            //                                 Value = i.Id.ToString(),
            //                             }).ToList();
            //ViewBag.Author = list;
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(tblAuthor a)
        {
            var values = db.tblAuthor.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAuthor(int id)
        {
            var d=db.tblAuthor.Find(id);
            db.tblAuthor.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallAuthor(int id)
        {
            var auth = db.tblAuthor.Find(id);
            return View("CallAuthor",auth);
        }
        
        public ActionResult EditAuthor(tblAuthor p)
        {
            var yazar = db.tblAuthor.Find(p.Id);
            yazar.Name = p.Name;
            yazar.Surname = p.Surname;
            yazar.Detail = p.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}