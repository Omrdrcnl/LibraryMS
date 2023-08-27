using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    public class PanelController : Controller
    {
        DbLibraryMSEntities db= new DbLibraryMSEntities();
        // GET: Panel
        [Authorize]
        public ActionResult Index()
        {
            var memberMail = (string)Session["Mail"];
            var values = db.tblMember.FirstOrDefault(x => x.Mail == memberMail);
            return View(values);
        }

        [HttpPost]
        public ActionResult Index2(tblMember m)
        {
            var memberMail = (string)Session["Mail"];
            var values = db.tblMember.FirstOrDefault(x => x.Mail == memberMail);
            values.Password = m.Password;
            values.School = m.School;
            values.Phone = m.Phone;
            values.Photo = m.Photo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyBooks()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.tblMember.Where(x => x.Mail == kullanici.ToString()).Select(z => z.Id).FirstOrDefault();
            var degerler = db.tblAction.Where(x => x.Member == id).ToList();
            return View(degerler);
        }
        //public ActionResult Announcement()
        //{
        //    var duyurulistesi = db.tblAnnounce.ToList();
        //    return View(duyurulistesi);
        //}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

    }
}