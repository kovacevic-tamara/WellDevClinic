﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201228155424_TestData")]
    partial class TestData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.ActionAndBenefit", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageAboutAction")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ActionsAndBenefits");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EndDate = new DateTime(2021, 1, 12, 16, 54, 23, 539, DateTimeKind.Local).AddTicks(8159),
                            MessageAboutAction = "Andol on sale! 50% off!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 18, 16, 54, 23, 535, DateTimeKind.Local).AddTicks(2299),
                            Status = 1
                        },
                        new
                        {
                            Id = 2L,
                            EndDate = new DateTime(2021, 1, 27, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5124),
                            MessageAboutAction = "Cheap bromazepam on huge quantities!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2021, 1, 2, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5087),
                            Status = 0
                        },
                        new
                        {
                            Id = 3L,
                            EndDate = new DateTime(2021, 1, 4, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5224),
                            MessageAboutAction = "Aspirin C for free!!",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2020, 12, 29, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5219),
                            Status = 0
                        },
                        new
                        {
                            Id = 4L,
                            EndDate = new DateTime(2021, 1, 19, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5232),
                            MessageAboutAction = "Amazing deal!! Brufen was 5$, now 15$",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2020, 12, 30, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5229),
                            Status = 2
                        },
                        new
                        {
                            Id = 5L,
                            EndDate = new DateTime(2021, 1, 12, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5240),
                            MessageAboutAction = "Cant miss!! Vitamin C just for 99$",
                            PharmacyName = "PH2",
                            StartDate = new DateTime(2020, 12, 28, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5236),
                            Status = 2
                        },
                        new
                        {
                            Id = 6L,
                            EndDate = new DateTime(2020, 12, 27, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5247),
                            MessageAboutAction = "Cheap sedatives!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 18, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5244),
                            Status = 1
                        });
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Api", b =>
                {
                    b.Property<string>("NameOfPharmacy")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApiKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("NameOfPharmacy");

                    b.ToTable("ApiKeys");

                    b.HasData(
                        new
                        {
                            NameOfPharmacy = "PH1",
                            ApiKey = "4545-as84-8s8g-zXCV",
                            Url = "http://localhost:4200/Ph1"
                        },
                        new
                        {
                            NameOfPharmacy = "PH2",
                            ApiKey = "7788-AV5R-zxQt-5845",
                            Url = "http://localhost:4200/Ph2"
                        },
                        new
                        {
                            NameOfPharmacy = "PH3",
                            ApiKey = "9745-At7S-Aqtr-5q8t",
                            Url = "http://localhost:4200/Ph3"
                        },
                        new
                        {
                            NameOfPharmacy = "PH4",
                            ApiKey = "HgT8-n47E-bE41-2gt5",
                            Url = "http://localhost:4200/Ph4"
                        });
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Medication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("MedicationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("TenderOfferId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.HasIndex("TenderOfferId");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Pharmacy.TenderOffer", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("TenderOffers");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Ingredient", b =>
                {
                    b.HasOne("PSW_Pharmacy_Adapter.Model.Medication", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MedicationId");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Medication", b =>
                {
                    b.HasOne("PSW_Pharmacy_Adapter.Model.Medication", null)
                        .WithMany("Alternative")
                        .HasForeignKey("MedicationId");

                    b.HasOne("PSW_Pharmacy_Adapter.Model.Pharmacy.TenderOffer", null)
                        .WithMany("Medications")
                        .HasForeignKey("TenderOfferId");
                });
#pragma warning restore 612, 618
        }
    }
}
