using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DemoMigration : Migration
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
                    Calories = table.Column<double>(type: "double", nullable: true),
                    Fat = table.Column<double>(type: "double", nullable: true),
                    Fiber = table.Column<double>(type: "double", nullable: true),
                    Protein = table.Column<double>(type: "double", nullable: true),
                    Carbohydrates = table.Column<double>(type: "double", nullable: true)
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
                    OrderId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValueSql: "(UUID())", collation: "utf8mb4_0900_ai_ci")
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
                    OrderItemId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValueSql: "(UUID())", collation: "utf8mb4_0900_ai_ci")
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
                    { 2, "Broth-based" },
                    { 3, "Savory Snacks" },
                    { 4, "Grilled & BBQ" },
                    { 5, "Appetizers" },
                    { 6, "Drinks" }
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
                    { new Guid("00000000-0000-0000-0000-000000000010"), "image/jpeg", "mi-xao.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "image/jpeg", "dumplings.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "image/jpeg", "bibim-guksu.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "image/jpeg", "minestrone-soup.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "image/jpeg", "cheeseburger.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "image/jpeg", "shawarma.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "image/jpeg", "chow-mein.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "image/jpeg", "samosa.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "image/jpeg", "gyoza.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "image/jpeg", "veggie-burger.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "image/jpeg", "spring-rolls.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "image/jpeg", "takoyaki.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "image/jpeg", "tea.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "image/jpeg", "seafood-pho.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "image/jpeg", "steamed-rice-roll.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "image/jpeg", "espresso.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "image/jpeg", "yakitori.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "image/jpeg", "smoothie.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "image/jpeg", "pad-thai.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "image/jpeg", "udon.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "image/jpeg", "spaghetti-carbonara.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "image/jpeg", "ramen.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "image/jpeg", "chicken-biryani.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "image/jpeg", "coconut-water.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "image/jpeg", "lemonade.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "image/jpeg", "chicken-satay.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "image/jpeg", "milkshake.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "image/jpeg", "bulgogi.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "image/jpeg", "soba-noodles.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "image/jpeg", "laksa.jpg" }
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
                    { "1", 0, "006fde69-74f8-4f90-9572-472a9f081fec", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEABKRcMirBFqKwLTjsmNOWO8B9sF1g/4BO6ER500dTM+ajzpw5ksYcbBHUfPjVWXsg==", null, false, null, null, "13db6117-1ac9-4873-9004-bb26dcb04183", null, false, "admin" },
                    { "2", 0, "af825ce6-ba57-4fa4-bc3f-d362f44e334d", "kitchen@gmail.com", false, false, null, "KITCHEN@GMAIL.COM", "KITCHEN", "AQAAAAIAAYagAAAAECVST91IPCSHD70FHisXOBhwnujfw+XhD3fjoNr49JzrVGS3u6Uje91pwwcrjEPohA==", null, false, null, null, "c95db870-a659-4ec6-b3c4-f3436d568186", null, false, "kitchen" },
                    { "3", 0, "f7a89812-4f22-4ffd-bff7-3c2544e35efd", "cashier@gmail.com", false, false, null, "CASHIER@GMAIL.COM", "CASHIER", "AQAAAAIAAYagAAAAEGmX7t0BF9HPiH4UB6TvWCvIgX4zShNdoVozJrJY6li+S8MiyUoYtxYQ4cOA2Hzo8w==", null, false, null, null, "042cde1c-170b-446b-83e5-46e3c9cc79bc", null, false, "cashier" }
                });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "ZoneId", "Name" },
                values: new object[,]
                {
                    { 1, "Inside" },
                    { 2, "Backyard" },
                    { 3, "Outside" },
                    { 4, "VIP" },
                    { 5, "Front" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "DiscountPrice", "ImageId", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, 2, 45000m, new Guid("00000000-0000-0000-0000-000000000001"), "Bun Bo Hue", 50000m, "Bowl" },
                    { 2, 2, 0m, new Guid("00000000-0000-0000-0000-000000000002"), "Pho", 50000m, "Bowl" },
                    { 3, 1, 22000m, new Guid("00000000-0000-0000-0000-000000000003"), "Banh Mi", 25000m, "Piece" },
                    { 4, 1, 0m, new Guid("00000000-0000-0000-0000-000000000004"), "Banh Xeo", 35000m, "Piece" },
                    { 5, 2, 37000m, new Guid("00000000-0000-0000-0000-000000000005"), "Banh Canh", 40000m, "Bowl" },
                    { 6, 1, 0m, new Guid("00000000-0000-0000-0000-000000000006"), "Banh Cuon", 30000m, "Plate" },
                    { 7, 1, 23000m, new Guid("00000000-0000-0000-0000-000000000007"), "Com Chien", 25000m, "Plate" },
                    { 8, 2, 0m, new Guid("00000000-0000-0000-0000-000000000008"), "Bun Rieu", 45000m, "Bowl" },
                    { 9, 2, 37000m, new Guid("00000000-0000-0000-0000-000000000009"), "Bun Thit Nuong", 40000m, "Bowl" },
                    { 10, 1, 0m, new Guid("00000000-0000-0000-0000-000000000010"), "Mi Xao", 45000m, "Plate" },
                    { 11, 5, 42000m, new Guid("00000000-0000-0000-0000-000000000011"), "Dumplings", 45000m, "Piece (6pcs)" },
                    { 12, 1, 0m, new Guid("00000000-0000-0000-0000-000000000012"), "Bibim Guksu", 45000m, "Plate" },
                    { 13, 2, 59000m, new Guid("00000000-0000-0000-0000-000000000013"), "Minestrone Soup", 62000m, "Bowl" },
                    { 15, 3, 75000m, new Guid("00000000-0000-0000-0000-000000000015"), "Cheeseburger", 80000m, "Piece (1pc)" },
                    { 16, 4, 0m, new Guid("00000000-0000-0000-0000-000000000016"), "Shawarma", 50000m, "Wrap" },
                    { 17, 1, 52000m, new Guid("00000000-0000-0000-0000-000000000017"), "Chow Mein", 55000m, "Plate" },
                    { 18, 5, 0m, new Guid("00000000-0000-0000-0000-000000000018"), "Samosa", 40000m, "Piece (4pcs)" },
                    { 19, 5, 39000m, new Guid("00000000-0000-0000-0000-000000000019"), "Gyoza", 42000m, "Piece (5pcs)" },
                    { 20, 3, 0m, new Guid("00000000-0000-0000-0000-000000000020"), "Veggie Burger", 70000m, "Piece (1pc)" },
                    { 21, 5, 0m, new Guid("00000000-0000-0000-0000-000000000021"), "Spring Rolls", 30000m, "Piece (3pcs)" },
                    { 22, 5, 0m, new Guid("00000000-0000-0000-0000-000000000022"), "Takoyaki", 48000m, "Piece (6pcs)" },
                    { 23, 6, 0m, new Guid("00000000-0000-0000-0000-000000000023"), "Tea", 15000m, "Cup" },
                    { 24, 2, 0m, new Guid("00000000-0000-0000-0000-000000000024"), "Seafood Pho", 60000m, "Bowl" },
                    { 25, 1, 0m, new Guid("00000000-0000-0000-0000-000000000025"), "Steamed Rice Roll", 30000m, "Plate" },
                    { 26, 6, 0m, new Guid("00000000-0000-0000-0000-000000000026"), "Espresso", 30000m, "Cup" },
                    { 27, 4, 0m, new Guid("00000000-0000-0000-0000-000000000027"), "Yakitori", 52000m, "Piece (3pcs)" },
                    { 28, 6, 0m, new Guid("00000000-0000-0000-0000-000000000028"), "Smoothie", 35000m, "Glass" },
                    { 29, 1, 0m, new Guid("00000000-0000-0000-0000-000000000029"), "Pad Thai", 55000m, "Plate" },
                    { 30, 2, 0m, new Guid("00000000-0000-0000-0000-000000000030"), "Udon", 70000m, "Bowl" },
                    { 31, 1, 0m, new Guid("00000000-0000-0000-0000-000000000031"), "Spaghetti Carbonara", 75000m, "Plate" },
                    { 32, 2, 0m, new Guid("00000000-0000-0000-0000-000000000032"), "Ramen", 65000m, "Bowl" },
                    { 33, 1, 0m, new Guid("00000000-0000-0000-0000-000000000033"), "Chicken Biryani", 65000m, "Plate" },
                    { 34, 6, 0m, new Guid("00000000-0000-0000-0000-000000000034"), "Coconut Water", 20000m, "Glass" },
                    { 35, 6, 0m, new Guid("00000000-0000-0000-0000-000000000035"), "Lemonade", 25000m, "Glass" },
                    { 36, 4, 0m, new Guid("00000000-0000-0000-0000-000000000036"), "Chicken Satay", 45000m, "Piece (4pcs)" },
                    { 37, 6, 0m, new Guid("00000000-0000-0000-0000-000000000037"), "Milkshake", 40000m, "Glass" },
                    { 38, 3, 0m, new Guid("00000000-0000-0000-0000-000000000038"), "Bulgogi", 85000m, "Plate" },
                    { 39, 2, 0m, new Guid("00000000-0000-0000-0000-000000000039"), "Soba Noodles", 50000m, "Bowl" },
                    { 40, 2, 0m, new Guid("00000000-0000-0000-0000-000000000040"), "Laksa", 58000m, "Bowl" }
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
                    { 10, 2, 2, 3 },
                    { 11, 5, 4, 1 },
                    { 12, 3, 5, 3 }
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
                table: "NutritionFact",
                columns: new[] { "ProductId", "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[,]
                {
                    { 1, 479.0, 50.0, 15.0, 3.0, 25.0 },
                    { 2, 431.0, 45.0, 8.0, 2.0, 25.0 },
                    { 3, 461.0, 55.0, 15.0, 3.0, 20.0 },
                    { 4, 517.0, 41.600000000000001, 16.699999999999999, 2.2999999999999998, 8.4000000000000004 },
                    { 5, 379.0, 45.0, 12.0, 2.0, 18.0 },
                    { 6, 590.0, 45.0, 8.0, 2.0, 5.0 },
                    { 7, 530.0, 55.0, 20.0, 3.0, 15.0 },
                    { 8, 482.0, 45.0, 10.0, 3.0, 20.0 },
                    { 9, 451.0, 45.0, 15.0, 3.0, 18.0 },
                    { 10, 650.0, 65.0, 18.0, 4.0, 22.0 },
                    { 11, 520.0, 60.0, 16.0, 4.0, 22.0 },
                    { 12, 490.0, 48.0, 14.0, 2.0, 22.0 },
                    { 13, 450.0, 50.0, 12.0, 3.0, 18.0 },
                    { 15, 480.0, 50.0, 15.0, 2.0, 24.0 },
                    { 16, 500.0, 55.0, 12.0, 3.0, 22.0 },
                    { 17, 440.0, 45.0, 15.0, 3.0, 20.0 },
                    { 18, 470.0, 50.0, 12.0, 3.0, 18.0 },
                    { 19, 380.0, 42.0, 10.0, 3.0, 15.0 },
                    { 20, 380.0, 35.0, 10.0, 4.0, 15.0 },
                    { 21, 390.0, 35.0, 10.0, 3.0, 12.0 },
                    { 22, 420.0, 48.0, 14.0, 2.0, 16.0 },
                    { 23, 120.0, 25.0, 2.0, 0.0, 2.0 },
                    { 24, 380.0, 45.0, 8.0, 2.0, 22.0 },
                    { 25, 250.0, 30.0, 8.0, 3.0, 12.0 },
                    { 26, 120.0, 24.0, 2.0, 0.0, 2.0 },
                    { 27, 300.0, 15.0, 12.0, 0.0, 32.0 },
                    { 28, 200.0, 45.0, 3.0, 1.0, 3.0 },
                    { 29, 420.0, 55.0, 12.0, 2.0, 18.0 },
                    { 30, 480.0, 65.0, 12.0, 3.0, 20.0 },
                    { 31, 540.0, 60.0, 18.0, 3.0, 22.0 },
                    { 32, 470.0, 50.0, 15.0, 3.0, 18.0 },
                    { 33, 520.0, 68.0, 16.0, 3.0, 25.0 },
                    { 34, 100.0, 25.0, 0.5, 1.0, 2.0 },
                    { 35, 120.0, 30.0, 0.20000000000000001, 0.0, 1.0 },
                    { 36, 350.0, 18.0, 15.0, 1.0, 28.0 },
                    { 37, 280.0, 48.0, 8.0, 0.0, 5.0 },
                    { 38, 450.0, 45.0, 15.0, 3.0, 25.0 },
                    { 39, 430.0, 50.0, 12.0, 3.0, 18.0 },
                    { 40, 510.0, 55.0, 14.0, 3.0, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "EndTime", "Note", "PeopleCount", "StartTime", "Status", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "1", null, null, 5, new DateTime(2025, 1, 7, 17, 11, 9, 418, DateTimeKind.Local).AddTicks(4501), 0, 1, 0m },
                    { "2", null, null, 2, new DateTime(2025, 1, 7, 17, 11, 9, 418, DateTimeKind.Local).AddTicks(4637), 0, 6, 370000m },
                    { "3", null, null, 4, new DateTime(2025, 1, 7, 17, 11, 9, 418, DateTimeKind.Local).AddTicks(4687), 0, 2, 115000m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "CreatedAt", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "401", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "4", 30000m, 6, 1, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "501", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "5", 25000m, 7, 2, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "601", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "6", 45000m, 8, 1, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TableId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10", 0, "0a4aba8b-d34b-4322-8e1a-7ee5cf805355", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAENqN5OpE+qhwg+l54mf6aDsbH9xJ27G/Jnf6n1tkOGoQaTw+jfrrq/pjGvHxedCnhQ==", null, false, null, null, "dec34075-128c-4e2d-9cd7-299248c5d4e0", 7, false, "client7" },
                    { "11", 0, "2968ed36-7a3d-40e5-9d91-69032df34743", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAEMmfVm5tpy4DvcFXY/P0pbFOfHjzO6133YvA7RvcgyqIPzYid/a+QmTsgJ3wdbUbaA==", null, false, null, null, "3b0c9678-e7e6-4637-98f1-840e0e3b4160", 8, false, "client8" },
                    { "12", 0, "611bd33d-0f61-4551-bc8c-61d9b2da1582", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEPUY4B8cedW+9zIW1Q6W+pBE7uyEOoeuHBHqY3g/Y4BmRiDDoozdycGg3lULa8lATg==", null, false, null, null, "6e92adf4-e490-4600-bd80-e6874807915a", 9, false, "client9" },
                    { "13", 0, "78946a8f-e854-4475-86cb-ccb5e9a5b2c0", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEH5hX8Zuy1gSc2+sHC5hhnIA5uZW9KW43dnPmVln0D5EgPghCMv1UDfujJDEy9lFzw==", null, false, null, null, "91f37505-f06f-434f-ad9d-8737c53a5d11", 10, false, "client10" },
                    { "4", 0, "6b91bd6f-bda6-4e03-8ae7-b9ad092153c9", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAEH+JTntMkSeHIpDE511VtnlO21UqtchGKctzyn7/QmjYAp3FNF8EDzv7eXl+WNRT2A==", null, false, null, null, "23a56440-2ba2-4efc-9345-e35ae5f9ca4f", 1, false, "client1" },
                    { "5", 0, "b4e6e61a-95d8-4a24-9d1c-d8e7aa197207", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEMkg+kTAiLLZaveREGeT7kd2fvjOEn8gx/043GDme5ryc+TZA2sMJCWYIA0nXztb5A==", null, false, null, null, "0e08b4b0-8c91-4ed3-9bf5-a63256a43586", 2, false, "client2" },
                    { "6", 0, "382c8897-5e1a-4949-b797-2b1730da7a18", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEFQP13eX7FjoHHOGi33WIer9JHAd/lnwWAhNAsQOVVLweSUTMvP5OLwfZdU53LFG0Q==", null, false, null, null, "3fff8934-6691-4e93-ac99-533a890df407", 3, false, "client3" },
                    { "7", 0, "bdee891f-6298-41b0-9b0b-bb4f31788421", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAEP3DkkQ01KifrCbethyYCyXAdkplI8i94hpZOi6JaEAd15N+WYavtG1OryKh9w1kvw==", null, false, null, null, "1ad7a87b-41cf-473c-ac1c-3905cc6d8e51", 4, false, "client4" },
                    { "8", 0, "a75ffda9-28fb-4fa1-9ca7-ce754dfbbd91", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAEIWT3QHIRYAPnfJtQ+eJtqXwzF4rA8GJYUUwsbL+8O3SBnpbFfk8t7iiGyL3+Lf56g==", null, false, null, null, "5aaba00d-561e-46bd-9df2-ba7d7d0d516d", 5, false, "client5" },
                    { "9", 0, "d2625b16-2c5f-4d19-a50c-46d8268a2e04", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAECc70XS0AgsN33k9OHnYtXm8N2+8Y0CZJ/rEasFIbbO3uGe4SbDNuObfUN3gEttiSw==", null, false, null, null, "fa9152e1-49e1-46c3-b42d-0ff4342098e6", 6, false, "client6" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "CreatedAt", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "201", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 25000m, 3, 3, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "202", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 35000m, 4, 2, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "203", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 40000m, 5, 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "204", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 30000m, 6, 1, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "205", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 25000m, 7, 2, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "206", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 50000m, 16, 1, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "207", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 55000m, 17, 1, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "301", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "3", 35000m, 4, 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "302", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "3", 40000m, 5, 2, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) }
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
