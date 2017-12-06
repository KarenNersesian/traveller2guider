using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Activity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityID { get; set; }

        [StringLength(20, ErrorMessage = "The theme of Activity can not be longer than 20 characters")]
        public string NameOfActivity { get; set; }

        [StringLength(50, ErrorMessage = "The Adress of your Activity can not be longer than 50 characters")]
        public string ActivityAdress { get; set; }

        public decimal Activity_Longitude {get; set; }
        public decimal Activity_Latitude { get; set; }

        [StringLength(2000, ErrorMessage = "The theme of Activity can not be longer than 50 characters")]
        public string Description { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        public string GuiderID { get; set; }

        [ForeignKey("GuiderID"), Column(Order = 1)]
        public virtual Guider Guider { get; set; }
    }
}