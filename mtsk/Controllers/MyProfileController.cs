using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Responses;
using Newtonsoft.Json;

namespace mtsk.Controllers
{
    public class MyProfileController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            var url = "https://mtsk-proje.herokuapp.com/api/users/";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
            var response = client.GetStringAsync(url);
            response.Wait();
            var q = response.Result;
            GetUserInformationResponseMessage message = new GetUserInformationResponseMessage();
            message = JsonConvert.DeserializeObject<GetUserInformationResponseMessage>(q);
            return View();
        }
    }
}
