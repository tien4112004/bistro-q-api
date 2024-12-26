using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveSeedDataToCsv : Migration
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

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Spicy" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 22, 14, 21, 3, 433, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 22, 14, 21, 3, 433, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 22, 14, 21, 3, 433, DateTimeKind.Local).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "101",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "102",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "103",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "104",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "105",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "106",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "107",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "108",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "201",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "202",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "203",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "204",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "205",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "301",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "302",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "401",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "501",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "601",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "TableId", "Number", "SeatsCount", "ZoneId" },
                values: new object[,]
                {
                    { 11, 5, 4, 1 },
                    { 12, 3, 5, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6bf425a-36e0-4368-9149-759319d7b03d", "AQAAAAIAAYagAAAAEGV6jUgyTvtYaS7MMM1vd+O6NMvXLkNIjEkr6WItXnEoLmxwNCgnTHegUy/Zr9AVYw==", "e690faca-f393-4613-8e5c-023a1ff40468" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b60c462-94da-422e-85a2-c282fb5358c9", "AQAAAAIAAYagAAAAEOi2OzgHO4iOH/4mHFRLjur8VtnhbyiWaGYbWM34HZheuzYRHUYQXPUidOdS1+gMhQ==", "26ec6b04-3b9f-42c9-8de7-3150e3f2bc63" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45a42d2e-d1d5-45f9-a2d7-dfe5078bc197", "AQAAAAIAAYagAAAAEECTrohNFKi0Kp8tAo2OAArl0izgHZeclyQzyF7IcixTPv9a70l3D2IXJ5lcbaFOaA==", "bf632477-ef96-4eec-a59d-49acbf31d3e1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1428de84-1402-427b-ac16-8b1fd986f4fe", "AQAAAAIAAYagAAAAEHoUsRe2aOC4T9VnIqduvSoyhGAND3SFhMgf7YcKRIyNfEd81fHispXJ5JMzPkp0Uw==", "de61f879-6d37-4282-b6c2-811cb8a18b83" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e605f727-0a50-441f-ba67-4c9d3380fe0c", "AQAAAAIAAYagAAAAEIkJeCZ1tmL/Z1ELcMTB8vQEgpggmk/Y4pJhTywwuNXxEhMPsUDS7LkPq3MQbm9mhQ==", "f7090051-90c9-48e3-ac6d-c30909110e8f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9693de7c-5d83-4845-83e2-65aa41a901b0", "AQAAAAIAAYagAAAAEMV9SrATky3M7sOJWhOqUVWI0ekNKZybDbnkmlDxK4rPpAcu4FqOpcDtigXozTxsiw==", "aa07eed0-5a98-4ca9-be00-b73baa093f7c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d536ac8d-b295-4243-9d39-ef3ab4477ea5", "AQAAAAIAAYagAAAAEFE5uM2quNKZE2CLoXMvdNJRFDYmpIlcGwmKtvNAzCPQ3XsSAuJURkZJOyIXVABoIA==", "3f0d05e7-2277-450f-bc03-1868e0fa1fb2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e25ce7b4-0df6-4cd9-9e23-87a55bee4b28", "AQAAAAIAAYagAAAAENxXySqAxEPbnh4FopWyPdAcxUuLidNfQUQP5TmNXa8oX79q0o3Mu6K7wy09ZT0KVQ==", "95905470-4726-4662-8ad9-4098dac8fbfa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81020520-3c8c-45b4-ab6c-c9530dc8b493", "AQAAAAIAAYagAAAAEPOPTFZlTrNJgF2XcDnw9m+PFdMyyQVEbkPb5Qqm/tXoe2dB+XzBHFbPJnKZVk4OiA==", "c0907217-6623-4c8f-9271-18ac6c361743" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d9cb6a-c020-4609-9cbf-915cde321280", "AQAAAAIAAYagAAAAEGkwL6w8MV9xfAIO6eoulPGew4/9Uwwj925VwZTszQPJZgVlDY7I7vh01ffGegtfJA==", "57198d01-f357-485f-9a47-6473979bab7e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80cf3b0a-6fb5-4acf-86da-3dae0d5c7eda", "AQAAAAIAAYagAAAAEMa2gZBk5Dsil76wYHLxTSDEzNi01X01ekUNo7YUqRf5wNsPFOf7oZnoBqAdQ247Gg==", "28e32824-0010-459b-958b-aba89e884c96" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a88d100c-f0b2-4069-a070-b4b81219e856", "AQAAAAIAAYagAAAAEAMYwsw1sssu0DmMQCApiuYFa2jpXw36EZOUTnENWy3QZ5fbK1FDlP3/G1WwxgDl+g==", "4b2896c1-cb8a-44be-99f4-e1fc03f801ff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bb061a3-ccd6-42f5-906d-4c2ea7679b1a", "AQAAAAIAAYagAAAAEG3Pox3xHGqnBC+gIl8kB4vIvCOo5Fud3nwS0pEhlNBL8DTdLk0XhlqGOZipeAKwAg==", "6b10be0a-51b5-42d1-a331-5fceb3043975" });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "ZoneId", "Name" },
                values: new object[] { 5, "Front" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 5);

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
    }
}
