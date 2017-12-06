using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class TravellerToGuiderRate
    {
        //[Key, Column(Order = 0)]
        //public int TravellerToGuiderRateID { get; set; }

        [Range(1,5)]
        public int Rate { get; set; }

        public string Comment { get; set; }

        [Key, Column(Order = 1)]
        public string GuiderID { get; set; }

        [Key, Column(Order = 2)]
        public string TravellerID { get; set; }

        [ForeignKey("GuiderID")]
        public virtual Guider Guider { get; set; }

        [DataType(DataType.Date)]
        public DateTime Rate_Entry { get; set; }

        [ForeignKey("TravellerID")]
        public virtual Traveller Traveller { get; set; }
        
    }
}