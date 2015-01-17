using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.Models.Services
{
    public class GuestCreator
    {
        public static IList<Guest> Create(int amount)
        {
            IList<Guest> guests = new List<Guest>();
            for (var i = 1; i <= amount; i++)
            {
                var guestName = RandomInfoGenerator.GenerateRandomName(i);
                var guest = new Guest(guestName, RandomInfoGenerator.GenerateMailAddressFromName(guestName));
                guest.Country = RandomInfoGenerator.GetRandomCountry(i);
                guest.Aniversary = RandomInfoGenerator.GenerateRandomDate(guest.Name);
                guest.Gender = RandomInfoGenerator.GetRandomGender(i);
                guests.Add(guest);
            }
            return guests;
        }
    }

    public static class RandomInfoGenerator
    {
        public static string GenerateRandomName(int seed)
        {
            var random = new Random(seed);
            int randomFirstNameNumer = random.Next(RandomInfoSources.FIRST_NAMES.Length - 1);
            int randomSecondNameNumber = random.Next(RandomInfoSources.SECOND_NAMES.Length - 1);
            return string.Format("{0} {1}",
                RandomInfoSources.FIRST_NAMES[randomFirstNameNumer],
                RandomInfoSources.SECOND_NAMES[randomSecondNameNumber]);
        }

        public static string GenerateMailAddressFromName(string name)
        {
            name = name.ToLower();
            if (name.IndexOf(" ") > -1)
                name = name.Replace(' ', '.');
            return string.Format("{0}@wgomes.net", name);
        }

        public static string GetRandomCountry(int seed)
        {
            var random = new Random(seed);
            int randomCountryNumber = random.Next(RandomInfoSources.COUNTRIES.Length - 1);
            return RandomInfoSources.COUNTRIES[randomCountryNumber];
        }

        public static DateTime GenerateRandomDate(string baseName)
        {
            var years = baseName.Length * 2;
            var months = baseName.Length;
            var days = 0;
            if (baseName.Length % 2 == 0)
            {
                days = Convert.ToInt32(Char.GetNumericValue(baseName[0]));
            }
            else
            {
                days = Convert.ToInt32(Char.GetNumericValue(baseName[1]));
            }

            return DateTime.Now.AddYears(-years).AddMonths(-months).AddDays(days);
        }

        public static string GetRandomGender(int seed)
        {
            var number = new Random(seed).Next();
            return (number + DateTime.Now.Ticks) % 2 == 0 ? "Male" : "Female";
        }
    }
}