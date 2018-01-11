using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Guider
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string GuiderID { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        [StringLength(256)]
        public string ImageFullPath { get; set; }
        
        [StringLength(256)]
        public string Skype { get; set; }

        [StringLength(2000)]
        public string AboutMe { get; set; }

        [StringLength(256)]
        public string AdressOfTaking { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(100)]
        public string Adress { get; set; }

        [StringLength(256)]
        public string IBAN { get; set; }

        [StringLength(256)]
        public string Passport { get; set; }

        [StringLength(256)]
        public string DocumentPDF { get; set; }

        [DataType(DataType.Currency)]
        public decimal ChargePerHour { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsAccepted { get; set; }

        [ForeignKey("CancellationPolicy")]
        public int? CancellationPolicyID { get; set; }

        [ForeignKey("Premium")]
        public int? PremiumID { get; set; }

        public virtual Premium Premium { get; set; }
        public virtual CancellationPolicy CancellationPolicy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<UnavailableDate> UnavailableDates { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<TravellerToGuiderRate> TravellerToGuiderRates { get; set; }
        public virtual ICollection<GuiderToTravellerBan> GuiderToTravellerBans { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<GuiderLanguageSkill> GuiderLanguageSkills { get; set; }
        public virtual ICollection<TravellerToGuiderFavourite> TravellerToGuiderFavourite { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}