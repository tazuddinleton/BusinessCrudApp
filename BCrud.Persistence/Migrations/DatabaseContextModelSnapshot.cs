﻿// <auto-generated />
using System;
using BCrud.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BCrud.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BCrud.Domain.Entities.Syllabus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DevelopmentOfficer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SyllabusUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestPlanUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TradeLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.HasIndex("TradeLevelId");

                    b.ToTable("Syllabi");
                });

            modelBuilder.Entity("BCrud.Domain.Entities.Trade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("BCrud.Domain.Entities.TradeLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TradeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.ToTable("TradeLevels");
                });

            modelBuilder.Entity("BCrud.Domain.Entities.Syllabus", b =>
                {
                    b.HasOne("BCrud.Domain.Entities.Trade", "Trade")
                        .WithMany()
                        .HasForeignKey("TradeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BCrud.Domain.Entities.TradeLevel", "TradeLevel")
                        .WithMany()
                        .HasForeignKey("TradeLevelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BCrud.Domain.Entities.TradeLevel", b =>
                {
                    b.HasOne("BCrud.Domain.Entities.Trade", null)
                        .WithMany("TradeLevels")
                        .HasForeignKey("TradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
