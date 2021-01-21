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
        public DbSet<MyBooks> MyBooks { get; set; }
        public DbSet<MyBookDetails> MyBookDetails { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
       
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SellApplication> SellApplication { get; set; }
        public DbSet<SellApplicationDetails> SellApplicationDetails { get; set; }
        public DbSet<RentApplication> RentApplication { get; set; }
        public DbSet<RentApplicationDetails> RentApplicationDetails { get; set; }

        public DbSet<RentOrder> RentOrder { get; set; }
        public DbSet<RentOrderDetails> RentOrderDetails { get; set; }
        public DbSet<Requests> Requests { get; set; }




    }
}
