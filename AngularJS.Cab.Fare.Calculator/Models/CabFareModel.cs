using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AngularJS.Cab.Fare.Calculator.Models
{
    public class CabFareModel
    {
        public decimal numMinutesAbove6mph { get; set; }
        public decimal numMilesBelow6mph { get; set; }
        public DateTime dateOfTrip { get; set; }
        public DateTime timeOfTrip { get; set; }
        public decimal minuteUnit { get; set; }
        public decimal mileUnit { get; set; }
        public decimal nightCharge { get; set; }
        public decimal weekDayCharge { get; set; }
        public decimal totalUnitsFee { get; set; }
        public decimal totalFare { get; set; }
    }
}