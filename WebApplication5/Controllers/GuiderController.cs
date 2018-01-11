using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication5.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PagedList;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class GuiderController : Controller
    {
        private GuiderService guiderService = new GuiderService();

        // GET: Guider
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Guider/ShowGuiders
        [HttpGet]
        public ActionResult ShowGuiders(string cityLat, string cityLng, int? page)
        {
            ViewBag.CurrentLat = cityLat;
            ViewBag.CurrentLng = cityLng;

            var nearbyGuiders = guiderService.ShowGuiders(cityLat, cityLng, page);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("ShowGuiders", nearbyGuiders.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Guider/GetGuiderProfile
        [HttpGet] 
        public ActionResult GetGuiderProfile(string guiderId)
        {
            PublicProfileGuiderViewModel publicProfileGuider = new PublicProfileGuiderViewModel();
            List<TravellerToGuiderRate> rates = new List<TravellerToGuiderRate>();
            if (guiderId == null)
            {
                // return View("Error");
            }

            try
            {
                publicProfileGuider.Guider = guiderService.GetGuider(guiderId);
                rates = guiderService.GetRatesOfSpecificGuider(guiderId);
                int sum = 0;
                if(rates.Count != 0)
                {
                    foreach (var item in rates)
                    {
                        sum += item.Rate;
                    }
                    publicProfileGuider.OverralRating = sum / rates.Count;
                    publicProfileGuider.TravellerToGuiderRates = rates;
                }
                else
                {
                    publicProfileGuider.OverralRating = 0;
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("GetGuiderProfile", publicProfileGuider);
        }

        ////
        //// POST: Add Guider into favourite list of current user
        //[HttpPost]
        //public JsonResult SetFavouriteGuider(string guiderId, string currentUserId)
        //{

        //    return Json();
        //}
    }
}