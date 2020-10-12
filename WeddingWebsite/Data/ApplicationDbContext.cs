using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeddingWebsite.Models;

namespace WeddingWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


    }
}
