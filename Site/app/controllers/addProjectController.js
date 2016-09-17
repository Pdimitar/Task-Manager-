'use strict';
app.controller('addProjectController', ['$http', '$scope', '$routeParams', 'authService', function ($http, $scope, $routeParams, authService) {

    var projectId = $routeParams.projectId;


    $http.get(serviceBase + 'api/task/getProjects').then(function (response) {
        $scope.getProject = response.data;
    })

    //$http.get(serviceBase + 'api/admin/GetRole').then(function (response) {
    //    $scope.getProject = response.data;

    

    $scope.addProject = {
        projectName: "",
        description: "",
      
    }


    $scope.AddProject = function (date3,date4) {

        $scope.addProject.startDate = date3;
        $scope.addProject.endDate = date4;

        $http.post(serviceBase + 'api/task/addProject', $scope.addProject).then(function (response) {
            $scope.addProject = response.data;

            $scope.addProject = {
                projectName: "",
                description: "",

            }

            $http.get(serviceBase + 'api/task/getProjects').then(function (response) {
                $scope.getProject = response.data;

            });
        });
    }




    $scope.deleteProject = function (projectId) {

        $http.delete(serviceBase + 'api/task/deleteProject/' + projectId).then(function (response) {
            $scope.addProject = response.data;


            $http.get(serviceBase + 'api/task/getProjects').then(function (response) {
                $scope.getProject = response.data;

            });
        });
    }


    $scope.tasks = function (projectId) {
        $http.get(serviceBase + 'api/task/getTasks/' + projectId).then(function (response) {

            $scope.listOfTasks = response.data;
        });
    }

    $http.get(serviceBase + 'api/admin/UnApprovedUser').then(function (unApproved) {
        if (unApproved.data == "False") {
            $scope.ngUnaprived = "false";

        } else if (unApproved.data == "True") {
            $scope.ngUnaprived = "true";
        };
    });
    





}]);

