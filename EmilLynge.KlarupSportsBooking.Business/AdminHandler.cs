using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class AdminHandler : DBHandler
    {
        public Admin GetAdmin(int id)
        {
            return Model.Admins.Find(id);
        }
        public List<Admin> GetAllAdmins()
        {
            return Model.Admins.ToList();
        }

        public bool AddAdmin(Admin admin)
        {
            Model.Admins.Add(admin);
            return SaveChangesToDB();
        }
        public bool RemoveAdmin(int id)
        {
            Model.Admins.Remove(Model.Admins.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateAdmin(int id, Admin admin)
        {
            var adm = Model.Admins.Find(id);
            adm.Name = admin.Name;
            return SaveChangesToDB();
        }
    }
}
