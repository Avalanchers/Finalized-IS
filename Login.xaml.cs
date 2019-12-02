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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        Users U = new Users();
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DataAccess DA = new DataAccess();
            bool Successful = DA.Login(U.Username, Convert.ToInt32(txtPassword.Password));
            if (Successful)
            {
                MessageBoxResult message = MessageBox.Show("Login Successful!");
                MainMenu test = new MainMenu();
                test.Show();
                this.Close();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Either Username Or Password Are Incorrect\nPlease Check Credentials");
            }
        }
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            U.Username = txtUsername.Text;
        }
    }
}
