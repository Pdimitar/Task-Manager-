'use strict';
app.controller('userStatsController', ['$http', '$scope', '$routeParams', 'authService', function ($http, $scope, $routeParams, authService) {

    $http.get(serviceBase + 'api/task/getAllTasks').then(function (response) {
        var getTasks = response.data;

        function isTodo(getTasks, getProject) {

            return getTasks.taskStates === 0;
        }

        $scope.Todo = getTasks.filter(isTodo)

        function isInProgress(getTasks) {
            return getTasks.taskStates === 1;
        }

        $scope.inProgres = getTasks.filter(isInProgress)

        function testing(getTasks) {
            return getTasks.taskStates === 2;
        }

        $scope.testing = getTasks.filter(testing)

        function complited(getTasks) {
            return getTasks.taskStates === 3;
        }

        $scope.complited = getTasks.filter(complited)
    })

    $http.get(serviceBase + 'api/admin/UnApprovedUser').then(function (unApproved) {
        if (unApproved.data == "False") {
            $scope.ngUnaprived = "false";

        } else if (unApproved.data == "True") {
            $scope.ngUnaprived = "true";
        };
    });
}]);

