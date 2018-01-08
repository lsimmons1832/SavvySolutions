using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Savvy.Models;


namespace Savvy.ViewModels.Customer
{
    public class SelectStylistAndService
    {
        [Required]
        public int StylistID { get; set; }
        [Required]
        public List<Savvy.Models.Service> Services { get; set; }
    }
}