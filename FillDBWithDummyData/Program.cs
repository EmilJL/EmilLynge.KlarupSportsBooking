using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.Business;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace FillDBWithDummyData
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivitiesHandler activitiesHandler = new ActivitiesHandler();
            AdminHandler adminHandler = new AdminHandler();
            ClosedDaysHandler closedDaysHandler = new ClosedDaysHandler();
            CompanyHandler companyHandler = new CompanyHandler();
            DBHandler dBHandler = new DBHandler();
            HallHandler hallHandler = new HallHandler();
            LoginHandler loginHandler = new LoginHandler();
            OngoingBookingsHandler ongoingBookingsHandler = new OngoingBookingsHandler();
            OpeningHoursHandler openingHoursHandler = new OpeningHoursHandler();
            SectionsHandler sectionsHandler = new SectionsHandler();
            SingleBookingsHandler singleBookingsHandler = new SingleBookingsHandler();
            StatisticsHandler statisticsHandler = new StatisticsHandler();

            Hall hall = new Hall()
            {
                Name = "Klarup Sportshal",
                Address = "Gammelvej 23, 6900 Ølby",
                AmountOfSections = 6
            };
            hallHandler.AddHall(hall);

            OpeningHour openingHourMonday = new OpeningHour()
            {
                NameOfDay = "Monday",
                OpeningTime = DateTime.ParseExact("00/01/01 9:00:00 AM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 4:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            OpeningHour openingHourTuesday = new OpeningHour()
            {
                NameOfDay = "Tuesday",
                OpeningTime = DateTime.ParseExact("00/01/01 8:00:00 AM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 4:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            OpeningHour openingHourWednesday = new OpeningHour()
            {
                NameOfDay = "Wednesday",
                OpeningTime = DateTime.ParseExact("00/01/01 5:00:00 AM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 8:30:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            OpeningHour openingHourThursday = new OpeningHour()
            {
                NameOfDay = "Thursday",
                OpeningTime = DateTime.ParseExact("00/01/01 9:00:00 AM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 4:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            OpeningHour openingHourFriday = new OpeningHour()
            {
                NameOfDay = "Friday",
                OpeningTime = DateTime.ParseExact("00/01/01 6:00:00 AM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 3:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            OpeningHour openingHourSaturday = new OpeningHour()
            {
                NameOfDay = "Saturday",
                OpeningTime = DateTime.ParseExact("00/01/01 1:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 10:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            OpeningHour openingHourSunday = new OpeningHour()
            {
                NameOfDay = "Sunday",
                OpeningTime = DateTime.ParseExact("00/01/01 5:00:00 AM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                ClosingTime = DateTime.ParseExact("00/01/01 1:00:00 PM", "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture),
                HallId = 1
            };
            openingHoursHandler.AddOpeningHour(openingHourMonday);
            openingHoursHandler.AddOpeningHour(openingHourTuesday);
            openingHoursHandler.AddOpeningHour(openingHourWednesday);
            openingHoursHandler.AddOpeningHour(openingHourThursday);
            openingHoursHandler.AddOpeningHour(openingHourFriday);
            openingHoursHandler.AddOpeningHour(openingHourSaturday);
            openingHoursHandler.AddOpeningHour(openingHourSunday);

            Admin admin = new Admin()
            {
                Name = "Emil Lynge",
                Email = "emil5923@edu.campusvejle.dk",
                Password = "easypassword",
                HallId = 1
            };
            adminHandler.AddAdmin(admin);

            Activity activity = new Activity()
            {
                Name = "Håndboldtræning",
                SectionsRequired = 3,
            };
            Activity activity2 = new Activity()
            {
                Name = "Håndboldkamp",
                SectionsRequired = 6,
            };
            Activity activity3 = new Activity()
            {
                Name = "Badmintonbane",
                SectionsRequired = 1,
            };
            Activity activity4 = new Activity()
            {
                Name = "Badmintonkamp",
                SectionsRequired = 3,
            };
            Activity activity5 = new Activity()
            {
                Name = "Volleyballtræning",
                SectionsRequired = 3,
            };
            Activity activity6 = new Activity()
            {
                Name = "Volleyballkamp",
                SectionsRequired = 3,
            };
            Activity activity7 = new Activity()
            {
                Name = "Floorballtræning",
                SectionsRequired = 1,
            };
            Activity activity8 = new Activity()
            {
                Name = "Floorballkamp",
                SectionsRequired = 3,
            };
            activitiesHandler.AddActivity(activity);
            activitiesHandler.AddActivity(activity2);
            activitiesHandler.AddActivity(activity3);
            activitiesHandler.AddActivity(activity4);
            activitiesHandler.AddActivity(activity5);
            activitiesHandler.AddActivity(activity6);
            activitiesHandler.AddActivity(activity7);
            activitiesHandler.AddActivity(activity8);

            Console.ReadLine();
            //Company company = new Company()
            //{
            //    Name = "AspIT",
            //    Address = "Carl Gustavsgade 2, Høje Taastrup",
            //    PhoneNumber = "22332244",
            //    Email = "aspit@aspit.dk",
            //    Password = "12345"
            //};
            //Company company2 = new Company()
            //{
            //    Name = "FreelanceLynge",
            //    Address = "Egegade 999, Kbh",
            //    PhoneNumber = "23242526",
            //    Email = "smh@aspit.dk",
            //    Password = "easyassignment"
            //};
            //companyHandler.AddCompany(company);
            //companyHandler.AddCompany(company2);
        }
    }
}
