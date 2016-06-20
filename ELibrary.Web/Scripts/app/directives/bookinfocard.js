(function () {
    "use strict";

    angular.module("elibrary.web").directive("bookInfoCard", function () {
        return {
            scope: {
                book: "=",
                initialCollapsed: "@collapsed",
                notifyParent: "&borrow"
            },
            templateUrl: "Scripts/app/directives/bookinfocard.html",
            controller: ["$scope","communicationFactory", BookInfoCardController]
        };
    });

    function BookInfoCardController($scope, communicationFactory) {
        $scope.collapsed = ($scope.initialCollapsed === "true");
        $scope.collapse = function () {
            var tagsAssociationUrl;
            if ($scope.collapsed && !$scope.book.tags) {
                for (var i = 0; i < $scope.book.links.length; i++) {
                    if ($scope.book.links[i].rel === "tagsassociation") {
                        tagsAssociationUrl = $scope.book.links[i].href;
                        break;
                    }
                }

                if (typeof (tagsAssociationUrl) !== "undefined") {
                    communicationFactory.getTagsByBook(tagsAssociationUrl)
                        .then(function (tags) {
                        $scope.book.tags = tags;
                    });
                }
            }

            $scope.collapsed = !$scope.collapsed;

        };

        $scope.navigateToTag = function (tag) {
            var hashUrl = btoa(JSON.stringify(tag));
            window.location = "/Books?tag=" + hashUrl;
        };

        $scope.borrowBook = function () {
            $scope.notifyParent();
        };
    }

}());