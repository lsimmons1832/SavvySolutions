using System.Collections.Generic;
using Savvy.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Savvy.ViewModels.Appointment
{
    public class BookAppointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [DisplayName("Stylist")]
        public int StylistId { get; set; }
        public int ServiceID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        [DisplayName("Book")]
        public bool SelectedService { get; set; }
        //public IEnumerable<Stylist> Stylists { get; set; }
        //public IEnumerable<Models.Service> Services { get; set; }
        //public IEnumerable<Models.Schedule> Schedules { get; set; }
        //public IEnumerable<Models.Customer> Customers { get; set; }

    }
}