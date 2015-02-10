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
            .when('/users', {
                templateUrl: 'views/user_list.html'
            })
            .when('/user', {
                templateUrl: 'views/user_add.html'
            })
            .when('/user/:guid', {
                templateUrl: 'views/user_edit.html'
            })
            .when('/formtemplate', {
                templateUrl: 'views/formtemplate_add.html'
            })
            .when('/formtemplate/:guid', {
                templateUrl: 'views/formtemplate_edit.html'
            })        
            .when('/inspect/vehicle', {                
                
            })
            .when('/inspections/vehicle/mine', {                
                
            });

        $routeProvider.otherwise({
            redirectTo: '/'
        });
    });
