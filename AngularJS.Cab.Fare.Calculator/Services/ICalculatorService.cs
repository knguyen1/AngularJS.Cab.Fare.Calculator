using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngularJS.Cab.Fare.Calculator.Models;

namespace AngularJS.Cab.Fare.Calculator.Services
{
    public interface ICalculatorService
    {
        CabFareModel GetTotalFare(CabFareModel model);
    }
}
