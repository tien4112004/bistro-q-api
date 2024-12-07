using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HopeThisIsTheLastMigration : Migration
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
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentType = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ImageId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    Unit = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiscountPrice = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProductId);
                    table.ForeignKey(
                        name: "Product_ibfk_1",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Product_ibfk_2",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.SetNull);
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PeopleCount = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderId);
                    table.ForeignKey(
                        name: "Order_ibfk_1",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TableId = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "Table_ibfk_2",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PriceAtPurchase = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "OrderItem_ibfk_1",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "OrderItem_ibfk_2",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Dry" },
                    { 2, "Broth-based" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ContentType", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "image/jpeg", "bun-bo-hue.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "image/jpeg", "pho.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "image/jpeg", "banh-mi.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "image/jpeg", "banh-xeo.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "image/jpeg", "banh-canh.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "image/jpeg", "banh-cuon.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "image/jpeg", "com-chien.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "image/jpeg", "bun-rieu.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "image/jpeg", "bun-thit-nuong.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "image/jpeg", "mi-xao.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "EndTime", "Note", "PeopleCount", "StartTime", "Status", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "4", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 30000m },
                    { "5", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 50000m },
                    { "6", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 45000m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Kitchen", "KITCHEN" },
                    { "3", null, "Cashier", "CASHIER" },
                    { "4", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TableId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "3a86419d-d2a4-4012-84d7-a09dbc110f10", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEFHkKz3ucjpyWKGU7TGx6wCKkuYSU8kRuEBIq80nHE9R2kAkTL8PxF/KHmOal3GzuQ==", null, false, null, null, "20b08de9-bbb0-47d1-b033-2b7d4e125a20", null, false, "admin" },
                    { "2", 0, "cb6c95b6-e943-4cdc-9d10-ea03ef580b86", "kitchen@gmail.com", false, false, null, "KITCHEN@GMAIL.COM", "KITCHEN", "AQAAAAIAAYagAAAAELBSynuR2bo+H5qdQEq6AlPxDOmD4YAPzespEPpr19ANiuXCdxt7p1H0DURMTnrM6Q==", null, false, null, null, "c2005e51-aa99-4f5a-86ab-e011123a28d5", null, false, "kitchen" },
                    { "3", 0, "4d3273a5-7393-426c-bd44-a2c36d1d7e71", "cashier@gmail.com", false, false, null, "CASHIER@GMAIL.COM", "CASHIER", "AQAAAAIAAYagAAAAECoS4gDLfm7YqgXkpIOvjoFdu/Ff35ImhamoXArX+FdjcSil/7GIN1OsNU2YKDqkQg==", null, false, null, null, "acd6cda1-eaaa-42a6-be5e-79cde24a2275", null, false, "cashier" }
                });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "ZoneId", "Name" },
                values: new object[,]
                {
                    { 1, "Inside" },
                    { 2, "Backyard" },
                    { 3, "Outside" },
                    { 4, "VIP" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "DiscountPrice", "ImageId", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, 2, 0m, new Guid("00000000-0000-0000-0000-000000000001"), "Bun Bo Hue", 50000m, "Bowl" },
                    { 2, 2, 0m, new Guid("00000000-0000-0000-0000-000000000002"), "Pho", 50000m, "Bowl" },
                    { 3, 1, 0m, new Guid("00000000-0000-0000-0000-000000000003"), "Banh Mi", 25000m, "Piece" },
                    { 4, 1, 0m, new Guid("00000000-0000-0000-0000-000000000004"), "Banh Xeo", 35000m, "Piece" },
                    { 5, 2, 0m, new Guid("00000000-0000-0000-0000-000000000005"), "Banh Canh", 40000m, "Bowl" },
                    { 6, 1, 0m, new Guid("00000000-0000-0000-0000-000000000006"), "Banh Cuon", 30000m, "Plate" },
                    { 7, 1, 0m, new Guid("00000000-0000-0000-0000-000000000007"), "Com Chien", 25000m, "Plate" },
                    { 8, 2, 0m, new Guid("00000000-0000-0000-0000-000000000008"), "Bun Rieu", 45000m, "Bowl" },
                    { 9, 2, 0m, new Guid("00000000-0000-0000-0000-000000000009"), "Bun Thit Nuong", 40000m, "Bowl" },
                    { 10, 1, 0m, new Guid("00000000-0000-0000-0000-000000000010"), "Mi Xao", 45000m, "Plate" }
                });

            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "TableId", "Number", "SeatsCount", "ZoneId" },
                values: new object[,]
                {
                    { 1, 1, 4, 1 },
                    { 2, 2, 4, 1 },
                    { 3, 3, 8, 1 },
                    { 4, 4, 6, 1 },
                    { 5, 1, 2, 2 },
                    { 6, 2, 2, 2 },
                    { 7, 3, 3, 2 },
                    { 8, 4, 3, 2 },
                    { 9, 1, 3, 3 },
                    { 10, 2, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "EndTime", "Note", "PeopleCount", "StartTime", "Status", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "1", null, null, 5, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4384), 0, 1, 490000m },
                    { "2", null, null, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4508), 0, 6, 265000m },
                    { "3", null, null, 4, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4527), 0, 2, 115000m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "CreatedAt", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "401", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4367), "4", 30000m, 6, 1, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4368) },
                    { "501", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4372), "5", 25000m, 7, 2, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4373) },
                    { "601", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4379), "6", 45000m, 8, 1, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4379) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TableId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10", 0, "5eba2a7b-8899-42c8-adff-56d00a079857", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAEMKpFFxXuajM2z1gxbJBYhzmIt2zILKvyEa/TZ4nD3Kg6HbZe04XZxtZp7105EJAwQ==", null, false, null, null, "1f0b604b-93de-45c9-9462-e6295ba942bc", 7, false, "client7" },
                    { "11", 0, "8a6a3c1d-419f-4c70-bb42-330148e1abc0", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAEOxOuFez7va+AvbHhbLv8If37+CxQqKzO0Yy5cc4lGj+Wk+NHoJEgj5xh7Tw6LEPvQ==", null, false, null, null, "f7d3511b-a28a-4be4-85e9-e9d70fa13118", 8, false, "client8" },
                    { "12", 0, "db2d8507-aa63-42aa-9b9b-6492fb7df34a", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEL2W/jyYmI3uW+rABY4m9mDEVkdax58pp5E1dHwedeD17/01lTyntn2zE+lcQB116w==", null, false, null, null, "26992a25-177f-48b2-a9d4-7d4209669785", 9, false, "client9" },
                    { "13", 0, "8df287d4-1c15-4877-8b40-db8af0b12b5a", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEIlSMIxuiMEDMX2eF1F0Q55LRmq6I8kpABq7gNS26GvorfmxrPbclRTXVG3JU8oPPg==", null, false, null, null, "a0ef6fff-25f8-4884-8074-90b84503317a", 10, false, "client10" },
                    { "4", 0, "4a8faa59-3eee-4e05-aa1d-86bad8d073fe", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAEKV7UV8XjHuvUSAtHz/JV0SxVvRayqNkDIO0NIwbQrk9c3dMtD01NaMWNPf7APNKmA==", null, false, null, null, "ae2a3db0-35d0-4a03-8117-bd019373bbcc", 1, false, "client1" },
                    { "5", 0, "3bc69e7b-dc45-480b-b44a-a678eb7711dc", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEOTSRuiDFaUiJWrUPXCAajaheZsRSw2bGJTUBE01BXCHxMJVInNY/DFr/QwN40A8JA==", null, false, null, null, "67f51de4-42c6-4a4c-a758-ca81dba5f80c", 2, false, "client2" },
                    { "6", 0, "b99d456d-fa84-4988-8bdf-02674109936e", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEPlKtAvbdApC0ld8O5jJwwM8LdWWS+Na+C7zKnP/qAXxZ0iysw41W2N7hsHXIHYkbw==", null, false, null, null, "a179cfaf-3d66-4385-bb76-e880c1ffb6c0", 3, false, "client3" },
                    { "7", 0, "28da7344-ddcb-4aec-8140-951f795c46dd", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAEOXYZcCa79nJdAkK1l5yNb/h/D/VhNUMTAw0gLu0mxgjXhJ5puzl8f3P9Fpv0WL3UA==", null, false, null, null, "d1f46438-4cd0-4d3e-96bd-d50efcb3f57a", 4, false, "client4" },
                    { "8", 0, "880bbf17-841b-43c3-8233-3262a01ef7cf", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAEEFJIUpGEFvcQwjux4LLM2QYO70KOnlavQNiQiry1asc2NrKJWDDSQ7SAHzUvSD7og==", null, false, null, null, "2e260389-7df6-436d-84e5-aae21062bbfb", 5, false, "client5" },
                    { "9", 0, "1c32b882-2a9b-4343-9192-c94dc33f45ef", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAEENdnRvm8YXzAQ7X1tExdhmgsdRUiSz4bgcDq92ibyXfvzulCgCwfQHBt80AJm1ZsA==", null, false, null, null, "6e3b2241-032d-4e29-8726-f26e3a6780b6", 6, false, "client6" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "CreatedAt", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "101", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4171), "1", 50000m, 1, 2, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4178) },
                    { "102", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4184), "1", 50000m, 2, 1, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4185) },
                    { "103", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4189), "1", 25000m, 3, 1, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4189) },
                    { "104", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4194), "1", 35000m, 4, 2, 0, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4195) },
                    { "105", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4200), "1", 40000m, 5, 1, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4200) },
                    { "106", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4205), "1", 30000m, 6, 3, 0, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4205) },
                    { "107", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4209), "1", 25000m, 7, 1, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4209) },
                    { "108", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4216), "1", 45000m, 8, 2, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4216) },
                    { "201", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4220), "2", 25000m, 3, 3, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4221) },
                    { "202", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4227), "2", 35000m, 4, 2, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4227) },
                    { "203", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4319), "2", 40000m, 5, 1, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4320) },
                    { "204", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4325), "2", 30000m, 6, 1, 0, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4326) },
                    { "205", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4331), "2", 25000m, 7, 2, 0, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4331) },
                    { "301", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4335), "3", 35000m, 4, 1, 1, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4336) },
                    { "302", new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4341), "3", 40000m, 5, 2, 2, new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4353) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4", "10" },
                    { "4", "11" },
                    { "4", "12" },
                    { "4", "13" },
                    { "4", "4" },
                    { "4", "5" },
                    { "4", "6" },
                    { "4", "7" },
                    { "4", "8" },
                    { "4", "9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_TableId",
                table: "Order",
                column: "TableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TableId",
                table: "Order",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImageId",
                table: "Product",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ZoneId",
                table: "Table",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TableId",
                table: "Users",
                column: "TableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionFact");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
