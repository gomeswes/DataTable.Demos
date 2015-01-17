using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.Models.Repositories
{
    public class GuestRepository
    {
        private IList<Guest> _guests;

        public GuestRepository(IList<Guest> guests) 
        {
            _guests = guests;
        }

        public IList<Guest> GetGuests(int totalDisplayRecords, int displayStart, string globalSearch)
        {
            return GetGuestsIEnumerable(globalSearch)
                        .OrderBy(p => p.Name)
                        .Skip(displayStart)
                        .Take(totalDisplayRecords)
                        .ToList<Guest>();
        }

        public int CountWithFilter(string globalSearch) 
        {
            return GetGuestsIEnumerable(globalSearch).Count();
        }

        public int CountTotalGuests()
        {
            return _guests.Count();
        }

        private IEnumerable<Guest> GetGuestsIEnumerable(string globalSearch)
        {
            return (from p in _guests
                    where
                        !string.IsNullOrEmpty(globalSearch) ?
                        (
                                (p.Name.Contains(globalSearch) ||
                                p.MailAddress.Contains(globalSearch) ||
                                p.Country.Contains(globalSearch) ||
                                p.Gender.Contains(globalSearch))
                        ) : 1 == 1
                    select p);
        }
    }
}