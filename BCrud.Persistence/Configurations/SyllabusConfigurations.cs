using BCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Persistence.Configurations
{
    public class SyllabusConfigurations : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(c => c.Id).HasField("_id");
            builder.Property(c => c.Name).HasField("_name")
                .IsRequired();
            builder.Property(c => c.TradeId).HasField("_tradeId");
            builder.Property(c => c.TradeLevelId).HasField("_tradeLevelId");
            builder.Property(c => c.Languages).HasField("_languages")
                .IsRequired();
            builder.Property(c => c.SyllabusFilename).HasField("_syllabusFilename");
            builder.Property(c => c.SyllabusUrl).HasField("_syllabusUrl");
            builder.Property(c => c.TestPlanFilename).HasField("_testPlanFilename");
            builder.Property(c => c.TestPlanUrl).HasField("_testPlanUrl");
            builder.Property(c => c.DevelopmentOfficer).HasField("_devOfficer")
                .IsRequired();
            builder.Property(c => c.Manager).HasField("_manager")
                .IsRequired();
            builder.Property(c => c.ActiveDate).HasField("_activeDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(c => c.Trade)
                .WithMany()
                .HasForeignKey(c => c.TradeId)
                .OnDelete(DeleteBehavior.NoAction);



            builder.HasOne(c => c.TradeLevel)
                .WithMany()
                .HasForeignKey(c => c.TradeLevelId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
