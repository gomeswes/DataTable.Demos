using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTable.Demos.Site.Models;

namespace DataTable.Demos.Model.Tests.Model
{
    [TestClass]
    public class GuestTests
    {
        [TestMethod]
        public void Create_Guess()
        {
            var guestName = "John Smith";
            var guestMail = "jsmith@wgomes.net";
            var guest = new Guest(guestName, guestMail);
            Assert.IsTrue(guest.Name.Equals(guestName) && guest.MailAddress.Equals(guestMail));
        }


        [TestMethod]
        public void Get_A_Random_Guest()
        {
            var guestCountExpected = 1;
            var newGuest = Guest.GetGuests(guestCountExpected, 0);
            Assert.AreEqual(newGuest.Count, guestCountExpected);
        }


    }
}
