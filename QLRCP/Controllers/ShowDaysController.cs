using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLRCP.Models;
using QLRCP.Models.CinemaEtites;

namespace QLRCP.Controllers
{
    public class ShowDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShowDays
        public ActionResult Index()
        {
            return View(db.ShowDays.ToList());
        }

        // GET: ShowDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDay showDay = db.ShowDays.Find(id);
            if (showDay == null)
            {
                return HttpNotFound();
            }
            return View(showDay);
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
