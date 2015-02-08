angular.module('ofgMobile', ['ngRoute'])
    .config(function($routeProvider) {

        $routeProvider.when('/', {
            templateUrl: 'views/home.html'
        })
        .when('/login', {
            templateUrl: 'views/login.html'
        })
        .when('/logout', {
            templateUrl: 'views/logout.html'
        })
        .when('/users/list', {
            templateUrl: 'views/listusers.html'
        });


        $routeProvider.otherwise({
            redirectTo: '/'
        });
    });

