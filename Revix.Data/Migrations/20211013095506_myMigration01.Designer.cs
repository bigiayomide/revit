// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Revix.Data;

namespace Revix.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211013095506_myMigration01")]
    partial class myMigration01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Revix.Models.CryptoListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedPrice")
                        .HasColumnType("TEXT");

                    b.Property<double>("MarketCap")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumMarketPairs")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalSupply")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CryptoListings");
                });
#pragma warning restore 612, 618
        }
    }
}
