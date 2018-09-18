using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class OpeningHoursHandler : DBHandler
    {
        public OpeningHour GetOpeningHour(int id)
        {
            return Model.OpeningHours.Find(id);
        }
        public List<OpeningHour> GetAllOpeningHours()
        {
            return Model.OpeningHours.ToList();
        }
        public bool AddOpeningHour(OpeningHour openingHour)
        {
            Model.OpeningHours.Add(openingHour);
            return SaveChangesToDB();
        }
        //public bool RemoveOngoingBooking(int id)
        //{
        //    Model.OngoingBookings.Remove(Model.OngoingBookings.Find(id));
        //    return SaveChangesToDB();
        //}
        public bool UpdateOpeningHours(int id, OpeningHour openingHour)
        {
            var opHour = Model.OpeningHours.Find(id);
            opHour.OpeningTime = openingHour.OpeningTime;
            opHour.ClosingTime = openingHour.ClosingTime;

            return SaveChangesToDB();
        }
    }
}
