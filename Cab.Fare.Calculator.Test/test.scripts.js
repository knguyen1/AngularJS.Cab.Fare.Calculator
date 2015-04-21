var injector = angular.injector(['ng', 'app']);
var service = injector.get('apiService');

var init = {
    setup: function () {
        this.$scope = injector.get('$rootScope').$new();
        var $controller = injector.get('$controller');
        $controller('cabfareCalculator', {
            $scope: this.$scope,
            FooService: service
        });
    }
};

module('Basic Controller Test', init);

test('Ensure that all services are injected correctly.', function () {
    ok(angular.isFunction(service.calculate));
});

test('Check that numMinutes = 5, numMiles = 2, and datetime at 2010/10/08 @ 5:30 PM equals 9.75.', function () {
    var numMinutes = 5;
    var numMiles = 2;
    var dateTimeOfTrip = new Date("2010-10-08");
    dateTimeOfTrip.setHours(17);
    dateTimeOfTrip.setMinutes(30);

    this.$scope.totalFare(numMinutes, numMiles, dateTimeOfTrip, dateTimeOfTrip);
    equal(this.$scope.fareHolder, 9.75);
});