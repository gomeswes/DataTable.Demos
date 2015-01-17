using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTable.Demos.Site.Controllers
{
    public class DemosController : Controller
    {
        //
        // GET: /Demo/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Basic() 
        {
            return View();
        }
    }
}
