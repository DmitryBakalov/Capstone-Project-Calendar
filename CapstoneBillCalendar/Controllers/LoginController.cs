﻿using CapstoneBillCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBillCalendar.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login       

        public ActionResult Index()
        {
            return View("Login");
        }

        public string Login(UserModel userModel)
        {
            return "Results: Usename = " + userModel.Username + " Password = " + userModel.Password;
        }
    }
}