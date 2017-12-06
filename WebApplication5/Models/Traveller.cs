using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Traveller
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string TravellerID { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        [StringLength(256)]
        public string ImageFullPath { get; set; }

        [StringLength(256)]
        public string Skype { get; set; }

        [StringLength(256)]
        public string AboutMe { get; set; }

        [StringLength(256)]
        public string Country { get; set; }

        [StringLength(256)]
        public string City { get; set; }

        [StringLength(256)]
        public string Adress { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<TravellerToGuiderRate> TravellerToGuiderRates { get; set; }
        public virtual ICollection<TravellerToGuiderFavourite> TravellerToGuiderFavourites { get; set; }
        public virtual ICollection<GuiderToTravellerBan> GuiderToTravellerBans { get; set; }
    }
}