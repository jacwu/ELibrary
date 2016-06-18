using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.API.Factories
{
    public class ModelFactory: IModelFactory
    {
        public TagModel CreateTagModel(Tag tag)
        {
            return new TagModel
            {
                Name = tag.Name,
                ImageName = tag.ImageName,
                Books = tag.Books.Select(m => CreateBookBasicModel(m))
            };
        }

        public BookBasicModel CreateBookBasicModel(Book book)
        {
            return new BookBasicModel
            {
                Title = book.Title,
                Description = book.Description,
                ImageName = book.ImageName,
                AuthorName = book.AuthorName
            };
        }

        public TagBasicModel CreateTagBasicModel(Tag tag)
        {
            return new TagBasicModel
            {
                Name = tag.Name,
                ImageName = tag.ImageName,
            };
        }
    }
}