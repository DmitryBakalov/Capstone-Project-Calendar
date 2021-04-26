using CapstoneBillCalendar.Models;
using CapstoneBillCalendar.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneBillCalendar.Services.Business
{
    // This class is used to authenticate the users 
    public class SecurityService
    {
        readonly SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindUser(user);
        }
    }
}