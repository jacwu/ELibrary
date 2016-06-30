(function () {
    "use strict";
    angular.module("elibrary.web").factory("tokenContainer",
        ["$cookies", function ($cookies) {

            return {
                getToken: function () {
                    var access_token = $cookies.get('access_token');
                   
                    return access_token;
                }
            };


        }]);

    angular.module("elibrary.web").config(["$httpProvider",
    function ($httpProvider) {

        $httpProvider.interceptors.push(["$rootScope", "$q",
            function ($rootScope, $q) {
                return {
                    'responseError': function (rejection) {
                        switch (rejection.status) {
                            case 401:
                                $rootScope.$broadcast('event:auth-loginRequired'
                                    , rejection);
                        }

                        //default behaviour
                        return $q.reject(rejection);
                    }
                };
            }]);
    }]);


}());