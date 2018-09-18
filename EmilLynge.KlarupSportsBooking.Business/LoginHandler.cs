using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class LoginHandler : DBHandler
    {
        public int loginAsAdmin(string email, string password)
        {
            try
            {
                Admin admin = Model.Admins.Where(a => a.Email.ToUpper() == email.ToUpper() && a.Password == password).First();
                return admin.Id;
            }
            catch (ArgumentNullException)
            {
                return -1;
            }
        }
        public int loginAsCompany(string name, string password)
        {
            try
            {
                Company company = Model.Companies.Where(a => a.Name.ToUpper() == name.ToUpper() && a.Password == password).First();
                return company.Id;
            }
            catch (ArgumentNullException)
            {
                return -1;
            }
        }
    }
}
