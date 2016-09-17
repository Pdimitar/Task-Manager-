app.factory('authorizationService', ['$q', '$rootScope', '$location', 'localStorageService', '$http',
    function ($q, $rootScope, $location, localStorageService, $http) {
        return {
            permissionModel: {
                permission: "",
            },

            permissionCheck: function (roleCollection) {

                var deferred = $q.defer();
                var parentPointer = this;
                $http.get(serviceBase + 'api/admin/getRole').then(function (role) {
                //parentPointer.permissionModel.permission = localStorageService.get('authorizationData').Role;
                    var userRole = role.data;
                parentPointer.permissionModel.permission = userRole;
                parentPointer.permissionModel.isPermissionLoaded = true;
                //deferred.resolve('request successful');
                parentPointer.getPermission(parentPointer.permissionModel, roleCollection, deferred);
                return deferred.promise;
                 });
            },

            getPermission: function (permissionModel, roleCollection, deferred) {
                var ifPermissionPassed = false;

                angular.forEach(roleCollection, function (role) {


                    if (permissionModel.permission == "admin") {
                        ifPermissionPassed = true;
                    } else if (permissionModel.permission == "user") {
                        ifPermissionPassed = true;
                    }


                });
                angular.forEach(roleCollection, function (role) {
                    if (!ifPermissionPassed) {
                        $location.path(routeForUnauthorizedAccess);
                        $rootScope.$on('$locationChangeSuccess', function (next, current) {
                            deferred.resolve();
                        });
                    }
                    else {
                        deferred.resolve();
                    }
                });
            }
        };
    }]);