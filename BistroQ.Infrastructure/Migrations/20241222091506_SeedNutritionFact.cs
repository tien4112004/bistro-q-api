using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNutritionFact : Migration
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
                table: "NutritionFact",
                columns: new[] { "ProductId", "Calories", "Fat", "Fiber", "Protein" },
                values: new object[,]
                {
                    { 1, 33.0, 129.0, 162.0, 160.0 },
                    { 2, 152.0, 98.0, 165.0, 70.0 },
                    { 3, 179.0, 81.0, 49.0, 157.0 },
                    { 4, 21.0, 5.0, 164.0, 173.0 },
                    { 5, 81.0, 100.0, 154.0, 139.0 },
                    { 6, 44.0, 19.0, 120.0, 153.0 },
                    { 7, 12.0, 49.0, 10.0, 123.0 },
                    { 8, 57.0, 8.0, 19.0, 34.0 },
                    { 9, 31.0, 116.0, 68.0, 36.0 },
                    { 10, 102.0, 25.0, 52.0, 45.0 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 10);

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
        }
    }
}
