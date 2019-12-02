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
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        
        public AddStudent()
        {
            InitializeComponent();
        }
        Users U = new Users();
        List<Buildings> B = new List<Buildings>();
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtFirstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.FirstName = txtFirstname.Text;
        }

        private void txtLastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.LastName = txtLastname.Text;
        }

        private void txtFacultyname_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.Facultyname = txtFacultyname.Text;
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        { 
            U.Amount_Fees = Convert.ToInt32(txtPrice.Text);
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.Username = txtUsername.Text;
        }


        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.PhoneNum = Convert.ToInt32(txtPhoneNumber.Text);
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rooms[] R = new Rooms[50];
            if (txtBuilding_ID.SelectedIndex == 0)
                U.Building_ID = 1;
            else if (txtBuilding_ID.SelectedIndex == 1)
                U.Building_ID = 2;
            else if (txtBuilding_ID.SelectedIndex == 2)
                U.Building_ID = 3;
            else if(txtBuilding_ID.SelectedIndex == 3)
                U.Building_ID = 4;
            DataAccess DA = new DataAccess();
            R = DA.GetRooms(U.Building_ID);
            if (txtRoom_ID.Items.Count == 0)
            {
                for (int i = 0; i < R[0].Counter; i++)
                {
                    if (R[i].Vacant_Beds != 0)
                    {
                        txtRoom_ID.Items.Add(R[i].Room_ID);
                    }
                }
            }
            else
            {
                txtRoom_ID.Items.Clear();
            }
        }
        int VacantBeds;
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Rooms[] R = new Rooms[50];
            DataAccess DA = new DataAccess(); 
            R = DA.GetRooms(U.Building_ID);
            for (int i = 0;i < R[0].Counter;i++)
            {
                if(R[i].Vacant_Beds != 0)
                {
                    U.Room_ID = R[i].Room_ID--;
                    VacantBeds = R[i].Vacant_Beds;
                }
            }
        }

        private void SaveEditStudent_Click(object sender, RoutedEventArgs e)
        {
            DataAccess insert = new DataAccess();
            U.Password = Convert.ToInt32(txtPassword.Password);
            int confirmpass = Convert.ToInt32(txtConfirmPassword.Password);
            if (U.Password == confirmpass)
            {
                insert.InsertINTOUser(U , VacantBeds);
                MainMenu Test = new MainMenu();
                Test.Show();
                this.Close();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Passwords Don't Match");
            }
        }

        private void CancelEditStudent_Click(object sender, RoutedEventArgs e)
        {
            MainMenu Test = new MainMenu();
            Test.Show();
            this.Close();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            U.Gender = "Male";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            U.Gender = "Female";
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.EMail = txtEmail.Text;
        }

        private void txtStudentID_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.User_ID = Convert.ToInt32(txtStudentID.Text);
        }
    }
}
