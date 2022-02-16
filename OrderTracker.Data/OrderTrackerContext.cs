using Microsoft.EntityFrameworkCore;

using OrderTracker.Model;

using System;
using System.Diagnostics.CodeAnalysis;

namespace OrderTracker.Data {
    public class OrderTrackerContext : DbContext {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }



        public OrderTrackerContext([NotNullAttribute] DbContextOptions options) : base(options) {

        }


        // you can use this method here to setup contraints on your model properties.
        // try go google fluent api and figure out how we can set each model's id to be unique
        protected override void OnModelCreating(ModelBuilder modelBuilder) {


        }
    }
}