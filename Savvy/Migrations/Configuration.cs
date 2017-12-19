using Savvy.Models;

namespace Savvy.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Savvy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Savvy.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "lsimmons1832",
                Email = "lsimmons1832@gmail.com",
            };

            userManager.CreateAsync(user, "password").Wait();
        }
    }
}
