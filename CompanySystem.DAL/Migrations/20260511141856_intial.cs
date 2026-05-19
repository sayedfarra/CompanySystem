using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanySystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronics", null },
                    { 2, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clothes", null },
                    { 3, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books", null },
                    { 4, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home Appliances", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "CreatedAt", "Description", "ExpiryDate", "ImagePath", "Price", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 5, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Laptop", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15000m, "Laptop", null },
                    { 2, 1, 20, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wireless Headphones", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 500m, "Headphones", null },
                    { 3, 1, 10, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Android Phone", new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8000m, "Smartphone", null },
                    { 4, 2, 50, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cotton T-Shirt", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200m, "T-Shirt", null },
                    { 5, 2, 25, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Jeans", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 600m, "Jeans", null },
                    { 6, 3, 15, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn C#", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 300m, "C# Book", null },
                    { 7, 3, 10, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Structures", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 400m, "Algorithms Book", null },
                    { 8, 4, 7, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "800W Microwave", new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2500m, "Microwave", null },
                    { 9, 4, 3, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Double Door", new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12000m, "Refrigerator", null },
                    { 10, 4, 4, new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automatic", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9000m, "Washing Machine", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
