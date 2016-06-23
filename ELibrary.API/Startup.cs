using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using IdentityServer3.AccessTokenValidation;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

[assembly: OwinStartup(typeof(ELibrary.API.Startup))]

namespace ELibrary.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            JwtSecurityTokenHandler.InboundClaimTypeMap = 
                new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = ConfigurationManager.AppSettings["STS"],
                    RequiredScopes = new[] { "elibrarymanagement" }
                });

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            AutofacConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
