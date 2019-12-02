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
using System.Data.SqlClient;
using Dapper;
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for StudentEdit.xaml
    /// </summary>
    public partial class StudentEdit : Window
    {
        public StudentEdit()
        {
            InitializeComponent();
        }
        Users U = new Users();
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtBuildingID_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void txtRoomID_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void txtFees_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SaveEditStudent_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand("UPDATE [User] SET First_Name = @Firstname , Last_Name = @Lastname , Password = @Password , EMail = @Email , Facultyname = @Facultyname , PhoneNum = @PhoneNum , Amount_Fees = @Amount_Fees , Room_ID = @Room_ID , Building_ID = @Building_ID WHERE User_ID = @UserID", conn))
                {
                    comm.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                    comm.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                    comm.Parameters.AddWithValue("@Email", txtEmail.Text);
                    comm.Parameters.AddWithValue("@Facultyname", txtFacultyname.Text);
                    comm.Parameters.AddWithValue("@Password", txtPassword.Password);
                    comm.Parameters.AddWithValue("@UserID", txtStudentID.Text);
                    comm.Parameters.AddWithValue("@PhoneNum", txtPhone.Text);
                    comm.Parameters.AddWithValue("@Amount_Fees", txtFees.Text);
                    comm.Parameters.AddWithValue("@Room_ID", txtRoomID.Text);
                    comm.Parameters.AddWithValue("@Building_ID", txtBuildingID.Text);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                using(SqlCommand comm = new SqlCommand("UPDATE [Room_User] SET First_Name = @FirstName , Last_Name = @LastName , Facultyname = @FacultyName WHERE User_ID = @UseID"))
                {
                    comm.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                    comm.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                    comm.Parameters.AddWithValue("@UserID", txtStudentID.Text);
                    comm.Parameters.AddWithValue("@Facultyname", txtFacultyname.Text);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBoxResult Message = MessageBox.Show("Student Updated Successfuly!");
                    MainMenu Test = new MainMenu();
                    Test.Show();
                    this.Close();
                }
            }
        }

        private void CancelEditStudent_Click(object sender, RoutedEventArgs e)
        {
            MainMenu Test = new MainMenu();
            Test.Show();
            this.Close();
        }

        private void DisplayEditStudent_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(PublicParameters.ConnectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT Username , First_Name , Last_Name , Password , EMail , Facultyname , Building_ID , Room_ID , PhoneNum , Amount_Fees FROM [User] WHERE User_ID = @User_ID", conn);
            comm.Parameters.AddWithValue("@User_ID", txtStudentID.Text);
            SqlDataReader rd = comm.ExecuteReader();
            while (rd.Read())
            {
                txtUsername.Text = rd.GetValue(0).ToString();
                txtFirstname.Text = rd.GetValue(1).ToString();
                txtLastname.Text = rd.GetValue(2).ToString();
                txtPassword.Password = rd.GetValue(3).ToString();
                txtEmail.Text = rd.GetValue(4).ToString();
                txtFacultyname.Text = rd.GetValue(5).ToString();
                txtBuildingID.Text = rd.GetValue(6).ToString();
                txtRoomID.Text = rd.GetValue(7).ToString();
                txtPhone.Text = rd.GetValue(8).ToString();
                txtFees.Text = rd.GetValue(9).ToString();
            }
            conn.Close();
        }

        private void txtFirstname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLastname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFacultyname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
