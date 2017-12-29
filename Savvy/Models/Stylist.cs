using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savvy.Models
{
    public class Stylist
    {
        public int StylistID { get; set; }
        public string Salon { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Service Services { get; set; }
        //public virtual Schedule Schedules { get; set; }

    }
}