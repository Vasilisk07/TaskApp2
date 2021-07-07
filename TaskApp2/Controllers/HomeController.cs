using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp2.Models;

namespace TaskApp2.Controllers
{
    public class HomeController : Controller
    {
        TaskContext DbTasks = new TaskContext();
        ApplicationDbContext DbUsers = ApplicationDbContext.Create();


        [Authorize(Roles = "Admin, Manager, Dev")]
        public ActionResult ListMyTask()
        {
            List<UserTaskModel> myTasks = new List<UserTaskModel>();
           string userName = User.Identity.Name;
            foreach (var item in DbTasks.ActualModels)
            {
                if (userName== item.UserName)
                {
                    myTasks.Add(new UserTaskModel {TaskName = item.TaskName, TaskInfo = item.Description, TaskTime = item.ActTaskLeigth.ToString() + "H", myTaskId= item.ActualTaskId });
                    ViewBag.Title = "Доступные задачи для :"+User.Identity.Name;
                }

            }
            if (myTasks.Count ==0)
            {
                ViewBag.Title = "Для Вас нет доступных задач";
            }
    

            return View(myTasks);
        }
        [Authorize(Roles = "Admin, Manager, Dev")]
        [HttpGet]
        public ActionResult EditMyTask(int id)
        {
            string userName = User.Identity.Name;
            foreach (var item in DbTasks.ActualModels)
            {
                if (item.UserName == userName && item.ActualTaskId == id)
                {
                    ViewBag.TaskName = item.TaskName;
                    return View(new ChangesTaskModel { Comit = "", Time = 0, IdChengTask=item.ActualTaskId } );
                }
            }

            return View();
        }
        [Authorize(Roles = "Admin, Manager, Dev")]
        public ActionResult DeteilsMyTask(string nameTask)
        {
            foreach (var item in DbTasks.Tasks)
            {
                if (item.TaskName==nameTask)
                {
                    return View(item);
                }
            }



            return RedirectToAction("ListMyTask", "Home");
        }
        [Authorize(Roles = "Admin, Manager, Dev")]
        [HttpPost]
        public ActionResult EditMyTask(ChangesTaskModel editsTask)
        {
            string userName = User.Identity.Name;
            int TaskId = 0;
            foreach (var item in DbTasks.ActualModels)
            {
                if (item.UserName == userName && item.ActualTaskId == editsTask.IdChengTask&&editsTask.Time>0)
                {
                    item.Description = editsTask.Comit!=null? $" {item.Description} | {DateTime.Now.ToString("dd.MM.yyyy")} {editsTask.Comit}":item.Description;
                    item.ActTaskLeigth += editsTask.Time;
                    TaskId = item.TaskId;
                }
            }
            if (TaskId>0)
            {
                foreach (var item in DbTasks.Tasks)
                {
                    if (item.TaskId==TaskId)
                    {
                        item.TaskLeigth += editsTask.Time;
                    }

                }

            }


            DbTasks.SaveChanges();
            return RedirectToAction("ListMyTask", "Home");
        }



        public ActionResult Index()
        {

            return View();
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}