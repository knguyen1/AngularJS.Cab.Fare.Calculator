using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJS.Cab.Fare.Calculator.Models;
using System.Net;

namespace AngularJS.Cab.Fare.Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        [HttpGet]
        public JsonResult Index(CabFareModel model)
        {
            if (model == null)
            {
                Response.StatusCode = 500;
                Response.StatusDescription = "Bad Request";
                return Json("Bad request");
            }

            //setup, get hour and day
            //int currentHour = (new DateTime(model.timeOfTrip)).Hour;
            //DayOfWeek currentDay = (new DateTime(model.dateOfTrip)).DayOfWeek;
            int currentHour = model.timeOfTrip.Hour;
            DayOfWeek currentDay = model.dateOfTrip.DayOfWeek;
            decimal nysSurcharge = (decimal)0.50;

            //mile unit = 1/5 of a mile, so it's a simple 5*numMiles
            decimal mileUnit = 5 * model.numMilesBelow6mph;

            //minute unit
            decimal minuteUnit = Math.Ceiling((decimal)model.numMinutesAbove6mph);

            //entry fee + 0.35/unit etc..
            decimal entryFee = (decimal)3.0;
            decimal totalUnitsFee = (decimal)0.35 * (mileUnit + minuteUnit);
            decimal nightCharge = 0;
            int weekDayCharge = 0;

            //night charge: if the ride took place after 8PM or before 6AM
            if (currentHour >= 20 || currentHour < 6)
                nightCharge = (decimal)0.50 * (mileUnit + minuteUnit);
            //weekday rush hour charge
            if ((currentDay >= DayOfWeek.Monday && currentDay <= DayOfWeek.Friday)
                && (currentHour >= 16 && currentHour < 21))
                weekDayCharge = 1;

            //reform the model
            model.mileUnit = mileUnit;
            model.minuteUnit = minuteUnit;
            model.nightCharge = nightCharge;
            model.weekDayCharge = weekDayCharge;
            model.totalUnitsFee = totalUnitsFee;
            model.totalFare = entryFee + totalUnitsFee + nightCharge + weekDayCharge + nysSurcharge;

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
