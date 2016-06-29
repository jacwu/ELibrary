(function () {
    "use strict";

    angular.module("elibrary.web", ["ngCookies"]);

    angular.module('elibrary.web').run(["$rootScope", "$window",
        function ($rootScope, $window) {
            $rootScope.$on('event:auth-loginRequired', function () {
                $window.location.reload();
            });
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