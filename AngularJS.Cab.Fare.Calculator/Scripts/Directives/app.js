/*
*   Created by knguyen on 4/18/2015.
*/

var baseUrl = $("base").first().attr("href"); //detect the location of AngularApp

var app = angular.module('app', ['ui.router', 'ui.bootstrap']);

app.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider

      //GET: /#/*
      .state('home', {
          url: '/',
          templateUrl: baseUrl + 'home.htm'
      })

      //GET: /#/about
      .state('about', { 
          url: '/about',
          templateUrl: baseUrl + 'about.htm'
      })

      //GET: /#/contact
      .state('contact', {
          url: '/contact',
          templateUrl: baseUrl + 'contact.htm'
      })
} ])
  .run(function ($rootScope) {
      $rootScope.endPoint = 'http://localhost:61652'; //change this if deployed on another env
  });