using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    public class BookController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Book
        public ActionResult Index()
        {
            var values = db.tblBook.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(tblBook b)
        {
            db.tblBook.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.tblBook.Find(id);
            db.tblBook.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult CallBook(tblBook b)
        {
            var book = db.tblBook.Find(b.Id);

            return View("Callbook",book);
        }
        public ActionResult EditBook(tblBook b)
        {
            var newbook = db.tblBook.Find(b.Id);
            newbook.Name = b.Name;
            newbook.Author = b.Author;
            newbook.Category = b.Category;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}