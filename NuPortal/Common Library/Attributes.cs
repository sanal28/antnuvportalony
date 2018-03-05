﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuPortal.Common_Library
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["EmpID"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/LoginView");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}