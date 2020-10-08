using J41564_CO6029_Assignment2.api.Classes;
using J41564_CO6029_Assignment2.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.DatabaseModel

{
    public class Database : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderLine> Orderlines { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Database(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Address>().HasKey(x => x.Id);
            modelBuilder.Entity<Address>().ToTable("Addresses");

            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<OrderLine>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderLine>().ToTable("Orderlines");

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().ToTable("Products");

        }

        

    }
}
