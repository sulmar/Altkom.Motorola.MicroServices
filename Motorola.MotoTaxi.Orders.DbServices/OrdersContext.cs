using Microsoft.EntityFrameworkCore;
using Motorola.MotoTaxi.Orders.DbServices.Configurations;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;

namespace Motorola.MotoTaxi.Orders.DbServices
{
    // add package Microsoft.EntityFrameworkCore
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }


        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();

            // wylacza sledzenie podczas pobierania obiektow
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Order>().ToTable("Zamowienia");

            //modelBuilder.Entity<Order>().OwnsOne(p => p.Start);
            //modelBuilder.Entity<Order>().OwnsOne(p => p.Destination);

            //modelBuilder.Entity<Order>().HasKey(p => p.Id);

            // modelBuilder.Entity<Order>().Property(p=>p.OrderDate).IsRequired

            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
