using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Data;
using TaskManager.Interfaces.User;
using Microsoft.Ajax.Utilities;

namespace TaskManager.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password) 
        {
            try
            {
                //In this block of code Im using LinkQ, that is a language
                //similar to SQL Server querys

                //Using LinkQ I compare the credentials 
                using(TaskManagerEntities1 dataBase = new TaskManagerEntities1()) 
                {
                    var list = from table in dataBase.T_USERS
                               where table.EMAIL == email && table.PASSWORD == password
                               select table;

                    if(list.Count() > 0 )
                    {
                        Session["User"] = list.First();

                        return Content("1");
                    }
                    else
                    {
                        return Content("Incorrect email or password :(");
                    }
                }

            }
            catch (Exception ex) 
            {
                return Content("Ha ocurrido un error" + ex.Message);
            }
        }

        public ActionResult CreateUser(FormCollection collection)
        {
            C_Task ob_task = new C_Task();
            User item = new User();
            try
            {
                item.Name = collection["newName"];
                item.Email = collection["newEmail"];
                item.Password = collection["newPassword"];

                if (item.Name.IsNullOrWhiteSpace() || item.Email.IsNullOrWhiteSpace() || item.Password.IsNullOrWhiteSpace())
                {
                    return Content("1");
                }
                else
                {
                    ob_task.createUser(item.Name, item.Email, item.Password);
                    return Content("2");
                }
            }
            catch (Exception ex)
            {
                return Content("3");
            }
        }
    }
}