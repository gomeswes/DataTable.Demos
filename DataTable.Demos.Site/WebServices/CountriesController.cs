using DataTable.Demos.Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace DataTable.Demos.Site.WebServices
{
    public class CountriesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var keySearch = HttpContext.Current.Request.QueryString["search"];
            if (!string.IsNullOrEmpty(keySearch))
                return RandomInfoSources.COUNTRIES.Where(c => c.ToLower().Contains(keySearch.ToLower())).ToArray<string>();

            return RandomInfoSources.COUNTRIES;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(IList<string> value)
        {
            StringBuilder countries = new StringBuilder();
            foreach (var country in value) {
                countries.AppendLine("\"" + country + "\",");
            }
            File.AppendAllText(@"H:\Projetos\DataTable.Demos\DataTable.Demos.Site\App_Data\Countries.txt", countries.ToString());
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