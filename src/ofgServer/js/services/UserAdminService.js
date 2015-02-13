angular.module('ofgMobile')
    .factory('UserAdminService', [
        '$http', 'UserService', function ($http, userService) {
            var service = {
                addUser: function (user) {
                    var req = {
                        method: 'POST',
                        url: '/rest/user/add',
                        headers: {
                            'Username': userService.Username,
                            'AuthToken': userService.AuthToken
                        },
                        data: user
                    };

                    return $http(req)
                        .then(function (result) {
                            return result.data;
                        });
                },
                editUser: function (user) {
                    var req = {
                        method: 'POST',
                        url: '/rest/user/edit',
                        headers: {
                            'Username': userService.Username,
                            'AuthToken': userService.AuthToken
                        },
                        data: user
                    };

                    return $http(req)
                        .then(function (result) {
                            return result.data;
                        });
                },
                getUser: function (userGuid) {
                    var req = {
                        method: 'GET',
                        url: '/rest/user/' + userGuid,
                        headers: {
                            'Username': userService.Username,
                            'AuthToken': userService.AuthToken
                        }
                    };

                    return $http(req)
                        .then(function (result) {
                            return result.data;
                        });
                },
                getUsers: function () {
                    var req = {
                        method: 'GET',
                        url: '/rest/users',
                        headers: {
                            'Username': userService.Username,
                            'AuthToken': userService.AuthToken
                        }
                    };

                    return $http(req)
                        .then(function (result) {
                            return result.data;
                        });
                }
            };

            return service;
        }
    ]);
