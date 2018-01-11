using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using System.Device.Location;
using WebApplication5.DAL;

namespace WebApplication5.Services
{
    public class GuiderService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Guider> ShowGuiders(string cityLat, string cityLng, int? page)
        {
            double lat = DataTypeConvert.ConvertToDouble(cityLat);
            double lon = DataTypeConvert.ConvertToDouble(cityLng);
            GeoCoordinate geoCoordinateFrom = new GeoCoordinate(lat, lon);

            var nearbyGuiders = (from guider in db.Guiders.AsEnumerable()
                                 let distance = geoCoordinateFrom.GetDistanceTo(new GeoCoordinate(guider.Latitude.Value, guider.Longitude.Value))
                                 where distance <= 100000
                                 orderby distance ascending
                                 select guider).ToList();
            return nearbyGuiders;
        }

        public Guider GetGuider(string guiderId)
        {
            Guider selectedGuider = new Guider();
            selectedGuider = db.Guiders.Find(guiderId);

            return selectedGuider;
        }

        public List<TravellerToGuiderRate> GetRatesOfSpecificGuider(string guiderId)
        {
            var rates = (from rate in db.TravellerToGuiderRates
                         where rate.GuiderID == guiderId
                         orderby rate.Rate_Entry descending
                         select rate).ToList();
            return rates;
        }
    }
}