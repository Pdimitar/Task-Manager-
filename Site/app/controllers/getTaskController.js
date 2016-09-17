'use strict';
app.controller('getTaskController', ['$http', '$scope', '$routeParams', function ($http, $scope, $routeParams) {

    var projectId = $routeParams.projectId;

    $scope.tasks = function (projectId) {
        $http.get(serviceBase + 'api/task/getTasks/' + projectId).then(function (response) {

            $scope.listOfTasks = response.data;
        });
    }

    //Drag And Drop Starts Here


    $http.get(serviceBase + 'api/task/getTasks/' + projectId).then(function (response) {

        $scope.listOfTasks = response.data;
    });



    $scope.addTask = {
        name: "",
        projectId: projectId,


    }

    $http.get(serviceBase + 'api/task/getUserId').then(function (response) {
        $scope.getsUser = response.data.id;

    })

    $scope.AddTask = function () {

        $scope.addTask.userId = $scope.getsUser

        $http.post(serviceBase + 'api/task/addTask', $scope.addTask).then(function (response) {
            $scope.addProject = response.data;

            $http.get(serviceBase + 'api/task/getTasks/' + projectId).then(function (response) {

                $scope.listOfTasks = response.data;
            });
        });

        $scope.addTask = {
            name: "",
            projectId: projectId
        }
    }

    $scope.onDrop = function (taskId, taskName, taskState, projectId) {
        $scope.editTask = {
            id: taskId,
            name: taskName,
            taskStates: taskState,
            projectId: projectId,
            userId: $scope.getsUser
        }

        $scope.isTeset = function () {
            if (taskState == 2) {
                return true
            } else {
                return false
            }
        }
        $http.put(serviceBase + 'api/task/editTask' , $scope.editTask).then(function (response) {
            $scope.listOfTasks = response.data;

            $http.get(serviceBase + 'api/task/getTasks/' + projectId).then(function (response) {

                $scope.listOfTasks = response.data;
            });
        });
    };

    $scope.deleteTask = function (taskId) {
        $http.delete(serviceBase + 'api/task/deleteTask/' + taskId).then(function (response) {
            $scope.listOfTasks = response.data;

            $http.get(serviceBase + 'api/task/getTasks/' + projectId).then(function (response) {

                $scope.listOfTasks = response.data;
            });
        });
    };
}]);