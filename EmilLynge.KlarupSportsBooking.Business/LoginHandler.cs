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
        public bool loginAsAdmin(string email, string password)
        {
            try
            {
                var k = Model.Admins.Where(a => a.Email.ToUpper() == email.ToUpper() && a.Password == password);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
        public bool loginAsCompany(string name, string password)
        {
            try
            {
                var k = Model.Companies.Where(a => a.Name.ToUpper() == name.ToUpper() && a.Password == password);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
