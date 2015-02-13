angular.module('ofgMobile')
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
