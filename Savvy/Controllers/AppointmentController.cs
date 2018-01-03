using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
            var customer = db.Appointments.Include(a => a.Customer);
            var stylist = db.Appointments.Include(a => a.Stylist);
            var service = db.Appointments.Include(a => a.Service);
            var schedule = db.Appointments.Include(a => a.Schedule);

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

        public ActionResult Create()
        {
            var create = new CreateApp
            {
                listStylist = PopulateStylistsDropDownList(),
                Services = SelectService(),
            };

            return View(create);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAppointment bookAppointment)
        {
            if (bookAppointment.SelectedService)
            {
                var appointment = new Appointment
                {
                    Stylist = db.Stylists.Find(bookAppointment.Stylist),
                    Service = db.Services.Find(bookAppointment.Services),
                    Date = bookAppointment.Date,
                    Customer = db.Customers.Find(bookAppointment.Customer)
                };
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.Appointments.Add(appointment);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                PopulateStylistsDropDownList(appointment.Stylist);
            }
                return Create();
        }

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
            PopulateStylistsDropDownList(appointment.Stylist);
            return View(appointment);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentToUpdate = db.Appointments.Find(id);
            if (TryUpdateModel(appointmentToUpdate, "",
               new string[] { "Stylist", "Service", "Date" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateStylistsDropDownList(appointmentToUpdate.AppointmentId);
            return View(appointmentToUpdate);
        }

        private SelectList PopulateStylistsDropDownList(object selectedStylist = null)
        {
            var stylistQuery = from s in db.Stylists
                select new
                {
                    StylistID = s.StylistID,
                    FName = s.User.FName
                };

            return new SelectList(stylistQuery, "StylistID", "FName", selectedStylist);
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

        private SelectList FindCustomer (object selectedCustomer = null)
        {
            var customerQuery = from c in db.Customers
                select new
                {
                    CustomerId = c.CustomerID,
                    User_Id = c.User.Id
                };

            return new SelectList(customerQuery, "CustomerId", "User_Id", selectedCustomer);
        }

        private List<Service> SelectService(object selectedService = null)
        {
            var serviceQuery = from s in db.Services
                               select s;


            return serviceQuery.ToList();
        }

    }
}
