using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp2.Models;

namespace TaskApp2.Controllers
{
    public class TaskController : Controller
    {
        TaskContext DbTasks = new TaskContext();
        ApplicationDbContext DbUsers = ApplicationDbContext.Create();

        public ActionResult TaskList()
        {

            return View(DbTasks.Tasks);
        }







        public ActionResult DeleteUserInTask(int idTask ,string userName)
        {

            foreach (var item in DbTasks.ActualModels)
            {
                if (item.TaskId == idTask && item.UserName == userName)
                {
                    DbTasks.Entry(item).State = EntityState.Deleted;  
                }
            }
            DbTasks.SaveChanges();

            string returnUrl = "DetailsTask\\" + idTask;

            return RedirectToAction(returnUrl);
        }


        public ActionResult DetailsTask(int id)
        {
            List<CurentTaskModel> CurentTaskUsers = new List<CurentTaskModel>();

            foreach (var item in DbTasks.ActualModels)
            {
                if (id == item.TaskId)
                {
                    CurentTaskUsers.Add(new CurentTaskModel { users = item.UserName, TasDesc = item.Description , TaskLeight= item.ActTaskLeigth.ToString()+" H"});
                }

            }
            foreach (var item in DbTasks.Tasks)
            {
                if (item.TaskId==id)
                {
                    ViewBag.Task = item;
                }

            }






            return View(CurentTaskUsers);

        }








        public ActionResult ShowListUsers(int id)
        {
            ViewBag.idTask = id;
           
            List<DevelopersModel> Devlist = new List<DevelopersModel>();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var user in DbUsers.Users)
            {
                if (userManager.GetRoles(user.Id)[0]=="Dev")
                {
                   Devlist.Add(new DevelopersModel { name = user.UserName, Email = user.Email });
                           
                }
            }




            return View(Devlist);
        }

        public ActionResult AddUserInTask(string name, int id )
        {
            string taskName = "";
            bool ifUserHasTask = false;
            foreach (var item in DbTasks.Tasks)
            {
                if (id== item.TaskId)
                {
                    taskName = item.TaskName;
                }
            }
            var Curenttask = new ActualTaskModel { ActTaskLeigth = 0, TaskId=id, Description="", UserName= name, TaskName= taskName };

            foreach (var ele in DbTasks.ActualModels)
            {
                if (ele.UserName== name&&ele.TaskId==id)
                {
                    ifUserHasTask = true;
                }

            }
            if (!ifUserHasTask)
            {
                DbTasks.ActualModels.Add(Curenttask);
                DbTasks.SaveChanges();
            }
            return RedirectToAction("TaskList", "Task");
        }


        public ActionResult AddUserToTask(int id)
        {
            ViewBag.idTask = id;
            
            return View(DbUsers.Users);
        }



        public ActionResult DeleteTask(int id)
        {
            TaskModel task = new TaskModel { TaskId = id };
            DbTasks.Entry(task).State = EntityState.Deleted;

            foreach (var item in DbTasks.ActualModels)
            {
                if (item.TaskId== id)
                {
                    DbTasks.Entry(item).State = EntityState.Deleted;
                }

            }
            DbTasks.SaveChanges();


            return RedirectToAction("TaskList", "Task");
        }




        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTask(TaskModel model)
        {
            var task = new TaskModel { TaskName = model.TaskName, TaskDescription = model.TaskDescription, TaskBegin = model.TaskBegin, TaskLeigth = 0, TaskEnd = model.TaskEnd };
            DbTasks.Tasks.Add(task);
            DbTasks.SaveChanges();


            return RedirectToAction("TaskList", "Task");
        }


    }
}