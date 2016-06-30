(function () {
    "use strict";

    angular.module("elibrary.web").factory("communicationFactory",
        ["$http", "tokenContainer", function ($http, tokenContainer) {
            return {
                getBooksByTag: function (booksUrl) {
                    var req = {
                        method: "GET",
                        url: booksUrl,
                        headers: {
                            'Authorization': 'Bearer ' + tokenContainer.getToken()
                        }
                    };

                    return $http(req)
                            .then(function (r) {
                                return r.data.books;
                            });
                },
                borrowBook: function (bookBorrowUrl) {
                    var req = {
                        method: "POST",
                        url: bookBorrowUrl,
                        headers: {
                            'Authorization': 'Bearer ' + tokenContainer.getToken()
                        }
                    };
                    return $http(req);
                },
                getOpenOrders: function (openOrdersUrl) {
                    var req = {
                        method: "GET",
                        url: openOrdersUrl,
                        headers: {
                            'Authorization': 'Bearer ' + tokenContainer.getToken()
                        }
                    };

                    return $http(req)
                            .then(function (r) {
                                return r.data;
                            });
                },
                returnBook: function (bookReturnUrl) {
                    var req = {
                        method: "PUT",
                        url: bookReturnUrl,
                        headers: {
                            'Authorization': 'Bearer ' + tokenContainer.getToken()
                        }
                    };
                    return $http(req);
                },
                getTagsByBook: function (tagsUrl) {
                    return $http.get(tagsUrl)
                        .then(function (r) {
                            return r.data;
                        });
                }
            };

        }]);

}());
