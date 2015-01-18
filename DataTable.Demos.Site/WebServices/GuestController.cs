using DataTable.Demos.Site.App_Start;
using DataTable.Demos.Site.Models;
using DataTable.Demos.Site.Models.Filters;
using DataTable.Demos.Site.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace DataTable.Demos.Site.WebServices
{
    public class GuestController : ApiController
    {



        // GET api/<controller>
        [HttpGet]
        public dynamic Get()
        {
            var echo = HttpContext.Current.Request.Params["sEcho"];
            var totalRecords = Convert.ToInt32(HttpContext.Current.Request.Params["iTotalRecords"]);
            var guestFilter = new GuestFilter();

            guestFilter.DisplayLength = Convert.ToInt32(HttpContext.Current.Request["iDisplayLength"]);
            guestFilter.DisplayStart = Convert.ToInt32(HttpContext.Current.Request["iDisplayStart"]);
            guestFilter.GlobalSearch = HttpContext.Current.Request.Params["sSearch"];
            guestFilter.Name = HttpContext.Current.Request["sSearch_0"];
            guestFilter.MailAddress = HttpContext.Current.Request["sSearch_1"];
            guestFilter.Country = HttpContext.Current.Request["sSearch_2"];
            guestFilter.SetAnniversary(HttpContext.Current.Request["sSearch_3"]);
            guestFilter.Gender = HttpContext.Current.Request["sSearch_4"];
            guestFilter.SetSortingCol(HttpContext.Current.Request["iSortCol_0"]);
            guestFilter.SetSortingDir(HttpContext.Current.Request["sSortDir_0"]);

            var guestRepository = new GuestRepository(DataCache.Guests);
            var data = guestRepository.GetGuests(guestFilter).Select(g => new { 
                    g.Name,
                    g.MailAddress,
                    g.Country,
                    Anniversary = g.Anniversary.ToString("dd/MM/yyyy"),
                    g.Gender
                }).ToList();
            return new
            {
                sEcho = echo,
                iTotalRecords = guestRepository.CountTotalGuests(),
                iTotalDisplayRecords = guestRepository.CountWithFilter(guestFilter),
                aaData = data
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}