using ELibrary.API.Factories;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IModelFactory _modelFactory;

        public IModelFactory TheModelFactory
        {
            get
            {
                return _modelFactory;
            }
        }

        public BaseApiController(IModelFactory modelFactory)
        {
            _modelFactory = modelFactory;

        }
    }
}
