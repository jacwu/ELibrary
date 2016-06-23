using ELibrary.Model.Entities;
using ELibrary.Model.Models;
using ELibrary.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController()
        {
        }
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();

            //OpenId Connect Hybrid Flow
            var token = (User.Identity as ClaimsIdentity)
                .FindFirst("access_token");
            if (token != null)
            {
                client.SetBearerToken(token.Value);
            }

            client.BaseAddress = new Uri(
                ConfigurationManager.AppSettings["ELibraryAPIEndPoint"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("api/library/tags");


            if (response.IsSuccessStatusCode)
            {
                var rspString = await response
                    .Content
                    .ReadAsStringAsync();
                var tags = JsonConvert
                    .DeserializeObject<IEnumerable<TagBasicModel>>(rspString);

                return View(tags);
            }
            else
            {
                return RedirectToAction("Index", "Error");
                
            }
        }
    }
}