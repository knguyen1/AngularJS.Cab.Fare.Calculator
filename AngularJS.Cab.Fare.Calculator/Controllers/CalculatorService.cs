using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJS.Cab.Fare.Calculator.Services;
using AngularJS.Cab.Fare.Calculator.Models;

namespace AngularJS.Cab.Fare.Calculator.Controllers
{
    /// <summary>
    /// Calculator helper service for controllers
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// Accepts a model of cabfare and calculates total fare.
        /// </summary>
        /// <param name="model">CabFareModel of the paramstring from HTTP</param>
        /// <returns>object of the total cabfare along with other info.</returns>
        public CabFareModel GetTotalFare(CabFareModel model)
        {
            //setup, get hour and day
            //int currentHour = (new DateTime(model.timeOfTrip)).Hour;
            //DayOfWeek currentDay = (new DateTime(model.dateOfTrip)).DayOfWeek;
            int currentHour = model.timeOfTrip.Hour;
            DayOfWeek currentDay = model.dateOfTrip.DayOfWeek;
            double nysSurcharge = (double)0.50;

            //mile unit = 1/5 of a mile, so it's a simple 5*numMiles
            double mileUnit = 5.0 * model.numMilesBelow6mph;

            //minute unit
            double minuteUnit = Math.Ceiling((double)model.numMinutesAbove6mph);

            //entry fee + 0.35/unit etc..
            double entryFee = (double)3.0;
            double totalUnitsFee = (double)0.35 * (mileUnit + minuteUnit);
            double nightCharge = 0;
            int weekDayCharge = 0;

            //night charge: if the ride took place after 8PM or before 6AM
            if (currentHour >= 20 || currentHour < 6)
                nightCharge = (double)0.50 * (mileUnit + minuteUnit);
            //weekday rush hour charge
            if ((currentDay >= DayOfWeek.Monday && currentDay <= DayOfWeek.Friday)
                && (currentHour >= 16 && currentHour < 21))
                weekDayCharge = 1;

            //make a new model and return it
            CabFareModel result = new CabFareModel()
            {
                numMilesBelow6mph = model.numMilesBelow6mph,
                numMinutesAbove6mph = model.numMinutesAbove6mph,
                dateOfTrip = model.dateOfTrip,
                timeOfTrip = model.timeOfTrip,
                mileUnit = mileUnit,
                minuteUnit = minuteUnit,
                nightCharge = nightCharge,
                weekDayCharge = weekDayCharge,
                totalUnitsFee = totalUnitsFee,
                totalFare = entryFee + totalUnitsFee + nightCharge + weekDayCharge + nysSurcharge
            };

            return result;
        }
    }
}