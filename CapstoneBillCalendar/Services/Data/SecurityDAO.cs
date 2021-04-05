using CapstoneBillCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneBillCalendar.Services.Data
{
    // This class will work with the database
    public class SecurityDAO
    {
        internal bool FindUser(UserModel user)
        {
            if (user.Username == "Kot" && user.Password == "qwer")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}