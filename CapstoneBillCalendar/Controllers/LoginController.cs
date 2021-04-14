using CapstoneBillCalendar.Models;
using CapstoneBillCalendar.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CapstoneBillCalendar.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login       

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel userModel)
        {            
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success)
            {
                FormsAuthentication.SetAuthCookie(userModel.Username, false);
                return View("~/Views/Home/Index.cshtml", userModel);
                //return View("LoginSuccess", userModel);
            }

            else
            {
                return View("LoginFailure", userModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {        
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}