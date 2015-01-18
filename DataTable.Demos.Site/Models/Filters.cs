using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTable.Demos.Site.Models.Extensions;

namespace DataTable.Demos.Site.Models.Filters
{
    public class GuestFilter
    {
        public int DisplayLength;
        public int DisplayStart;

        private string _name;
        public string Name
        {
            set
            {
                if (value != null)
                    _name = value.TrimToLower();
            }
            get
            {
                return _name;
            }
        }
        public bool IsNameSearch()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public string _mailAddress;
        public string MailAddress
        {
            set
            {
                if (value != null)
                    _mailAddress = value.TrimToLower();
            }
            get
            {
                return _mailAddress;
            }
        }
        public bool IsMailAddressSearch()
        {
            return !string.IsNullOrEmpty(MailAddress);
        }

        private string _country;
        public string Country
        {
            set
            {
                if (value != null)
                    _country = value.TrimToLower();
            }
            get
            {
                return _country;
            }
        }
        public bool IsCountrySearch()
        {
            return !string.IsNullOrEmpty(Country);
        }

        private DateTime _anniversary;
        public DateTime Anniversary
        {
            get
            {
                return _anniversary;
            }
        }
        public void SetAnniversary(string anniversary) 
        { 
            DateTime anniversaryDate;
            DateTime.TryParse(anniversary, out anniversaryDate);
            _anniversary = anniversaryDate;
        }
        public bool IsAnniversarySearch()
        {
            return Anniversary.CompareTo(DateTime.MinValue) > 0;
        }

        private string _gender;
        public string Gender
        {
            set
            {
                if (value != null)
                    _gender = value.TrimToLower();
            }
            get
            {
                return _gender;
            }
        }
        public bool IsGenderSearch()
        {
            return !string.IsNullOrEmpty(Gender);
        }

        public string GlobalSearch;
        public bool IsGlobalSearch()
        {
            return !string.IsNullOrEmpty(GlobalSearch.TrimToLower());
        }
    }
}