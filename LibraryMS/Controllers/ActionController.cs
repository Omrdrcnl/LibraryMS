using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
            // Kitabın Situation değerini false olarak güncelleme işlemi
            var bookToUpdate = db.tblBook.Find(p.Book);
            if (bookToUpdate != null)
            {
                bookToUpdate.Situation = false;
                db.SaveChanges();
            }

            db.tblAction.Add(p);
            db.SaveChanges();

            return RedirectToAction("LendBook");
        }
        public ActionResult BorrowBookList()
        {
            var k = db.tblAction.Where(y => y.tblBook.Situation == false).ToList();
            return View(k);
        }

        public ActionResult BorrowBook(tblAction a)
        {
            var lend = db.tblAction.Find(a.Id);
            DateTime d1 = DateTime.Parse(lend.ReturnDate.ToString());
            DateTime d2 = DateTime.Parse(lend.PurchaseDate.ToString());

            TimeSpan d3 = d1-d2;

            ViewBag.day=d3.TotalDays;

            return View("BorrowBook", lend);
        }
        public ActionResult BorrowBookEdit(tblAction a)
        {

            var lend = db.tblAction.Find(a.Id);
            lend.ProcessDate = a.ProcessDate;
            lend.Process = true;

            var bookToUpdate = db.tblBook.Find(a.Book);
            if (bookToUpdate != null)
            {
                //burayı çalıstıramadım :( yerine sql trigger sistemi kullandım
                bookToUpdate.Situation = true;// sonra buldum sayfada book değişkenine yer vermememişim a değeri bu sebeple ulaşamıyormuş :)
                db.SaveChanges();             // tekrar aktif etmeyecegim trigger düzgün çalısıyor zaten.
            }

            db.SaveChanges();
            return RedirectToAction("BorrowBookList");


        }

    }
}