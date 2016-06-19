using ELibrary.API.Factories;
using ELibrary.Service;
using System;
using System.Linq;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    [Route("api/library/books/{bookid?}", Name = "Books")]
    public class BooksController : BaseApiController
    {
        private ITagService _tagService;

        public BooksController(ITagService tagService, IModelFactory modelFactory):base(modelFactory)
        {
            _tagService = tagService;
        }
        public IHttpActionResult Get()
        {
            return InternalServerError(new NotImplementedException());
        }


    }
}