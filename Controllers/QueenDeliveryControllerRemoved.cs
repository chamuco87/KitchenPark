using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenPark.Controllers
{
    public class QueenDeliveryControllerRemoved : Controller
    {
        public ActionResult IndexRemoved()
        {

            return View("~/Views/Home/QueenDeliveryRemoved.cshtml");
        }
    }
}