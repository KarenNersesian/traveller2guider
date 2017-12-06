using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Premium
    {
        [Key]
        public int PremiumID { get; set; }

        public decimal CostOfPackageEuros { get; set; }

        public virtual ICollection<Guider> Guiders { get; set; }

    }
}