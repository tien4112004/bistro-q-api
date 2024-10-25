using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ZoneId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    Unit = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiscountPrice = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProductId);
                    table.ForeignKey(
                        name: "Product_ibfk_1",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    SeatsCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TableId);
                    table.ForeignKey(
                        name: "Table_ibfk_1",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "ZoneId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "NutritionFact",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProductId);
                    table.ForeignKey(
                        name: "NutritionFact_ibfk_1",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalAmount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderId);
                    table.ForeignKey(
                        name: "Order_ibfk_1",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "TableId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    PriceAtPurchase = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "OrderDetail_ibfk_1",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "OrderDetail_ibfk_2",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "TableId",
                table: "Order",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "ZoneId",
                table: "Table",
                column: "ZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionFact");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
