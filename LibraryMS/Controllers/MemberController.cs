using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Models.Entity;
using LibraryMS.Controllers;
using PagedList;
using PagedList.Mvc;

namespace LibraryMS.Controllers
{
    public class MemberController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: Member
        public ActionResult Index(int page=1)
        {


            var members = db.tblMember.ToList().ToPagedList(page, 3);

            return View(members);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(tblMember m)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            db.tblMember.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMember(int id)
        {
            var member = db.tblMember.Find(id);
            db.tblMember.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallMember(int id)
        {
            var member = db.tblMember.Find(id);
            return View(member);
        }
        public ActionResult EditMember(tblMember m)
        {
            var member = db.tblMember.Find(m.Id);
            member.Name = m.Name;
            member.Surname = m.Surname;
            member.UserName = m.UserName;
            member.Password = m.Password;
            member.Phone = m.Phone;
            member.School = m.School;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}