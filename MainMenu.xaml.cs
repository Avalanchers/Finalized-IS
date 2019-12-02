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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent Test = new AddStudent();
            Test.Show();
            this.Close();
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentEdit Test = new StudentEdit();
            Test.Show();
            this.Close();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent Test = new DeleteStudent();
            Test.Show();
            this.Close();
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
