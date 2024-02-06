using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Models.TaskView;
using TaskManager.Models.TaskCreation;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<LoadTasks> list = null;
            using (TaskManagerEntities1 dataBase = new TaskManagerEntities1())
            {
                list = (from data in dataBase.T_TASKS
                       where data.COMPLETED == 1
                       orderby data.TASK_ID
                       select new LoadTasks
                       {
                           TaskSubject = data.TASK_SUBJECT,
                           TaskDeadline = data.TASK_DEADLINE,
                           TaskName = data.TASK_NAME,
                           Description = data.TASK_DESCRIPTION
                       }).ToList();
            }

            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(string subject, string date, string name, string description) 
        {
            if(subject!=null)
            {
                return Json("1");
            }
            return null;
        }
    }
}