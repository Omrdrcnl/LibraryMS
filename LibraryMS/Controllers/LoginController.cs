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
                Session["Mail"] = info.Mail.ToString();
                //TempData["Id"] =info.Id.ToString();
                //TempData["name"] =info.Name.ToString();
                //TempData["Surname"] =info.Surname.ToString();
                //TempData["UserName"] =info.UserName.ToString();
                //TempData["Photo"] =info.Photo.ToString();
                //TempData["School"] =info.School.ToString();
                //TempData["Password"] =info.Password.ToString();
                //TempData["phone"] =info.Phone.ToString();
                return RedirectToAction("Index","Panel");
            }
            else
            {
                return View();
            }

           
        }
    }
}