using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Savvy.ViewModels.Schedule
{
    public class CreateSchedule
    {
        public int StylistId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}