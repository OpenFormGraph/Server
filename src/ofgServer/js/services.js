angular.module('fdMobile')
    .factory('UserService', [
        '$http', function ($http) {
            var service = {
                isLoggedIn: false,
                Username: "",
                AuthToken: "",
                session: function () {
                    service.Username = localStorage.getItem("Username");
                    service.AuthToken = localStorage.getItem("AuthToken");

                    if (service.AuthToken != null && service.AuthToken != ""
                        && service.Username != null && service.Username != "") {
                        service.isLoggedIn = true;
                    } else {
                        service.isLoggedIn = false;
                    }
                },
                login: function (user) {
                    return $http.post('/rest/login', user)
                        .then(function (response) {
                            service.isLoggedIn = true;

                            localStorage.setItem("Username", response.data.Username);
                            localStorage.setItem("AuthToken", response.data.AuthToken);

                            $http.defaults.headers.common['Username'] = response.data.Username;
                            $http.defaults.headers.common['AuthToken'] = response.data.AuthToken;

                            return response;
                        });
                },
                logout: function () {
                    service.isLoggedIn = false;
                    localStorage.setItem("Username", null);
                    localStorage.setItem("AuthToken", null);

                    $http.defaults.headers.common['Username'] = null;
                    $http.defaults.headers.common['AuthToken'] = null;

                }
            };
            return service;
        }
    ]);
