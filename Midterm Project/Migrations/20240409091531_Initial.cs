using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Midterm_Project.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 9, 9, 15, 31, 434, DateTimeKind.Utc).AddTicks(9922), "Electronic devices", "Electronics" },
                    { 2, new DateTime(2024, 4, 9, 9, 15, 31, 434, DateTimeKind.Utc).AddTicks(9924), "Clothing items", "Clothing" },
                    { 3, new DateTime(2024, 4, 9, 9, 15, 31, 434, DateTimeKind.Utc).AddTicks(9926), "Books and literature", "Books" },
                    { 4, new DateTime(2024, 4, 9, 9, 15, 31, 434, DateTimeKind.Utc).AddTicks(9927), "Household appliances", "Home Appliances" },
                    { 5, new DateTime(2024, 4, 9, 9, 15, 31, 434, DateTimeKind.Utc).AddTicks(9929), "Furniture items", "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", "John Doe", "john@example.com", "ABC Electronics", "123456789" },
                    { 2, "456 Elm St", "Jane Smith", "jane@example.com", "XYZ Clothing", "987654321" },
                    { 3, "789 Oak St", "Alice Johnson", "alice@example.com", "Book World", "456123789" },
                    { 4, "987 Pine St", "Michael Brown", "michael@example.com", "Home Comfort Appliances", "654987321" },
                    { 5, "654 Cedar St", "Emily White", "emily@example.com", "Furniture Palace", "321789654" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "LastUpdated", "Name", "Price", "StockQuantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 9, 9, 15, 31, 435, DateTimeKind.Utc).AddTicks(134), "Latest smartphone model", null, "Smartphone", 499.99m, 100, 1 },
                    { 2, 2, new DateTime(2024, 4, 9, 9, 15, 31, 435, DateTimeKind.Utc).AddTicks(137), "Cotton T-Shirt", null, "T-Shirt", 19.99m, 200, 2 },
                    { 3, 3, new DateTime(2024, 4, 9, 9, 15, 31, 435, DateTimeKind.Utc).AddTicks(138), "Best-selling novel", null, "Novel", 9.99m, 50, 3 },
                    { 4, 4, new DateTime(2024, 4, 9, 9, 15, 31, 435, DateTimeKind.Utc).AddTicks(141), "Large capacity refrigerator", null, "Refrigerator", 799.99m, 20, 4 },
                    { 5, 5, new DateTime(2024, 4, 9, 9, 15, 31, 435, DateTimeKind.Utc).AddTicks(144), "Comfortable sofa set", null, "Sofa", 899.99m, 10, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
