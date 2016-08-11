using ELibrary.Api.Constants;
using ELibrary.API.Extensions;
using ELibrary.API.Factories;
using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using ELibrary.Service;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    [Route("api/library/books/{bookid?}", Name = "Books")]
    public class BooksController : BaseApiController
    {
        private ITagService _tagService;
        private IBookService _bookService;
        private IUnitOfWork _unitOfWork;

        public Func<string, string> GetWebPath = HostingEnvironment.MapPath;

        public BooksController(ITagService tagService, 
            IBookService bookService,
            IUnitOfWork unitOfWork,
            IModelFactory modelFactory):base(modelFactory)
        {
            _bookService = bookService;
            _tagService = tagService;
            _unitOfWork = unitOfWork;
        }
        public IHttpActionResult Get()
        {
            return InternalServerError(new NotImplementedException());
        }

        [Route("api/library/books/{bookid}/tags", Name = "TagsAssociation")]
        public IHttpActionResult Get(int bookId)
        {
            var results = _tagService.GetTagsForBook(bookId)
                .ToList()
                .Select(f => TheModelFactory.CreateTagBasicModel(Url, "Tags", f));

            return Ok(results);
        }

        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }
            try
            {
                var workingFolder = GetWebPath(@"/content/bookimages");

                var provider = new BookUploadDataStreamProvider(workingFolder);

                await Request.Content.ReadAsMultipartAsync(provider);

                int[] tagList = provider.FormData["tagIds"].Split(',').Select(str => int.Parse(str)).ToArray();

                // create book
                Book book = new Book
                {
                    Title = provider.FormData["title"],
                    AuthorName = provider.FormData["authorName"],
                    Description = provider.FormData["description"],
                    PublishYear = int.Parse(provider.FormData["publishYear"]),
                    ImageName = UnquoteToken(provider.FileData[0].Headers.ContentDisposition.FileName),
                    Tags = tagList.SelectMany(id => _tagService.AllTags.Where(tag => tag.Id == id)).ToList()
                };


                var bookCreated = _bookService.CreateBook(book);
                _unitOfWork.Commit();

                var result = TheModelFactory.CreateBookModel(Url, "Books", bookCreated);

                string location = string.Empty;
                foreach (var link in result.Links)
                {
                    if (link.Rel.Equals(RelConstant.SELF))
                    {
                        location = link.Href;
                    }
                }

                return Created(location, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Delete(int bookId=-1)
        {
            if (bookId < 0)
                return BadRequest("No BookId");

            _bookService.DeleteBookById(bookId);
            _unitOfWork.Commit();

            return StatusCode(HttpStatusCode.NoContent);

        }

        private static string UnquoteToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
            {
                return token.Substring(1, token.Length - 2);
            }

            return token;
        }
    }
}