using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TheNewestMigration : Migration
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
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "OrderDetail_ibfk_2",
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
                columns: new[] { "OrderId", "EndTime", "StartTime", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 100m },
                    { "2", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 200m },
                    { "3", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 300m },
                    { "4", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 400m }
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
                    { "1", 0, "0fae9efa-f49d-4abb-9bfb-56ffd21ece24", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEBJcUz1tbJOwH1BF7or4HGxIomGo+YR6D0kreJSZGW1FnbYfF0CDySKx0jC6fErP1g==", null, false, null, null, "4535f0b5-39f8-4305-9082-91de28f392f6", null, false, "admin" },
                    { "2", 0, "5acafa97-7453-46e0-a82f-432920f60cd7", "kitchen@gmail.com", false, false, null, "KITCHEN@GMAIL.COM", "KITCHEN", "AQAAAAIAAYagAAAAEMF9J7kRglpgU1CT/ew5ToUDvp5pen/sm46CE70ynin8z0q0BNHhCpqwaFq9TS3BBA==", null, false, null, null, "2ecea54b-2161-4be0-b7dc-065aa6cc37f5", null, false, "kitchen" },
                    { "3", 0, "f2b39d72-3a49-4efb-8835-d09438ee70b1", "cashier@gmail.com", false, false, null, "CASHIER@GMAIL.COM", "CASHIER", "AQAAAAIAAYagAAAAEMl3U+yWWOlUnxlolBVl8ssvcnUo4ckzD7hw7h5Zq2wYAKuf1yzJGnbxTNMdYlcFSA==", null, false, null, null, "931fdb90-b526-4b5c-8b64-b7bed3f3dafd", null, false, "cashier" }
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
                columns: new[] { "OrderId", "EndTime", "StartTime", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "5", null, new DateTime(2024, 11, 19, 4, 4, 21, 158, DateTimeKind.Local).AddTicks(5895), 1, 500m },
                    { "6", null, new DateTime(2024, 11, 19, 4, 4, 21, 158, DateTimeKind.Local).AddTicks(5919), 2, 600m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderDetailId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "1", "1", 10m, 1, 2 },
                    { "2", "1", 10m, 2, 1 },
                    { "3", "2", 10m, 3, 3 },
                    { "4", "3", 100m, 4, 1 },
                    { "5", "3", 50m, 5, 2 },
                    { "6", "4", 80m, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TableId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10", 0, "a058ae4c-0fe4-4f13-bbb1-2173ffd2f255", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAEGAUhEKX/ascxhqYFts4IQ8CrDI2tSECf+kfNnA3xjJLLZFB/ia8Ck2dPrPlG6RwQQ==", null, false, null, null, "fd4d079b-7418-4265-aba7-2fd6004e9673", 7, false, "client7" },
                    { "11", 0, "baf37111-b24f-4ebf-9458-f1adb35f0fee", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAEJ22o2db7gbsvMGDMsKOGucIFNk0R9kx5xNRPpwUecqELMiEIStXP/ZvQ7NMqQzTug==", null, false, null, null, "515a8f1a-b137-49e5-99f8-c56cc2a2242d", 8, false, "client8" },
                    { "12", 0, "de1476e8-bf39-4ba9-acf8-bd199b9a4161", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEDTTH39d7p/vM3cVth2qMJM+zlBjixTUigDQms8/6IKMvWbP926xMY+wKO9U0Nqpyw==", null, false, null, null, "31c6f807-3b8d-4fcd-a4ba-98ac00c3d7c9", 9, false, "client9" },
                    { "13", 0, "d019ae99-dec2-40af-836d-34c91d67afff", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEFjqF905qnENNEYT4tGNq7fOoy79SiBZCfmA287feirQplFUOvnh1j5AfZX3NQ6RFw==", null, false, null, null, "fe951268-4c5e-4db0-858d-f8853c32bba1", 10, false, "client10" },
                    { "4", 0, "043b9af3-8a61-4a2d-bea8-8453b2261b1b", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAEFZCIj8WyfCjirLVmBtIKDxe7AFZLkCakp0wZz70hQb/kBG5q6ec7Ht2FfRfY53YRg==", null, false, null, null, "b41a22b0-9820-4a0b-abb3-a763f38507b9", 1, false, "client1" },
                    { "5", 0, "71187aa4-575c-4ea9-be04-dc45f51ff662", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEIh7267DiVTaWx0IfEc+fdX9KAOY4u/h/qiqqF9rPPBviAd0Syw+YT6R+CVzW8FHMQ==", null, false, null, null, "128206c9-178b-4a86-941f-99d37941431d", 2, false, "client2" },
                    { "6", 0, "ea571012-0eab-4db0-91c8-094c79da804c", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEMQtzvEkM/l/qadi3bPSj4hoqnmZ6t70I7ymHzxkQx66gcEqJDvVqNUDnG20N2Oe9g==", null, false, null, null, "320b7417-c012-4f6a-be4c-9f848a62cd93", 3, false, "client3" },
                    { "7", 0, "9cd3a22b-a126-481f-af71-0dc7e5ec3006", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAECfCvp9439Z+b7Kuo1AvmaM0e1wsIjmLJX8yQVa/Hk5aGcIWHVuvg0iZrYQHj8Aaeg==", null, false, null, null, "0af1ac90-96e9-4d6f-8c07-e4d9dfaee9bb", 4, false, "client4" },
                    { "8", 0, "5629a938-9b77-4550-8872-9bf748412c7f", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAEOLj3OygQXflTSzOaVmNcgTPFDGwb6gwOSJtGfxGrc3G8YILG+azQwMS1B6IDS7gkA==", null, false, null, null, "6b495c32-64be-4e95-acf5-30d2349bb311", 5, false, "client5" },
                    { "9", 0, "1d688381-3f94-437b-92c1-46bbe355450c", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAEIDzE5RWY4K0U1xNfzyylrREuqp9thU10BPOObLjdFUa9LxfcK23UWs1Yvd4UZ7Q3w==", null, false, null, null, "35012b35-e188-4e8c-bcf0-09afc7f146e3", 6, false, "client6" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderDetailId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "7", "5", 20m, 7, 2 },
                    { "8", "6", 30m, 8, 1 }
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
                name: "OrderDetail");

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
