angular.module('bwg.services')
    .factory('emailService', ['$http', function ($http) {

        var email = {};
       

        email.sendMail = function (mail) {
            return $http({
                url: '/api/SendEmail',
                method: "POST",
                data: mail
            });
        }

       

        return email;

    }]);