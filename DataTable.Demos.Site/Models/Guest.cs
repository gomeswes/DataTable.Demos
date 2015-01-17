using DataTable.Demos.Site.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.Models
{
    public class Guest
    {
        public Guest(string name, string mailAddress)
        {
            Name = name;
            MailAddress = mailAddress;
        }

        public string Name { get; set; }
        public string MailAddress { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public DateTime Aniversary { get; set; }
        public Char Gender { get; set; }


        public static IList<Guest> GetGuests(int amount, int startingPoint)
        {
            var guests = new List<Guest>();
            for (var i = startingPoint; i < amount; i++)
            {
                guests.Add(new Guest(RandomInfoGenerator.GenerateRandomName(i), "unkonwn-1@wgomes.net"));
            }
            return guests;
        }
    }
}