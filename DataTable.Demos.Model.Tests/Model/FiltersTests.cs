using DataTable.Demos.Site.Models;
using DataTable.Demos.Site.Models.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTable.Demos.Model.Tests.Model.FiltersTests
{
    [TestClass]
    public class GuestFilterTests
    {
        [TestMethod]
        public void MustSetSortProperty()
        {
            var guestFilter = new GuestFilter();
            guestFilter.SetSortingCol("1");
            var guestName = "Name of the guest";
            var guestMail = "mail@oftheguest.com";
            var guest = new Guest(guestName, guestMail);
            var prop = guestFilter.GetSortingProp(guest);
            Assert.IsTrue(prop.ToString() == guestMail);
        }

        [TestMethod]
        public void MustSetDefaultPropertyOnError() 
        {
            var guestFilter = new GuestFilter();
            guestFilter.SetSortingCol("88");
            var guestName = "Name of the guest";
            var guestMail = "mail@oftheguest.com";
            var guest = new Guest(guestName, guestMail);
            var prop = guestFilter.GetSortingProp(guest);
            Assert.IsTrue(prop.ToString() == guestName);        
        }
    }
}
