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
    /// Interaction logic for CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        Company company;
        SingleBookingsHandler singleBookingsHandler;
        OngoingBookingsHandler ongoingBookingsHandler;
        ActivitiesHandler activitiesHandler;
        OpeningHoursHandler openingHoursHandler;

        public CompanyWindow(Company company)
        {
            InitializeComponent();
            this.company = company;
            singleBookingsHandler = new SingleBookingsHandler();
            ongoingBookingsHandler = new OngoingBookingsHandler();
            activitiesHandler = new ActivitiesHandler();
            openingHoursHandler = new OpeningHoursHandler();
            cboActivityOngoingBooking.ItemsSource = activitiesHandler.GetAllActivities().Select(a => a.Name);
            cboActivitySingleBooking.ItemsSource = activitiesHandler.GetAllActivities().Select(a => a.Name);
            int[] hours = new int[24] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
            cboOngoingBookingStartTimeFull.ItemsSource = hours;
            cboOngoingBookingEndTimeFull.ItemsSource = hours;
            cboSingleBookingStartTimeFull.ItemsSource = hours;
            cboSingleBookingEndTimeFull.ItemsSource = hours;
            String[] halfHours = new String[2] { "00", "30"};
            cboOngoingBookingEndTimeHalf.ItemsSource = halfHours;
            cboOngoingBookingStartTimeHalf.ItemsSource = halfHours;
            cboSingleBookingEndTimeHalf.ItemsSource = halfHours;
            cboSingleBookingStartTimeHalf.ItemsSource = halfHours;
            dpSingleBooking.DisplayDateStart = DateTime.Now;
            dpOngoingBookingStartDate.DisplayDateStart = DateTime.Now;
            dpOngoingBookingEndDate.DisplayDateStart = DateTime.Now.AddDays(7);
        }

        private void btnRequestSingleBooking_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime();
            date = dpSingleBooking.SelectedDate.Value;
            DateTime startTime;
            if (double.Parse(cboSingleBookingStartTimeHalf.SelectedItem.ToString()) == 30)
            {
                startTime = date.AddHours(double.Parse(cboSingleBookingStartTimeFull.SelectedItem.ToString()) + 0.5);
            }
            else
            {
                startTime = date.AddHours(double.Parse(cboSingleBookingStartTimeFull.SelectedItem.ToString()));
            }
            DateTime endTime;
            if (double.Parse(cboSingleBookingEndTimeHalf.SelectedItem.ToString()) == 30)
            {
                endTime = date.AddHours(double.Parse(cboSingleBookingEndTimeFull.SelectedItem.ToString()) + 0.5);
            }
            else
            {
                endTime = date.AddHours(double.Parse(cboSingleBookingEndTimeFull.SelectedItem.ToString()));
            }
            
            Activity activity = activitiesHandler.GetActivityFromName(cboActivitySingleBooking.SelectedValue.ToString());
            SingleBooking singleBooking = new SingleBooking
            {
                StartTime = startTime,
                EndTime = endTime,
                ActivityId = activity.Id,
                CompanyId = company.Id,
                IsConfirmed = false,
            };
            try
            {
                singleBookingsHandler.AddSingleBooking(singleBooking);
                MessageBox.Show("Bookingen er efterspurgt!");
                dpSingleBooking.SelectedDate = DateTime.Now;
                cboSingleBookingStartTimeFull.SelectedIndex = -1;
                cboSingleBookingStartTimeHalf.SelectedIndex = -1;
                cboSingleBookingEndTimeHalf.SelectedIndex = -1;
                cboSingleBookingEndTimeFull.SelectedIndex = -1;
                cboActivitySingleBooking.SelectedIndex = -1;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Noget gik galt, prøv igen.");
            }   
        }

        private void btnRequestOngoingBooking_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = new DateTime();
            startDate = dpOngoingBookingStartDate.SelectedDate.Value;
            DateTime endDate = new DateTime();
            endDate = dpOngoingBookingEndDate.SelectedDate.Value;
            DateTime startTime;
            if (double.Parse(cboOngoingBookingStartTimeHalf.SelectedItem.ToString()) == 30)
            {
                startTime = startDate.AddHours(double.Parse(cboOngoingBookingStartTimeFull.SelectedItem.ToString()) + 0.5);
            }
            else
            {
                startTime = startDate.AddHours(double.Parse(cboOngoingBookingStartTimeFull.SelectedItem.ToString()));
            }
            DateTime endTime;
            if (double.Parse(cboOngoingBookingEndTimeHalf.SelectedItem.ToString()) == 30)
            {
                endTime = endDate.AddHours(double.Parse(cboOngoingBookingEndTimeFull.SelectedItem.ToString()) + 0.5);
            }
            else
            {
                endTime = endDate.AddHours(double.Parse(cboOngoingBookingEndTimeFull.SelectedItem.ToString()));
            }
            Activity activity = activitiesHandler.GetActivityFromName(cboActivityOngoingBooking.SelectedValue.ToString());

            OngoingBooking ongoingBooking = new OngoingBooking
            {
                StartDay = startDate,
                EndDay = endDate,
                StartTime = startTime,
                EndTime = endTime,
                CompanyId = company.Id,
                ActivityId = activity.Id,
                DayOfWeek = (int)startDate.DayOfWeek,
                IsConfirmed = false
            };
            try
            {
                ongoingBookingsHandler.AddOngoingBooking(ongoingBooking);
                MessageBox.Show("Bookingen er efterspurgt!");
                dpOngoingBookingStartDate.SelectedDate = DateTime.Now;
                dpOngoingBookingEndDate.SelectedDate = DateTime.Now.AddDays(7);
                cboOngoingBookingStartTimeFull.SelectedIndex = -1;
                cboOngoingBookingStartTimeHalf.SelectedIndex = -1;
                cboOngoingBookingEndTimeHalf.SelectedIndex = -1;
                cboOngoingBookingEndTimeFull.SelectedIndex = -1;
                cboActivityOngoingBooking.SelectedIndex = -1;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Noget gik galt, prøv igen.");
            }
        }
    }
}
