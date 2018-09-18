using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class StatisticsHandler : DBHandler
    {
        public double GetHallUsePercentageForSpecificDay(DateTime date)
        {
            //int dayOfWeek = (int) date.DayOfWeek;
            //var sBookings = Model.SingleBookings.Where(b => b.IsConfirmed == true && b.StartTime.Date == date);
            //var oBookings = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true && oB.)
            //return 2.2;
        }
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
        public Company GetCompanyThatUsesTheHallMost()
        {
            //var sBookingTotalTime = Model.SingleBookings.Where(b => b.IsConfirmed == true).GroupBy(b => b.CompanyId);
            //foreach (var group in sBookingTotalTime)
            //{
            //    gro
            //}
            //var oBookings = Model.OngoingBookings.Where(oB => oB.IsConfirmed == true);
            //var k = sBookings.OrderBy(b => b.EndTime - b.StartTime).Last();
            //foreach (SingleBooking booking in sBookings)
            //{
                
            //}
        }
    }
}
