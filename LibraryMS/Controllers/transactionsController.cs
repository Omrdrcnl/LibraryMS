using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMS.Controllers;
using LibraryMS.Models.Entity;

namespace LibraryMS.Controllers
{
    public class transactionsController : Controller
    {
        DbLibraryMSEntities db = new DbLibraryMSEntities();
        // GET: transactions
        public ActionResult Index()
        {
            var t = db.tblAction.Where(x => x.Process==true).ToList();
            return View(t);
        }
    }
}