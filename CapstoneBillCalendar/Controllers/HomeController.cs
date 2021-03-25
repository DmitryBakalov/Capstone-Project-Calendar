using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBillCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetEvents()
        {
            using (BillCalendarDatabaseEntities dc = new BillCalendarDatabaseEntities())
            {
                var events = dc.BillPayments.ToList();
                return new JsonResult
                {
                    Data = events,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(BillPayment e)
        {
            var status = false;
            using (BillCalendarDatabaseEntities dc = new BillCalendarDatabaseEntities())
            {
                if (e.PaymentId > 0)
                {
                    // Update the event
                    var v = dc.BillPayments.Where(a => a.PaymentId == e.PaymentId).FirstOrDefault();
                    if (v != null)
                    {
                        v.PayeeName = e.PayeeName;
                        v.DueDate = e.DueDate;
                        v.PaidDate = e.PaidDate;
                        v.Description = e.Description;
                        v.Paid = e.Paid;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.BillPayments.Add(e);
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int paymentID)
        {
            var status = false;
            using (BillCalendarDatabaseEntities dc = new BillCalendarDatabaseEntities())
            {
                var v = dc.BillPayments.Where(a => a.PaymentId == paymentID).FirstOrDefault();
                if (v != null)
                {
                    dc.BillPayments.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
        
}