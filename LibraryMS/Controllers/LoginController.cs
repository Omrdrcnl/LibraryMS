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
    public class LoginController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblMember m)
        {
            var info = db.tblMember.FirstOrDefault(x => x.Mail == m.Mail && x.Password == m.Password);
            if(info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.Mail, false);
                return RedirectToAction("Index","Panel");
            }
            else
            {
                return View();
            }

           
        }
    }
}