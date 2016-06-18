using ELibrary.Api.Constants;
using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace ELibrary.API.Factories
{
    public class ModelFactory: IModelFactory
    {
        LinkModel CreateLink(string href, 
            string rel, 
            string method = MethodConstant.GET)
        {
            return new LinkModel
            {
                Href = href,
                Rel = rel,
                Method = method
            };
        }

        public TagModel CreateTagModel(UrlHelper urlHelper,
            string routeName,
            Tag tag)
        {
            return new TagModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, 
                                new { tagId = tag.Id }), 
                                RelConstant.SELF)
                },
                Name = tag.Name,
                ImageName = tag.ImageName,
                Books = tag.Books.Select(
                    m => CreateBookBasicModel(urlHelper, 
                                        "Books", m))
            };
        }

        public BookBasicModel CreateBookBasicModel(UrlHelper urlHelper,
            string routeName, 
            Book book)
        {
            return new BookBasicModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName,
                                new {bookId = book.Id }), 
                                RelConstant.SELF),
                },
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                AuthorName = book.AuthorName
            };
        }

        public TagBasicModel CreateTagBasicModel(UrlHelper urlHelper,
            string routeName, 
            Tag tag)
        {
            return new TagBasicModel
            {
                Links = new List<LinkModel>
                {
                    CreateLink(urlHelper.Link(routeName, 
                                new { tagId = tag.Id }), 
                                RelConstant.SELF)
                },
                Name = tag.Name,
                ImageName = tag.ImageName,
            };
        }
    }
}