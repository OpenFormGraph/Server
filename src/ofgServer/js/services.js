﻿angular.module('ofgMobile')
    .factory('UserService', [
        '$http', function ($http) {
            var service = {
                isLoggedIn: false,
                isDataAdmin: false,
                isUserAdmin: false,
                Username: "",
                AuthToken: "",
                session: function () {
                    service.Username = Lockr.get("Username", null);
                    service.AuthToken = Lockr.get("AuthToken", null);
                    service.isUserAdmin = Lockr.get("IsUserAdmin", false);
                    service.isDataAdmin = Lockr.get("IsDataAdmin", false);

                    if (service.AuthToken != null 
                        && service.Username != null) {
                        service.isLoggedIn = true;
                    } else {
                        service.isLoggedIn = false;
                    }
                },
                login: function (user) {
                    return $http.post('/rest/login', user)
                        .then(function (response) {
                            if (response.data.Result == "Success") {
                                service.isLoggedIn = true;
                                service.isUserAdmin = response.data.IsUserAdmin;
                                service.isDataAdmin = response.data.IsDataAdmin;

                                Lockr.set("Username", response.data.Username);
                                Lockr.set("AuthToken", response.data.AuthToken);
                                Lockr.set("IsUserAdmin", service.isUserAdmin);
                                Lockr.set("IsDataAdmin", service.isDataAdmin);

                                $http.defaults.headers.common['Username'] = response.data.Username;
                                $http.defaults.headers.common['AuthToken'] = response.data.AuthToken;

                                return response;
                            } else {
                                //TODO - Add Bootstrap Dialog
                                window.alert("Username or password not correct.");
                            }
                            return null;
                        });
                },
                logout: function () {
                    service.isLoggedIn = false;
                    Lockr.flush();

                    $http.defaults.headers.common['Username'] = null;
                    $http.defaults.headers.common['AuthToken'] = null;

                }
            };
            return service;
        }
    ]);

angular.module('ofgMobile')
    .factory('UserAdminService', [
        '$http', 'UserService', function($http, userService) {
            var service = {
                addUser: function(user) {
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
                        .then(function(result) {
                            return result.data;
                        });
                },
                editUser: function(user) {
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
                        .then(function(result) {
                            return result.data;
                        });
                    },
                getUser: function(userGuid) {
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
                getUsers: function() {
                    var req = {
                        method: 'GET',
                        url: '/rest/users',
                        headers: {
                            'Username': userService.Username,
                            'AuthToken': userService.AuthToken
                        }
                    };

                    return $http(req)
                        .then(function(result) {
                            return result.data;
                        });
                }
            };

            return service;
        }
    ]);

angular.module('ofgMobile')
    .factory('FormTemplateService', [
        '$http', 'UserService', function ($http, userService) {
            var service = {
                saveFormTemplate: function(formTemplate) {
                    var req = {
                        method: 'POST',
                        url: '/rest/formtemplate',
                        headers: {
                            'Username': userService.Username,
                            'AuthToken': userService.AuthToken
                        },
                        data: formTemplate
                    };

                    return $http(req)
                        .then(function(result) {
                            return result.data;
                        });
                },
                getFormTemplate : function(guid) {
                    var req = {
                        method: 'GET',
                        url: '/rest/formtemplate/' + guid,
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
                getFormTemplates : function() {
                    var req = {
                        method: 'GET',
                        url: '/rest/formtemplates',
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
                getFormSubjects : function() {
                    var req = {
                        method: 'GET',
                        url: '/rest/lookup/formsubject',
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