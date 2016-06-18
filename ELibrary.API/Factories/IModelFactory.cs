using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace ELibrary.API.Factories
{
    public interface IModelFactory
    {
        TagModel CreateTagModel(UrlHelper urlHelper, 
            string routeName, 
            Tag tag);
        TagBasicModel CreateTagBasicModel(UrlHelper urlHelper,
            string routeName, 
            Tag tag);
        BookBasicModel CreateBookBasicModel(UrlHelper urlHelper,
            string routeName,
            Book book);
    }
}
