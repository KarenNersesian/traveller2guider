using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }

        [StringLength(256)]
        public string LanguageName { get; set; }

        [StringLength(50)]
        public string LanguageShortName { get; set; }

        public virtual ICollection<GuiderLanguageSkill> GuiderLanguageSkills { get; set; }
    }
}