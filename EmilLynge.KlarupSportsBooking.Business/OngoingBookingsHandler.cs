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

            onBook.MondayStartTime = ongoingBooking.MondayStartTime;
            onBook.MondayEndTime = ongoingBooking.MondayEndTime;
            onBook.TuesdayStartTime = ongoingBooking.TuesdayStartTime;
            onBook.TuesdayEndTime = ongoingBooking.TuesdayEndTime;
            onBook.WednesdayStartTime = ongoingBooking.WednesdayStartTime;
            onBook.WednesdayEndTime = ongoingBooking.WednesdayEndTime;
            onBook.ThursdayStartTime = ongoingBooking.ThursdayStartTime;
            onBook.ThursdayEndTime = ongoingBooking.ThursdayEndTime;
            onBook.FridayStartTime = ongoingBooking.FridayStartTime;
            onBook.FridayEndTime = ongoingBooking.FridayEndTime;
            onBook.SaturdayStartTime = ongoingBooking.SaturdayStartTime;
            onBook.SaturdayEndTime = ongoingBooking.SaturdayEndTime;
            onBook.SundayStartTime = ongoingBooking.SundayStartTime;

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

    }
}
