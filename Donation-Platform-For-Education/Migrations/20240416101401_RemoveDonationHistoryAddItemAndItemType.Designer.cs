﻿// <auto-generated />
using System;
using Donation_Platform_For_Education.Infarstructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Donation_Platform_For_Education.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240416101401_RemoveDonationHistoryAddItemAndItemType")]
    partial class RemoveDonationHistoryAddItemAndItemType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Donation_Platform_For_Education.Domain.Entity.AdminDomain.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("Donation_Platform_For_Education.Domain.Entity.DonorDomain.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("donors");
                });

            modelBuilder.Entity("Donation_Platform_For_Education.Domain.Entity.ItemDomain.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DonationHistory")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("itemTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("itemTypeId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain.ItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("itemTypes");
                });

            modelBuilder.Entity("Donation_Platform_For_Education.Domain.Entity.AdminDomain.Admin", b =>
                {
                    b.OwnsOne("Donation_Platform_For_Education.Domain.Entity.AdminDomain.AdminContactInfo", "contactInfo", b1 =>
                        {
                            b1.Property<Guid>("AdminId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("phoneNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AdminId");

                            b1.ToTable("admins");

                            b1.WithOwner()
                                .HasForeignKey("AdminId");
                        });

                    b.Navigation("contactInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("Donation_Platform_For_Education.Domain.Entity.ItemDomain.Item", b =>
                {
                    b.HasOne("Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain.ItemType", "type")
                        .WithMany()
                        .HasForeignKey("itemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("type");
                });
#pragma warning restore 612, 618
        }
    }
}
