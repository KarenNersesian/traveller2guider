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
using WebApplication5.DAL;
using System.Device.Location;
using PagedList;

namespace WebApplication5.Controllers
{
    public class GuiderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
            double lat = DataTypeConvert.ConvertToDouble(cityLat);
            double lon = DataTypeConvert.ConvertToDouble(cityLng);
            GeoCoordinate geoCoordinateFrom = new GeoCoordinate(lat, lon);

            var nearbyGuiders = (from guider in db.Guiders.AsEnumerable()
                                 let distance = geoCoordinateFrom.GetDistanceTo(new GeoCoordinate(guider.Latitude.Value, guider.Longitude.Value))
                                 where distance <= 100000
                                 orderby distance ascending
                                 select guider).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("ShowGuiders", nearbyGuiders.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Guider/GetGuiderProfile
        [HttpGet] 
        public ActionResult GetGuiderProfile(string guiderId)
        {
            if (guiderId == null)
            {
                // return View("Error");
            }
            Guider selectedGuider = new Guider();
            try
            {
                selectedGuider = db.Guiders.Find(guiderId);
            }
            catch (Exception e)
            {
                //return Error("View");
            }
            string omega = guiderId;

            return View("GetGuiderProfile", selectedGuider);
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