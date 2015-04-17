using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS.Cab.Fare.Calculator.Controllers
{
    public class CalculateController : Controller
    {
        //
        // GET: /Calculate/

        //for fun, let's see if we can calculate this in C# and ajax it to the UI front end

        [HttpPost]
        public JsonResult Calculate(string variable)
        {
            var result = "Hey, I got this thing " + variable;

            return Json(result);
        }

    }
}
