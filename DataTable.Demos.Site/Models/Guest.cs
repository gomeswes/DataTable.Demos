using DataTable.Demos.Site.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.Models
{
    public class Guest : IEquatable<Guest>
    {
        public Guest(string name, string mailAddress)
        {
            Name = name;
            MailAddress = mailAddress;
        }

        public string Name { get; set; }
        public string MailAddress { get; set; }
        public string Country { get; set; }
        public DateTime Anniversary
        { 
            get; 
            set; 
        }
        public string Gender { get; set; }



        public static int CountTotalGuests() 
        {
            var maxGuests = 500000;
            return maxGuests;
        }


        public bool Equals(Guest other)
        {
            return other != null && other.MailAddress.Equals(MailAddress);
        }
    }
}