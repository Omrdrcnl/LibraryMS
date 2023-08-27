using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    
    
    public class MessagesController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Messages
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var messages = db.tblMessages.Where(x => x.Acceptor == uyemail.ToString()).ToList(); ;
            return View(messages);
        }

        public ActionResult Sent()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var messages = db.tblMessages.Where(x => x.Sender == uyemail.ToString()).ToList(); ;
            return View(messages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(tblMessages t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.Sender = uyemail.ToString();
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblMessages.Add(t);
            db.SaveChanges();
            return RedirectToAction("Sent", "Messages");
        }
    }
}