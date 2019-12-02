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
        List<Rooms>[] TBRoom = new List<Rooms>[50];
        List<Buildings> TBBuilding = new List<Buildings>();
        public Users GetUsers(string Username)
        {
            Users U = new Users();
            //using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            //{
            //    using(SqlCommand comm = new SqlCommand("SELECT User_ID , First_Name , Last_Name , Facultyname , EMail , PhoneNum , Amount_Fees , Room_ID , Building_ID , Gender FROM [User] WHERE Username = @Username" , conn))
            //    {
            //        comm.Parameters.AddWithValue("@Username", Username);
            //        //if(Username == null)
            //        //{
            //        //    unitspram.Value = DBNull.Value;
            //        //}
            //        conn.Open();
            //        SqlDataReader rd = comm.ExecuteReader();
            //        //comm.Parameters.AddWithValue("@Password", Password);
                    
            //        while(rd.Read())
            //        {
            //            U.User_ID = Convert.ToInt32(rd.GetValue(0).ToString());
            //            U.FirstName = rd.GetValue(1).ToString();
            //            U.LastName = rd.GetValue(2).ToString();
            //            U.Facultyname = rd.GetValue(3).ToString();
            //            U.EMail = rd.GetValue(4).ToString();
            //            U.PhoneNum = Convert.ToInt32(rd.GetValue(5).ToString());
            //            U.Amount_Fees = Convert.ToInt32(rd.GetValue(6).ToString());
            //            U.Room_ID = Convert.ToInt32(rd.GetValue(7).ToString());
            //            U.Building_ID = Convert.ToInt32(rd.GetValue(8).ToString());
            //            U.Gender = rd.GetValue(9).ToString();              
            //        }
            //    }
            //}
            return U;
        }
        public Rooms[] GetRooms(int Building_ID)
        { 
            Rooms[] R = new Rooms[50];
            using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT COUNT(Room_ID) FROM Room WHERE Building_ID = @Building_ID";
                    comm.Parameters.AddWithValue("@Building_ID", Building_ID);
                    conn.Open();
                    Int32 number = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    comm.CommandText = "SELECT * FROM Room WHERE Building_ID = @BuildingID";
                    comm.Parameters.AddWithValue("@BuildingID", Building_ID);
                    conn.Open();
                    SqlDataReader rd = comm.ExecuteReader();
                    int x = 0;
                    while(rd.Read())
                    {
                        R[x] = new Rooms();
                        R[x].Counter = number; 
                        R[x].Room_ID = Convert.ToInt32(rd["Room_ID"]);
                        R[x].Number_Beds = Convert.ToInt32(rd["Number_Beds"]);
                        R[x].Price = Convert.ToInt32(rd["Price"]);
                        R[x].Vacant_Beds = Convert.ToInt32(rd["Vacant_Beds"]);
                        R[x].Building_ID = Convert.ToInt32(rd["Building_ID"]);
                        //TBRoom[x] = new List<Rooms>();
                        //TBRoom[x].Insert(0, R);
                        x++;
                    }
                    conn.Close();
                }
            }
            
            return R;
        }

        public List<Buildings> GetBuildings()
        {
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

        public bool Login(string Username , int Password)
        {
            using(SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using(SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";
                    comm.Parameters.AddWithValue("@Username", Username);
                    comm.Parameters.AddWithValue("@Password", Password);
                    conn.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.Fill(ds);
                    conn.Close();
                    bool Successful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
                    if (Successful)
                        return true;
                    else
                        return false;
                }
            }
        }
        public void InsertINTOUser(Users U , int VacantBeds)
        {
            using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {

                using (SqlCommand comm = conn.CreateCommand())
                {
                    VacantBeds -= 1;
                    comm.CommandText = "UPDATE Room SET Vacant_Beds = @VacantBeds WHERE Room_ID = @RoomID";
                    comm.Parameters.AddWithValue("@RoomID", U.Room_ID);
                    comm.Parameters.AddWithValue("@VacantBeds", VacantBeds);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                Rooms R = new Rooms();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "INSERT INTO [User](User_ID,Username,Password,Facultyname,EMail,PhoneNum,Amount_Fees,First_Name,Last_Name,Room_ID,Building_ID,Gender)" +
                   "VALUES(@UserID , @Username , @Password , @Facultyname , @EMail , @PhoneNum , @Amount_Fees , @First_Name , @Last_Name , @Room_ID , @Building_ID , @Gender);";
                    comm.Parameters.AddWithValue("@UserID", U.User_ID);
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
                using(SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "INSERT INTO Room_User(User_ID , Room_ID , First_Name , Last_Name , Facultyname)" +
                        "VALUES(@User_ID , @Room_ID , @First_Name , @Last_Name , @Facultyname);";
                    comm.Parameters.AddWithValue("@User_ID", U.User_ID);
                    comm.Parameters.AddWithValue("@Room_ID", U.Room_ID);
                    comm.Parameters.AddWithValue("@First_Name", U.FirstName);
                    comm.Parameters.AddWithValue("@Last_Name", U.LastName);
                    comm.Parameters.AddWithValue("@Facultyname", U.Facultyname);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void UpdateRoom(int Price , int Room_ID , int VacantBeds)
        {
            using(SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using(SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "UPDATE Room SET Price = @Price , Vacant_Beds = @VacantBeds WHERE Room_ID = @RoomID";
                    comm.Parameters.AddWithValue("@RoomID", Room_ID);
                    comm.Parameters.AddWithValue("@Price", Price);
                    comm.Parameters.AddWithValue("@VacantBeds", VacantBeds);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void UpdateRoom_Bed(int Room_ID , List<Rooms> test)
        {
            using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                
            }
        }
        public void UpdateUser(int User_ID , string First_Name, string Last_Name, string Facultyname, string EMail, int PhoneNum, int Amount_Fees, int Room_ID, int Building_ID)
        {
            //using(SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            //{
            //    using(SqlCommand comm = conn.CreateCommand())
            //    {
            //        comm.CommandText = "UPDATE User SET First_Name = @FirstName , Last_Name = @LastName , Facultyname = @Facultyname , EMail = @Email , PhoneNum = @PhoneNum , Amount_Fees = @AmountFees , Room_ID = @Room_ID , Building_ID = @Building_ID WHERE User_ID = @User_ID";
            //        comm.Parameters.AddWithValue("@FirstName", First_Name);
            //        comm.Parameters.AddWithValue("@LastName", Last_Name);
            //        comm.Parameters.AddWithValue("@Facultyname", Facultyname);
            //        comm.Parameters.AddWithValue("@Email", EMail);
            //        comm.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            //        comm.Parameters.AddWithValue("@Amount_Fees", Amount_Fees);
            //        comm.Parameters.AddWithValue("@Room_ID", Room_ID);
            //        comm.Parameters.AddWithValue("@Building_ID", Building_ID);
            //        conn.Open();
            //        comm.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //}
        }

        public void DeleteUser(string Username)
        {
            //using(SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            //{
            //    using(SqlCommand comm = new SqlCommand("DELETE FROM [User] WHERE Username = @Username" , conn))
            //    {
            //        comm.Parameters.AddWithValue("@Username", Username);
            //        conn.Open();
            //        comm.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //}
        }
    }
}
