﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenPark.Controllers
{
    public class JimJimController : Controller
    {
        public ActionResult Index()
        {

            return View("~/Views/Home/JimJim.cshtml");
        }
    }
}