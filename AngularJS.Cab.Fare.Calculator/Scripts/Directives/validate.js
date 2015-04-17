/*
*   Created by knguyen on 4/18/2015.
*/

//directives file to validate form inputs
app.directive('validNumber', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }

            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }
                var allowed = val.replace(/[^0-9.]+/g, ''); //allow only numbers at the period
                if (val !== allowed) {
                    ngModelCtrl.$setViewValue(allowed);
                    ngModelCtrl.$render();
                }
                return allowed;
            });

            element.bind('keypress', function (event) {
                if (event.keyCode === 32) { //prevent the space
                    event.preventDefault();
                }
            });
        }
    };
});