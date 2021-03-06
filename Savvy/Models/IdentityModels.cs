﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Savvy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FName { get; set; }
        public string LName { get; set; }
        public string UserRoles { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<Savvy.Models.Appointment> Appointments {get; set;}
        public System.Data.Entity.DbSet<Savvy.Models.Customer> Customers {get; set;}
        public System.Data.Entity.DbSet<Savvy.Models.Schedule> Schedules {get; set;}
        public System.Data.Entity.DbSet<Savvy.Models.Service> Services {get; set;}
        public System.Data.Entity.DbSet<Savvy.Models.Stylist> Stylists {get; set;}

        //public System.Data.Entity.DbSet<Savvy.ViewModels.Appointment.BookAppointment> BookAppointments { get; set; }
    }
}