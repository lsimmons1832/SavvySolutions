using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savvy.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Stylist Stylist { get; set; }
        public virtual Service Service { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}