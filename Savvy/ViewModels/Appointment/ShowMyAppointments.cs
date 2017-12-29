using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savvy.ViewModels.Appointment
{
    public class ShowMyAppointments
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int StylistId { get; set; }
    }
}