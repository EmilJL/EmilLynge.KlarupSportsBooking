using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class TotalTimeHolder
    {
        public double oBTime;
        public double sBTime;
        public int companyId;
    }
    public class StatisticsHandler : DBHandler
    {
        //public double GetHallUsePercentageForSpecificDay(DateTime date)
        //{
        //    //int dayOfWeek = (int) date.DayOfWeek;
        //    //var sBookings = Model.SingleBookings.Where(b => b.IsConfirmed == true && b.StartTime.Date == date);
        //    //var oBookings = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true && oB.)
        //    //return 2.2;
        //}
        
        public double GetHallUsePercentageForSpecificWeek()
        {
            return 2.2;
        }
        public double GetHallUsePercentageForSpecificMonth()
        {
            return 2.2;
        }
        public double GetHallUsePercentageForSpecificQuarter()
        {
            return 2.2;
        }
        public double GetHallUsePercentageForSpecificYear()
        {
            return 2.2;
        }
        public List<Company> GetOrderedListOfCompaniesUsingTheHallTheMost()
        {
            SingleBookingsHandler singleBookingsHandler = new SingleBookingsHandler();
            OngoingBookingsHandler ongoingBookingsHandler = new OngoingBookingsHandler();
            CompanyHandler companyHandler = new CompanyHandler();
            var datTimeTho = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true).GroupJoin(Model.SingleBookings.Where(sB => sB.IsConfirmed == true),
                                                                                        b => b.CompanyId,
                                                                                        sB => sB.CompanyId,
                                                                                        (b, sB) => new
                                                                                        {
                                                                                            SingleBookings = sB,
                                                                                            OngoingBookingsTime = ongoingBookingsHandler.GetAmountOfTimeForOngoingBooking(b.Id)
                                                                                        });
            var result = datTimeTho.OrderByDescending(b => b.SingleBookings.Select(sB => singleBookingsHandler.GetTimeForSingleBooking(sB.Id) + b.OngoingBookingsTime));
            var resultIds = result.Select(r => r.SingleBookings.Select(s => s.CompanyId)).ToList();
            List<Company> companyListMostToLeastUsage = new List<Company>();
            foreach (var id in resultIds)
            {
                companyListMostToLeastUsage.Add(Model.Companies.Find(id));
            }
            return companyListMostToLeastUsage;
        }
        public Company GetCompanyThatUsesTheHallMost()
        {
            return GetOrderedListOfCompaniesUsingTheHallTheMost()[0];
            //var sBList = Model.SingleBookings.Where(sB => sB.IsConfirmed == true).GroupBy()
            //var sBTimeList = Model.SingleBookings.Where(sB => sB.IsConfirmed == true).SelectMany(sB => singleBookingsHandler.GetTimeForSingleBooking(sB.Id));
            //var oBTimeList = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true).SelectMany(oB => ongoingBookingsHandler.GetAmountOfTimeForOngoingBooking(oB.Id));

            //var sBookingTotalTime = Model.SingleBookings.Where(b => b.IsConfirmed == true).GroupBy(b => b.CompanyId);           
            //var oBookings = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true);
            //var datTimeTho = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true).GroupJoin(Model.SingleBookings.Where(sB => sB.IsConfirmed == true),
            //                                                                            b => b.CompanyId,
            //                                                                            sB => sB.CompanyId,
            //                                                                            (b, sB) => new
            //                                                                            {
            //                                                                                SingleBookings = sB,
            //                                                                                OngoingBookingsTime = ongoingBookingsHandler.GetAmountOfTimeForOngoingBooking(b.Id)
            //                                                                            });
            //var result = datTimeTho.OrderBy(b => b.SingleBookings.Select(sB => singleBookingsHandler.GetTimeForSingleBooking(sB.Id) + b.OngoingBookingsTime));
            //var oBookingsTotalTime = new List<OngoingBooking>();
            //double oBookingH
            //foreach (var booking in oBookings)
            //{
            //    var
            //}
            //var k = sBookings.Select(b => b.EndTime - b.StartTime);
            //foreach (SingleBooking booking in sBookings)
            //{

            //}
        }
        public double GetAmountOfHoursOpenOnDay(DateTime date)
        {
            return Model.OpeningHours.Where(d => d.NameOfDay == date.DayOfWeek.ToString() && !Model.ClosedDays.Any(c => c.Date == date)).Select(dt => (dt.ClosingTime - dt.OpeningTime).TotalHours).FirstOrDefault();
        }

        /// <summary>
        /// This method returns the percentage that a hall in use in its open hours, during a given timespan, in relation to a given date.
        /// </summary>
        /// <param name="date">This parameter is the date from which the information should be extracted.</param>
        /// <param name="timeSpanType">This is the type of timespan that the percentage is to be extracted from. 1 = single day, 2 = single week, 3 = single month, 4 = a quarter of a year, 5 = a single year</param>
        /// <returns></returns>
        public double GetHallUsagePercentageForGivenTimeSpan(DateTime date, int timeSpanType)
        {
            SingleBookingsHandler singleBookingsHandler = new SingleBookingsHandler();
            OngoingBookingsHandler ongoingBookingsHandler = new OngoingBookingsHandler();
            double totalTimeUsedPercentage = 0;
            int counter = 0;

            switch (timeSpanType)
            {
                //Returns usage for single day
                case 1:
                    totalTimeUsedPercentage = GetHallTimeUseForDay(date);
                    break;
                //Returns usage for single week
                case 2:
                    while (date.DayOfWeek.ToString() != "Monday" || counter != 8)
                    {
                        date.AddDays(-1);
                        counter++;
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                        date.AddDays(1);
                    }
                    totalTimeUsedPercentage = totalTimeUsedPercentage / 7;
                    
                    break;
                //Returns usage for single month
                case 3:
                    DateTime currentMonth = new DateTime(date.Year, date.Month, date.Day);
                    date = new DateTime(date.Year, date.Month, 1);
                    while (date.Month == currentMonth.Month)
                    {
                        totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                        counter++;
                        date.AddDays(1);
                    }
                    totalTimeUsedPercentage = totalTimeUsedPercentage / counter+1;
                    break;
                //Returns usage for quarter of a year
                case 4:
                    // This code is copypasted and slightly edited from https://stackoverflow.com/questions/8698303/how-do-i-discover-the-quarter-of-a-given-date
                    if (date.Month >= 4 && date.Month <= 6)
                    {
                        date = new DateTime(date.Year, 4, 1);
                        while (date.Month <= 6)
                        {
                            totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                            counter++;
                            date.AddDays(1);
                        }
                        
                    }
                    else if (date.Month >= 7 && date.Month <= 9)
                    {
                        date = new DateTime(date.Year, 7, 1);
                        while (date.Month <= 9)
                        {
                            totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                            counter++;
                            date.AddDays(1);
                        }
                    }
                    else if (date.Month >= 10 && date.Month <= 12)
                    {
                        date = new DateTime(date.Year, 9, 1);
                        while (date.Month <= 12)
                        {
                            totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                            counter++;
                            date.AddDays(1);
                        }
                    }
                    else
                    {
                        date = new DateTime(date.Year, 1, 1);
                        while (date.Month <= 3)
                        {
                            totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                            counter++;
                            date.AddDays(1);
                        }
                    }
                    totalTimeUsedPercentage = totalTimeUsedPercentage / counter + 1;
                    break;
                //Returns usage for single year
                case 5:
                    DateTime currentYear = new DateTime(date.Year, 1, 1);
                    date = new DateTime(date.Year, 1, 1);
                    while (date.Year == currentYear.Year)
                    {
                        totalTimeUsedPercentage += GetHallTimeUseForDay(date);
                        counter++;
                        date.AddDays(1);
                    }
                    totalTimeUsedPercentage = totalTimeUsedPercentage / counter + 1;
                    break;
                default:
                    return 0;
            }
            return totalTimeUsedPercentage;
        }
        /// <summary>
        /// This is the method that extracts the hall time in use on a given day.
        /// </summary>
        /// <param name="date">This is the date that the percentage is calculated from.</param>
        /// <returns></returns>
        public double GetHallTimeUseForDay(DateTime date)
        {
            SingleBookingsHandler singleBookingsHandler = new SingleBookingsHandler();
            OngoingBookingsHandler ongoingBookingsHandler = new OngoingBookingsHandler();
            var hallTimeUseForTimeSpanSingles = Model.SingleBookings.Where(s => s.IsConfirmed == true && s.StartTime.Date == date.Date).Select(sTime => singleBookingsHandler.GetTimeForSingleBooking(sTime.Id)).Sum();
            var hallTimeUseFoTimeSpanOngoings = Model.OngoingBookings.Where(o => o.IsConfirmed == true && o.StartDay.DayOfWeek == date.DayOfWeek && o.StartDay.Day <= date.Day && o.EndDay.Day >= date.Day).Select(oTime => (oTime.EndTime - oTime.StartTime).TotalHours).Sum();
            return (hallTimeUseForTimeSpanSingles + hallTimeUseFoTimeSpanOngoings) / GetAmountOfHoursOpenOnDay(date) * 100;
        }
        //public List<Activity> GetOrderedListOfMostUsedActivities()
        //{
        //    var sBookings
        //}
    }
}

