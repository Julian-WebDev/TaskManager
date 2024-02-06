using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Models.TaskView;
using TaskManager.Models.TaskCreation;
using Microsoft.Ajax.Utilities;
using TaskManager.Interfaces;
using TaskManager.Interfaces.Task;
using TaskManager.Data;
using TaskManager.Models.TaskUpdate;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            //List<LoadTasks> list = null;
            //using (TaskManagerEntities1 dataBase = new TaskManagerEntities1())
            //{
            //    list = (from data in dataBase.T_TASKS
            //            where data.COMPLETED == 1
            //            orderby data.TASK_ID
            //            select new LoadTasks
            //            {
            //                TaskSubject = data.TASK_SUBJECT,
            //                TaskDeadline = data.TASK_DEADLINE,
            //                TaskName = data.TASK_NAME,
            //                Description = data.TASK_DESCRIPTION
            //            }).ToList();
            //}
            //return View(list);
            return View();
        }

        public ActionResult CompletedTasks() 
        {
           return View();
        }

        //This method gets the data of the task that I need to change and return the view
        //of the task update page
        public ActionResult EditTask(int id)
        {
            try
            {
                List<TaskUpdate> list = null;
                using (TaskManagerEntities1 dataBase = new TaskManagerEntities1())
                {
                    list = (from data in dataBase.T_TASKS
                            where data.TASK_ID == id
                            orderby data.TASK_ID
                            select new TaskUpdate
                            {
                                Id = data.TASK_ID,
                                Subject = data.TASK_SUBJECT,
                                Date = data.TASK_DEADLINE,
                                Name = data.TASK_NAME,
                                Description = data.TASK_DESCRIPTION
                            }).ToList();
                }
                return View(list);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }
            
        }

        [HttpPost]
        public ActionResult CreateTask(FormCollection collection)
        {
            //Using this object I can manage the items without creating inncesary space in the memory
            Task item = new Task();

            item.Subject = collection["subject"];
            item.Date = collection["date"];
            item.Name = collection["name"];
            item.Description = collection["description"];

            if (item.Subject.IsNullOrWhiteSpace()|| item.Name.IsNullOrWhiteSpace() || item.Description.IsNullOrWhiteSpace())
            {
                return Content("1");
            }
            else
            {
                C_Task task = new C_Task();
                task.insertTask(item.Subject, item.Date, item.Name, item.Description);
                return Content("2");
            }
        }

        public ActionResult GetTask() 
        {
            using(TaskManagerEntities1 dataBase = new TaskManagerEntities1())
            {
                //To avoid errors, in the select I have to choose the spaces that I need
                //because if I select all the fields when I'm calling
                //3 spaces it will throw an error
                List<LoadTasks> list = null;
                list = (from data in dataBase.T_TASKS
                        where data.COMPLETED == 1
                        orderby data.TASK_ID
                        select new LoadTasks
                        {
                            //I select the spaces that I need
                            Id = data.TASK_ID,
                            TaskSubject = data.TASK_SUBJECT,
                            TaskDeadline = data.TASK_DEADLINE,
                            TaskName = data.TASK_NAME,
                            Description = data.TASK_DESCRIPTION
                        }).ToList();

                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCompletedTasks()
        {
            using (TaskManagerEntities1 dataBase = new TaskManagerEntities1())
            {
                List<LoadTasks> list = null;
                list = (from data in dataBase.T_TASKS
                        where data.COMPLETED == 2
                        orderby data.TASK_ID
                        select new LoadTasks
                        {
                            //I select the spaces that I need
                            Id = data.TASK_ID,
                            TaskSubject = data.TASK_SUBJECT,
                            TaskDeadline = data.TASK_DEADLINE,
                            TaskName = data.TASK_NAME,
                            Description = data.TASK_DESCRIPTION
                        }).ToList();

                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult DeleteTask(FormCollection collection)
        {
            Task task = new Task();
            task.id = collection["param"];

            C_Task ob_c_task = new C_Task();
            try
            {
                ob_c_task.deleteTask(task.id);
                return Content("1");
            }
            catch (Exception ex) { 
                return Content("2");
            }
        }

        public ActionResult updateTasks(FormCollection collection)
        {
            Task task = new Task();

            task.id = collection["id"];
            task.Subject = collection["subject"];
            task.Date = collection["date"];
            task.Name = collection["name"];
            task.Description = collection["description"];

            try
            {
                C_Task ob_c_task = new C_Task();
                ob_c_task.update(task.id, task.Subject, task.Date, task.Name, task.Description);
                return Content("1");
            }
            catch (Exception ex) 
            {
                return Content("2");
            }

        }

        public ActionResult CompleteTask(FormCollection collection)
        {
            C_Task ob_c_task = new C_Task();
            Task task = new Task();
            task.id = collection["param"];

            try
            {
                ob_c_task.complete(task.id);
                return Content("1");
            }catch (Exception ex)
            {
                return Content("2");
            }

        }

        public ActionResult IncompleteTask(FormCollection collection)
        {
            C_Task ob_c_task = new C_Task();
            Task task = new Task();
            task.id = collection["param"];

            try
            {
                ob_c_task.incomplete(task.id);
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("2");
            }
        }
    }
}