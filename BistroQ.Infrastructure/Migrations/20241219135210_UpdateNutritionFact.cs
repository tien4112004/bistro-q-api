using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNutritionFact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Product",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAtPurchase",
                table: "OrderItem",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderItemId",
                table: "OrderItem",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Order",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Order",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "NutritionFact",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fiber",
                table: "NutritionFact",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "NutritionFact",
                type: "double",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "101",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6162), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6172) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "102",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6200), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6201) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "103",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6213), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "104",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6220), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6221) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "105",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6229), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "106",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6243), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6244) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "107",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6265), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6266) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "108",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6280), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6281) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "201",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6288), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6289) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "202",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6298), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "203",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6380), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6381) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "204",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6392), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "205",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6402), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6402) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "301",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6410), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "302",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6423), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6436) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "401",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6457), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "501",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6467), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6467) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "601",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6480), new DateTime(2024, 12, 19, 20, 52, 9, 746, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cd8f10c-a4f0-4646-a7ef-8b5bda23b2dd", "AQAAAAIAAYagAAAAEF9kftrAzZuzgyelkGqOU2025q/OtdiFPajp1qQMS8R53MOl6wwZYe2dxCb45HvmJA==", "f92c5d86-8062-424b-8e66-668dfe6b65b5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ea69192-66b8-4a68-ac0e-972aa079543e", "AQAAAAIAAYagAAAAEMObKKT+6W4VEM1U7I1YeqKsH9gbMvDQFth5KRpiZH/Q3OhExyeq0nPCaxk4BLZkiA==", "2029296f-65cd-432a-964b-c56b6b694935" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "493bf003-1480-4f98-a3f6-0059205acbeb", "AQAAAAIAAYagAAAAEFBD5mOWmL8Cg67arWgfxi73v4qMycnL2hLZOkLL9FAH0fOanrv0P2PPxvGSUmD83Q==", "25894f48-2ed9-4a32-909d-5390adb32171" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28dc09ce-6116-418f-9ab0-01871b216a8d", "AQAAAAIAAYagAAAAECrsbScCpZCxUfYq5BqCC4qsiGdPPOjx93zClRHDy7oxvBtG7YY4cDkt7w2pDmG5qw==", "06768528-c0d2-4cb2-a1bb-5c9fd6313a0c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10586063-31c7-48f8-a86a-3f217b980f2a", "AQAAAAIAAYagAAAAEDDQ0hTbUN772yQfWz9OOWQgX3DJtuLPBFpMJDMNXERzYNy5R4a3SdBlvq9T2Mbhaw==", "d3301cc2-26b6-42ed-bce6-63dfe8e62f14" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b41f5789-7f41-4197-b0e2-3f4dcfcc8e2b", "AQAAAAIAAYagAAAAENFChPrmid5s4mBQRhFrEAHvhZSoJ/qcsR9NWsAAbUQCr0VxgOYehJYeg5IDokOR4g==", "204abb97-e487-4786-ab5b-fb294f5e9022" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0ab7518-f0a3-407f-9ec8-6d4d5c99363b", "AQAAAAIAAYagAAAAEDOdo0RRaujCpjTZ7n/3YMkXH3LkipmaYFFUSCNTwbc/UoP8VRGoUeHqyU6sbaDohQ==", "fdab2550-ce28-46c8-844d-8682b4f539d0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ed61dbc-ab3f-4555-b9dc-17e893eb43b7", "AQAAAAIAAYagAAAAEPyAki6h+k9ztEWWkOLM5QCf7s0DBxZZ/sSU21Vdl8/ypU7wM1AnAieOLA9s4jvg7w==", "3fa81d2d-b193-4c9e-be12-992d456fa311" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3413fc39-79a9-4bc3-982a-f9dd6b0e7547", "AQAAAAIAAYagAAAAEMqverPaovRr/5JAyKJ+Yn75jG6UpbvFGGphLH2J1LTqdY5bZMbfLzLSOG+y18jzYg==", "dbd41014-5e72-48d9-a00f-6c50eb84a014" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c93a386f-768b-4222-960b-15c0bf9b8c4f", "AQAAAAIAAYagAAAAEK4nPvkveyPOTORe+duWvhUViBGAiUSpO5fWSSkI1Pq8fwhaLI4jawVsP0l9FuP0PA==", "cb3092c0-f40f-4e0c-87cc-4bc3059590e6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0865c761-e2b0-41e7-8ae9-8b1f6a015a4d", "AQAAAAIAAYagAAAAECis/GOAYSP0+/SoxxHAf0OpQEnEe124Dvei5o4+hlV0KCFNpailmHwjsgaRhFZ2zQ==", "26802709-f63c-400c-89bb-3ccb9a535ca2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1517de77-2f8b-43ac-9530-163b813ef120", "AQAAAAIAAYagAAAAEKxrtOGFMLIkMy/kChB/7PRjK91M4cLEpIBpExUy6baZAcKmAcL97ChAnUFuyA7Cvw==", "eedd6dbd-1c26-4290-88de-e1b34f818878" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8898e363-8471-442e-8963-40246f6a662d", "AQAAAAIAAYagAAAAEFmfpwiZFIzOhNiZkci21S64S47RxtAASrKMdppzq9oJdl3/2HafnGp9Pl7DMwMyNg==", "f5b49459-d44c-405b-ac11-dcf5e9eeb2a6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fat",
                table: "NutritionFact");

            migrationBuilder.DropColumn(
                name: "Fiber",
                table: "NutritionFact");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "NutritionFact");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Product",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAtPurchase",
                table: "OrderItem",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderItemId",
                table: "OrderItem",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldDefaultValueSql: "(UUID())")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Order",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Order",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldDefaultValueSql: "(UUID())")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "101",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4171), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "102",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4184), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "103",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4189), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "104",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4194), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4195) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "105",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4200), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4200) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "106",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4205), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "107",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4209), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "108",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4216), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "201",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4220), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "202",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4227), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "203",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4319), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "204",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4325), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "205",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4331), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "301",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4335), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4336) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "302",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4341), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "401",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4367), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "501",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4372), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "601",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4379), new DateTime(2024, 12, 5, 16, 28, 40, 563, DateTimeKind.Local).AddTicks(4379) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a86419d-d2a4-4012-84d7-a09dbc110f10", "AQAAAAIAAYagAAAAEFHkKz3ucjpyWKGU7TGx6wCKkuYSU8kRuEBIq80nHE9R2kAkTL8PxF/KHmOal3GzuQ==", "20b08de9-bbb0-47d1-b033-2b7d4e125a20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eba2a7b-8899-42c8-adff-56d00a079857", "AQAAAAIAAYagAAAAEMKpFFxXuajM2z1gxbJBYhzmIt2zILKvyEa/TZ4nD3Kg6HbZe04XZxtZp7105EJAwQ==", "1f0b604b-93de-45c9-9462-e6295ba942bc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a6a3c1d-419f-4c70-bb42-330148e1abc0", "AQAAAAIAAYagAAAAEOxOuFez7va+AvbHhbLv8If37+CxQqKzO0Yy5cc4lGj+Wk+NHoJEgj5xh7Tw6LEPvQ==", "f7d3511b-a28a-4be4-85e9-e9d70fa13118" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db2d8507-aa63-42aa-9b9b-6492fb7df34a", "AQAAAAIAAYagAAAAEL2W/jyYmI3uW+rABY4m9mDEVkdax58pp5E1dHwedeD17/01lTyntn2zE+lcQB116w==", "26992a25-177f-48b2-a9d4-7d4209669785" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8df287d4-1c15-4877-8b40-db8af0b12b5a", "AQAAAAIAAYagAAAAEIlSMIxuiMEDMX2eF1F0Q55LRmq6I8kpABq7gNS26GvorfmxrPbclRTXVG3JU8oPPg==", "a0ef6fff-25f8-4884-8074-90b84503317a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb6c95b6-e943-4cdc-9d10-ea03ef580b86", "AQAAAAIAAYagAAAAELBSynuR2bo+H5qdQEq6AlPxDOmD4YAPzespEPpr19ANiuXCdxt7p1H0DURMTnrM6Q==", "c2005e51-aa99-4f5a-86ab-e011123a28d5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d3273a5-7393-426c-bd44-a2c36d1d7e71", "AQAAAAIAAYagAAAAECoS4gDLfm7YqgXkpIOvjoFdu/Ff35ImhamoXArX+FdjcSil/7GIN1OsNU2YKDqkQg==", "acd6cda1-eaaa-42a6-be5e-79cde24a2275" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a8faa59-3eee-4e05-aa1d-86bad8d073fe", "AQAAAAIAAYagAAAAEKV7UV8XjHuvUSAtHz/JV0SxVvRayqNkDIO0NIwbQrk9c3dMtD01NaMWNPf7APNKmA==", "ae2a3db0-35d0-4a03-8117-bd019373bbcc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bc69e7b-dc45-480b-b44a-a678eb7711dc", "AQAAAAIAAYagAAAAEOTSRuiDFaUiJWrUPXCAajaheZsRSw2bGJTUBE01BXCHxMJVInNY/DFr/QwN40A8JA==", "67f51de4-42c6-4a4c-a758-ca81dba5f80c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b99d456d-fa84-4988-8bdf-02674109936e", "AQAAAAIAAYagAAAAEPlKtAvbdApC0ld8O5jJwwM8LdWWS+Na+C7zKnP/qAXxZ0iysw41W2N7hsHXIHYkbw==", "a179cfaf-3d66-4385-bb76-e880c1ffb6c0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28da7344-ddcb-4aec-8140-951f795c46dd", "AQAAAAIAAYagAAAAEOXYZcCa79nJdAkK1l5yNb/h/D/VhNUMTAw0gLu0mxgjXhJ5puzl8f3P9Fpv0WL3UA==", "d1f46438-4cd0-4d3e-96bd-d50efcb3f57a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "880bbf17-841b-43c3-8233-3262a01ef7cf", "AQAAAAIAAYagAAAAEEFJIUpGEFvcQwjux4LLM2QYO70KOnlavQNiQiry1asc2NrKJWDDSQ7SAHzUvSD7og==", "2e260389-7df6-436d-84e5-aae21062bbfb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c32b882-2a9b-4343-9192-c94dc33f45ef", "AQAAAAIAAYagAAAAEENdnRvm8YXzAQ7X1tExdhmgsdRUiSz4bgcDq92ibyXfvzulCgCwfQHBt80AJm1ZsA==", "6e3b2241-032d-4e29-8726-f26e3a6780b6" });
        }
    }
}
