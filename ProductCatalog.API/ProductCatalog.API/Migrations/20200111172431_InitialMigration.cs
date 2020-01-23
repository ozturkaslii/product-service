using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "LastUpdated", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, "C1476", new DateTimeOffset(new DateTime(2020, 1, 11, 20, 24, 31, 473, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, 3, 0, 0, 0)), "Havana Light Grey Jacket", null, 399.0m },
                    { 2, "P5752", new DateTimeOffset(new DateTime(2020, 1, 11, 20, 24, 31, 476, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 3, 0, 0, 0)), "Lezio Mid Blue Check Suit", null, 359.0m },
                    { 3, "J461LB", new DateTimeOffset(new DateTime(2020, 1, 11, 20, 24, 31, 476, DateTimeKind.Unspecified).AddTicks(401), new TimeSpan(0, 3, 0, 0, 0)), "Navy Overcoat", null, 499.0m },
                    { 4, "H6049", new DateTimeOffset(new DateTime(2020, 1, 11, 20, 24, 31, 476, DateTimeKind.Unspecified).AddTicks(405), new TimeSpan(0, 3, 0, 0, 0)), "Light Blue Stripe Shirt", null, 99.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
