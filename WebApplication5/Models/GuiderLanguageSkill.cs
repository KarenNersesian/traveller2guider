using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class GuiderLanguageSkill
    {
        //[Key, Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int GuiderLanguageSkillID { get; set; }

        [Key, Column(Order = 1)]
        public int LanguageID { get; set; }

        [Key, Column (Order = 2)]
        public string GuiderID { get; set; }

        [ForeignKey("GuiderID")]
        public virtual Guider Guider { get; set; }

        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; }

        public DateTime DateOfInsertingLanguageSkill { get; set; }

        public bool IsCertified { get; set; }
        
    }
}