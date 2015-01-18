using DataTable.Demos.Site.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.Models.Repositories
{
    public class GuestRepository
    {
        public GuestRepository(IList<Guest> guests) 
        {
            _guests = guests;
        }

        public IList<Guest> GetGuests(GuestFilter guestFilter)
        {
            return GetGuestsIEnumerable(guestFilter)
                        .OrderBy(p => p.Name)
                        .Skip(guestFilter.DisplayStart)
                        .Take(guestFilter.DisplayLength)
                        .ToList<Guest>();
        }

        public int CountWithFilter(GuestFilter guestFilter) 
        {
            return GetGuestsIEnumerable(guestFilter).Count();
        }

        public int CountTotalGuests()
        {
            return _guests.Count();
        }

        private IEnumerable<Guest> GetGuestsIEnumerable(GuestFilter guestFilter)
        {
            var query = (from p in _guests
                    where
                        !string.IsNullOrEmpty(guestFilter.GlobalSearch) ?
                        (
                                (p.Name.Contains(guestFilter.GlobalSearch) ||
                                p.MailAddress.Contains(guestFilter.GlobalSearch) ||
                                p.Country.Contains(guestFilter.GlobalSearch) ||
                                p.Gender.Contains(guestFilter.GlobalSearch))
                        ) : 1 == 1
                    select p);

            if (guestFilter.IsNameSearch()) {
                query = query.Where(guest => guest.Name != null && guest.Name.ToLower().Contains(guestFilter.Name));
            }
            if (guestFilter.IsMailAddressSearch())
            {
                query = query.Where(guest => guest.MailAddress != null && guest.MailAddress.ToLower().Contains(guestFilter.MailAddress));
            }
            if (guestFilter.IsCountrySearch())
            {
                query = query.Where(guest => guest.Country != null && guest.Country.ToLower().Contains(guestFilter.Country));
            }

            if (guestFilter.IsAnniversarySearch())
            {
                query = query.Where(guest => guest.Anniversary.Date.Equals(guestFilter.Anniversary));
            }

            if (guestFilter.IsGenderSearch()) {
                query = query.Where(guest => guest.Gender != null && guest.Gender.ToLower().Contains(guestFilter.Gender));
            }

            return query;

        }
        private IList<Guest> _guests;
    }

    
}