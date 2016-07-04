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


}());