using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Factories
{
    public interface IModelFactory
    {
        TagModel CreateTagModel(Tag tag);
        TagBasicModel CreateTagBasicModel(Tag tag);
        BookBasicModel CreateBookBasicModel(Book book);
    }
}
