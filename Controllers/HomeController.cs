using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenPark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string view = "";
            Random random = new Random();
            var n = random.Next(0, 2);
            if (n == 0)
            {
                view = "~/Views/Home/Index.cshtml";
            }
            else {
                view = "~/Views/Home/Index.cshtml";
            }
            return View(view);
        }

        public ActionResult LaCapitalMX()
        {
            
            return View("~/Views/Home/LaCapitalMX.cshtml");
        }
        public ActionResult CaramelCoffee()
        {

            return View("~/Views/Home/CaramelCoffee.cshtml");
        }

        public ActionResult TacosP11()
        {

            return View("~/Views/Home/TacosP11.cshtml");
        }

        public ActionResult LosJemos()
        {

            return View("~/Views/Home/LosJemos.cshtml");
        }
        public ActionResult MrBeef()
        {

            return View("~/Views/Home/MrBeef.cshtml");
        }
        public ActionResult JimJim()
        {

            return View("~/Views/Home/JimJim.cshtml");
        }
        public ActionResult TheBBQBros()
        {

            return View("~/Views/Home/TheBBQBros.cshtml");
        }
        public ActionResult QueenDelivery()
        {

            return View("~/Views/Home/QueenDelivery.cshtml");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}