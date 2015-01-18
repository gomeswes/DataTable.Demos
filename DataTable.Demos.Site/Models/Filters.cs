using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTable.Demos.Site.Models.Extensions;
using System.Reflection;

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

        private string[] cols = new string[] { "Name", "MailAddress", "Country", "Anniversary", "Gender" };
        private int sortIndex;
        public SortDirection SortDirection;
        public void SetSortingCol(string colIndex)
        {
            
            int iColIndex;
            int.TryParse(colIndex, out iColIndex);
            if (iColIndex > cols.Length - 1)
                iColIndex = 0;
            sortIndex = iColIndex;
        }
        public object GetSortingProp(Guest guest)
        {
            PropertyInfo property = guest.GetType().GetProperties().FirstOrDefault(prop => prop.Name == cols[sortIndex]);
            return property.GetValue(guest, null);
        }
        public void SetSortingDir(string dir)
        {
            if (!string.IsNullOrEmpty(dir) && dir.Equals("desc", StringComparison.CurrentCultureIgnoreCase))
            {
                SortDirection = SortDirection.Desc;
            }
            else
            {
                SortDirection = SortDirection.Asc;
            }

        }
        
    }
    public enum SortDirection
    {
        Asc, Desc
    }
}