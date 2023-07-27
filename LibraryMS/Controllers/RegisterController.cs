using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    public class RegisterController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblMember m)
        {
            db.tblMember.Add(m);
            db.SaveChanges();
            return View();
        }
    }
}