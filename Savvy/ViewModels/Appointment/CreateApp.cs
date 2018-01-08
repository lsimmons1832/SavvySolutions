using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Savvy.ViewModels.Appointment
{
    public class CreateApp
    {
        public SelectList listStylist { get; set; }
        public List<Models.Service> Services { get; set; }
        public DateTime Date { get; set; }
        public bool SelectedService { get; set; }
        public int Customer { get; set; }
    }
}