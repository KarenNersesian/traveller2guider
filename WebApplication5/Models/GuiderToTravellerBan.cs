using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class GuiderToTravellerBan
    {
        //[Key, Column(Order = 0)]
        //public int GuiderToTravellerBanID { get; set; }

        public DateTime DateOfBanning { get; set; }
        
        [StringLength(256, ErrorMessage = "Please describe the reason of banning not longer than 256 characters")]
        public string ReasonForBanning { get; set; }

        public bool IsBanned { get; set; }

        [Key, Column(Order = 1)]
        public string GuiderID { get; set; }

        [Key, Column(Order = 2)]
        public string TravellerID { get; set; }

        [ForeignKey("GuiderID")]
        public virtual Guider Guider { get; set; }

        [ForeignKey("TravellerID")]
        public virtual Traveller Traveller { get; set; }
    }
}