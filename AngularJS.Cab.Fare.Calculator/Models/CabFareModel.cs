using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AngularJS.Cab.Fare.Calculator.Models
{
    public class CabFareModel
    {
        public double numMinutesAbove6mph { get; set; }
        public double numMilesBelow6mph { get; set; }
        public DateTime dateOfTrip { get; set; }
        public DateTime timeOfTrip { get; set; }
        public double minuteUnit { get; set; }
        public double mileUnit { get; set; }
        public double nightCharge { get; set; }
        public double weekDayCharge { get; set; }
        public double totalUnitsFee { get; set; }
        public double totalFare { get; set; }
    }
}