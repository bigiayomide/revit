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
    [Migration("20211013125204_myMigration02")]
    partial class myMigration02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Revix.Data.Entities.CryptoListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CoinDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedPrice")
                        .HasColumnType("TEXT");

                    b.Property<long>("MarketCap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long>("NumMarketPairs")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<long>("TotalSupply")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CryptoListings");
                });
#pragma warning restore 612, 618
        }
    }
}
