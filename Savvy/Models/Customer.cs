using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savvy.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}