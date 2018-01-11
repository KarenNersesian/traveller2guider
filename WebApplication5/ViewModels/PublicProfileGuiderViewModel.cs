using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class PublicProfileGuiderViewModel
    {
        public Guider Guider { get; set; }
        public List<TravellerToGuiderRate> TravellerToGuiderRates { get; set; }
        private double overralRating;
        public double OverralRating 
        {
            get
            {
                return overralRating;
            }
            set
            {
                overralRating = value;
            }
        }
    }
}