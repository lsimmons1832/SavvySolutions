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

        private List<Service> services;

        public virtual List<Service> GetServices()
        {
            return services;
        }

        public virtual void SetServices(List<Service> value)
        {
            services = value;
        }
        //public virtual Schedule Schedules { get; set; }

    }
}