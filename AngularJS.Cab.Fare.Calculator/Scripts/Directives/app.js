/*
*   Created by knguyen on 4/18/2015.
*/

var baseUrl = $("base").first().attr("href");

var app = angular.module('app', ['ui.router', 'ui.bootstrap']);

app.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
      .state('home', {
          url: '/',
          templateUrl: baseUrl + 'home.htm'
      })
      .state('about', {
          url: '/about',
          templateUrl: baseUrl + 'about.htm'
      })
      .state('contact', {
          url: '/contact',
          templateUrl: baseUrl + 'contact.htm'
      })
} ]);