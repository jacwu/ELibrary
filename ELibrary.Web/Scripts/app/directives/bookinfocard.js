(function () {
    "use strict";

    angular.module("elibrary.web").directive("bookInfoCard", function () {
        return {
            templateUrl: "Scripts/app/directives/bookinfocard.html",
            controller: ["$scope", BookInfoCardController]
        };
    });

    function BookInfoCardController($scope) {

    }

}());