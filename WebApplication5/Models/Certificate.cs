using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Certificate
    {

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificateID { get; set; }

        public string GuiderID { get; set; }

        [StringLength(256)]
        public string Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime Certificate_Entry { get; set; }

        public bool IsAccepted { get; set; }

        [ForeignKey("GuiderID"), Column(Order = 1)]
        public Guider Guider { get; set; }
    }
}