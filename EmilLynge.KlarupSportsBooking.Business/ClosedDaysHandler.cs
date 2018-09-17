using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class ClosedDaysHandler : DBHandler
    {
        public ClosedDay GetClosedDay(int id)
        {
            return Model.ClosedDays.Find(id);
        }
        public List<ClosedDay> GetAllClosedDays()
        {
            return Model.ClosedDays.ToList();
        }

        public bool AddClosedDay(ClosedDay closedDay)
        {
            Model.ClosedDays.Add(closedDay);
            return SaveChangesToDB();
        }
        public bool RemoveClosedDay(int id)
        {
            Model.ClosedDays.Remove(Model.ClosedDays.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateClosedDay(int id, ClosedDay closedDay)
        {
            var cd = Model.ClosedDays.Find(id);
            cd.Date = closedDay.Date;
            cd.Description = closedDay.Description;
            return SaveChangesToDB();
        }
    }
}
