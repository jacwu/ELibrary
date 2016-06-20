(function () {
    "use strict";

    angular.module("elibrary.web").factory("communicationFactory",
        ["$http", function ($http) {
            return {
                getBooksByTag: function (booksUrl) {

                    return $http.get(booksUrl)
                            .then(function (r) {
                                return r.data.books;
                            });
                }

            };
        }]);

}());
