using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class CompanyHandler : DBHandler
    {
        public Company GetCompany(int id)
        {
            return Model.Companies.Find(id);
        }
        public List<Company> GetAllCompanies()
        {
            return Model.Companies.ToList();
        }
        public bool AddCompany(Company company)
        {
            Model.Companies.Add(company);
            return SaveChangesToDB();
        }
        public bool RemoveCompany(int id)
        {
            Model.Companies.Remove(Model.Companies.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateCompany(int id, Company company)
        {
            var comp = Model.Companies.Find(id);
            comp.Address = company.Address;
            comp.Email = company.Email;
            comp.Name = company.Name;
            comp.Password = company.Password;
            comp.PhoneNumber = company.PhoneNumber;
            return SaveChangesToDB();
        }
        public DateTime GetNextBookingStartTimeForCompany(int id)
        {
            SingleBooking sB = null;
            OngoingBooking oB = null;
            if (Model.SingleBookings.Any(b => b.IsConfirmed == true && b.CompanyId == id))
            {
                sB = Model.SingleBookings.Where(b => b.IsConfirmed == true && b.CompanyId == id).OrderBy(b => b.StartTime).First();
            }
            if (Model.OngoingBookings.Any(b => b.IsConfirmed == true && b.CompanyId == id))
            {
                oB = Model.OngoingBookings.Where(b => b.IsConfirmed == true && b.CompanyId == id).OrderBy(b => b.StartTime).First();
            }
            if (sB != null && oB == null)
            {
                return sB.StartTime;
            }
            else if (sB == null && oB != null)
            {
                return oB.StartTime;
            }
            else if (oB.StartTime > sB.StartTime)
            {
                return oB.StartTime;
            }
            else
            {
                return DateTime.Now;
            }
        }
        public int GetCompanyIdFromName(string name)
        {
            return Model.Companies.Where(c => c.Name.ToUpper() == name.ToUpper()).Select(c => c.Id).First();
        }
        public DateTime GetNextBookingEndTimeForCompany(int id)
        {
            var date = GetNextBookingStartTimeForCompany(id);
            if (Model.SingleBookings.Any(b => b.StartTime == date))
            {
                return Model.SingleBookings.Where(b => b.StartTime == date).Select(b => b.EndTime).First();
            }
            else
            {
                return Model.OngoingBookings.Where(b => b.StartTime == date).Select(b => b.EndTime).First();
            }
        }
        //REMEMBER TO FIX DB SO CONFIRMED ONGOING BOOKINGS HAS COMPANY ID
        //public DateTime getTimeForNextBookingForCompany(int id)
        //{
        //    DateTime nextOngoingBookingStart = Model.ConfirmedOngoingBookings.Where(oB => oB.)
        //}
    }
}
