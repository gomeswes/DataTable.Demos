using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTable.Demos.Site.Models.Services;
using System.Collections;
using System.Collections.Generic;

namespace DataTable.Demos.Model.Tests.Model
{
    [TestClass]
    public class ServicesTests
    {
        [TestMethod]
        public void RandomName_Tester()
        {
            var firstRandomName = RandomInfoGenerator.GenerateRandomName(0);
            var secondRandomName = RandomInfoGenerator.GenerateRandomName(1);
            Assert.AreNotEqual(firstRandomName, secondRandomName);
        }

        [TestMethod]
        public void GenerateOneMilionNames()
        {
            var names = new ArrayList();
            var expectedCount = 1000000;
            for (var i = 1; i <= expectedCount; i++)
            {
                names.Add(RandomInfoGenerator.GenerateRandomName(i));
            }

            var dis = names.ToArray().Distinct();

            Assert.AreEqual(expectedCount, names.Count);
        }

        [TestMethod]
        public void GenerateOneMilionMailAddresses()
        {
            var mailAddresses = new ArrayList();
            var expectedCount = 1000000;
            for (var i = 1; i <= expectedCount; i++)
            {
                mailAddresses.Add(
                RandomInfoGenerator
                    .GenerateMailAddressFromName(RandomInfoGenerator.GenerateRandomName(i))
                );
            }
            Assert.AreEqual(expectedCount, mailAddresses.Count);
        }

        [TestMethod]
        public void GetOneMilionRandomCountryTests()
        {
            var countries = new ArrayList();
            var expectedCount = 1000000;
            for (var i = 1; i <= 1000000; i++) 
            {
                countries.Add(RandomInfoGenerator.GetRandomCountry(i));
            }

            Assert.AreEqual(expectedCount, countries.Count);
        }

        [TestMethod]
        public void GetRandomDateTests() 
        {
            var firstDateTime = RandomInfoGenerator.GenerateRandomDate(RandomInfoGenerator.GenerateRandomName(1));
            var secondDateTime = RandomInfoGenerator.GenerateRandomDate(RandomInfoGenerator.GenerateRandomName(2));
            Assert.AreNotEqual(firstDateTime, secondDateTime);
        }

        [TestMethod]
        public void GetRandomGenderTest() 
        {
            var maxTests = 1000000;
            var genders = new List<string>();
            for (var i = 0; i < maxTests; i++) {
                genders.Add(RandomInfoGenerator.GetRandomGender(i));
            }
            var malesCount = genders.Count(s=> s == "Male");
            Assert.IsTrue(malesCount < genders.Count());
        }
    }
}
