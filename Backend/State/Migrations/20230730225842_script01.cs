using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace State.Migrations
{
    /// <inheritdoc />
    public partial class script01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Building_type = table.Column<string>(type: "text", nullable: false),
                    Latest_price_eur = table.Column<int>(type: "integer", nullable: false),
                    Surface_area_m2 = table.Column<int>(type: "integer", nullable: false),
                    Rooms_count = table.Column<int>(type: "integer", nullable: false),
                    Bedrooms_count = table.Column<int>(type: "integer", nullable: false),
                    Contact_phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street_address = table.Column<string>(type: "text", nullable: false),
                    Postal_code = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    ListingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostalAddress_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostalAddress_ListingId",
                table: "PostalAddress",
                column: "ListingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostalAddress");

            migrationBuilder.DropTable(
                name: "Listing");
        }
    }
}
