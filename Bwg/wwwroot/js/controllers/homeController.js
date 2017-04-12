angular.module('bwg.controllers').controller('HomeController', 
    function ($scope, $location, $anchorScroll, $window) {

        $scope.submitted = true;

        $scope.goTo = function (tag) {
            $location.hash(tag);
            $anchorScroll.yOffset = 60;
            $anchorScroll();
        };

        $scope.isActive = function (viewLocation) {
            return viewLocation === $location.path();
        };

        $scope.goToLogin = function () {
            $window.open('https://crm.bwg.com.pl/Account/Login', '_blank');
        }

        $scope.goToRegister = function () {
            $window.open('https://crm.bwg.com.pl/Account/RegisterContragent', '_blank');
        }
    })