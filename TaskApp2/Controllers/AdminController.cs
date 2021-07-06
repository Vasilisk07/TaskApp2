using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskApp2.Models;

namespace TaskApp2.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext DbUsers = ApplicationDbContext.Create();

        public ActionResult DeleteUser(string userName)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByName(userName);
            if (user != null)
            {
                userManager.Delete(user);
               
            }

            return RedirectToAction("UserList", "Admin");
        }

        public ActionResult UserList()
        {
           List< UserViewModel> userlist= new List<UserViewModel>();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var user in DbUsers.Users)
            {
                userlist.Add(new UserViewModel { UserEmail = user.Email, UserName = user.UserName, UserRoles = userManager.GetRoles(user.Id)[0] });
            }
            return View(userlist);
        }

       
        public ActionResult ListRole(string UserName)
        {
            ViewBag.userName = UserName;
            List<RoleModels> rModelList = new List<RoleModels>();
            foreach (var role in DbUsers.Roles)
            {
                rModelList.Add(new RoleModels { RolesName = role.Name });
            }



            return View(rModelList);
        }
       
        public ActionResult EditUser(string roleName, string userName)
        {
            
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByName(userName);
            if (user != null)
            {
                userManager.RemoveFromRole(user.Id, userManager.GetRoles(user.Id)[0]);
                userManager.AddToRole(user.Id, roleName);
            }

            return RedirectToAction("UserList", "Admin");
        }



        public ActionResult Index()
        {
            return View();
        }
    }
}