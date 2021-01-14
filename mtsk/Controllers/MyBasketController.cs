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
    public class MyBasketController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/temporder/";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.GetStringAsync(url);
                Console.WriteLine(response.Result);
                MyBasketViewModel message = new MyBasketViewModel();
                message.getBasketResponseMessage = JsonConvert.DeserializeObject<GetBasketResponseMessage>(response.Result);
                ViewBag.totalPrice = 0;
                ViewBag.totalPiece = 0;
                foreach (var item in message.getBasketResponseMessage.data.siparisData)
                {
                    ViewBag.totalPrice += item.ORDERPRICE;
                    ViewBag.totalPiece += item.ORDERPIECE;
                }
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
