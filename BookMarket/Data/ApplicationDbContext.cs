using System;
using System.Collections.Generic;
using System.Text;
using BookMarket.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<TagNames> TagNames { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
       
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SellApplications> SellApplications { get; set; }

        public DbSet<RentApplications> RentApplications { get; set; }


    }
}
