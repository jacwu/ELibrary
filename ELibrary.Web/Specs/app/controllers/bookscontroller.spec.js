describe('Test BooksController', function () {
    var $scope, $controller, deferred;
    var books = [{ title: 'Javascript', links: [{ rel: 'borrowbook', href: 'api/library/books/3' }] },
                            { title: 'Restful', links: [{ rel: 'borrowbook', href: 'api/library/books/4' }] }];

    beforeEach(function () {
        module('elibrary.web');

        module(function ($provide) {
            communicationFactory_mock = {
                borrowBook: function (url) {
                    deferred.resolve({});
                    return deferred.promise;
                },
                getBooksByTag: function (url) {
                    deferred.resolve(
                        books
                    );
                    return deferred.promise;
                }
            };

            tagValue_mock = { "links": [{ "href": "api/library/tags/1", "rel": "self", "method": "GET" }], "name": "Programming", "imageName": "programming.png" };

            $provide.value('communicationFactory', communicationFactory_mock);
            $provide.value('tagValue', tagValue_mock);
        });

        inject(function (_$controller_, $q, $rootScope) {
            $controller = _$controller_;
            deferred = $q.defer();
            $scope = $rootScope.$new();
        });
    });

    it('data in scope should be initialized successfully', function () {
        var BookController = $controller('BooksController', { $scope: $scope });
        expect($scope.ready).toBeFalsy();
        expect($scope.books).toBeUndefined();
        $scope.$apply();
        expect($scope.ready).toBeTruthy();
        expect(typeof($scope.books)).toBe('object');
    });

    it('remove the book from book list', function () {
        var BookController = $controller('BooksController', { $scope: $scope });
        $scope.borrowBook(books[0]);
        $scope.$apply();
        expect($scope.books.length).toBe(1);
    });
})