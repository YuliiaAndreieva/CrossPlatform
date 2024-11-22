using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetTypes",
                columns: table => new
                {
                    AssetTypeCode = table.Column<int>(type: "int", nullable: false),
                    AssetTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetTypes", x => x.AssetTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefContactOutcomes",
                columns: table => new
                {
                    OutcomeStatusCode = table.Column<int>(type: "int", nullable: false),
                    OutcomeStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefContactOutcomes", x => x.OutcomeStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "RefPreferenceFactors",
                columns: table => new
                {
                    FactorCode = table.Column<int>(type: "int", nullable: false),
                    FactorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefPreferenceFactors", x => x.FactorCode);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAndProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAndProducts", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialOfferDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.SpecialOfferId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLoyalties",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateFirstPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherLoyaltyDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLoyalties", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerLoyalties_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdMembers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MemberCount = table.Column<int>(type: "int", nullable: false),
                    CountOfChildren = table.Column<int>(type: "int", nullable: false),
                    CountOfWageEarners = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdMembers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_HouseholdMembers_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAssets",
                columns: table => new
                {
                    CustomerAssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AssetTypeCode = table.Column<int>(type: "int", nullable: false),
                    DateAssetAcquired = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAssets", x => x.CustomerAssetId);
                    table.ForeignKey(
                        name: "FK_CustomerAssets_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAssets_RefAssetTypes_AssetTypeCode",
                        column: x => x.AssetTypeCode,
                        principalTable: "RefAssetTypes",
                        principalColumn: "AssetTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactHistories",
                columns: table => new
                {
                    ContactHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OutcomeStatusCode = table.Column<int>(type: "int", nullable: false),
                    ContactDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactHistories", x => x.ContactHistoryId);
                    table.ForeignKey(
                        name: "FK_ContactHistories_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactHistories_RefContactOutcomes_OutcomeStatusCode",
                        column: x => x.OutcomeStatusCode,
                        principalTable: "RefContactOutcomes",
                        principalColumn: "OutcomeStatusCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPreferences",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FactorCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreferences", x => new { x.CustomerId, x.FactorCode });
                    table.ForeignKey(
                        name: "FK_CustomerPreferences_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPreferences_RefPreferenceFactors_FactorCode",
                        column: x => x.FactorCode,
                        principalTable: "RefPreferenceFactors",
                        principalColumn: "FactorCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProductHoldings",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDiscontinued = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductHoldings", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CustomerProductHoldings_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProductHoldings_ServicesAndProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ServicesAndProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOffers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false),
                    DateOfferAccepted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOffers", x => new { x.CustomerId, x.SpecialOfferId });
                    table.ForeignKey(
                        name: "FK_CustomerOffers_CustomerProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOffers_SpecialOffers_SpecialOfferId",
                        column: x => x.SpecialOfferId,
                        principalTable: "SpecialOffers",
                        principalColumn: "SpecialOfferId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistories_CustomerId",
                table: "ContactHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistories_OutcomeStatusCode",
                table: "ContactHistories",
                column: "OutcomeStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAssets_AssetTypeCode",
                table: "CustomerAssets",
                column: "AssetTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAssets_CustomerId",
                table: "CustomerAssets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOffers_SpecialOfferId",
                table: "CustomerOffers",
                column: "SpecialOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_FactorCode",
                table: "CustomerPreferences",
                column: "FactorCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProductHoldings_ProductId",
                table: "CustomerProductHoldings",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactHistories");

            migrationBuilder.DropTable(
                name: "CustomerAssets");

            migrationBuilder.DropTable(
                name: "CustomerLoyalties");

            migrationBuilder.DropTable(
                name: "CustomerOffers");

            migrationBuilder.DropTable(
                name: "CustomerPreferences");

            migrationBuilder.DropTable(
                name: "CustomerProductHoldings");

            migrationBuilder.DropTable(
                name: "HouseholdMembers");

            migrationBuilder.DropTable(
                name: "RefContactOutcomes");

            migrationBuilder.DropTable(
                name: "RefAssetTypes");

            migrationBuilder.DropTable(
                name: "SpecialOffers");

            migrationBuilder.DropTable(
                name: "RefPreferenceFactors");

            migrationBuilder.DropTable(
                name: "ServicesAndProducts");

            migrationBuilder.DropTable(
                name: "CustomerProfiles");
        }
    }
}
