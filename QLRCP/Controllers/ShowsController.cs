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
    public class ShowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Cinema).Include(s => s.Movie).Include(s => s.ShowDay).Include(s => s.ShowTime);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
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
