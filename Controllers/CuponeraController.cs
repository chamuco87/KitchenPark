using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenPark;

namespace KitchenPark.Controllers
{
    public class CuponeraController : Controller
    {
        private DB_A57E75_chamucolol87Entities1 db = new DB_A57E75_chamucolol87Entities1();
        public ActionResult Index()
        {

            return View("~/Views/Home/Cuponera.cshtml");
        }

        public ActionResult Validated()
        {
           
            var dir = Server.MapPath("/Content/images/Restaurants/KitchenPark");
            var path = Path.Combine(dir,"Cuponera.PNG"); //validate the path for security or use other means to generate the path.
            return base.File(path, "image/png");
        }

        [HttpPost]
        public ActionResult Validate(string email, string tel, string url)
        {
            Customer cust = new Customer();

            cust.Email = email;
            cust.Tel = tel;
            cust.Restaurant = url;
            cust.LoggedIn = DateTime.Now;
            db.Customers.Add(cust);

            db.SaveChanges();

            return Json(new { isSuccess = true }, JsonRequestBehavior.AllowGet);
        }
    }
}