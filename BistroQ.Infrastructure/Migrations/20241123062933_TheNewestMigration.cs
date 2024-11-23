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
                    Status = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
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
                    Status = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                columns: new[] { "OrderId", "EndTime", "PeopleCount", "StartTime", "Status", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "4", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null, 30000m },
                    { "5", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null, 50000m },
                    { "6", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Completed", null, 45000m }
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
                    { "1", 0, "bcf53321-77e2-421a-a9d7-24545db984ab", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOFBcKKHqanfV5CdOZJwZb1bIBAU6eXiq3c2AK0Gh4GPxq6rneAV3dKf2NcBJtsGlw==", null, false, null, null, "155c00a6-546d-49ac-85fa-c0cf557b851b", null, false, "admin" },
                    { "2", 0, "397ca3be-ffc8-4408-88bf-01b2f580326a", "kitchen@gmail.com", false, false, null, "KITCHEN@GMAIL.COM", "KITCHEN", "AQAAAAIAAYagAAAAEAdIzz45N7L5H0E//gSBBRtT2Y+f1rbjuV5b+oDRoZse/Ex4M+zKeK9M+Py/1COsmA==", null, false, null, null, "b05778f8-0f1a-4fc3-a60e-584c026af420", null, false, "kitchen" },
                    { "3", 0, "03465457-cf48-4a35-8637-b98978530b9b", "cashier@gmail.com", false, false, null, "CASHIER@GMAIL.COM", "CASHIER", "AQAAAAIAAYagAAAAELQ0B18pcbEW9dFAbL01+LydaO+9CN+j1XRXokEmQZKHf2mPUCcuLQoz4gN2J8medA==", null, false, null, null, "af8d94d9-27ce-44b2-9bb1-00b6e331b8b5", null, false, "cashier" }
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
                columns: new[] { "OrderId", "EndTime", "PeopleCount", "StartTime", "Status", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "1", null, 5, new DateTime(2024, 11, 23, 13, 29, 32, 857, DateTimeKind.Local).AddTicks(8435), "In Progress", 1, 490000m },
                    { "2", null, 2, new DateTime(2024, 11, 23, 13, 29, 32, 857, DateTimeKind.Local).AddTicks(8586), "In Progress", 6, 265000m },
                    { "3", null, 4, new DateTime(2024, 11, 23, 13, 29, 32, 857, DateTimeKind.Local).AddTicks(8605), "In Progress", 2, 115000m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status" },
                values: new object[,]
                {
                    { "401", "4", 30000m, 6, 1, "Completed" },
                    { "501", "5", 25000m, 7, 2, "Completed" },
                    { "601", "6", 45000m, 8, 1, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TableId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10", 0, "d744fead-418c-41b4-9588-8abed9d88763", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAEKVn4wCDgxaPjZgpqoZVP8YlR37ubn+wTkwu7Aomzj9H0ntUaGtbg9hyDnuSayheUQ==", null, false, null, null, "bc69656f-92e7-4e62-a46e-b3883bc934e4", 7, false, "client7" },
                    { "11", 0, "0655542b-0d5d-4272-8124-c923b4da61cc", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAEA9szq4RrnTj2cUrUejqXNvpHB5mZX51xZ9snP8zTwbIAM1MnJCZXyvdbV72ElUnmg==", null, false, null, null, "dca7ce28-a8c9-4759-aac0-87a350497c07", 8, false, "client8" },
                    { "12", 0, "a67955a0-914e-4ce3-8329-e482d9f8968c", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEEFGvrvJKCMCH19D2hxoPmfNynTVjamAYMzhot2MEgxro0HCOZDKH8i5eluPzqxigw==", null, false, null, null, "ddc42576-b0ea-4b8b-9878-a45e2c16c390", 9, false, "client9" },
                    { "13", 0, "1fc4c5ac-fc63-45b0-b081-27130d45cbc5", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEDD+lsXNYaP7Y77/Ea3a8xHZeRWhFwXHNPRPqAFgVZTnH0boZEI4RDEJa3v39WARDw==", null, false, null, null, "b7fa8609-f780-4fa8-adc3-367383de3503", 10, false, "client10" },
                    { "4", 0, "2c10edde-3b67-4bad-aa70-23e7b486eb1a", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAENa8CWutoNM1El6nLt0qbfJXqareRFloGQg/bESByNOWzlk8cJ0sywf4XdpDspAL1A==", null, false, null, null, "f6b2298c-088b-49e9-b114-88e3fe087eca", 1, false, "client1" },
                    { "5", 0, "be9a0bd0-c4c3-488e-ae59-fc16d8327aa5", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEP3WNapmRSSdpzNxFKj96l8SC1K9jPVrkCmMAi4HUt5IoZigQeHqNAHaPgOYhfv6ng==", null, false, null, null, "7d1cd2a4-cace-4385-83f3-d800fd8485ce", 2, false, "client2" },
                    { "6", 0, "5ce245d9-fe13-4c3b-9f6e-0b298b4154db", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEMQW3zlGr0ma5X9D/BkfccKV0L+42y84x6o55zHOokGOreN1aHU8rlSyD9NFu7u0gw==", null, false, null, null, "50b2b925-84ed-4282-89f3-50bc0883ad3c", 3, false, "client3" },
                    { "7", 0, "5c90fdc7-41f2-4f31-aa30-ccf77e235952", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAEO/F1pnlG0cZ0iwrkjbVPFI6tjIlOktfVaAC6MPxzgG2VpisiAWxcobfTRSh/aLdyg==", null, false, null, null, "fbcf96fe-1171-4c92-85e8-2492fd98d0ef", 4, false, "client4" },
                    { "8", 0, "a0918fbb-ff71-4c59-b6f7-c814597f3f89", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAEOzIZJgpT7MdSwKjj2Q4dvdrTvfiXajdeYfCA15nutFP18ukKeHOEdT1zb5XikrxCQ==", null, false, null, null, "67d1b8bb-07d0-4db8-8e57-4667986dae4a", 5, false, "client5" },
                    { "9", 0, "c3501d27-10c3-42cb-9150-1a7dd35927d2", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAEOlgIYu4qmPwb96XSt9dIupqseMMiLDEzujpYkdFmORGrck0zUkDoMmxXvlvTTkKPw==", null, false, null, null, "d8e1473c-47bc-48e8-9987-a42a83f07fe5", 6, false, "client6" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status" },
                values: new object[,]
                {
                    { "101", "1", 50000m, 1, 2, "In Progress" },
                    { "102", "1", 50000m, 2, 1, "In Progress" },
                    { "103", "1", 25000m, 3, 1, "In Progress" },
                    { "104", "1", 35000m, 4, 2, "Pending" },
                    { "105", "1", 40000m, 5, 1, "Completed" },
                    { "106", "1", 30000m, 6, 3, "Pending" },
                    { "107", "1", 25000m, 7, 1, "In Progress" },
                    { "108", "1", 45000m, 8, 2, "In Progress" },
                    { "201", "2", 25000m, 3, 3, "Completed" },
                    { "202", "2", 35000m, 4, 2, "Completed" },
                    { "203", "2", 40000m, 5, 1, "In Progress" },
                    { "204", "2", 30000m, 6, 1, "Pending" },
                    { "205", "2", 25000m, 7, 2, "Pending" },
                    { "301", "3", 35000m, 4, 1, "In Progress" },
                    { "302", "3", 40000m, 5, 2, "Completed" }
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
