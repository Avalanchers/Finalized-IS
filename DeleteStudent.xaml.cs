using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DeleteStudent.xaml
    /// </summary>
    public partial class DeleteStudent : Window
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }
        Users U = new Users();
        public static class idk
        {
            public static int RoomID { get; set; }
            public static int NumberBeds { get; set; }
            public static int VacantBeds { get; set; }
        }
        private void CancelDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            MainMenu Test = new MainMenu();
            Test.Show();
            this.Close();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete Student Entry?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand("SELECT Room_ID FROM Room_User WHERE User_ID = @UserID", conn))
                    {
                        comm.Parameters.AddWithValue("@UserID", txtStudentID.Text);
                        conn.Open();
                        SqlDataReader rd = comm.ExecuteReader();
                        if (rd.Read())
                            idk.RoomID = Convert.ToInt32(rd.GetValue(0));
                        conn.Close();
                    }
                }
                using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand("DELETE FROM [Room_User] WHERE User_ID = @User_id", conn))
                    {
                        comm.Parameters.AddWithValue("@User_ID", txtStudentID.Text);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    using (SqlCommand comm = new SqlCommand("SELECT Number_Beds , Vacant_Beds FROM Room WHERE Room_ID = @Room_ID", conn))
                    {
                        comm.Parameters.AddWithValue("@Room_ID", idk.RoomID);
                        conn.Open();
                        SqlDataReader rd = comm.ExecuteReader();
                        rd.Read();
                        idk.NumberBeds = Convert.ToInt32(rd["Number_Beds"]);
                        idk.VacantBeds = Convert.ToInt32(rd["Vacant_Beds"]);
                        conn.Close();
                    }
                    using (SqlCommand comm = new SqlCommand("UPDATE Room SET Vacant_Beds = @Vacant_Beds WHERE Room_ID = @RoomID", conn))
                    {
                        idk.VacantBeds++;
                        comm.Parameters.AddWithValue("@RoomID", idk.RoomID);
                        comm.Parameters.AddWithValue("@Vacant_Beds", idk.VacantBeds);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    using (SqlCommand comm = new SqlCommand("DELETE FROM [User] WHERE User_ID = @User_ID", conn))
                    {
                        comm.Parameters.AddWithValue("@User_ID", txtStudentID.Text);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
        }
        private void txtFirstname_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtLastname_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtEmal_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtFacultyname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtStudentID.Text != "")
            {
                SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT First_Name , Last_Name , Facultyname , EMail FROM [User] WHERE User_ID = @UseID", conn);
                comm.Parameters.AddWithValue("@UseID", Convert.ToInt32(txtStudentID.Text));
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    txtFirstname.Text = rd.GetValue(0).ToString();
                    txtLastname.Text = rd.GetValue(1).ToString();
                    txtFacultyname.Text = rd.GetValue(2).ToString();
                    txtEmail.Text = rd.GetValue(3).ToString();
                }
                conn.Close();
            }
            else
            {

            }
        }
    }
}
