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
        AdminHandler adminHandler;
        public MainWindow()
        {
            InitializeComponent();
            loginHandler = new LoginHandler();
            adminHandler = new AdminHandler();
        }

        private void btnLoginAsCompany_Click(object sender, RoutedEventArgs e)
        {
            int id = loginHandler.loginAsCompany(txtCompanyNameLogin.Text, pwBCompanyPassword.Password);
            if (id != -1)
            {
                /// REMEMBER TO CHANGE COMPANY TO COMPANIES IN DB
            }
            else
            {
                MessageBox.Show("Name and/or password is incorrect. Try again!");
            }
        }

        private void btnLoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            int id = loginHandler.loginAsAdmin(txtAdminEmailLogin.Text, pwBAdminPassword.Password);

            if (id != -1)
            {
                var adminWindow = new AdminWindow(adminHandler.GetAdmin(id));
                adminWindow.Owner = this;
                adminWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Email and/or password is incorrect. Try again!");
                pwBAdminPassword.Password = "";
            }
        }
    }
}
