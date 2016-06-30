using ELibrary.Api.Constants;
using ELibrary.API.Factories;
using ELibrary.Data.Infra;
using ELibrary.Model.Entities;
using ELibrary.Service;
using System.Linq;
using System.Web.Http;

namespace ELibrary.API.Controllers
{
    [Authorize(Roles ="NormalUser")]
    [Route("api/library/orders/{orderid?}", Name="Orders")]
    public class OrdersController :  BaseApiController
    {
        private IOrderService _orderService;
        private IUnitOfWork _unitOfWork;

        public OrdersController(IOrderService orderService,
                                IUnitOfWork unitOfWork,
                                IModelFactory modelFactory) : base(modelFactory)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult Get()
        {
            var results = _orderService.GetOpenOrders(User.Identity.Name)
                .ToList()
                .Select(f=>TheModelFactory.CreateOrderModel(Url, "Orders", f));

            return Ok(results);
        }

        [HttpPost]
        [Route("api/library/books/{bookid}/borrow", Name = "BorrowBook")]
        public IHttpActionResult BorrowBook(int bookId)
        {
            Order order = _orderService.BorrowBook(bookId, User.Identity.Name);
            _unitOfWork.Commit();

            var result = TheModelFactory.CreateOrderModel(Url, "Orders", order);

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

        [HttpPut]
        [Route("api/library/orders/{orderid}/return/", Name = "ReturnBook")]
        public IHttpActionResult ReturnBook(int orderId)
        {
            _orderService.ReturnBook(orderId);
            _unitOfWork.Commit();

            return Ok();
        }

    }
}
