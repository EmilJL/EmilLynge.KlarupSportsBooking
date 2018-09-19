using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmilLynge.KlarupSportsBooking.DAL.EF;
using EmilLynge.KlarupSportsBooking.Business;

namespace EmilLynge.KlarupSportsBooking.Tester
{
    [TestClass]
    public class LogInHandlerTest
    {
        [TestMethod]
        public void LoggingInAsCompanyTest()
        {
            var password = "123";
            var name = "atit";
            LoginHandler handler = new LoginHandler();
            int result = handler.loginAsCompany(name, password);
            Assert.AreEqual(-1, result);
        }
        public void LogginInAsAdminTest()
        {
            var password = "easypassword";
            var email = "emil@edu.campusvejle.dk";
            LoginHandler handler = new LoginHandler();
            int result = handler.loginAsAdmin(email, password);
            Assert.AreEqual(1, result);
        }
    }
}
