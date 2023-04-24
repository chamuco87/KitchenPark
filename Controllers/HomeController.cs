using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenPark.Models;

namespace KitchenPark.Controllers
{
    public class HomeController : Controller
    {
        private DB_A57E75_chamucolol87Entities1 db = new DB_A57E75_chamucolol87Entities1();
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
        //public ActionResult QueenDelivery()
        //{

        //    return View("~/Views/Home/QueenDelivery.cshtml");
        //}
        public ActionResult Stevenson()
        {

            return View("~/Views/Home/Stevenson.cshtml");
        }
        public ActionResult Oxlack()
        {

            return View("~/Views/Home/Oxlack.cshtml");
        }
        public ActionResult GetFormDetails(int table)
        {

            return View("~/Views/Home/_FormDetails.cshtml");
        }
        public ActionResult GetDinnerDetails(int numberOfPeople)
        {

            return View("~/Views/Home/_DinnerDetails.cshtml", numberOfPeople);
        }
        public ActionResult success(string me_reference_id)
        {
            var record = db.ReservationDetails.FirstOrDefault(m => m.me_reference_id == me_reference_id);
            record.status = "Confirmed/Paid";

            var a = db.SaveChanges();

            return View("~/Views/Home/OxlackConfirmation.cshtml");
        }
        public ActionResult RequestPayment(ReservationDetails requestDetails)
        {
            ReservationDetail request = new ReservationDetail();
            request.me_reference_id = "OX" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Millisecond.ToString();
            request.name = requestDetails.name;
            request.Email = requestDetails.email;
            request.Tel = requestDetails.telefono;
            request.numberOfPeople = requestDetails.numberOfPeople;
            request.totalPrice = requestDetails.totalPrice;
            request.platillo1 = requestDetails.selections[0].platillo;
            request.bebida1 = requestDetails.selections[0].bebida;
            request.observaciones1 = null;
            request.platillo2 = requestDetails.selections[1].platillo;
            request.bebida2 = requestDetails.selections[1].bebida;
            request.observaciones2 = null;
            request.platillo3 = requestDetails.selections[2].platillo;
            request.bebida3 = requestDetails.selections[2].bebida;
            request.observaciones3 = null;
            request.platillo4 = requestDetails.selections[3].platillo;
            request.bebida4 = requestDetails.selections[3].bebida;
            request.observaciones4 = null;
            request.tableNumber = requestDetails.tableNumber;
            request.RequestedOn = DateTime.Now;
            request.status = "Requested";

            db.ReservationDetails.Add(request);

            var a = db.SaveChanges();

            return Json(new { me_reference_id = request.me_reference_id }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateRequest(string payment_request_id, string me_reference_id)
        {
            

            var record = db.ReservationDetails.FirstOrDefault(m => m.me_reference_id == me_reference_id);
            record.status = "Updated";
            record.payment_request_id = payment_request_id;

            var a = db.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cuponera()
        {

            return View("~/Views/Home/Cuponera.cshtml");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}