using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Savvy.ViewModels.Appointment
{
    public class BookAppointment
    {
        public int AppointmentId { get; set; }
        public SelectList Stylist { get; set; }
        //public int MyStylist { get; set; }
        public int Services { get; set; }
        public DateTime Schedule { get; set; }
        public int CustomerId { get; set; }
    }
}