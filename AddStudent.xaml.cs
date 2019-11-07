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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.LastName = Last.Text;
        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            U.FirstName = First.Text;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            U.Username = Username.Text;
        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            U.EMail = Email.Text;
        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            U.Facultyname = Faculty.Text;
        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {
            U.PhoneNum = Convert.ToInt32(Phone.Text);
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            DataAccess read = new DataAccess();
            B = read.GetBuildings();
            Buildings.Items.Add(B[0].Building_ID.ToString());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataAccess read = new DataAccess();
            B = read.GetBuildings();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataAccess read = new DataAccess();
            B = read.GetBuildings();

        }

        private void TextBox_TextChanged_6(object sender, TextChangedEventArgs e)
        {
            U.Amount_Fees = Convert.ToInt32(Fees.Text);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            U.Gender = "Male";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            U.Gender = "Female";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataAccess insert = new DataAccess();
            U.Password = Convert.ToInt32(Pass.Password);
            int confirmpass = Convert.ToInt32(confirm.Password);
            if(U.Password == confirmpass)
            {
                insert.InsertINTOUser(U);
                this.Close();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Passwords Don't Match");
            }
        }
    }
}
