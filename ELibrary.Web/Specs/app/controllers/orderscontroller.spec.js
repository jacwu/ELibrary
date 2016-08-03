describe('Test OrdersController', function () {
    var $scope, $controller, deferred, communicationFactory_mock;
    var orders = [{ username: 'testuser', links: [{ rel: 'returnbook', href: 'api/library/orders/3/return' }] },
                            { username: 'testuser', links: [{ rel: 'returnbook', href: 'api/library/orders/4/return' }] }];

    beforeEach(function () {
        module('elibrary.web');

        module(function ($provide) {
            communicationFactory_mock = {
                returnBook: function (url) {
                    deferred.resolve({});
                    return deferred.promise;
                },
                getOpenOrders: function (url) {
                    deferred.resolve(
                        orders
                    );
                    return deferred.promise;
                }
            };

            openBooksUrlValue_mock = 'api/elibrary/orders';

            $provide.value('communicationFactory', communicationFactory_mock);
            $provide.value('openBooksUrlValue', openBooksUrlValue_mock);
        });

        inject(function (_$controller_, $q, $rootScope) {
            $controller = _$controller_;
            deferred = $q.defer();
            $scope = $rootScope.$new();
        });
    });

    it('returnbook href is passed into returnBook', function () {
        orders = [{ username: 'testuser', links: [{ rel: 'returnbook', href: 'api/library/orders/3/return' }] },
                            { username: 'testuser', links: [{ rel: 'returnbook', href: 'api/library/orders/4/return' }] }];
        spyOn(communicationFactory_mock, 'returnBook').and.callThrough();
        var BookController = $controller('OrdersController', { $scope: $scope });
        $scope.returnBook(orders[0]);
        expect(communicationFactory_mock.returnBook).toHaveBeenCalledWith(orders[0].links[0].href);
    });

    it('remove the order from order list', function () {
        orders = [{ username: 'testuser', links: [{ rel: 'returnbook', href: 'api/library/orders/3/return' }] },
                            { username: 'testuser', links: [{ rel: 'returnbook', href: 'api/library/orders/4/return' }] }];

        var BookController = $controller('OrdersController', { $scope: $scope });
        $scope.returnBook(orders[0]);
        $scope.$apply();
        expect($scope.orders.length).toBe(1);
    });
})