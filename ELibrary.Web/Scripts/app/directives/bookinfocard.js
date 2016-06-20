(function () {
    "use strict";

    angular.module("elibrary.web").directive("bookInfoCard", function () {
        return {
            scope: {
                book: "="
            },
            templateUrl: "Scripts/app/directives/bookinfocard.html",
            controller: ["$scope", BookInfoCardController]
        };
    });

    function BookInfoCardController($scope) {

    }

}());