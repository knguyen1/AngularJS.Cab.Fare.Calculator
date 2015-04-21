using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJS.Cab.Fare.Calculator.Models;
using System.Net;
using AngularJS.Cab.Fare.Calculator.Services;

namespace AngularJS.Cab.Fare.Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        /// <summary>
        /// Depenendency injection using StructureMap.MVC
        /// The controller is loosely dependent on the calculator service.
        /// </summary>
        private ICalculatorService _service;
        public CalculatorController(ICalculatorService service)
        {
            _service = service;
        }

        //
        // GET: /Calculator/

        /// <summary>
        /// Accepts a JSON model of cabfare and calculates total fare.
        /// </summary>
        /// <param name="model">CabFareModel of the paramstring from HTTP</param>
        /// <returns>JSON object of the total cabfare along with other info.</returns>
        [HttpGet]
        public ActionResult Index(CabFareModel model)
        {
            if (model == null)
            {
                Response.StatusCode = 500;
                Response.StatusDescription = "Bad Request";
                return Json("Bad request");
            }

            //call the calculate service, now hidden behind the abstraction
            var result = _service.GetTotalFare(model);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
