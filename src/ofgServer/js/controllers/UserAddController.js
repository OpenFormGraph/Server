angular.module('ofgMobile')
    .controller('UserAddCtrl', [
        '$http', '$scope', '$routeParams', '$location', 'UserAdminService',
        function ($http, $scope, $routeParams, $location, userAdminService) {
            var self = this;

            self.user = {};

            self.addUser = function () {
                userAdminService.addUser(self.user)
                    .then(function (result) {
                        $location.path("#/users");
                    });
            };
        } ]);