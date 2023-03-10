using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenPark.Controllers
{
    public class CuponeraController : Controller
    {
        
        public ActionResult Index()
        {

            return View("~/Views/Home/Cuponera.cshtml");
        }

        [HttpPost]
        public ActionResult Cuponera(string email, string tel)
        {
           
            var dir = Server.MapPath("/Content/images/Restaurants/KitchenPark");
            var path = Path.Combine(dir,"Cuponera.PNG"); //validate the path for security or use other means to generate the path.
            return base.File(path, "image/png");
        }
    }
}