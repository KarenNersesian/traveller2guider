using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.DAL;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class FavouriteService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public TravellerToGuiderFavourite GetSpecificLike(string guiderId, string travellerId)
        {
            var travellerToGuiderFavourite = db.TravellerToGuiderFavourites.Find(guiderId, travellerId);

            return travellerToGuiderFavourite;
        }
    }
}