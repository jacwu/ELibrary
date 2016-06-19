using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using System.Web.Http.Routing;

namespace ELibrary.API.Factories
{
    public interface IModelFactory
    {
        TagBasicModel CreateTagBasicModel(UrlHelper urlHelper, string routeName, Tag tag);
        TagModel CreateTagModel(UrlHelper urlHelper, string routeName, Tag tag);
        BookBasicModel CreateBookBasicModel(UrlHelper urlHelper, string routeName, Book book);
        BookModel CreateBookModel(UrlHelper urlHelper, string routeName, Book book);
        OrderModel CreateOrderModel(UrlHelper urlHelper, string routeName, Order order);
    }
}
