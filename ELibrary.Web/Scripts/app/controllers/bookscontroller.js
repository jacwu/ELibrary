(function () {
    "use strict";

    angular.module("elibrary.web").controller("BooksController",
        ["$scope", "tagValue", 
            function ($scope, tagValue) {

        var booksUrl;
        $scope.ready = false;

        $scope.tag = tagValue;
        
        for (var i = 0; i < tagValue.links.length; i++) {
            if (tagValue.links[i].rel === "self") {
                booksUrl = tagValue.links[i].href;
                break;
            }
        }

        if (typeof (booksUrl) !== "undefined") {
            //retrieve book list




        }


    }]);


}());