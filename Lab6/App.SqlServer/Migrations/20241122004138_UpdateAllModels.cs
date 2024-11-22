using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefAssetType",
                columns: table => new
                {
                    AssetTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetType", x => x.AssetTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefContactOutcome",
                columns: table => new
                {
                    OutcomeStatusCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutcomeStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefContactOutcome", x => x.OutcomeStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAndProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAndProduct", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                columns: table => new
                {
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialOfferDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.SpecialOfferId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAsset",
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
                    table.PrimaryKey("PK_CustomerAsset", x => x.CustomerAssetId);
                    table.ForeignKey(
                        name: "FK_CustomerAsset_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAsset_RefAssetType_AssetTypeCode",
                        column: x => x.AssetTypeCode,
                        principalTable: "RefAssetType",
                        principalColumn: "AssetTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactHistory",
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
                    table.PrimaryKey("PK_ContactHistory", x => x.ContactHistoryId);
                    table.ForeignKey(
                        name: "FK_ContactHistory_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactHistory_RefContactOutcome_OutcomeStatusCode",
                        column: x => x.OutcomeStatusCode,
                        principalTable: "RefContactOutcome",
                        principalColumn: "OutcomeStatusCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProductHolding",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDiscontinued = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductHolding", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CustomerProductHolding_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProductHolding_ServiceAndProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ServiceAndProduct",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOffer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferId = table.Column<int>(type: "int", nullable: false),
                    DateOfferAccepted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOffer", x => new { x.CustomerId, x.SpecialOfferId });
                    table.ForeignKey(
                        name: "FK_CustomerOffer_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOffer_SpecialOffer_SpecialOfferId",
                        column: x => x.SpecialOfferId,
                        principalTable: "SpecialOffer",
                        principalColumn: "SpecialOfferId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistory_CustomerId",
                table: "ContactHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactHistory_OutcomeStatusCode",
                table: "ContactHistory",
                column: "OutcomeStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAsset_AssetTypeCode",
                table: "CustomerAsset",
                column: "AssetTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAsset_CustomerId",
                table: "CustomerAsset",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOffer_SpecialOfferId",
                table: "CustomerOffer",
                column: "SpecialOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProductHolding_ProductId",
                table: "CustomerProductHolding",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactHistory");

            migrationBuilder.DropTable(
                name: "CustomerAsset");

            migrationBuilder.DropTable(
                name: "CustomerOffer");

            migrationBuilder.DropTable(
                name: "CustomerProductHolding");

            migrationBuilder.DropTable(
                name: "RefContactOutcome");

            migrationBuilder.DropTable(
                name: "RefAssetType");

            migrationBuilder.DropTable(
                name: "SpecialOffer");

            migrationBuilder.DropTable(
                name: "ServiceAndProduct");
        }
    }
}
