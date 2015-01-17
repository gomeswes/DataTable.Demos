using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTable.Demos.Site.Models.Services;

namespace DataTable.Demos.Model.Tests.Model
{
    [TestClass]
    public class ServicesTests
    {
        [TestMethod]
        public void RandomName_Tester()
        {
            var firstName = RandomInfoGenerator.GenerateRandomName(0);
            var secondName = RandomInfoGenerator.GenerateRandomName(1);
            Assert.AreNotEqual(firstName, secondName);
        }
    }
}
