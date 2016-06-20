﻿(function () {
    "use strict";

    angular.module("elibrary.web").directive("bookInfoCard", function () {
        return {
            scope: {
                book: "=",
                initialCollapsed: "@collapsed"
            },
            templateUrl: "Scripts/app/directives/bookinfocard.html",
            controller: ["$scope", BookInfoCardController]
        };
    });

    function BookInfoCardController($scope) {
        $scope.collapsed = ($scope.initialCollapsed === "true");
        $scope.collapse = function () {

            $scope.collapsed = !$scope.collapsed;

        };
    }

}());