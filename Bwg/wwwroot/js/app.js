var app = angular.module('bwg', ['bwg.controllers', 'ui.router'])


app.config(function ($stateProvider, $locationProvider, $urlRouterProvider) {

$urlRouterProvider.otherwise('/');

$stateProvider
    .state('home', {
        url: '/',
        templateUrl: 'templates/home.html'

  //  }).state('about', {
  //      url: '/about',
 //       templateUrl: 'templates/about.html'

    });

});





angular.module('bwg.filters', []);
angular.module('bwg.services', []);
angular.module('bwg.controllers', []);



