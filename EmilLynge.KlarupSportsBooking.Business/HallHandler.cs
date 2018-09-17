using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class HallHandler : DBHandler
    {
        public Hall GetHall(int id)
        {
            return Model.Halls.Find(id);
        }
        public List<Hall> GetAllHalls()
        {
            return Model.Halls.ToList();
        }
        public bool AddHall(Hall hall)
        {
            Model.Halls.Add(hall);
            return SaveChangesToDB();
        }
        public bool RemoveHall(int id)
        {
            Model.Halls.Remove(Model.Halls.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateHall(int id, Hall hall)
        {
            var ha = Model.Halls.Find(id);
            ha.Address = hall.Address;
            ha.AmountOfSections = hall.AmountOfSections;
            ha.Name = hall.Name;
            return SaveChangesToDB();
        }
    }
}
