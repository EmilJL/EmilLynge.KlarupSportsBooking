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
        //REMEMBER TO FIX DB SO CONFIRMED ONGOING BOOKINGS HAS COMPANY ID
        //public DateTime getTimeForNextBookingForCompany(int id)
        //{
        //    DateTime nextOngoingBookingStart = Model.ConfirmedOngoingBookings.Where(oB => oB.)
        //}
    }
}
