(function () {
    "use strict";
    angular.module("elibrary.web").factory("tokenContainer",
        ["$location", "$cookies", function ($location, $cookies) {

            return {
                getToken: function () {
                    var access_token = $cookies.get('access_token');
                   
                    return access_token;
                }
            };


        }]);


}());