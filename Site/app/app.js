var app = angular.module('TaskManager', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ang-drag-drop',
    'angularjs-datetime-picker']);

app.config(function ($routeProvider) {

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"

    });

    $routeProvider.when("/addProject", {
        controller: "addProjectController",
        templateUrl: "/app/views/home.html",
        resolve: {
            permission: function (authorizationService, $route) {
                return authorizationService.permissionCheck([roles.user]);
            },
        }
    });

    $routeProvider.when("/getTasks/:projectId", {
        controller: "getTaskController",
        templateUrl: "/app/views/tasks.html",
        resolve: {
            permission: function (authorizationService, $route) {
                return authorizationService.permissionCheck([roles.user]);
            },
        }
    });

    $routeProvider.when("/userStats", {
        controller: "userStatsController",
        templateUrl: "/app/views/userStats.html",
        resolve: {
            permission: function (authorizationService, $route) {
                return authorizationService.permissionCheck([roles.user]);
            },
        }
    });

    $routeProvider.when("/allProjects", {
        controller: "allProjectsController",
        templateUrl: "/app/views/allProjects.html",
        resolve: {
            permission: function (authorizationService, $route) {
                return authorizationService.permissionCheck([roles.admin]);
            },
        }
    });

    $routeProvider.when("/allUsers", {
        controller: "allUsersController",
        templateUrl: "/app/views/allUsers.html",
        resolve: {
            permission: function (authorizationService, $route) {
                return authorizationService.permissionCheck([roles.admin]);
            },
        }
    });


    //NotAuthorized


    $routeProvider.otherwise({ redirectTo: "/addProject" });
});

var serviceBase = window.location.protocol + "//" + window.location.host + "/";

var roles = {
    user: 0,
    admin: 1
}

var routeForUnauthorizedAccess = '/NotAuthorized';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'TaskManager'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
    authService.fillUserType();
}]);