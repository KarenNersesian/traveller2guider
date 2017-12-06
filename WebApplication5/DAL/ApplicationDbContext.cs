using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication5.Models;
using System.Data.Entity;

namespace WebApplication5.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<CancellationPolicy> CancellationPolicies { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Guider> Guiders { get; set; }
        public DbSet<GuiderLanguageSkill> GuiderLanguageSkills { get; set; }
        public DbSet<GuiderToTravellerBan> GuiderToTravellerBans { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<TravellerToGuiderFavourite> TravellerToGuiderFavourites { get; set; }
        public DbSet<TravellerToGuiderRate> TravellerToGuiderRates { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UnavailableDate> UnavailableDates { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}