angular.module('ofgMobile')
    .controller('UserEditCtrl', [
        '$http', '$scope', '$routeParams', '$location', 'UserAdminService',
        function ($http, $scope, $routeParams, $location, userAdminService) {
            var self = this;

            self.Guid = $routeParams.guid;
            self.user = {};

            self.editUser = function () {
                self.user.Guid = self.Guid;

                userAdminService.editUser(self.user)
                    .then(function (result) {
                        $location.path("#/users");
                    });
            };
        }
    ]);