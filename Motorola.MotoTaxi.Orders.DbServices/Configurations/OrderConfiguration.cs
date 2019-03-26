using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Orders.DbServices.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Fluent Api
            builder.OwnsOne(p => p.Start);
            builder.OwnsOne(p => p.Destination);
            builder.HasKey(p => p.Id);
        }
    }
}
