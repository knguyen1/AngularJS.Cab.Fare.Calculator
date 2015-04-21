/*
*   Created by knguyen on 4/18/2015.
*/

var baseUrl = $("base").first().attr("href"); //detect the location of AngularApp

var app = angular.module('app', ['ui.router', 'ui.bootstrap']);

app.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
    
    //$provide.decorator('$httpBackend', angular.mock.e2e.$httpBackendDecorator);

    $urlRouterProvider.otherwise('/');

    $stateProvider

    //state: /#/*
      .state('home', {
          url: '/',
          templateUrl: baseUrl + 'home.htm'
      })

    //state: /#/about
      .state('about', {
          url: '/about',
          templateUrl: baseUrl + 'about.htm'
      })

    //state: /#/contact
      .state('contact', {
          url: '/contact',
          templateUrl: baseUrl + 'contact.htm'
      })
} ])
  .run(function ($rootScope) {
      $rootScope.endPoint = 'http://localhost:61652'; //change this if deployed on another env
  });