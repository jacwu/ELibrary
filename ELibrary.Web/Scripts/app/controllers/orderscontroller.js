(function () {
    "use strict";

    angular.module("elibrary.web").controller("OrdersController", ["$scope", "communicationFactory", "openBooksUrlValue", function ($scope, communicationFactory, openBooksUrlValue) {

        communicationFactory.getOpenOrders(openBooksUrlValue).then(function (orders) {
            $scope.orders = orders;
        });

        $scope.returnBook = function (order) {
            var bookReturnUrl;

            for (var i = 0; i < order.links.length; i++) {
                if (order.links[i].rel === "returnbook") {
                    bookReturnUrl = order.links[i].href;
                    break;
                }
            }

            if (typeof (bookReturnUrl) !== "undefined") {
                communicationFactory.returnBook(bookReturnUrl).then(function () {

                    var idx = $scope.orders.indexOf(order);
                    if (idx > -1)
                        $scope.orders.splice(idx, 1);

                });
            }
        };

    }]);

}());