using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roleAdmin = new IdentityRole { Name = "Admin" };
            var roleMan = new IdentityRole { Name = "Manager" };
            var roleDev = new IdentityRole { Name = "Dev" };

            roleManager.Create(roleAdmin);
            roleManager.Create(roleMan);
            roleManager.Create(roleDev);

            var admin = new ApplicationUser { Email = "Admin@mail.com", UserName = "Administrator" };
            string password = "123Ll_";
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
            }


            base.Seed(context);
        }
    }
}