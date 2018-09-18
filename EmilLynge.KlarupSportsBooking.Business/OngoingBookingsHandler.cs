using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class OngoingBookingsHandler : DBHandler
    {
        public OngoingBooking GetOngoingBooking(int id)
        {
            return Model.OngoingBookings.Find(id);
        }
        public List<OngoingBooking> GetAllOngoingBookings()
        {
            return Model.OngoingBookings.ToList();
        }
        public List<OngoingBooking> GetAllAcceptedOngoingBookings()
        {
            return Model.OngoingBookings.Where(b => b.IsConfirmed == true).ToList();
        }
        public List<OngoingBooking> GetAllPendingOngoingBookings()
        {
            return Model.OngoingBookings.Where(b => b.IsConfirmed == false).ToList();
        }
        public bool AddOngoingBooking(OngoingBooking ongoingBooking)
        {
            Model.OngoingBookings.Add(ongoingBooking);
            return SaveChangesToDB();
        }
        public bool RemoveOngoingBooking(int id)
        {
            Model.OngoingBookings.Remove(Model.OngoingBookings.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateOngoingBooking(int id, OngoingBooking ongoingBooking)
        {
            var onBook = Model.OngoingBookings.Find(id);
            onBook.StartDay = ongoingBooking.StartDay;
            onBook.EndDay = ongoingBooking.EndDay;
            onBook.StartTime = ongoingBooking.StartTime;
            onBook.EndTime = ongoingBooking.EndTime;

            return SaveChangesToDB();
        }
        public bool AcceptOngoingBookingRequest(int ongoingBookingId, int adminId)
        {
            var onBook = Model.OngoingBookings.Find(ongoingBookingId);
            onBook.IsConfirmed = true;
            ConfirmedOngoingBooking cBooking = new ConfirmedOngoingBooking()
            {
                AdminId = adminId,
                ConfirmDate = DateTime.Now,
                OngoingBookingId = ongoingBookingId
            };
            Model.ConfirmedOngoingBookings.Add(cBooking);

            return SaveChangesToDB();
        }
        public int GetAmountOfDaysForOngoingBooking(int id)
        {
            var booking = GetOngoingBooking(id);
            return (booking.EndDay - booking.StartDay).Days / 7;
        }
        public double GetAmountOfTimeForOngoingBooking(int id)
        {
            var booking = GetOngoingBooking(id);
            return GetAmountOfDaysForOngoingBooking(id) * (booking.StartTime - booking.EndTime).TotalHours;
        }
    }
}
