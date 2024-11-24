﻿// <auto-generated />
using System;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.SqlServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241123223132_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.ContactHistory", b =>
                {
                    b.Property<int>("ContactHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactHistoryId"));

                    b.Property<DateTime>("ContactDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OutcomeStatusCode")
                        .HasColumnType("int");

                    b.HasKey("ContactHistoryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OutcomeStatusCode");

                    b.ToTable("ContactHistories");
                });

            modelBuilder.Entity("App.Models.CustomerAsset", b =>
                {
                    b.Property<int>("CustomerAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerAssetId"));

                    b.Property<int>("AssetTypeCode")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssetAcquired")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerAssetId");

                    b.HasIndex("AssetTypeCode");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAssets");
                });

            modelBuilder.Entity("App.Models.CustomerLoyalty", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFirstPurchase")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherLoyaltyDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerLoyalties");
                });

            modelBuilder.Entity("App.Models.CustomerOffer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialOfferId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfferAccepted")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId", "SpecialOfferId");

                    b.HasIndex("SpecialOfferId");

                    b.ToTable("CustomerOffers");
                });

            modelBuilder.Entity("App.Models.CustomerPreference", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FactorCode")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "FactorCode");

                    b.HasIndex("FactorCode");

                    b.ToTable("CustomerPreferences");
                });

            modelBuilder.Entity("App.Models.CustomerProductHolding", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAcquired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDiscontinued")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerProductHoldings");
                });

            modelBuilder.Entity("App.Models.CustomerProfile", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerProfiles");
                });

            modelBuilder.Entity("App.Models.HouseholdMember", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CountOfChildren")
                        .HasColumnType("int");

                    b.Property<int>("CountOfWageEarners")
                        .HasColumnType("int");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("HouseholdMembers");
                });

            modelBuilder.Entity("App.Models.RefAssetType", b =>
                {
                    b.Property<int>("AssetTypeCode")
                        .HasColumnType("int");

                    b.Property<string>("AssetTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetTypeCode");

                    b.ToTable("RefAssetTypes");
                });

            modelBuilder.Entity("App.Models.RefContactOutcome", b =>
                {
                    b.Property<int>("OutcomeStatusCode")
                        .HasColumnType("int");

                    b.Property<string>("OutcomeStatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OutcomeStatusCode");

                    b.ToTable("RefContactOutcomes");
                });

            modelBuilder.Entity("App.Models.RefPreferenceFactor", b =>
                {
                    b.Property<int>("FactorCode")
                        .HasColumnType("int");

                    b.Property<string>("FactorDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FactorCode");

                    b.ToTable("RefPreferenceFactors");
                });

            modelBuilder.Entity("App.Models.ServiceAndProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("ServicesAndProducts");
                });

            modelBuilder.Entity("App.Models.SpecialOffer", b =>
                {
                    b.Property<int>("SpecialOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialOfferId"));

                    b.Property<string>("SpecialOfferDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialOfferId");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("App.Models.ContactHistory", b =>
                {
                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("ContactHistories")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.RefContactOutcome", "RefContactOutcome")
                        .WithMany("ContactHistories")
                        .HasForeignKey("OutcomeStatusCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RefContactOutcome");
                });

            modelBuilder.Entity("App.Models.CustomerAsset", b =>
                {
                    b.HasOne("App.Models.RefAssetType", "RefAssetType")
                        .WithMany("CustomerAssets")
                        .HasForeignKey("AssetTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("CustomerAssets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RefAssetType");
                });

            modelBuilder.Entity("App.Models.CustomerLoyalty", b =>
                {
                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("CustomerLoyalties")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("App.Models.CustomerOffer", b =>
                {
                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("CustomerOffers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.SpecialOffer", "SpecialOffer")
                        .WithMany("CustomerOffers")
                        .HasForeignKey("SpecialOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SpecialOffer");
                });

            modelBuilder.Entity("App.Models.CustomerPreference", b =>
                {
                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("CustomerPreferences")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.RefPreferenceFactor", "RefPreferenceFactor")
                        .WithMany("CustomerPreferences")
                        .HasForeignKey("FactorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RefPreferenceFactor");
                });

            modelBuilder.Entity("App.Models.CustomerProductHolding", b =>
                {
                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("CustomerProductHoldings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.ServiceAndProduct", "ServiceAndProduct")
                        .WithMany("CustomerProductHoldings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ServiceAndProduct");
                });

            modelBuilder.Entity("App.Models.HouseholdMember", b =>
                {
                    b.HasOne("App.Models.CustomerProfile", "Customer")
                        .WithMany("HouseholdMembers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("App.Models.CustomerProfile", b =>
                {
                    b.Navigation("ContactHistories");

                    b.Navigation("CustomerAssets");

                    b.Navigation("CustomerLoyalties");

                    b.Navigation("CustomerOffers");

                    b.Navigation("CustomerPreferences");

                    b.Navigation("CustomerProductHoldings");

                    b.Navigation("HouseholdMembers");
                });

            modelBuilder.Entity("App.Models.RefAssetType", b =>
                {
                    b.Navigation("CustomerAssets");
                });

            modelBuilder.Entity("App.Models.RefContactOutcome", b =>
                {
                    b.Navigation("ContactHistories");
                });

            modelBuilder.Entity("App.Models.RefPreferenceFactor", b =>
                {
                    b.Navigation("CustomerPreferences");
                });

            modelBuilder.Entity("App.Models.ServiceAndProduct", b =>
                {
                    b.Navigation("CustomerProductHoldings");
                });

            modelBuilder.Entity("App.Models.SpecialOffer", b =>
                {
                    b.Navigation("CustomerOffers");
                });
#pragma warning restore 612, 618
        }
    }
}