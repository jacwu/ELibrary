using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ELibrary.API.Filters
{
    public class RequiredScopeAttribute: ActionFilterAttribute
    {
        public string Scope { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var matchScope = (actionContext.RequestContext.Principal.Identity as ClaimsIdentity)
                .Claims.Any(c => c.Type == "scope" && c.Value == Scope);

            if(!matchScope)
            {
                var response = new HttpResponseMessage
                {
                    Content = new StringContent("valid token needed"),
                    StatusCode = HttpStatusCode.Unauthorized
                };

                throw new HttpResponseException(response);
            }
            
            base.OnActionExecuting(actionContext);
        }
    }
}