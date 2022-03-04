﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreFrontLab.UI.MVC.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Unresolved()//basic "Default Custom Error Page" for unhandled errors
        {
            return View();
        }
    }
}