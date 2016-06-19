using System.Collections.Generic;
using System.Linq;
using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System.Web.Http.Routing;
using ELibrary.Api.Constants;

namespace ELibrary.API.Factories
{
    class ModelFactory : IModelFactory
    {

        LinkModel CreateLink(string href, string rel, string method = MethodConstant.GET)
        {
            return new LinkModel
            {
                Href = href,
                Rel = rel,
                Method = method
            };
        }
        public TagBasicModel CreateTagBasicModel(UrlHelper urlHelper, string routeName, Tag tag)
        {
            return new TagBasicModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new { tagId = tag.Id }), RelConstant.SELF)
                },
                Name = tag.Name,
                ImageName = tag.ImageName
            };
        }

        public TagModel CreateTagModel(UrlHelper urlHelper, string routeName, Tag tag)
        {
            return new TagModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new { tagId = tag.Id }), RelConstant.SELF)
                },
                Name = tag.Name,
                ImageName = tag.ImageName,
                Books = tag.Books.Select(m => CreateBookBasicModel(urlHelper, "Books", m))
            };
        }

        public BookBasicModel CreateBookBasicModel(UrlHelper urlHelper, string routeName, Book book)
        {
            return new BookBasicModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, 
                            new {bookId = book.Id }), 
                            RelConstant.SELF),
                    CreateLink(urlHelper.Link("TagsAssociation", 
                            new { bookId = book.Id}), 
                            RelConstant.TagsAssociation),
                    CreateLink(urlHelper.Link("BorrowBook", 
                            new { bookId = book.Id}), 
                            RelConstant.BorrowBook, "POST")
                },
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                AuthorName = book.AuthorName

            };
        }

        public BookModel CreateBookModel(UrlHelper urlHelper, string routeName, Book book)
        {
            return new BookModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName,
                            new {bookId = book.Id }),
                            RelConstant.SELF),
                    CreateLink(urlHelper.Link("TagsAssociation",
                            new { bookId = book.Id}),
                            RelConstant.TagsAssociation),
                    CreateLink(urlHelper.Link("BorrowBook",
                            new { bookId = book.Id}),
                            RelConstant.BorrowBook, "POST")
                },
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                AuthorName = book.AuthorName,
                Tags = book.Tags.Select(m => CreateTagBasicModel(urlHelper, "Tags", m))
            };
        }

        public OrderModel CreateOrderModel(UrlHelper urlHelper, string routeName, Order order)
        {
            return new OrderModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, new { orderId = order.Id}), RelConstant.SELF)
                },
                OpenDate = order.OpenDate.ToString("yyyy-MM-dd"),
                CloseDate = order.CloseDate,
                UserName = order.UserName,
                Book = CreateBookBasicModel(urlHelper, "Books", order.Book)
            };
        }
    }
}
