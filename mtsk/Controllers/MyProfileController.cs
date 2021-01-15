using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Responses;
using mtsk.ViewModel;
using Newtonsoft.Json;

namespace mtsk.Controllers
{
    public class MyProfileController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/users/";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.GetStringAsync(url);
                MyProfileViewModel message = new MyProfileViewModel();
                message.getUserInformationResponseMessage = JsonConvert.DeserializeObject<GetUserInformationResponseMessage>(response.Result);
                return View(message);
            }
        }
        public ActionResult SessionRemove()
        {
            if (Session["token"] != null)
            {
                Session.Remove("token");
                Session.Remove("name");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
