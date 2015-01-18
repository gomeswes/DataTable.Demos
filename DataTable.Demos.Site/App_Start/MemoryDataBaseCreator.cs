using DataTable.Demos.Site.Models;
using DataTable.Demos.Site.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.App_Start
{
    public class DataCache
    {
        public static IList<Guest> Guests { get; private set; }
        public static void CreateGuestsCache()
        {
            //Guests = GuestCreator.Create(211991);
            Guests = GuestCreator.Create(10000);
        }
    }


}