using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
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
                    { 3, "Spicy" }
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
                    { "1", 0, "638f17c2-5405-4e6f-b43e-40afd8788672", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEGZSlN5nxCd8sK83PjOpgvl4b40ZeJCx1xW+aR/fFWV8pLR8dDRoNOaDxJZavTNNvA==", null, false, null, null, "6b578dd3-df4c-4127-8ae0-d0d54ec5416b", null, false, "admin" },
                    { "2", 0, "71ce686c-a356-4ca1-863a-27b9f11658ac", "kitchen@gmail.com", false, false, null, "KITCHEN@GMAIL.COM", "KITCHEN", "AQAAAAIAAYagAAAAEH7E/cVnQRZiDy5tnqC1Qp+AuesCl/kSPnAvRDxcPqmVUelhyW5fHdxT5Iff/li09g==", null, false, null, null, "cba74f2b-f465-4987-8e7b-fc9cf4571626", null, false, "kitchen" },
                    { "3", 0, "f155d7e4-cb7d-4ec6-bfc8-f336ce952db3", "cashier@gmail.com", false, false, null, "CASHIER@GMAIL.COM", "CASHIER", "AQAAAAIAAYagAAAAEHosHTvM+aREydkhTv8ZHnOaem+eNxNCem/sJjvpKfXUCIKaVT93R3pL/Pvy4MPtxQ==", null, false, null, null, "369f9d0a-f50f-4806-abf8-abd865ee62ff", null, false, "cashier" }
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
                    { 10, 650.0, 65.0, 18.0, 4.0, 22.0 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "EndTime", "Note", "PeopleCount", "StartTime", "Status", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "1", null, null, 5, new DateTime(2024, 12, 28, 11, 50, 40, 725, DateTimeKind.Local).AddTicks(5355), 0, 1, 490000m },
                    { "2", null, null, 2, new DateTime(2024, 12, 28, 11, 50, 40, 725, DateTimeKind.Local).AddTicks(5514), 0, 6, 265000m },
                    { "3", null, null, 4, new DateTime(2024, 12, 28, 11, 50, 40, 725, DateTimeKind.Local).AddTicks(5550), 0, 2, 115000m }
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
                    { "10", 0, "a72f432a-f664-4325-8345-0431082fd361", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAEA8fv8QkVOtD3q7Cp6miivxMbdK120K87FE6wyRNAlT9Jsn4TOi7ecoyVC+D8cIAtA==", null, false, null, null, "cab89db9-5c8e-46ec-950e-3a7a5c19b230", 7, false, "client7" },
                    { "11", 0, "6cb84dc3-5896-4e1e-a7c6-2316ad75e105", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAENUrvD6hCU4iZYFVkxUBYsgC5pXGoeSS3FbHInQA/Ssv6aNDR0eK4gUQxjhGKRx17Q==", null, false, null, null, "778d11e5-2ef5-4e98-bd18-4b01ef2cfad5", 8, false, "client8" },
                    { "12", 0, "e61cf8b8-2063-4009-81de-6c7d651e62ab", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEItNfrzhNnX3r+NUNXLkxIbRD6TpT2pttqN3uDH88Pkm3w2wh5g5lijNF9JLWEib1w==", null, false, null, null, "da332dab-c7ba-49c8-b3d9-e959f488141c", 9, false, "client9" },
                    { "13", 0, "451d639a-1d86-4fc9-b049-515cb4a63934", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEJUJAPgHj7qUh/mlRIKiotnWz9X7y5ayxaITGUv75W0c5vCMKqMT2mR3RZub9qMeHQ==", null, false, null, null, "17930c4b-5873-4665-bc04-325b7dc329cc", 10, false, "client10" },
                    { "4", 0, "b8e54401-4023-4823-b19a-636b511e524a", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAEPzVPUtP69AXQSV0Lq8H/+8UsCRgzQRQ/tFQ7Vy+4Jv7cWeDjEIes0zijScHu1VgeQ==", null, false, null, null, "9ab226b0-5366-4c2d-81f1-368cdc8009d1", 1, false, "client1" },
                    { "5", 0, "3117e11d-bd97-400a-8fe4-15737bcf517b", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEMnb7r1EsvN1br0ZiA+gG81SBMX1csRU9aW43/022pajQu5oMNHBOSDdJPwZWhT+Aw==", null, false, null, null, "d2d19548-5b96-4f4c-a199-df8dc92e837a", 2, false, "client2" },
                    { "6", 0, "77c908ab-3549-44ad-bef3-85ad016bbf72", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEFe381muNntSkenCVNR2E9bSz74TXG9dHQZ/y3iMJiUhM5gKnITT9D+KgKBHuU4xcA==", null, false, null, null, "309cf38f-f927-4c38-a9b1-cfdbc82246e3", 3, false, "client3" },
                    { "7", 0, "4e80b6b9-5e3b-43d8-9a78-05c3e0c3528b", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAEML/mAvTvi+pgYMz+rYJM5ZSTiLfLVVZ4P3z+L711CkMNo94SJNtnAywh1f0DweLDg==", null, false, null, null, "d4243a69-483a-4d7b-a7a1-438f09df6477", 4, false, "client4" },
                    { "8", 0, "3bce3609-abf2-4382-83b0-eb056e4daebd", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAEPjNx3uW4kzEN/kiWF3GohGOLnvtSwWUAPb132fnfwR0UgrnzxYfRgc7R6ENNGicNg==", null, false, null, null, "968981bd-6489-44f1-9ed4-26f526dfae29", 5, false, "client5" },
                    { "9", 0, "cd187681-3902-4f9b-bc89-ea380c4e59a2", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAEMAGtO9+9YxCgw6OJAnC4n9CXu+yBQCroHfXpiipSyxjqN2a3CqAfj+AAphMFOhMRg==", null, false, null, null, "6374c13a-8a44-4135-9cfd-a7c6744f9404", 6, false, "client6" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "CreatedAt", "OrderId", "PriceAtPurchase", "ProductId", "Quantity", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "101", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 50000m, 1, 2, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "102", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 50000m, 2, 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "103", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 25000m, 3, 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "104", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 35000m, 4, 2, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "105", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 40000m, 5, 1, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "106", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 30000m, 6, 3, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "107", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 25000m, 7, 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "108", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "1", 45000m, 8, 2, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "201", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 25000m, 3, 3, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "202", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 35000m, 4, 2, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "203", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 40000m, 5, 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "204", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 30000m, 6, 1, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "205", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "2", 25000m, 7, 2, 0, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
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
