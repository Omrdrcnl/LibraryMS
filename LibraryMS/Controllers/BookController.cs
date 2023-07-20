using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    public class BookController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Book
        public ActionResult Index(string p)
        {
            //arama yapma
            var books = from b in db.tblBook select b;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(b => b.Name.Contains(p));
            }
            //var books = db.tblBook.ToList();
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            // Categori tablosunu liste olarak getirmek için Liste oluşturuyoruz.
            List<SelectListItem> value = (from i in db.tblCategory.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name,            // display member
                                              Value = i.Id.ToString(), //value member
                                          }).ToList();
            //taşıma işlemi --kategorileri taşıyacak
            ViewBag.Book = value;
            //yazar işlemleri
            List<SelectListItem> value2 = (from i in db.tblAuthor.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.Id.ToString(),
                                           }).ToList();
            ViewBag.Author = value2;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(tblBook b)
        {
            var cat = db.tblCategory.Where(c => c.Id == b.tblCategory.Id).FirstOrDefault();
            var aut = db.tblAuthor.Where(a => a.Id == b.tblAuthor.Id).FirstOrDefault(); if (cat != null && aut != null)
                b.tblAuthor = aut;
            b.tblCategory = cat;
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
            List<SelectListItem> value = (from i in db.tblCategory.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name,            // display member
                                              Value = i.Id.ToString(), //  value member
                                          }).ToList();
            ViewBag.Book = value;
            List<SelectListItem> value2 = (from i in db.tblAuthor.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.Id.ToString(),
                                           }).ToList();
            ViewBag.Category = value2;
            return View("Callbook", book);
        }
        public ActionResult EditBook(tblBook b)
        {
            var newbook = db.tblBook.Find(b.Id);
            newbook.Name = b.Name;
            newbook.Publisher = b.Publisher;
            newbook.PublicationYear = b.PublicationYear;
            newbook.CountPage = b.CountPage;
            newbook.Situation = true;
            //İlişkili tabloda eşleştirme işlemi
            var cat = db.tblCategory.Where(c => c.Id == b.tblCategory.Id).FirstOrDefault();
            var aut = db.tblAuthor.Where(a => a.Id == b.tblAuthor.Id).FirstOrDefault();
            newbook.Category = cat.Id;
            newbook.Author = aut.Id;

            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}