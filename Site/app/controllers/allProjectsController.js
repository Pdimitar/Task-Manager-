'use strict';
app.controller('allProjectsController', ['$http', '$scope', '$routeParams', function ($http, $scope, $routeParams) {

    $http.get(serviceBase + 'api/admin/getAllProjects').then(function (response) {
        $scope.allProject = response.data
    });
}]);

