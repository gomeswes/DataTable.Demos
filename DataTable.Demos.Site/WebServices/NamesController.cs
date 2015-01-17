using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text;
using System.IO;
namespace DataTable.Demos.Site.WebServices
{
    public class NamesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(IList<object> value)
        {
            StringBuilder firstNames = new StringBuilder();
            StringBuilder secondNames = new StringBuilder();
            foreach (var names in value) {
                var listNames = ((JArray)names).ToList();
                firstNames.AppendLine("\"" + listNames[0] + "\", ");
                secondNames.AppendLine("\""+listNames[1] + "\", ");
            }

            File.AppendAllText(@"H:\Projetos\DataTable.Demos\DataTable.Demos.Site\App_Data\FirstNames.txt",firstNames.ToString());
            File.AppendAllText(@"H:\Projetos\DataTable.Demos\DataTable.Demos.Site\App_Data\SecondNames.txt",secondNames.ToString());
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