using System.Collections.Generic;
using Savvy.Models;
using System;
using System.ComponentModel;

namespace Savvy.ViewModels.Appointment
{
    public class BookAppointment
    {
        [DisplayName("Stylist")]
        public int Stylist { get; set; }
        public int Services { get; set; }
        public DateTime Date { get; set; }
        public int Customer { get; set; }
        [DisplayName("Book")]
        public bool SelectedService { get; set; }
        //public IEnumerable<Stylist> Stylists { get; set; }
        //public IEnumerable<Models.Service> Services { get; set; }
        //public IEnumerable<Models.Schedule> Schedules { get; set; }
        //public IEnumerable<Models.Customer> Customers { get; set; }

    }
}