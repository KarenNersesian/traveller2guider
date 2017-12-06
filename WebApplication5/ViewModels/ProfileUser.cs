using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class ProfileUser
    {
        public Traveller Traveller { get; set; }
        public ApplicationUser AspUser { get; set; }
        public Guider Guider { get; set; }
    }
}