angular.module('fdMobile')
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

angular.module('fdMobile')
    .controller('LoginCtrl', [
        'UserService', '$location',
        function (userService, $location) {
            var self = this;
            self.user = { username: '', password: '' };

            self.login = function () {
                userService.login(self.user).then(function (success) {
                    $location.path('/');
                }, function (error) {
                    self.errorMessage = error.data.msg;
                });
            };
        }
    ]);

angular.module('fdMobile')
    .controller('LogoutCtrl', [
        'UserService',
        function (userService) {
            var self = this;

            self.logout = function () {
                userService.logout();
                return "You have been logged out.";
            };
        }
    ]);
