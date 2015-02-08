angular.module('ofgMobile')
    .controller('MainCtrl', [
        'UserService',
        function (userService) {
            var self = this;
            self.userService = userService;

            // Check if the user is logged in when the application
            // loads
            // User Service will automatically update isLoggedIn
            // after this call finishes
            userService.session();
        }
    ]);

angular.module('ofgMobile')
    .controller('LoginCtrl', [
        'UserService', '$location',
        function(userService, $location) {
            var self = this;
            self.user = { username: '', password: '' };

            self.login = function() {
                userService.login(self.user).then(function(success) {
                    $location.path('/');
                }, function(error) {
                    self.errorMessage = error.data.msg;
                });
            };
        }
    ]);

angular.module('ofgMobile')
    .controller('LogoutCtrl', [
        'UserService',
        function(userService) {
            var self = this;

            self.logout = function() {
                userService.logout();
                return "You have been logged out.";
            };
        }
    ]);

angular.module('ofgMobile')
    .controller('SearchCtrl', [
        'UserService',
        function(userService) {
            var self = this;

            
        }
    ]);

angular.module('ofgMobile')
    .controller('UserAdminCtrl', [
        '$http', '$scope', '$routeParams', 'UserAdminService',
        function ($http, $scope, $routeParams, userAdminService) {
            var self = this;

            self.user = {};


        }
    ]);

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
