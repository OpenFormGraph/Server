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
    .controller('FormTemplateCtrl', [
        'UserService',
        function(userService) {
            var self = this;

            
        }
    ]);

angular.module('ofgMobile')
    .controller('UserAddCtrl', [
        '$http', '$scope', '$routeParams', '$location', 'UserAdminService',
        function($http, $scope, $routeParams, $location, userAdminService) {
            var self = this;

            self.user = {};

            self.addUser = function() {
                userAdminService.addUser(self.user)
                    .then(function(result) {
                        $location.path("#/users");
                    });
             };
        }]);

angular.module('ofgMobile')
    .controller('UserEditCtrl', [
        '$http', '$scope', '$routeParams', '$location', 'UserAdminService',
        function($http, $scope, $routeParams, $location, userAdminService) {
            var self = this;

            self.Guid = $routeParams.guid;
            self.user = {};

            self.editUser = function() {
                self.user.Guid = self.Guid;

                userAdminService.editUser(self.user)
                    .then(function(result) {
                        $location.path("#/users");
                    });
            };
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
