angular.module('ofgMobile')
    .controller('UserListCtrl', [
        '$http', '$scope', '$routeParams', 'UserAdminService',
        function ($http, $scope, $routeParams, userAdminService) {
            var self = this;

            self.category = $routeParams.category;
            $scope.data = {};

            userAdminService.getUsers()
                .then(function (result) {
                    $scope.data.Users = result;
                });
        }
    ]);