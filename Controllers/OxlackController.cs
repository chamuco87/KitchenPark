using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenPark.Models;
using System.Net;
using System.Net.Mail;

namespace KitchenPark.Controllers
{
    public class OxlackController : Controller
    {
        private DB_A57E75_chamucolol87Entities1 db = new DB_A57E75_chamucolol87Entities1();
        public ActionResult Index()
        {
            var tblSummary = db.ReservationDetails.Where(m => m.status == "Confirmed/Paid").GroupBy(l => l.tableNumber)
             .Select(cl => new TableSummary
               {
                   TableNumber = cl.FirstOrDefault().tableNumber,
                   Occupied = cl.Sum(c => c.numberOfPeople),
                   Class = cl.Sum(c => c.numberOfPeople) == 0 ? "status-free" : cl.Sum(c => c.numberOfPeople) == 4 ? "status-occupied" : "status-normal"
               }).ToList();

            List<TableSummary> finalTbl = new List<TableSummary>();
            for (int tableNumber = 1; tableNumber <= 16; tableNumber++)
            {
                var hasRecords = tblSummary.FirstOrDefault(m => m.TableNumber == tableNumber);
                if (hasRecords != null)
                {
                    finalTbl.Add(hasRecords);
                }
                else
                {
                    var newRecord = new TableSummary
                    {
                        TableNumber = tableNumber,
                        Occupied = 0,
                        Class = "status-free"
                    };

                    finalTbl.Add(newRecord);
                }
            }

            return View("~/Views/Home/Oxlack.cshtml", finalTbl);
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
        //public ActionResult Stevenson()
        //{

        //    return View("~/Views/Home/Stevenson.cshtml");
        //}
        public ActionResult Oxlack()
        {

            var tblSummary = db.ReservationDetails.Where(m => m.status == "Confirmed/Paid").GroupBy(l => l.tableNumber)
              .Select(cl => new TableSummary
                {
                    TableNumber = cl.FirstOrDefault().tableNumber,
                    Occupied = cl.Sum(c => c.numberOfPeople),
                    Class = cl.Sum(c => c.numberOfPeople) == 0 ? "status-free" : cl.Sum(c => c.numberOfPeople) == 4 ? "status-occupied" : "status-normal"
                }).ToList();

            List<TableSummary> finalTbl = new List<TableSummary>();
            for (int tableNumber = 1; tableNumber <= 16; tableNumber++)
            {
                var hasRecords = tblSummary.FirstOrDefault(m => m.TableNumber == tableNumber);
                if (hasRecords != null)
                {
                    finalTbl.Add(hasRecords);
                }
                else
                {
                    var newRecord = new TableSummary
                    {
                        TableNumber = tableNumber,
                        Occupied = 0,
                        Class = "status-free"
                    };

                    finalTbl.Add(newRecord);
                }
            }

            return View("~/Views/Home/Oxlack.cshtml", finalTbl);
        }
        public ActionResult GetFormDetails(int table)
        {
            var availableSeats = 4;
            var record = db.ReservationDetails.Where(m => m.tableNumber == table && m.status == "Confirmed/Paid").ToList();
            if (record.Count > 0)
            {
                var numberOfPeople = record.Sum(u => u.numberOfPeople);
                availableSeats = 4 - numberOfPeople;
            }
            ViewBag.availableSeats = availableSeats;
            return View("~/Views/Home/_FormDetails.cshtml");
        }
        public ActionResult GetDinnerDetails(int numberOfPeople)
        {

            return View("~/Views/Home/_DinnerDetails.cshtml", numberOfPeople);
        }
        public ActionResult success(string me_reference_id)
        {
            var record = db.ReservationDetails.FirstOrDefault(m => m.me_reference_id == me_reference_id);


            string body = @"<table cellpadding='0' cellspacing='0' border='0' width='100%' class='m_-9170671452901837084marginFix'>
<tbody><tr><td align='center'>
<table cellpadding='0' cellspacing='0' border='0' width='467' class='m_-9170671452901837084full-width-container'>
<tbody><tr><td width='447' align='center' style='min-width:447px;padding:0px 10px' class='m_-9170671452901837084full-width-container'>
<table cellpadding='0' cellspacing='0' border='0' width='100%'>
<tbody><tr><td align='center' style='padding-top:15px;font-size:8px;line-height:10px'>
</td></tr>
<tr><td align='center' style='padding:10px 0 5px;line-height:0px' height='43'>
</td></tr>
</tbody></table>
</td></tr>
</tbody></table>
</td></tr>
<tr><td align='center' width='100%'>

<table cellpadding='0' cellspacing='0' border='0' width='100%' class='m_-9170671452901837084marginFix'>
<tbody><tr><td align='center'>
<table cellpadding='0' cellspacing='0' border='0' width='467' class='m_-9170671452901837084full-width-container'>
<tbody><tr><td width='447' align='center' style='min-width:447px;padding:0 10px 0' class='m_-9170671452901837084full-width-container'>
<table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='min-width:100%'><tbody><tr><td>


<table width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ffffff'>
  <tbody><tr>
    <td style='border:1px solid #bfbfbf;border-bottom:none;background:#002da1 url('https://ci6.googleusercontent.com/proxy/PtnAJsDCKiRXXXzE28pAyfwIB8W11Yfri_HnyRxWSVBF81UDiNIEbZ2xcOGkc1MNAuL78K6QyM4mMZODzLmBOZgkuwYvalk-ViF-1VknIl8P5jH5CgVUXfUvqH1y-934_fH99r7KPQ4OJLyYDblEowZsqi8IvyP-yk9c9Wk=s0-d-e1-ft#https://image.mailing.ticketmaster.com/lib/fe9e15747366047975/m/1/b58a380c-2533-49ff-b916-3059814c1503.png') no-repeat top center' background='https://ci6.googleusercontent.com/proxy/PtnAJsDCKiRXXXzE28pAyfwIB8W11Yfri_HnyRxWSVBF81UDiNIEbZ2xcOGkc1MNAuL78K6QyM4mMZODzLmBOZgkuwYvalk-ViF-1VknIl8P5jH5CgVUXfUvqH1y-934_fH99r7KPQ4OJLyYDblEowZsqi8IvyP-yk9c9Wk=s0-d-e1-ft#https://image.mailing.ticketmaster.com/lib/fe9e15747366047975/m/1/b58a380c-2533-49ff-b916-3059814c1503.png'>
      <table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>
        <tbody><tr>
          <td class='m_-9170671452901837084noMobileHeight' style='padding:26px 16px 5px;color:#ffffff;text-align:center'>
            <h1 style='color:white !important'> <name>, los detalles de tu compra.
            </h1>
          </td>
        </tr>
        <tr>
          <td class='m_-9170671452901837084noMobileHeight' style='padding:0 16px 22px;color:#ffffff;text-align:center'>
            <a  style='text-decoration:none' target='_blank' ><font style='color:#ffffff'>Cuenta <cuenta></font></a>
          </td>
        </tr>
      </tbody></table>
    </td>
  </tr>
</tbody></table>





<table width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ffffff'>
  <tbody><tr>
    

    <td style='border:1px solid #bfbfbf;border-top:none;border-bottom:1px solid #bfbfbf'>

      <table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>
        <tbody><tr>
          <td>
            <table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>
              <tbody><tr>
                <td>
                  <table class='m_-9170671452901837084stackTbl' style='display:inline' width='215' cellspacing='0' cellpadding='0' border='0' align='left'>
                    <tbody><tr>
                      <td style='padding:16px 0px 10px 16px;vertical-align:top;text-align:center;margin-top:0!important' class='m_-9170671452901837084stackTbl' width='215'>
                        <img src='http://kitchenpark.com.mx/Content/images/Restaurants/Oxlack/Tickets/Ox<ticketNumber>.PNG' width='215' />          
                      </td>
                    </tr>
                  </tbody></table>
                  <table class='m_-9170671452901837084stackTbl' style='display:inline' width='200' cellspacing='0' cellpadding='0' border='0' align='right'>
                    <tbody><tr>
                      <td style='vertical-align:top;padding-top:20px;margin-top:0!important' class='m_-9170671452901837084stackTbl' width='175'>
                        <table width='100%' cellspacing='0' cellpadding='0' border='0' align='left'>
                          <tbody><tr>
                            <td style='font-size:18px;line-height:22px;font-weight:bold;padding-left:16px;padding-right:16px'>
                              Podcast en vivo con Oxlack en La Capital-MX
                            </td>
                          </tr>
                        </tbody></table>

                        <table width='100%' cellspacing='0' cellpadding='0' border='0' align='left'>
                          <tbody><tr>
                            <td style='padding:18px 10px 16px 16px' width='18' valign='top'>
                              <img src='https://ci6.googleusercontent.com/proxy/8UyPBVWidtI1ElvwOuVPcHJWiI-dpudviShePXsCV4tGbcepoEhHLEms_ndngefaR7PaRyGum8vFIoquTL8T1Lrg5fdMNTDOOYvLyZwczoMSgSZvzTGfLpdOf1fqKRZpzt-KUmO9dbza9sMr_YEJ9DSTATLG8u66K_CILjQ=s0-d-e1-ft#https://image.mailing.ticketmaster.com/lib/fe9e15747366047975/m/1/e08ab839-29f0-4849-8f9f-39a1c73df875.png' width='16' height='21' class='CToWUd' data-bit='iit'>
                            </td>
                            <td style='padding:16px 16px 16px 0;font-weight:normal;font-size:14px;line-height:16px;text-align:left;vertical-align:middle' valign='top'>
                              
                              <font style='color:#262626!important'>La Capital-MX, Kitchen Park, Monterrey</font>
                              
                            </td>
                          </tr>
                        </tbody></table>

                        
                            <table width='100%' cellspacing='0' cellpadding='0' border='0' align='left'>
                              <tbody><tr>
                                <td style='padding:0px 10px 16px 16px' width='18' valign='top'>
                                  <img src='https://ci4.googleusercontent.com/proxy/Mge7WT0gewCy3eNI62LJrlzcj0iqwv0wyPb6CuBlS5Cw9FeIXWJcfwLFxeIvu6P0PMZguXgUypgy0oLutcSkr2JU3IGmT2n38Yah6hOBN60ex1K8zBttfXHAWCQT3zR55hzM-oHJZSuqollt_IJy5mtUP9jGfNFv04vuFgQ=s0-d-e1-ft#https://image.mailing.ticketmaster.com/lib/fe9e15747366047975/m/1/eafb3c6f-15c2-4d46-a66e-84dede326386.png' width='18' height='18' class='CToWUd' data-bit='iit'>
                                </td>
                                <td style='padding:0px 16px 16px 0;font-weight:normal;font-size:14px;line-height:16px;text-align:left;vertical-align:middle' valign='top'>
                          
                        <font style='color:#262626!important'>May 20 May 2023 @  8:00 pm</font>
                        
                        </td>
                        </tr>
                        </tbody></table>
                        

                      </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
            </tbody></table>
          </td>
        </tr>
        
      </tbody></table>


  </td>
  </tr>


  <tr>
    <td style='border:1px solid #bfbfbf;border-top:none;padding-bottom:16px'>
      <table width='100%' cellspacing='0' cellpadding='0' border='0' align='left'>
        <tbody><tr>
          <td style='padding:16px 16px 0;font-size:18px;line-height:20px'>
            <b>Tu compra
            </b>
          </td>
        </tr>
        <tr>
          <td>
            <table class='m_-9170671452901837084stackTbl' style='display:inline;margin-top:0!important' width='215' cellspacing='0' cellpadding='0' border='0' align='left'>
              <tbody><tr>
                <td style='padding:16px 5px 0px 16px;vertical-align:top' width='30'>
                  <img src='https://ci4.googleusercontent.com/proxy/1TErHwr2kpD9EpSt9u6B0MvquqAyFS2OS7LbU5wivTnuPujoXYcEc57xdSlcna8G_covi-rK4plAxlKCE8-260Zgbmduhcw00Gpjwn2YXs-58u44dOJazaotzyUZq6HjWWa4ob4OmFaDOYz3cNzgWb6MdHB4Hj-WAInjEwQ=s0-d-e1-ft#https://image.mailing.ticketmaster.com/lib/fe9e15747366047975/m/1/f28e29a5-816c-456f-9be4-8003cbcd1218.png' width='26' height='26' class='CToWUd' data-bit='iit'>
                </td>
                <td style='padding:16px 16px 0px 0px'>
                  <b><numero>x</b> Ticket

                </td>
              </tr>
            </tbody></table>
            <table class='m_-9170671452901837084stackTbl' style='display:inline;margin-top:0!important' width='200' cellspacing='0' cellpadding='0' border='0' align='right'>
              <tbody><tr>
                <td style='padding:12px 16px 0'>
                  <table class='m_-9170671452901837084wide-btn m_-9170671452901837084stackTbl' width='168' cellspacing='0' cellpadding='0' border='0' align='right'>
                    <tbody><tr>
                      <td style='font-weight:bold;color:#ffffff;font-weight:normal;padding:0 30px;background-color:#026cdf;border-radius:2px' height='37' align='center'>
                        Confirmado
                        </td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>
              </tbody></table>
            </td>
        </tr>

        <tr>
          <td style='padding:16px 16px 0'>

            <table width='100%' cellspacing='0' cellpadding='0' border='0' align='left'>

        
        <tbody><tr>

          
          <td colspan='3' style='padding:10px 0;border-top:1px solid #bfbfbf;border-bottom:1px solid #ebebeb'>
            <span class='il'>Boleto</span> normal
          </td>
        </tr>
        
        <tr>
          <td style='padding:10px 0;width:40%'>
            <table cellspacing='0' cellpadding='0' border='0' align='left'>
              <tbody><tr>
                <td style='font-weight:bold;font-size:12px;line-height:14px;color:#0150a7'>
                  SECCIÓN
                </td>
              </tr>
              <tr>
                <td>Mesa: <mesa>
                </td>
              </tr>
            </tbody></table>
          </td>
          <td style='padding:10px 0'>
            <table cellspacing='0' cellpadding='0' border='0' align='left'>
              <tbody><tr>
                <td style='font-weight:bold;font-size:12px;line-height:14px;color:#0150a7;padding-left:5px;border-left:1px solid #ebebeb'>
                  Personas
                </td>
              </tr>
              <tr>
                <td style='padding-left:5px;border-left:1px solid #ebebeb'>
                   <personas>
                   
                </td>
              </tr>
            </tbody></table>
          </td>
          <td style='padding:10px 0;width:35%'>
            <table cellspacing='0' cellpadding='0' border='0' align='left'>
              <tbody><tr>
                <td style='font-weight:bold;font-size:12px;line-height:14px;color:#0150a7;padding-left:5px;border-left:1px solid #ebebeb'>
                  Platillos
                </td>
              </tr>
              <tr>
                <td style='padding-left:5px;border-left:1px solid #ebebeb'>
                   La Capital-MX
                   
                </td>
              </tr>
            </tbody></table>
          </td>
        </tr>
        

        <tr>
          <td colspan='3' style='padding:10px 0;border-top:1px solid #ebebeb;font-size:12px'>
        
            PAGADO
        
      </td>
      </tr>


        
        


        
</tbody></table>
</td></tr>


      </tbody></table>
    </td>
  </tr>
  <tr>
    <td style='height:30px;line-height:30px'>&nbsp;
    </td>
  </tr>
</tbody></table>








<table width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ffffff'>
  <tbody><tr>
    <td style='padding:0 16px'>
      <table width='100%' cellspacing='0' cellpadding='0' border='0' align='left'>
        <tbody><tr>
          <td style='text-align:center'>
            <b>ESTE MAIL ES VÁLIDO PARA ENTRAR AL EVENTO
            </b>
          </td>
        </tr>
      </tbody></table>
    </td>
  </tr>
</tbody></table>

<table width='100%' cellspacing='0' cellpadding='0' border='0'>
  <tbody><tr>
    <td style='height:30px;line-height:30px'>&nbsp;
    </td>
  </tr>
</tbody></table>




















</td></tr></tbody></table>
</td></tr>
</tbody></table>
</td></tr>
</tbody></table>
</td></tr>
</tbody></table>";

            if (record != null)
            {
                var latestTicket = db.ReservationDetails.OrderByDescending(m => m.qrTicket).Select(m => m.qrTicket).FirstOrDefault();
                if (latestTicket == null)
                {
                    latestTicket = 0;
                }

                record.qrTicket = latestTicket + 1;
                body = body.Replace("<name>", record.name).Replace("<numero>", record.numberOfPeople.ToString()).Replace("<mesa>", record.tableNumber.ToString()).Replace("<personas>", record.numberOfPeople.ToString()).Replace("<ticketNumber>", record.qrTicket.ToString());

            }

            if (record != null && record.status != "Confirmed/Paid")
            {
                record.status = "Confirmed/Paid";



                var fromAddress = new MailAddress("jose@carbajalsalinas.com", "La Capital-MX");
                var toAddress = new MailAddress(record.Email, record.name);
                const string fromPassword = "QmericA2468";
                const string subject = "Boletos de Entrada al Podcast con Oxlack";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                var a = db.SaveChanges();
            }

            body = body.Replace("http://kitchenpark.com.mx", "");

            if (record == null)
            {
                body = "<h1>Reserva no encontrada.</h1>";
            }



            ViewBag.Body = body;
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