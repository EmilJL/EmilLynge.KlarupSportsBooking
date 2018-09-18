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
using EmilLynge.KlarupSportsBooking.Business;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.GUI
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        OngoingBookingsHandler oBHandler;
        SingleBookingsHandler sBHandler;
        Admin admin;
        CompanyHandler companyHandler;
        ActivitiesHandler activityHandler;
        int[] sections;
        public AdminWindow(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            oBHandler = new OngoingBookingsHandler();
            sBHandler = new SingleBookingsHandler();
            companyHandler = new CompanyHandler();
            activityHandler = new ActivitiesHandler();

            dtgRequestedOngoingBookings.ItemsSource = oBHandler.GetAllPendingOngoingBookings();
            dtgRequestedSingleBookings.ItemsSource = sBHandler.GetAllPendingSingleBookings();
            sections = new int[6] { 1, 2, 3, 4, 5, 6 };
            cboNewActivitySectionsRequired.ItemsSource = sections;
        }
        public void Refresh()
        {

       
        }
        //protected void SetCompanyMostUsingHall()
        //{
        //    var k = oBHandler.GetAllAcceptedOngoingBookings();

        //}
        private void btnAcceptSingleBookingRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SingleBooking sB = dtgRequestedSingleBookings.SelectedItem as SingleBooking;
                sBHandler.AcceptSingleBookingRequest(sB.Id, admin.Id);
                dtgRequestedSingleBookings.SelectedItem = null;
                dtgRequestedSingleBookings.ItemsSource = sBHandler.GetAllPendingSingleBookings();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You need to select a booking to accept it.");
            }
        }

        private void btnAcceptOngoingBookingRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OngoingBooking oB = dtgRequestedOngoingBookings.SelectedItem as OngoingBooking;
                oBHandler.AcceptOngoingBookingRequest(oB.Id, admin.Id);
                dtgRequestedOngoingBookings.SelectedItem = null;
                dtgRequestedOngoingBookings.ItemsSource = oBHandler.GetAllPendingOngoingBookings();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You need to select a booking to accept it.");
            }
        }

        private void btnDeleteSingleBookingRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SingleBooking sB = dtgRequestedSingleBookings.SelectedItem as SingleBooking;
                sBHandler.RemoveSingleBooking(sB.Id);
                dtgRequestedSingleBookings.SelectedItem = null;
                dtgRequestedSingleBookings.ItemsSource = sBHandler.GetAllPendingSingleBookings();
                MessageBox.Show("Booking deleted.");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You need to select a booking to delete it.");
            }
        }

        private void btnDeleteOngoingBookingRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OngoingBooking oB = dtgRequestedOngoingBookings.SelectedItem as OngoingBooking;
                oBHandler.RemoveOngoingBooking(oB.Id);
                dtgRequestedOngoingBookings.SelectedItem = null;
                dtgRequestedOngoingBookings.ItemsSource = oBHandler.GetAllPendingOngoingBookings();
                MessageBox.Show("Booking deleted.");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You need to select a booking to delete it.");
            }
        }

        private void btnGetPercentageOfHallUsage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddNewCompany_Click(object sender, RoutedEventArgs e)
        {
            Company company = new Company()
            {
                Address = txtNewCompanyAddress.Text,
                Name = txtNewCompanyName.Text,
                PhoneNumber = txtNewCompanyPhoneNumber.Text,
                Email = txtNewCompanyEmail.Text,
                Password = txtNewCompanyPassword.Text
            };
            try
            {
                companyHandler.AddCompany(company);
                MessageBox.Show("Foreningen er blevet tilføjet!");
                txtNewCompanyAddress.Text = "";
                txtNewCompanyName.Text = "";
                txtNewCompanyPhoneNumber.Text = "";
                txtNewCompanyEmail.Text = "";
                txtNewCompanyPassword.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Noget af informationen, der er angivet, er fejlagtigt. Prøv igen!");
            }
           
        }
        // REMEMBER TO ADD VALIDATION HERE AND ABOVE
        private void btnAddNewActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity activity = new Activity()
            {
                Name = txtNewActivityName.Text,
                SectionsRequired = (int) cboNewActivitySectionsRequired.SelectedValue
            };
            try
            {
                activityHandler.AddActivity(activity);
                txtNewActivityName.Text = "";
                MessageBox.Show("Aktiviteten er blevet tilføjet!");
            }
            catch (ArgumentException)
            {
                // REMEMBER TO IMPLEMENT THIS EXCEPTION
                MessageBox.Show("Aktivitetsnavnet må ikke indeholde tal, eller være identisk til et, der allerede eksisterer.");
            }
            
        }
    }
}
