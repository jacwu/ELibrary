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
    public class TagsController : ApiController
    {
        public IHttpActionResult Get()
        {
            //return Ok(new string[] { "value1", "value2" });

            var _tagService = new TagService(
                new TagRepository(
                new DbFactory()
                ));
            var results = _tagService.AllTags.ToList();
            return Ok(results);

        }
    }
}
