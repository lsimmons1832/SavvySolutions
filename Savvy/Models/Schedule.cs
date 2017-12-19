using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savvy.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}