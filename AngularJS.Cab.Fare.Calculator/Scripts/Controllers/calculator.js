/*
*   Created by knguyen on 4/18/2015.
*/

//here, we establish our calculator controller, which will will pass the model to the home.htm view
var cabfareCalculator = app.controller('cabfareCalculator',
    ['$scope', 'apiService', function ($scope, apiService) {

        $scope.toggleMin = function () {
            $scope.minDate = $scope.minDate ? null : new Date();
        };

        $scope.toggleMin();

        //initialize variables
        $scope.init = function () {
            $scope.numMinutesAbove6mph = 10;
            $scope.numMilesBelow6mph = 5;
            $scope.dateOfTrip = new Date();
            $scope.timeOfTrip = new Date();
        }

        //clear variables... might use this function later
        $scope.clear = function () {
            $scope.dateOfTrip = null;
            $scope.timeOfTrip = null;
            $scope.numMinutesAbove6mph = null;
            $scope.numMilesBelow6mph = null;
        };

        //using angular promises
        $scope.checkBackEnd = function (numMinutesAbove6mph, numMilesBelow6mph, dateOfTrip, timeOfTrip) {

            //prepare the payload
            var payload = "/?numMinutesAbove6mph=" + numMinutesAbove6mph + "&numMilesBelow6mph=" + numMilesBelow6mph
                + "&dateOfTrip=" + dateFormat(dateOfTrip, "mm/dd/yyyy HH:MM:ss") + "&timeOfTrip=" + dateFormat(timeOfTrip, "mm/dd/yyyy HH:MM:ss");

            //send it to the api service
            apiService.calculate(payload)
                .then(function (res) {
                    //success
                    alert(res.totalFare);
                }, function (err) {
                    //failure
                });
        };

        //finally, we have all the variables.  begin calculating the fare
        $scope.totalFare = function (numMinutesAbove6mph, numMilesBelow6mph, dateOfTrip, timeOfTrip) {
            //setup, get hour and day
            var currentHour = timeOfTrip.getHours();
            var currentDay = dateOfTrip.getDay();
            var nysSurcharge = 0.50;

            //mile unit = 1/5 of a mile, so it's simply 5 * numMiles
            var mileUnit = 5 * numMilesBelow6mph;

            //minute unit = 60 secs not in motion, or traveling above 6mph
            //so it's simply the nearest whole number of minutes, rounded up
            var minuteUnit = Math.ceil(numMinutesAbove6mph);

            //entry fee + 0.35/unit + 0.50 if at night + weekday peak hour + NYS surcharge
            var entryFee = 3.0;
            var totalUnitsFee = 0.35 * (mileUnit + minuteUnit);
            var nightCharge = 0
            var weekDayCharge = 0;

            //night charge: if the ride took place after 8:00 PM OR before 
            if (currentHour >= 20 || currentHour < 6)
                nightCharge = 0.50 * (mileUnit + minuteUnit);

            //weekday rush hour charge: if the ride takes place during a weekday AND between 4pm and 8pm
            if ((currentDay >= 1 && currentDay < 6) && (currentHour >= 16 && currentHour < 21))
                weekDayCharge = 1;

            $scope.fareHolder = entryFee + totalUnitsFee + nightCharge + weekDayCharge + nysSurcharge;

            return entryFee + totalUnitsFee + nightCharge + weekDayCharge + nysSurcharge;
        };

        //run init() to prepare all variables
        $scope.init();
    } ]);