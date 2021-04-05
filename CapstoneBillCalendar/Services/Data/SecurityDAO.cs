using CapstoneBillCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CapstoneBillCalendar.Services.Data
{
    // This class will work with the database
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\darkb\source\repos\Capstone-Project-Calendar\CapstoneBillCalendar\App_Data\BillCalendarDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        internal bool FindUser(UserModel user)
        {
            // Assume that query did not find any users
            bool success = false;

            // Writhe the query
            string queryString = "SELECT * FROM Users WHERE username = @Username AND password = @Password";

            // Create and open database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);

                // Associating @Username placeholder with the actual value of the model user.Username
                command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

                // Open database and run the command
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            return success;
        }
    }
}