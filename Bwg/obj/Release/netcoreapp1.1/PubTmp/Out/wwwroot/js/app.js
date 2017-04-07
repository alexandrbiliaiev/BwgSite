var app = angular.module('bwg', ['bwg.controllers', 'ui.router'])


app.config(function ($stateProvider, $urlRouterProvider) {

$urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('home', {
            url: '/home',
            templateUrl: 'templates/home.html'
           
        }).state('about', {
            url: '/about',
            templateUrl: 'templates/about.html'
            
        })

});





angular.module('bwg.filters', []);
angular.module('bwg.services', []);
angular.module('bwg.controllers', []);



