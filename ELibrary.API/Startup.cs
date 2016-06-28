using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using Microsoft.Owin.Security.Jwt;

[assembly: OwinStartup(typeof(ELibrary.API.Startup))]

namespace ELibrary.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap =
                new Dictionary<string, string>();

            var certificate = new X509Certificate2(Convert.FromBase64String("MIIDFjCCAgKgAwIBAgIQYt1be2tn9KBIu2efgllAuDAJBgUrDgMCHQUAMBExDzANBgNVBAMTBlRlbXBDQTAeFw0xNjA1MDcxNTU3MzNaFw0zOTEyMzEyMzU5NTlaMCgxJjAkBgNVBAMTHWVsaWJyYXJ5aWRlbnRpdHkubG9jYWx0ZXN0Lm1lMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAxrFZcqjEQvgkzzm1L6NdU5pk5uz1dEi27/Uu7PeFD2usqTeB4WyrbtbOM/K4Q2gsFuNrewqlFM9g2luC5qP4rCm8YUyOUApR4sYQDK/Hg3wLku5o6qIY4AxnyOTowILV5rXWYbKXxdTUEOyRl9ONwrdMSp31/4qZuxFp0oZNe9nGfaHRhEuq9u+Hv6ZL0HrWzJrte8umnbuV4BLItp8BXVm/Y1WP+kqpicwcWv4+wd4WdFIOVszqD5bPnw41g5RNaRJzA6+Q+tSs+VCgIwm9SXOxGRmzV1vTl7BALmr0QC+IMban6KpzvhDxZU22KNUy8HQB7n/xf0WC46N1xfhloQIDAQABo1swWTATBgNVHSUEDDAKBggrBgEFBQcDATBCBgNVHQEEOzA5gBCbPN9Kx3Uq+0/77b6clc0NoRMwETEPMA0GA1UEAxMGVGVtcENBghDMfmtv2JxSo0CrMFezbilgMAkGBSsOAwIdBQADggEBAAJa+Bu0CqviUBAD3JxhQpZ2QBxFuFxhEkL46XNNQvJfYO7IpX3woyxfQAeh1D+EoIWPqTqxGfM96NT0tGROIQjqOWh8YUyHdrA/ac3pXXvO3ZhvQhcWL/39oQtKh30b5JHuEdBFedPEmN0RfpLaLHeFS6yFs8rT0o223Am/KnUzPmeRpMYCxQ/qTcORE01tQZf9u8X+HMu0BDFiuYrfL3ZOmh1RZi0zo09ggx+iQsdA4+Vhk3YvN0Z9py8YGljQSbv52Hm7lgBa5JlsTiVEoM3ksoPfCK6Bwb4mUS9jPoOJERfUg2NxICEMBmoH7boEhoPePAwG8TBxBAWYA9yt9oA="));

            var stsIssuer = ConfigurationManager.AppSettings["STSIssuerUri"];

            var audience = stsIssuer + "/resources";

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new[] { audience },
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = audience,
                    ValidIssuer = stsIssuer,
                    IssuerSigningKey = new X509SecurityKey(certificate)
                }
            });

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            AutofacConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
