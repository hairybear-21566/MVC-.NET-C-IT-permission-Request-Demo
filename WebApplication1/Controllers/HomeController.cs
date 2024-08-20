using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Data() {
            Dictionary<String,String> keyValuePairs = new Dictionary<String,String>();
            keyValuePairs.Add("1", "foo");
            keyValuePairs.Add("2", "bar");
            keyValuePairs.Add("3", "baz");
            keyValuePairs.Add("4", "gaaa");
            ViewBag.Data = keyValuePairs;
            return View();
        }
    }
}