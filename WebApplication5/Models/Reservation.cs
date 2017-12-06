using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public enum CreditCardType {
        A, B, C, D
    }

    public class Reservation
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; } 

        public bool IsAccepted { get; set; }
        public bool IsBilled { get; set; }
        public bool IsActive { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        public CreditCardType? CreditCardType { get; set; }
        public decimal CostOfEuros { get; set; }
        public decimal OtherCostOfEuros { get; set; }

        [StringLength(256)]
        public string Country_Bill { get; set; }

        [StringLength(256)]
        public string FirstName_Bill { get; set; }

        [StringLength(256)]
        public string LastName_Bill { get; set; }

        [StringLength(256)]
        public string StreetAdress1_Bill { get; set; }

        [StringLength(256)]
        public string StreetAdress2_Bill { get; set; }

        [StringLength(256)]
        public string City_Bill { get; set; }

        [StringLength(256)]
        public string State_Bill { get; set; }

        [StringLength(50)]
        [DataType(DataType.PostalCode)]
        public string ZipCode_Bill { get; set; }
        
        [StringLength(256)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber_Bill { get; set; }

        public string GuiderID { get; set; }
        public string TravellerID { get; set; }

        [ForeignKey("GuiderID"), Column(Order = 1)]
        public virtual Guider Guider { get; set; }

        [ForeignKey("TravellerID"), Column(Order = 2)]
        public virtual Traveller Traveller { get; set; }

        public virtual Conversation Conversation { get; set; }
    }
}