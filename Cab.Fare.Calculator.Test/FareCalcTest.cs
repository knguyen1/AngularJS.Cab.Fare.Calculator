using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using AngularJS.Cab.Fare.Calculator.Services;
using AngularJS.Cab.Fare.Calculator.Controllers;
using System.Web.Mvc;
using AngularJS.Cab.Fare.Calculator.Models;

namespace Cab.Fare.Calculator.Test
{
    [TestClass]
    public class FareCalcTest
    {
        [TestMethod]
        public void Index_Action_Returns_View()
        {
            //arrange
            var expectedViewName = "Index";
            var controller = new HomeController();

            //act
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result,"Should have returned a ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "View should have been named {0}", expectedViewName); //must return default view
        }

        [TestMethod]
        public void Calculate_WhenParamsEqual_5MinsUnits_2MilesUnits_2010_10_08_5_30PM_ToEqual_975Fare_ReturnsJsonResult()
        {
            //arrange
            var service = new CalculatorService();
            var controller = new CalculatorController(service);
            AngularJS.Cab.Fare.Calculator.Models.CabFareModel input = new AngularJS.Cab.Fare.Calculator.Models.CabFareModel()
            {
                numMinutesAbove6mph = 5,
                numMilesBelow6mph = 2,
                dateOfTrip = new DateTime(2010, 10, 8),
                timeOfTrip = DateTime.ParseExact("17:30:00", "HH:mm:ss", CultureInfo.InvariantCulture),
                minuteUnit = 0,
                mileUnit = 0,
                nightCharge = 0,
                weekDayCharge = 0,
                totalUnitsFee = 0,
                totalFare = 0
            };

            //perform the action
            var actual = controller.Index(input);

            //assert
            Assert.IsInstanceOfType(actual, typeof(JsonResult),"Should have returned a JsonResult");
            var jsonResult = (JsonResult)actual;
            Assert.IsInstanceOfType(jsonResult.Data, typeof(CabFareModel), "Data not able ton convert to CabFareModel");
            var model = (CabFareModel)jsonResult.Data;
            Assert.AreEqual(9.75, model.totalFare, "The total fare is wrong");
        }
    }
}
