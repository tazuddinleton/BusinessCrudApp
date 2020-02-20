using BCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Persistence.Configurations
{
    public class TradeLevelConfigurations : IEntityTypeConfiguration<TradeLevel>
    {
        public void Configure(EntityTypeBuilder<TradeLevel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasField("_id");
            builder.Property(c => c.Title).HasField("_title")
                .IsRequired();          
            
        }
    }
}
