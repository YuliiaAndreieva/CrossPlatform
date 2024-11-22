using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerProfile",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfile", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RefPreferenceFactor",
                columns: table => new
                {
                    FactorCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefPreferenceFactor", x => x.FactorCode);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLoyalty",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateFirstPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherLoyaltyDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLoyalty", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerLoyalty_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdMember",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MemberCount = table.Column<int>(type: "int", nullable: false),
                    CountOfChildren = table.Column<int>(type: "int", nullable: false),
                    CountOfWageEarners = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdMember", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_HouseholdMember_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPreference",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FactorCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreference", x => new { x.CustomerId, x.FactorCode });
                    table.ForeignKey(
                        name: "FK_CustomerPreference_CustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerProfile",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPreference_RefPreferenceFactor_FactorCode",
                        column: x => x.FactorCode,
                        principalTable: "RefPreferenceFactor",
                        principalColumn: "FactorCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreference_FactorCode",
                table: "CustomerPreference",
                column: "FactorCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLoyalty");

            migrationBuilder.DropTable(
                name: "CustomerPreference");

            migrationBuilder.DropTable(
                name: "HouseholdMember");

            migrationBuilder.DropTable(
                name: "RefPreferenceFactor");

            migrationBuilder.DropTable(
                name: "CustomerProfile");
        }
    }
}
