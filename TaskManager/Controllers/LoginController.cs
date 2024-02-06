using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

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
    }
}