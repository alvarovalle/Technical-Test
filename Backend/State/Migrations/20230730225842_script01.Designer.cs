﻿// <auto-generated />
using System;
using Backend.State.Listing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace State.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230730225842_script01")]
    partial class script01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.State.Listing.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Bedrooms_count")
                        .HasColumnType("integer");

                    b.Property<string>("Building_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contact_phone_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Latest_price_eur")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rooms_count")
                        .HasColumnType("integer");

                    b.Property<int>("Surface_area_m2")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Listing");
                });

            modelBuilder.Entity("Backend.State.Listing.PostalAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ListingId")
                        .HasColumnType("integer");

                    b.Property<string>("Postal_code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street_address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ListingId")
                        .IsUnique();

                    b.ToTable("PostalAddress");
                });

            modelBuilder.Entity("Backend.State.Listing.PostalAddress", b =>
                {
                    b.HasOne("Backend.State.Listing.Listing", null)
                        .WithOne("PostalAddress")
                        .HasForeignKey("Backend.State.Listing.PostalAddress", "ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.State.Listing.Listing", b =>
                {
                    b.Navigation("PostalAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}