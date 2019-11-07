using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1
{
    class DataAccess
    {

        List<Users> TBUser = new List<Users>();
        List<Rooms> TBRoom = new List<Rooms>();
        List<Buildings> TBBuilding = new List<Buildings>();
        public List<Users> GetUsers(string Username, int Password)
        {
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Project")))
            //{
            //    var output = connection.Query<Users>($"SELECT * FROM User WHERE Username = '{Username}' AND Password = {Password};").ToList();
            //    return output;
            //}
            using(SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using(SqlCommand comm = new SqlCommand("SELECT * FROM User WHERE Username = @Username AND Password = @Password;" , conn))
                {
                    if (comm.Connection.State == System.Data.ConnectionState.Closed)
                        conn.Open();
                    SqlDataReader rd = comm.ExecuteReader();
                    comm.Parameters.AddWithValue("@Username", Username);
                    comm.Parameters.AddWithValue("@Password", Password);
                    Users U = new Users();
                    while(rd.Read())
                    {
                        U.FirstName = rd["First_Name"].ToString();
                        U.LastName = rd["Last_Name"].ToString();
                        U.Facultyname = rd["Facultyname"].ToString();
                        U.EMail = rd["EMail"].ToString();
                        U.PhoneNum = Convert.ToInt32(rd["PhoneNum"]);
                        U.Amount_Fees = Convert.ToInt32(rd["Amount_Fees"]);
                        U.Room_ID = Convert.ToInt32(rd["Room_ID"]);
                        U.Building_ID = Convert.ToInt32(rd["Building_ID"]);
                        U.Gender = rd["Gender"].ToString();
                        TBUser.Add(U);
                    }
                }
            }
            return TBUser;
        }
        public List<Rooms> GetRooms(int Room_ID)
        {
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Project")))
            //{
            //    var output = connection.Query<Rooms>($"SELECT * FROM User WHERE Room_ID = {Room_ID} AND Vacant_Beds != 0;").ToList();
            //    return output;
            //}
        }

        public List<Buildings> GetBuildings()
        {
            //using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Project")))
            //{
            //    var output = connection.Query<Buildings>($"SELECT * FROM Building").ToList();
            //    return output;
            //}
            Buildings B = new Buildings();
            using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM Building";
                    SqlDataReader rd = comm.ExecuteReader();
                    while (rd.Read())
                    {
                        B.Building_ID = Convert.ToInt32(rd["Building_ID"]);
                        B.Number_Rooms = Convert.ToInt32(rd["Number_Rooms"]);
                        B.Gender = rd["Gender"].ToString();
                        TBBuilding.Add(B);
                    }
                }
            }
            return TBBuilding;
        }

        public void InsertINTOUser(Users U)
        {
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Project")))
            //{
            //    SqlCommand insert = new SqlCommand("INSERT INTO User(Username,Password,First_Name,Last_Name,Facultyname,EMail,PhoneNum,Amount_Fees,Room_ID,Building_ID) VALUES ('" + Username + "'," + Password + ",'" + First_Name + "','" + Last_Name + "','" + Facultyname + "','" + EMail + "'," + PhoneNum + "," + Amount_Fees + "," + Room_ID + "," + Building_ID + ");");
            //    insert.ExecuteNonQuery();
            //}
            using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "INSERT INTO [User](Username,Password,Facultyname,EMail,PhoneNum,Amount_Fees,First_Name,Last_Name,Room_ID,Building_ID,Gender)" +
                   "VALUES(@Username , @Password , @Facultyname , @EMail , @PhoneNum , @Amount_Fees , @First_Name , @Last_Name , @Room_ID , @Building_ID , @Gender);";
                    comm.Parameters.AddWithValue("@Username", U.Username);
                    comm.Parameters.AddWithValue("@Password", U.Password);
                    comm.Parameters.AddWithValue("@Facultyname", U.Facultyname);
                    comm.Parameters.AddWithValue("@EMail", U.EMail);
                    comm.Parameters.AddWithValue("@PhoneNum", U.PhoneNum);
                    comm.Parameters.AddWithValue("@Amount_Fees", U.Amount_Fees);
                    comm.Parameters.AddWithValue("@First_Name", U.FirstName);
                    comm.Parameters.AddWithValue("@Last_Name", U.LastName);
                    comm.Parameters.AddWithValue("@Room_ID", U.Room_ID);
                    comm.Parameters.AddWithValue("@Building_ID", U.Building_ID);
                    comm.Parameters.AddWithValue("@Gender", U.Gender);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void UpdateRoom(int Price , int Room_ID)
        {
            //try
            //{
            //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Project")))
            //    {
            //        SqlCommand UpdateR = new SqlCommand("UPDATE Room r SET Price = " + Price + "WHERE r.Room_ID = " + Room_ID + ";");
            //        UpdateR.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
        public void UpdateUser(int User_ID , string First_Name, string Last_Name, string Facultyname, string EMail, int PhoneNum, int Amount_Fees, int Room_ID, int Building_ID)
        {
            //try
            //{
            //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Project")))
            //    {
            //        SqlCommand UpdateU = new SqlCommand("UPDATE User u SET u.First_Name = " + "'" + First_Name + "',u.Last_Name = '" + Last_Name + "',u.Facultyname = '" + Facultyname + "',EMail = '" + EMail + "',PhoneNum = " + PhoneNum + ",Amount_Fees = " + Amount_Fees + ",Room_ID = " + Room_ID + ",Building_ID = " + Building_ID + " WHERE User_ID = " + User_ID + ";");
            //        UpdateU.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
    }
}
