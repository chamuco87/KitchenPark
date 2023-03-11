﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenPark.Controllers
{
    public class CaramelCoffeeController : Controller
    {
        
        public ActionResult Index()
        {

            return View("~/Views/Home/CaramelCoffee.cshtml");
        }
        public ActionResult Validated()
        {

            var dir = Server.MapPath("/Content/images/Restaurants/CaramelCoffee");
            var path = Path.Combine(dir, "NoBlur.png"); //validate the path for security or use other means to generate the path.
            return base.File(path, "image/png");
        }
    }
}