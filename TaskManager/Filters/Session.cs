using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Controllers;
using TaskManager.Models;

namespace TaskManager.Filters
{
    public class Session : ActionFilterAttribute
    {
        //Filter to verify if theres an active session, in case of theres no session 
        //it will redirect to the login page to create one
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //See if theres session
            var oUser = (T_USERS)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if(filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }else
            {
                //If the user tries to get into the login even if theres a session, it will
                //redirect to the home page
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Task/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}