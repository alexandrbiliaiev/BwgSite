angular.module('bwg.controllers').controller('HomeController',
    function ($scope, $location, $http, $state, $anchorScroll, $window, $interval, $timeout,
        emailService) {

        $scope.submitted = false;

        $scope.mail = {
            name: '',
            email: '',
            subject: '',
            company: '',
            phone: '',
            text: ''
        };

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
            $window.open('https://crm.bwg.com.pl/Account/RegisterContragent');
        }



        $scope.send = function () {

            if (emailForm.$invalid) {
                return;
            }

            emailService.sendMail($scope.mail).then(function (response) {

                $scope.mail = {
                    name: '',
                    email: '',
                    subject: '',
                    company: '',
                    phone: '',
                    text: ''
                };

                $scope.sent = true;

               $timeout(function() 
               { $scope.sent = false;}, 6000);

                
               

            }).catch(function () {
                $state.go('error');
            });
        };


    })