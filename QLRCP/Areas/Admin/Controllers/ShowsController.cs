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

namespace QLRCP.Areas.Admin.Controllers
{
    public class ShowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Cinema).Include(s => s.Movie).Include(s => s.ShowDay).Include(s => s.ShowTime);
            return View(shows.ToList());
        }

        // GET: Admin/Shows/Details/5
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

        // GET: Admin/Shows/Create
        public ActionResult Create()
        {
            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "Name");
            ViewBag.MovieID = new SelectList(db.Movies, "Id", "Name");
            ViewBag.ShowDayID = new SelectList(db.ShowDays, "Id", "Day");
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "Id", "Time");
            return View();
        }

        // POST: Admin/Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CinemaID,MovieID,ShowDayID,ShowTimeId")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "Name", show.CinemaID);
            ViewBag.MovieID = new SelectList(db.Movies, "Id", "Name", show.MovieID);
            ViewBag.ShowDayID = new SelectList(db.ShowDays, "Id", "Id", show.ShowDayID);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "Id", "Id", show.ShowTimeId);
            return View(show);
        }

        // GET: Admin/Shows/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "Name", show.CinemaID);
            ViewBag.MovieID = new SelectList(db.Movies, "Id", "Name", show.MovieID);
            ViewBag.ShowDayID = new SelectList(db.ShowDays, "Id", "Day", show.ShowDayID);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "Id", "Time", show.ShowTimeId);
            return View(show);
        }

        // POST: Admin/Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CinemaID,MovieID,ShowDayID,ShowTimeId")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaID = new SelectList(db.Cinemas, "Id", "Name", show.CinemaID);
            ViewBag.MovieID = new SelectList(db.Movies, "Id", "Name", show.MovieID);
            ViewBag.ShowDayID = new SelectList(db.ShowDays, "Id", "Id", show.ShowDayID);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "Id", "Id", show.ShowTimeId);
            return View(show);
        }

        // GET: Admin/Shows/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
            db.SaveChanges();
            return RedirectToAction("Index");
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
