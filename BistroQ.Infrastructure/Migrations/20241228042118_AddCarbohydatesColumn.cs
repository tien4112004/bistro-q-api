using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCarbohydatesColumn : Migration
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

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrates",
                table: "NutritionFact",
                type: "double",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 479.0, null, 15.0, 3.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 431.0, null, 8.0, 2.0, 25.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 461.0, null, 15.0, 3.0, 20.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 517.0, null, 16.699999999999999, 2.2999999999999998, 8.4000000000000004 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 379.0, null, 12.0, 2.0, 18.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 590.0, null, 8.0, 2.0, 5.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 530.0, null, 20.0, 3.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 482.0, null, 10.0, 3.0, 20.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 451.0, null, 15.0, 3.0, 18.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[] { 650.0, null, 18.0, 4.0, 22.0 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbohydrates",
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
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 33.0, 129.0, 162.0, 160.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 152.0, 98.0, 165.0, 70.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 179.0, 81.0, 49.0, 157.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 21.0, 5.0, 164.0, 173.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 81.0, 100.0, 154.0, 139.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 44.0, 19.0, 120.0, 153.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 12.0, 49.0, 10.0, 123.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 57.0, 8.0, 19.0, 34.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 31.0, 116.0, 68.0, 36.0 });

            migrationBuilder.UpdateData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Calories", "Fat", "Fiber", "Protein" },
                values: new object[] { 102.0, 25.0, 52.0, 45.0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 22, 16, 15, 4, 932, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 22, 16, 15, 4, 932, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 22, 16, 15, 4, 932, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ba75fbc-33a9-4ae5-a929-6f30af4bd953", "AQAAAAIAAYagAAAAEKsFS0mHIYMuI94Ty/a6p1ObHL340BrMrkrqXpT8WSkH8S59Fy1CMLQ6OlVm+YvaSQ==", "962b2751-2da4-494b-830c-48027552e73c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "794e60d4-546a-48e8-b568-e480f4944133", "AQAAAAIAAYagAAAAEDI/qBOcx/Zrh3yO6/+nNAKLrfGibnzMCx3I5WxKlZdPtt2MTGRQ3NWt/YjM+eI7nQ==", "cf5470f2-fddf-42ab-b145-f69c7f3cd6c9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bac6ec0-1242-4b00-8180-18b823aec1d7", "AQAAAAIAAYagAAAAEG7zGAABWsh51LcOghDMhLJ3TWsWZwshAuSpFw7tPlDClmJ2hovO5FAOBJF6BkUFDA==", "0dd87ee6-4b0a-4bdf-b3b2-9634206e395a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "410959ae-55cf-4a9c-a29e-3a4d83040e1e", "AQAAAAIAAYagAAAAEG+1fvMFkIZD6HRhUgbofDvUBgSvLt3cWWYxm42O7YXerR39QhgGpyuPIkQT4VVlMg==", "0cd19aa6-b1bc-4a69-96a2-332fdee3aef8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d901023-f4ba-47e7-834b-3492a394ceb6", "AQAAAAIAAYagAAAAEEEMXWRd/AdZW1tTssulwgXFKPfRaFQ1Zoun+LZ4g8HluF6GMBptsY6tUqZiMsaMNQ==", "8be474dc-b31e-4d62-9ccd-3e5d1493e1f0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffd8cc09-ad7b-422b-b3c1-d3f767a4cd33", "AQAAAAIAAYagAAAAENxg3jNCLxY49Sj+4ReX9+WurvuOC1xIfot4+kwYd0ztN2fVvnDqSbi8IwNcVWi/SQ==", "28ccb8db-1ad3-4ef4-a031-6c343429c8fd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9618f5b3-83c9-4d0f-a180-c00d4a05208f", "AQAAAAIAAYagAAAAEIjk5M1ZqwaJVoNz430iwbv0PXDsfnsFDrUpMR2keCnJugIY0Dr5pGvGTAWGCUQ+cg==", "fd86f805-ac9d-4c20-8891-bf55ab097e00" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef4b6038-c9e2-4351-a2d6-a743e04637d2", "AQAAAAIAAYagAAAAEIHdHY+yqi6ST22z4z6Uz31So9tUojg3ZON0bnbsjlr88EsC1T+eZlBv2RCZh82Omg==", "d3e260b1-41b6-4115-8840-3deb9ccb971a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da8bd9eb-2a11-4814-b8b4-04c2a6147958", "AQAAAAIAAYagAAAAEIp4VR9yNb8gsDjD5/FJkNJtCXxkWijQwX6RPP1VI297DS0+p0Z3xr0RArgPWHah+g==", "2b5463dd-cbff-4a11-bdbb-769ecfdf480e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c064c8b3-a89d-495b-a5e0-9d52927a14d3", "AQAAAAIAAYagAAAAENiehM6RiUX3qA/P6AuCr3k7S+r/HKe81LlVsfzYDCF5q47K48xyt92G+frpqWOw0w==", "28d1d99b-1143-4ec1-8dd4-56dd1571dce1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bfdc420-7a41-415d-89e1-25e369767f01", "AQAAAAIAAYagAAAAEJdgIm8cm3aw/U7Z6mzQ1WQUHJKLzwEitpWdDmUvhG2WViTtwjYn9JlTDHFYInNwVg==", "bad69526-59c4-4c21-a482-9ec0230ceb9b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d677b81-895f-41c6-a76b-19b5af03cebd", "AQAAAAIAAYagAAAAEF+cbijuia2znd8zB6LliweasrDWxz//ss1VYAhwf98LfgnwzvsHEin+y2wIjJxajA==", "b855ae05-83be-4e86-b5cb-da134638b4c5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad78ef7-937c-4659-9c40-4f907e853587", "AQAAAAIAAYagAAAAEPMBpKGxj0KiOEaL3yoSMRRAZQ/zHAk2YUJq/7wsiULK9nGZLmLMNQO47MTs+VZsEQ==", "d3c3dc4b-8a0e-4d24-8ea1-b47e3084fd51" });
        }
    }
}
