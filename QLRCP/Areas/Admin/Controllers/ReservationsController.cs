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
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Customer).Include(r => r.Seat).Include(r => r.Show).Include(r => r.Show.Cinema).Include(r => r.Show.Movie).Include(r => r.Show.ShowDay).Include(r => r.Show.ShowTime);
            return View(reservations.ToList());
        }

        // GET: Admin/Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Admin/Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Users, "Id", "Name");
            ViewBag.SeatID = new SelectList(db.Seats, "Id", "Id");
            ViewBag.ShowID = new SelectList(db.Shows, "ID", "ID");
            return View();
        }

        // POST: Admin/Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,SeatID,ShowID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Users, "Id", "Name", reservation.CustomerID);
            ViewBag.SeatID = new SelectList(db.Seats, "Id", "Id", reservation.SeatID);
            ViewBag.ShowID = new SelectList(db.Shows, "ID", "ID", reservation.ShowID);
            return View(reservation);
        }

        // GET: Admin/Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Users, "Id", "Name", reservation.CustomerID);
            ViewBag.SeatID = new SelectList(db.Seats, "Id", "Id", reservation.SeatID);
            ViewBag.ShowID = new SelectList(db.Shows, "ID", "ID", reservation.ShowID);
            return View(reservation);
        }

        // POST: Admin/Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,SeatID,ShowID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Users, "Id", "Name", reservation.CustomerID);
            ViewBag.SeatID = new SelectList(db.Seats, "Id", "Id", reservation.SeatID);
            ViewBag.ShowID = new SelectList(db.Shows, "ID", "ID", reservation.ShowID);
            return View(reservation);
        }

        // GET: Admin/Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Admin/Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
