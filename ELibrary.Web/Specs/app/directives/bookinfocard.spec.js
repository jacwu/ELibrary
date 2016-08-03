describe('Test bookInfoCard', function () {
    var element;
    var scope;
    var book = {
        links: [
        {
            href: "api/library/books/3",
            rel: "self",
            method: "GET"
        },
        {
            href: "api/library/books/3/tags",
            rel: "tagsassociation",
            method: "GET"
        }],
        title: "CLR via C#, Second Edition",
        description: "Dig deep and master the intricacies of the common language runtime, C#, and .NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team - you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components.",
        authorName: "Jeffrey Richter",
        imageName: "clrviacsharp.jpg"
    };

    var tags = [
        {
            links: [
            {
                href: "http://localhost:1234/api/library/tags/2",
                rel: "self",
                method: "GET"
            }
            ],
            name: "C#",
            imageName: "csharp.png"
        },
        {
            links: [
            {
                href: "http://localhost:1234/api/library/tags/3",
                rel: "self",
                method: "GET"
            }
            ],
            name: ".Net",
            imageName: "doNet.png"
        }];

    beforeEach(function () {
        module('elibrary.web');
        module('directive.module');

        module(function ($provide) {
            communicationFactory_mock = {
                getTagsByBook: function (url) {
                    deferred.resolve(
                        tags
                    );
                    return deferred.promise;
                }
            };

            $provide.value('communicationFactory', communicationFactory_mock);
        });

        inject(function ($rootScope, $compile, $q) {
            deferred = $q.defer();
            scope = $rootScope.$new();
            scope.book = book;
            scope.borrowBook = jasmine.createSpy('borrowBook');

            element = $compile(angular.element('<book-info-card book="book" collapsed="true" borrow="borrowBook(book)"></book-info-card>'))(scope);
            scope.$digest();
        });
    });

    describe('Isolated Scope', function () {               
        it('two way binding on isolated scope', function () {
            var isolatedScope = element.isolateScope();
            expect(isolatedScope.book).toBe(scope.book);            
        });

        it('one way binding on isolated scope', function () {
            var isolatedScope = element.isolateScope();
            expect(isolatedScope.initialCollapsed).toEqual('true');
            expect(isolatedScope.collapsed).toBeTruthy();
        });

        it('should call borrowBook method of parent scope when invoked from notifyParent of isolated scope', function () {
            var isolatedScope = element.isolateScope();
            expect(typeof (isolatedScope.notifyParent)).toEqual('function');
            isolatedScope.notifyParent();
            expect(scope.borrowBook).toHaveBeenCalled();
        });
    });

    describe('HTML interaction', function () {        
        it('getTagsByBook is called with tagsassociation url', function () {
            spyOn(communicationFactory_mock, 'getTagsByBook').and.callThrough();

            var headingdiv = element.find('div div');
            headingdiv.click();
            expect(communicationFactory_mock.getTagsByBook).toHaveBeenCalledWith(book.links[1].href);           
        });

        it('tags are binding to span objects', function () {
            var isolatedScope = element.isolateScope();
            var headingdiv = element.find('div div');
            var bodydiv = element.find('div div:nth-child(2)');

            headingdiv.click();
            expect(isolatedScope.book.tags).toBe(tags);

            var elem = element.find('.panel-body');
            var elem = elem.find(':nth-child(4)');
            var span = elem.find(':nth-child(1)');
            expect(span.text().trim()).toEqual(tags[0].name);
            span = elem.find(':nth-child(2)');
            expect(span.text().trim()).toEqual(tags[1].name);
        });

        it('book properties are shown correctly', function () {
            var elem = element.find('em');
            expect(elem.text()).toEqual(book.authorName);

            elem = element.find('h3').clone();
            elem.children().remove();
            expect(elem.text().trim()).toEqual(book.title);

            elem = element.find('img');
            expect(elem.attr('src')).toContain(book.imageName);

            elem = element.find('.panel-body');
            elem = elem.find(':nth-child(2)');
            expect(elem.find('div').text()).toEqual(book.description);                   
        });

        it('click submit button will notify the parent', function () {
            var btn = element.find('button');
            btn.click();
            expect(scope.borrowBook).toHaveBeenCalled();                    
        });

        it('body should hide and show per heading click', function () {
            var headingdiv = element.find('div div');

            var bodydiv = element.find('div div:nth-child(2)');
            expect(bodydiv.hasClass('ng-hide')).toBeTruthy();

            headingdiv.click();
            expect(bodydiv.hasClass('ng-hide')).toBeFalsy();

            headingdiv.click();
            expect(bodydiv.hasClass('ng-hide')).toBeTruthy();
        });
    });
});