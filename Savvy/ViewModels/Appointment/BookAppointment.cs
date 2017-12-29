using System.Collections.Generic;
using Savvy.Models;

namespace Savvy.ViewModels.Appointment
{
    public class BookAppointment
    {
        //public SelectList Stylist { get; set; }
        //public int MyStylist { get; set; }
        //public int Services { get; set; }
        //public DateTime Schedule { get; set; }
        //public int CustomerId { get; set; }
        public IEnumerable<Stylist> Stylists { get; set; }
        public IEnumerable<Models.Service> Services { get; set; }
        public IEnumerable<Models.Schedule> Schedules { get; set; }
        public IEnumerable<Models.Customer> Customers { get; set; }

    }
}