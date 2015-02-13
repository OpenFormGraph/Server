angular.module('ofgMobile')
    .factory('FormTemplateService', [
        '$http', 'UserService', function ($http, userService) {
            var service = {
                saveFormTemplate: function (formTemplate) {
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
                        .then(function (result) {
                            return result.data;
                        });
                },
                getFormTemplate: function (guid) {
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
                getFormTemplates: function () {
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
                getFormSubjects: function () {
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