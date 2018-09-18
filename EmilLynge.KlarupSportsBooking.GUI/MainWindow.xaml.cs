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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmilLynge.KlarupSportsBooking.Business;

namespace EmilLynge.KlarupSportsBooking.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginHandler loginHandler;
        public MainWindow()
        {
            InitializeComponent();
            loginHandler = new LoginHandler();
        }

        private void btnLoginAsCompany_Click(object sender, RoutedEventArgs e)
        {
            if (loginHandler.loginAsCompany(txtCompanyNameLogin.Text, pwBCompanyPassword.Password))
            {

            }
            else
            {
                MessageBox.Show("Name and/or password is incorrect. Try again!");
            }
        }

        private void btnLoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (loginHandler.loginAsAdmin(txtAdminEmailLogin.Text, pwBAdminPassword.Password))
            {

            }
            else
            {
                MessageBox.Show("Email and/or password is incorrect. Try again!");
            }
        }
    }
}
