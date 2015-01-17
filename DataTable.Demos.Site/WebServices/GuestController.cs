using DataTable.Demos.Site.App_Start;
using DataTable.Demos.Site.Models;
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
            var displayLength = Convert.ToInt32(HttpContext.Current.Request["iDisplayLength"]);
            var displayStart = Convert.ToInt32(HttpContext.Current.Request["iDisplayStart"]);
            var globalSearch = HttpContext.Current.Request.Params["sSearch"];

            var guestRepository = new GuestRepository(DataCache.Guests);

            return new
            {
                sEcho = echo,
                iTotalRecords = guestRepository.CountTotalGuests(),
                iTotalDisplayRecords = guestRepository.CountWithFilter(globalSearch),
                aaData = guestRepository.GetGuests(displayLength, displayStart, globalSearch).Select(g => new { 
                    g.Name,
                    g.MailAddress,
                    g.Country,
                    Anniversary = g.Anniversary.ToString("dd/MM/yyyy"),
                    g.Gender
                }).ToList()
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