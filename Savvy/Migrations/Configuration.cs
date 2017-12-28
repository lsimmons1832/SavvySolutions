using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Savvy.Models;

namespace Savvy.Migrations
{
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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "lsimmons1832",
                    Email = "lsimmons1832@gmail.com",
                    FName = "Latasha",
                    LName = "Simmons"
                };

                var chkUser = userManager.Create(user, "password");

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Customer role     
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);

            }

            // creating Creating Stylist role     
            if (!roleManager.RoleExists("Stylist"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Stylist";
                roleManager.Create(role);

            }
        }
    }
}
