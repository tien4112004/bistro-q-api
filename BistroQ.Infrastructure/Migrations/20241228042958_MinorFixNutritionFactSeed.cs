using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorFixNutritionFactSeed : Migration
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

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 29, 57, 851, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 29, 57, 851, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 29, 57, 851, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3758b4c-dc36-4a45-a39a-b3d9fd8a876e", "AQAAAAIAAYagAAAAEN0o+ZF8YWlr/Zm3ZLu/n/cTH+id62yFpr9vfKJe6qxkBxwJeM+bwxwuAFtLm43u8w==", "a801ca34-7c1c-4ea6-8831-e323dd179e67" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05b31e46-5146-4cae-9933-268fe05b275b", "AQAAAAIAAYagAAAAEFe6Mx4lmRn+2Y+DgGHNGRYoeyF/xf72hNu+P28GHkWFxrYlrTbosrqZkRWWjUxsbw==", "822e972c-1233-4dd1-a891-8bf528dca3f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a340c911-7d59-4cc1-8cfb-8255b6099fbd", "AQAAAAIAAYagAAAAEHaCV4bJXZIP1mJlalto3AJG0YXqZh7AM9uvXop2BqxWLRMGurNZmcKL6fMe9gDL3w==", "707c9a48-ec36-47bc-92ff-b4ab40d3c748" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "248824d8-5b42-49af-9e10-785ef840828f", "AQAAAAIAAYagAAAAEMOM35EZ8KuTq8EgtRa+0GUEFqFEmBRXM/8KmklJvsxponXX6IvOP65mjQ5xAg2gPA==", "541e40f5-5c24-42db-a5fd-070ba10cd2a2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5364f228-da0b-4593-acc2-648934837425", "AQAAAAIAAYagAAAAEJJpeK3d0EJK5BJdrw/QCXblv9SFS9rgOANj4QuLQ4BTjQexy2X2jXzHJaa8wDAjDQ==", "13512ea1-f66f-4cb1-96dd-93541bcb29c9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57762ec7-9501-4a8d-95a5-4473036db430", "AQAAAAIAAYagAAAAELPe5eZsDC81FlSHELpcq6HSJqZPk95KiVV6WAoeRskqXUoFj2GYrkPGIaWjDkd1hg==", "54a8d132-8b25-4bd9-9d9a-1331e0bd4ab1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5fd51e0-7b2d-4018-b842-2f2ab4889260", "AQAAAAIAAYagAAAAEBZfUZGZYkXYzmM8A+J0oD5qymTINxtvl+Uh2+QKW/uxcI8FOireQW4a/y4DO3nJLw==", "08a13fa1-746b-495d-957b-e3b9ad728cec" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eeb79b6-3599-4d8b-bb9f-b2f9b7dc60ed", "AQAAAAIAAYagAAAAEGlCfZ0/hxvSEgU5B3mCsmVdT8r+ZMDrCI7LzlAaADVbKsNLYZCJkHfVZo3+SzN0Hg==", "9ab64dfa-1959-4b17-964e-a517b02055dd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67c962a1-6dee-444e-a3f8-b3dacfbe24a6", "AQAAAAIAAYagAAAAEOWm9Ce95aiQGG+KbGBzQF6khV3DS+FoiTsT+N8hWbRwpNmDA5LEf2xrhldl+z+kJw==", "5bc2776f-225a-4d10-a323-be2b39d0a069" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0830d76-5420-475e-8d30-0a57337234e6", "AQAAAAIAAYagAAAAEHn1z1PNdpq9D5k0hxSn8B7dd4/mj3ChNcOYvRV2R9/n3m5w/OBc7tfLl8VwbN+S+A==", "2b6d58c1-655d-43f9-ba9e-04eb8e6d2819" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56e1e28a-3c15-458f-a666-997591023e40", "AQAAAAIAAYagAAAAEIbMfp4FUPpEtm9r+vo8EIL0UKikaJHOOLcflvLNC0MpzE6zsvYWdJOTHv2p91n6Vw==", "b463595b-4566-44ff-803a-c6ac7f260e59" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d6268f0-65f5-46ee-a796-dddfac6fc632", "AQAAAAIAAYagAAAAEDynrvgMPyhJjT37wM4hFutcRpaeQNtQCymCn8lRML6p1uBctdyLSORAZ/hw/WrXVg==", "a388e867-a672-4420-a981-d5433d65a044" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d08dc062-82e7-471e-8157-a74e4c4ea4c0", "AQAAAAIAAYagAAAAELE934wRvL/sXk7kcPiesxydcvaFQ3GUnxBiW6fj5ENiuDHm4esexjHPOiAwXU3qTA==", "7f8ae0aa-700c-4832-9d60-ac6097b65083" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2024, 12, 28, 11, 21, 16, 495, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 21, 16, 495, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 21, 16, 495, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dd33505-fe53-48da-8f07-4ec11371b1a9", "AQAAAAIAAYagAAAAEOzYl6A70paSAZbCAFhbPH9aZsEaVZgbWL563PkXivVfvl7c7wHHAQaM+KzAsXqvlQ==", "9b5e84a5-1937-4b24-ad9e-3fbdb6d8d07b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c189b1ca-df3f-4a88-9e6b-282b84d31c31", "AQAAAAIAAYagAAAAENixJ5eTwFuZIAx5Pj7Xp/AgyIc1qj9GhZqUS4nuviriyV3NuAfspZ1zu3XwWV0oKA==", "5cee1dc8-9a8c-4bb3-9bc8-433f1ec29dd7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73e324e0-03a6-4e65-8d88-ac43baca8c8a", "AQAAAAIAAYagAAAAEP1+p0n0qIYnXDAel19Unykj7xoiKjsuLthXAi31TziBFlaUBXXAukWPYVICmQ3FTw==", "ecc46f7e-31e5-4de2-b9bd-e17b0151d84d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b4871da-42a7-4c02-91b4-d50c21e4727e", "AQAAAAIAAYagAAAAEN/AcZhfBnI9mnVDuJfNA3EpA+pVAvDDrPNDgswoezqZVc7Ch0La9e6z7Y9b18U/IQ==", "da4d1866-d5b9-4ef5-880b-d5b182338ee3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52662364-515f-4e48-a9c0-44f3c75bd53b", "AQAAAAIAAYagAAAAENOTPIOO+KKgvX+nijDBVl5QiD3NsM1yMxfatlePkRrtvWY7dbLpNpsQkl/V+6wXvw==", "16be571e-af96-4e29-aea4-55b0ad1fe549" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4813ff1-3d1c-41e6-82fe-462d9e757cb9", "AQAAAAIAAYagAAAAEHyHJV0Hdt5rDPRjgENVHrzlUCsye7dFPDe/vAGWfieCZa1phEQZtzaFB/pmrItjTA==", "9d3e3fe2-d438-4435-b1f2-b6abf1a4232e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04743ead-234a-46bc-8f0b-d88f9aff298d", "AQAAAAIAAYagAAAAEOsMznQZNS4Fyv60Ab0WtjDGEH2xch19q33qliqm45HqBsDSSLQOyT3Bu0dYIAOxFA==", "e86528ed-f159-4aae-bf14-9ae1d1c65e8d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2205bdca-3bd3-46ec-8714-a683bd02a5f1", "AQAAAAIAAYagAAAAEFE44+GhDWmOwhp+H1ZAL3fEksgyDS6alrY0mpCYJQJUh6/ZthdK12A0eFrW84nzAQ==", "6e906222-6598-4467-b8b6-18e21aa01ca2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ec714d7-c5b9-4bcc-a0e8-035bdeb5498a", "AQAAAAIAAYagAAAAEJFLFZ4v9GPd93IaaAsB2Hu0U/P/xR28o8YIaDf6MjCeCL7nmtTzgF03YsnbPGz9Dg==", "5bb04430-d5da-4c24-b2af-afd3814df4de" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59324c6f-0ae0-4204-9eb2-ba81d2d46514", "AQAAAAIAAYagAAAAEDUCIbNhQbt7jOYz4/+s8i+P2XuDGXHSRMosdRq+cRrK7rNvZSTP/ccHXdB61yUOZw==", "2418ae68-7b33-4b1b-8892-7428327785cd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebede79f-0ab2-4e30-a7e7-03afebbf9c45", "AQAAAAIAAYagAAAAEGD8KS7ifQJBMvErng8dvZIJkQ1ivZL3PaSidrfJrWqZxT5Ru22P2OxROqqYkJBuZg==", "093223e0-bb70-4559-a57f-b02a98f735b9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74279bb3-76d5-486a-8f82-6855a8f3bf1e", "AQAAAAIAAYagAAAAEAqZ8CGckrLNLojYS4M0MDqj2bI41OOOA8+afHa6KYSrrkL14yyvLOCxD448dt+wSw==", "50f2df6a-8300-45ee-b9f6-8bdcde5ba98f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0887cbd6-b72b-4083-9141-c17d74755fa4", "AQAAAAIAAYagAAAAELKfBZWXa7EFMiF/d43has0CSbZ55/A35NDb3fiVQhQJVgRTwsDstwQFmNQTjINr6Q==", "b546cbfe-3e5e-4931-9612-acb52b44c4b8" });
        }
    }
}
