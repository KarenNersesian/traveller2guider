using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class UnavailableDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnavailableID { get; set; }

        [DataType(DataType.Date)]
        public DateTime UnavailableFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime UnavailableTo { get; set; }

        [DataType(DataType.Date)]
        public DateTime UnavailableDateEntry { get; set; }

        [ForeignKey("Guider")]
        public string GuiderID { get; set; }

        public Guider Guider { get; set; }
    }
}