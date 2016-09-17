'use strict'
app.controller("allUsersController", ['$http', '$scope', '$routeParams', function ($http, $scope, $routeParams) {

    $http.get(serviceBase + 'api/admin/getUnAppruvetUsers').then(function (response) {
        $scope.AllUnApprovedUsers = response.data
    });


    $scope.adtivateUser = function (userId) {

        $http.put(serviceBase + 'api/admin/activateUser/' + userId).then(function (response) {
            $scope.AllUnApprovedUsers = response.data


            $http.get(serviceBase + 'api/admin/getUnAppruvetUsers').then(function (response) {
                $scope.AllUnApprovedUsers = response.data
            });
        });
    }

    $scope.desctivateUser = function (userId) {


        $http.put(serviceBase + 'api/admin/deactivateUser/' + userId).then(function (response) {
            $scope.AllUnApprovedUsers = response.data


            $http.get(serviceBase + 'api/admin/getUnAppruvetUsers').then(function (response) {
                $scope.AllUnApprovedUsers = response.data
            });
        });
    }

}])