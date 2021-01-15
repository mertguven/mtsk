using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Requests;
using mtsk.Models.Responses;
using mtsk.ViewModel;
using Newtonsoft.Json;

namespace mtsk.Controllers
{
    public class MyBasketController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/temporder/";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.GetStringAsync(url);
                MyBasketViewModel message = new MyBasketViewModel();
                message.getBasketResponseMessage = JsonConvert.DeserializeObject<GetBasketResponseMessage>(response.Result);
                ViewBag.totalPrice = 0;
                ViewBag.totalPiece = 0;
                foreach (var item in message.getBasketResponseMessage.data.siparisData)
                {
                    ViewBag.totalPrice += item.TEMPORDERPRICE;
                    ViewBag.totalPiece += item.TEMPORDERPIECE;
                }
                return View(message);
            }
        }

        [HttpPost]
        public ActionResult Index(int deleteId)
        {
            Console.WriteLine(deleteId);
            return View();
            /*using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/temporder/delete";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, deleteId);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                MyBasketViewModel message = new MyBasketViewModel();
                message.deleteOrderResponseMessage = JsonConvert.DeserializeObject<DeleteOrderResponseMessage>(responseString.Result);
                Console.WriteLine(message.deleteOrderResponseMessage.success);
                return View(message);
            }*/
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
