using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    public class StatisticsController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        
        // GET: Statistics
        public ActionResult Index()
        {
            var m = db.tblMember.Count();
            ViewBag.Member = m;
            var b = db.tblBook.Count();
            ViewBag.Book = b;
            var lb = db.tblBook.Where(x=> x.Situation==false).Count();
            ViewBag.LendBook = lb;
            var s = db.tblPenal.Sum(x => x.Money);
            ViewBag.Safe = s;

            return View();
        }
        public ActionResult LinqCart()
        {
            //yüklenilecek degerleri linq sorgular kullanark çekip vievbaglarla sayfaya tasıma yapacagız.
            var value1 = db.tblBook.Count();
            var value2 = db.tblMember.Count();
            var value3 = db.tblPenal.Sum(x => x.Money);
            var value4 = db.tblBook.Where(x=> x.Situation==false).Count();
            var value5 = db.tblCategory.Count();
            var value8 = db.BesatAuthor().FirstOrDefault();
            var value9 = db.tblBook.GroupBy(x=>x.Publisher).OrderByDescending(z=>z.Count()).Select(x=>x.Key).FirstOrDefault();

            ViewBag.Value1 = value1;
            ViewBag.Value2 = value2;
            ViewBag.Value3 = value3;
            ViewBag.Value4 = value4;
            ViewBag.Value5 = value5;

            ViewBag.Value8 = value8;
            ViewBag.Value9 = value9;

            return View();
        }
    }
}