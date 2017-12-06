using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public enum CancellationType
    {
        Strict, Fifty_Fifty, Flex
    }

    public class CancellationPolicy
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CancellationPolicyID { get; set; }

        public CancellationType CancellationType { get; set; }

        public virtual ICollection<Guider> Guiders { get; set; }
    }
}