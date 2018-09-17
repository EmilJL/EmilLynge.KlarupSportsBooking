using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class SingleBookingsHandler : DBHandler
    {
        public SingleBooking GetSingleBooking(int id)
        {
            return Model.SingleBookings.Find(id);
        }
        public List<SingleBooking> GetAllSingleBookings()
        {
            return Model.SingleBookings.ToList();
        }
        public bool AddSingleBooking(SingleBooking singleBooking)
        {
            Model.SingleBookings.Add(singleBooking);
            return SaveChangesToDB();
        }
        public bool RemoveSingleBooking(int id)
        {
            Model.SingleBookings.Remove(Model.SingleBookings.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateSingleBooking(int id, SingleBooking singleBooking)
        {
            var singleBook = Model.SingleBookings.Find(id);
            singleBook.StartTime = singleBooking.StartTime;
            singleBook.EndTime = singleBooking.EndTime;

            return SaveChangesToDB();
        }
        public bool AcceptSingleBookingRequest(int singleBookingId, int adminId)
        {
            var singleBook = Model.SingleBookings.Find(singleBookingId);
            singleBook.IsConfirmed = true;
            ConfirmedSingleBooking cSingleBooking = new ConfirmedSingleBooking()
            {
                AdminId = adminId,
                ConfirmDate = DateTime.Now,
                SingleBookingId = singleBookingId
            };
            Model.ConfirmedSingleBookings.Add(cSingleBooking);

            return SaveChangesToDB();
        }
    }
}
