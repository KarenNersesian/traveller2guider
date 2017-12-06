using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class TravellerToGuiderFavourite
    {
        //[Key, Column(Order = 0)]
        //public int TravellerToGuiderFavouriteID { get; set; }

        public string Description { get; set; }

        [Key, Column(Order = 1)]
        public string GuiderID { get; set; }

        [Key, Column(Order = 2)]
        public string TravellerID { get; set; }

        [DataType(DataType.Date)]
        public DateTime FavouriteEntry { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("GuiderID")]
        public virtual Guider Guider { get; set; }

        [ForeignKey("TravellerID")]
        public virtual Traveller Traveller { get; set; }
    }
}