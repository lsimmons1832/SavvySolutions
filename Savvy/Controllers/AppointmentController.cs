using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Savvy.Models;
using Savvy.ViewModels.Appointment;

namespace Savvy.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appointment
        public ActionResult Index()
        {
            var stylist = db.Stylists.Include(s => s.StylistID);
            var service = db.Services.Include(t => t.Name);
            var customer = db.Customers.Include(c => c.CustomerID);

            return View(db.Appointments.ToList());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            var listStylist = FindStylist();
            ViewBag.Stylists = listStylist;

            //var listService = LocateServiceByStylist();
            //ViewBag.Services = listService;

            return View();
        }

        [HttpPost]
        public ActionResult ShowStylistDetails(BookAppointment book)
        {
            int SelectedValue = book.MyStylist;

            var serviceQuery = from s in db.Services
                               where s.Stylist.StylistID == SelectedValue
                               select new
                               {
                                   Name = s.Name
                               };

            return View(serviceQuery);
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAppointment newAppointment)
        {
            var appointment = new Appointment
            {
                Customer = db.Customers.Find(newAppointment.CustomerId),
                Schedule = db.Schedules.Find(newAppointment.Schedule),
                Service = db.Services.Find(newAppointment.Services),
                Stylist = db.Stylists.Find(newAppointment)
            };

            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newAppointment);
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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

        private SelectList FindStylist(object selectedStylist = null)
        {
            var stylistQuery = from s in db.Stylists
                               select new
                               {
                                   StylistID = s.StylistID,
                                   FName = s.User.FName
                               };

            return new SelectList(stylistQuery, "StylistID", "FName", selectedStylist);
        }

    
    }
}
