using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace WpfApp1
{
    public class Users
    {
        public int User_ID { get; set; }
        
        public string Username { get; set; }

        public int Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Facultyname { get; set; }

        public string EMail { get; set; }

        public int PhoneNum { get; set; }

        public int Amount_Fees { get; set; }

        public int Room_ID { get; set; }

        public int Building_ID { get; set; }

        public string Gender { get; set; }

    }
    public static class PublicParameters
    {
        //public static Users CurrrentUser;
        public static string ConnectionString = @"Server=DESKTOP-CD9Q2K9\YEIMSFSQL; Database=Project; Integrated Security=SSPI; User ID=sa; Password=0Y10e92i64m69s68F;";
    }
}
