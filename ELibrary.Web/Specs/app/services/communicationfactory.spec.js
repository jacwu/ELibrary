describe('Test communicationfactory', function () {
    var communicationFactory, $httpBackend;
    beforeEach(function () {
        module('elibrary.web');

        inject(function ($injector) {
            communicationFactory = $injector.get('communicationFactory');
            $httpBackend = $injector.get('$httpBackend');
        });
    });

    afterEach(function() {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    it('getBooksByTag should return books field', function () {
        var returnData = {
            name: 'Programming',
            imageName: 'Programming.png',
            books: [
                { title: 'Javascript', description: 'book for Javascript' },
                { title: 'Restful', description: 'book for Restful Service' }
            ]
        };

        $httpBackend.expectGET('api/library/tags/1').respond(returnData);

        var returnedPromise = communicationFactory.getBooksByTag('api/library/tags/1');

        var result;
        returnedPromise.then(function (response) {
            result = response;
        });

        $httpBackend.flush();
        expect(result).toEqual(returnData.books); // don't use toBe
    });

    it('borrowBook should return the post response', function () {
        var returnData = {
            openDate: '2016-06-25',
            closeDate: null
        };

        $httpBackend.expectPOST('api/library/books/1/borrow').respond(201, returnData);

        var returnedPromise = communicationFactory.borrowBook('api/library/books/1/borrow');

        var result;
        returnedPromise.then(function (response) {
            result = response;
        });

        $httpBackend.flush();
        expect(result.status).toEqual(201);
        expect(result.data).toEqual(returnData);
    });
})