using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBillCalendar.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewData["userName"] = User.Identity.Name;
            return View();            
        }
                

        public ActionResult About()
        {
            ViewBag.Message = "My contact information.";

            return View();
        }

        [Authorize]
        public ActionResult Calendar()
        {
            ViewBag.Message = "This is your Calendar";
            ViewData["userName"] = User.Identity.Name;
            return View();
        }

        public JsonResult GetRecords()
        {
            using (BillCalendarDatabaseEntities dc = new BillCalendarDatabaseEntities())
            {
                var filteredRecordsList = new List<BillPayment>();
                var records = dc.BillPayments.ToList();

                for (int i = 0; i < records.Count; i++)
                {
                    var currentUsername = records[i].username;

                    if (currentUsername == User.Identity.Name)
                    {
                        filteredRecordsList.Add(records[i]);
                    }
                }                                

                return new JsonResult
                {
                    Data = filteredRecordsList,
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
                        v.PaymentAmount = e.PaymentAmount;
                        v.DueDate = e.DueDate;
                        v.PaidDate = e.PaidDate;
                        v.Description = e.Description;
                        v.Paid = e.Paid;
                        v.ThemeColor = e.ThemeColor;
                        v.username = e.username;
                    }
                }
                else
                {
                    dc.BillPayments.Add(e);
                }

                dc.SaveChanges();
                status = true;
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