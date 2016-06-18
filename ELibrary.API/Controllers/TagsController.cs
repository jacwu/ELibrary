using ELibrary.API.Factories;
using ELibrary.Data;
using ELibrary.Data.Infra;
using ELibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    [Route("api/library/tags/{tagid?}", Name = "Tags")]
    public class TagsController : BaseApiController
    {
        private ITagService _tagService;

        public TagsController(ITagService tagService, 
            IModelFactory modelFactory) : base(modelFactory)
        {
            _tagService = tagService;
        }
        public IHttpActionResult Get()
        {
            var results = _tagService.AllTags.ToList()
                .Select(t => TheModelFactory.CreateTagBasicModel(Url, "Tags", t));

            return Ok(results);
        }

        public IHttpActionResult Get(int tagId)
        {
            var result = _tagService.GetTag(tagId);

            if (result != null)
                return Ok(TheModelFactory.CreateTagModel(Url, "Tags", result));

            return NotFound();
        }
    }
}
