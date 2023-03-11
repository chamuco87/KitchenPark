using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenPark.Controllers
{
    public class LaCapitalMXController : Controller
    {

        public ActionResult Index()
        {

            return View("~/Views/Home/LaCapitalMX.cshtml");
        }
        public ActionResult Validated()
        {

            var dir = Server.MapPath("/Content/images/Restaurants/LaCapitalMX");
            var path = Path.Combine(dir, "NoBlur.PNG"); //validate the path for security or use other means to generate the path.
            return base.File(path, "image/png");
        }
    }

}