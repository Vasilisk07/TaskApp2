using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
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

            var Bob = new ApplicationUser { Email = "Bob@mail.com", UserName = "Bob" };
            var resultBob = userManager.Create(Bob, password);
            if (resultBob.Succeeded)
            {
                userManager.AddToRole(Bob.Id, roleDev.Name);
            }

            var Ostin = new ApplicationUser { Email = "Ostin@mail.com", UserName = "Ostin" };
            var resultOstin = userManager.Create(Ostin, password);
            if (resultOstin.Succeeded)
            {
                userManager.AddToRole(Ostin.Id, roleMan.Name);
            }

            var Karl = new ApplicationUser { Email = "Karl@mail.com", UserName = "Karl" };
            var resultKarl = userManager.Create(Karl, password);
            if (resultOstin.Succeeded)
            {
                userManager.AddToRole(Karl.Id, roleDev.Name);
            }
            var Sam = new ApplicationUser { Email = "Sam@mail.com", UserName = "Sam" };
            var resultSam = userManager.Create(Sam, password);
            if (resultOstin.Succeeded)
            {
                userManager.AddToRole(Sam.Id, roleDev.Name);
            }
            var Jack = new ApplicationUser { Email = "Jack@mail.com", UserName = "Jack" };
            var resultJack = userManager.Create(Jack, password);
            if (resultOstin.Succeeded)
            {
                userManager.AddToRole(Jack.Id, roleDev.Name);
            }


            base.Seed(context);
        }
    }








}