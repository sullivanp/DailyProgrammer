using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraphMapper.Controllers
{
    public class GraphMapperController : Controller
    {
        //
        // GET: /GraphMapper/
        public string Index()
        {
            return "This is my <b>default</b> action...";
            //return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", numtimes is " + numTimes);
            //return "This is the Welcome action method...";
        }
	}
}