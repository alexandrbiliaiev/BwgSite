angular.module('bwg.controllers').controller('HomeController',
    function ($scope, $location, $anchorScroll) {

        $scope.submitted = true;

        $scope.goTo = function (tag) {
            $location.hash(tag);
            $anchorScroll.yOffset = 60;
            $anchorScroll();
        };

        $scope.isActive = function (viewLocation) {
            return viewLocation === $location.path();
        };

    })