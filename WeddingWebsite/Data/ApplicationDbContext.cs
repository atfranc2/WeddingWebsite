using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Models;
using WeddingWebsite.Dtos;

namespace WeddingWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Couple> Couples { get; set; }
        public DbSet<SpecialtyDrinkModel> DrinkSpecials { get; set; }

        public DbSet<SongRequest> SongRequests { get; set; }

        public DbSet<DrinkRequest> DrinkRequests { get; set; }

        public DbSet<RSVP> RSVPs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



    }
}
