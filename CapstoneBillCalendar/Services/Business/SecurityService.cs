using CapstoneBillCalendar.Models;
using CapstoneBillCalendar.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneBillCalendar.Services.Business
{
    // This class will be used to authenticate the users 
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindUser(user);
        }
    }
}