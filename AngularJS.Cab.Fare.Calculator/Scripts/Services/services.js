/*
* @author Kyle Nguyen
* @date 4/18/2015
* @engdoc services
* @name app.apiService
* @description Angular services to call the API backend.
* # apiService
* Service in the app module
*/

app.service('apiService', ['$http', '$q', '$rootScope', function apiService($http, $q, $rootScope) {
    var apiService = this;

    //call the calculate API with the payload
    apiService.calculate = function (payload) {
        var defer = $q.defer();

        $http.get($rootScope.endPoint + '/Calculator' + payload)
            .success(function (res) {
                //success, now give response
                defer.resolve(res);
            })
            .error(function (err, status) {
                //uh oh, something happened
                defer.reject(err);
            });

        return defer.promise;
    };

    //    //some other possible services
    //    apiService.postSomething = function (param) {
    //        var defer = $q.defer();

    //        $http.post(.... etc...

    //        return defer.promise;
    //    }

    return apiService
} ]);
