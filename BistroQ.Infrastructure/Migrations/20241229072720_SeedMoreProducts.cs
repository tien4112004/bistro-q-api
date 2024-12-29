using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProducts : Migration
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
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Savory Snacks");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 4, "Grilled & BBQ" },
                    { 5, "Appetizers" },
                    { 6, "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ContentType", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), "image/jpeg", "dumplings.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "image/jpeg", "bibim-guksu.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "image/jpeg", "minestrone-soup.jpg" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "image/jpeg", "french-onion-soup.jpg" },
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

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 29, 14, 27, 19, 979, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 29, 14, 27, 19, 979, DateTimeKind.Local).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 29, 14, 27, 19, 979, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a89f7a03-6e99-4611-b3fe-1ac4cdb54e6f", "AQAAAAIAAYagAAAAELcCc4SP9gXthdrEP2Q5VnJqT+IuLTIkZ/QdsWGiv3TTbXNogHsakbfUyF00zFxxhQ==", "4850a35a-40c7-4135-a1a7-8e2eb324761c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "140f7974-9eac-4e82-a26b-db38878dcc5c", "AQAAAAIAAYagAAAAEJ+e1Rfo816/Kf/DluZ4c2b2bQyCfJAxPz+zvOBx4j7FUYhkt3jBXb4RQjF4VI3bIA==", "66866033-12ba-493d-9fce-e6fb4a0ea6e5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "439da447-1f47-4fbe-8705-5d9441f9ca55", "AQAAAAIAAYagAAAAEAqKBNddyuyGektwvRkdQTsvdLGX/cPIZCwODigx4SkTAEqs14HtiI5KaoLtUq27og==", "5c8c2eca-9b49-4840-956a-b09efd2829d8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b731f66e-7f0f-4448-90f7-9ae760db6957", "AQAAAAIAAYagAAAAEFz/dGeJdIpqc6uzWTCpuxcefnLLq1mWhEvM2kX5pL9O80cHmjWRrCgXavb7D43SoQ==", "2648545b-f96a-49dd-96c7-5652f6e44108" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "106ccc49-af61-4968-b808-d5dee333e483", "AQAAAAIAAYagAAAAEMOH9ZXbhcmz8FcV7ZzLnM+bB/jxrs0YI3mfGup+bl3vovRxH/9ahl1o5aQ9CKFCjw==", "f42cbc94-80a5-4703-89d3-9ee275031dd4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a1e7012-882f-4698-ad4b-935754859add", "AQAAAAIAAYagAAAAEPMhxEotsF6Mh6zxJI/Kd1qrYGACVJlNaYcZCE1+Vo8WIQhdq8rQhgMq82N3v2XorA==", "adfc20dc-8ba4-479d-a761-db606507c354" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f39de81-8a64-469a-b818-24d43f290aa6", "AQAAAAIAAYagAAAAEJTb7uO3A6lJjOzBmnXOb/RHZtfNZDju9HwlBuA/L0YEyfEtSlSu1MsJcVfrSKHKbA==", "b3061abd-05de-4b2b-a463-ef17645d516a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68dc6164-c60f-4b82-809f-06d7df156de5", "AQAAAAIAAYagAAAAELu2UoWQMekpMtFpZNJL8WWFQ1mInnLopJSeflwU24bknZXUKaj//yxCH7tGG/JOPw==", "94fd3bd5-3874-420e-bad4-603527c8a0c3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ded19252-f2f0-4825-b7a6-e53029156b42", "AQAAAAIAAYagAAAAEONEtdOyPASFwvQ8P9MnCUbgsonHmrJYjt7e0HfnjUnSFK+xHmW3Jg84GBacu7XkAw==", "1db7e947-04e2-4d19-a957-83ba5e4790db" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5d8eb6c-0a64-45d3-8cee-b15281417647", "AQAAAAIAAYagAAAAELE46pEyN2Shb7KctLvg7S14c+bM3l3QFv/OaZvKyJmw3lPhjFCVrP5zhuflpM1GCQ==", "cb2b6b3e-5743-43fa-be5b-0e6d2de6e45f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4d907e6-c090-4699-9b30-7d060cee9395", "AQAAAAIAAYagAAAAEHpansIO7hOtsEtroFYjUpGGkOEc2MNBfyTfR9N/tVcUJIC9mqGvsEKXH/kxesW2Tw==", "5f10468f-de80-4580-b22f-b049ae7e98eb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "943b3eba-64f4-4a16-8975-a9fd982dccd8", "AQAAAAIAAYagAAAAEJqbN13ChMA9PMlFsztHoSXtGj5aEfF9DDdNTReUN4i+jpXg4GCN42zzPN8bccLp7A==", "9daa7ee1-e6f5-4d96-8be4-0ba7dbd8ff1f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b89784d-da68-4430-a358-ef661582c1e5", "AQAAAAIAAYagAAAAEHgenTKAzKxsLEi7Q9NFeUU+qe0DE3pVYFW/kYVFUVKdBbilbnkf4bG7qOZJQnAZsQ==", "c6e87c69-ff62-41df-a054-c5a75df0baec" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "DiscountPrice", "ImageId", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 11, 5, 0m, new Guid("00000000-0000-0000-0000-000000000011"), "Dumplings", 45000m, "Piece (6pcs)" },
                    { 12, 1, 0m, new Guid("00000000-0000-0000-0000-000000000012"), "Bibim Guksu", 45000m, "Plate" },
                    { 13, 2, 0m, new Guid("00000000-0000-0000-0000-000000000013"), "Minestrone Soup", 62000m, "Bowl" },
                    { 14, 2, 0m, new Guid("00000000-0000-0000-0000-000000000014"), "French Onion Soup", 70000m, "Bowl" },
                    { 15, 3, 0m, new Guid("00000000-0000-0000-0000-000000000015"), "Cheeseburger", 80000m, "Piece (1pc)" },
                    { 16, 4, 0m, new Guid("00000000-0000-0000-0000-000000000016"), "Shawarma", 50000m, "Wrap" },
                    { 17, 1, 0m, new Guid("00000000-0000-0000-0000-000000000017"), "Chow Mein", 55000m, "Plate" },
                    { 18, 5, 0m, new Guid("00000000-0000-0000-0000-000000000018"), "Samosa", 40000m, "Piece (4pcs)" },
                    { 19, 5, 0m, new Guid("00000000-0000-0000-0000-000000000019"), "Gyoza", 42000m, "Piece (5pcs)" },
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
                table: "NutritionFact",
                columns: new[] { "ProductId", "Calories", "Carbohydrates", "Fat", "Fiber", "Protein" },
                values: new object[,]
                {
                    { 11, 520.0, 60.0, 16.0, 4.0, 22.0 },
                    { 12, 490.0, 48.0, 14.0, 2.0, 22.0 },
                    { 13, 450.0, 50.0, 12.0, 3.0, 18.0 },
                    { 14, 520.0, 62.0, 14.0, 4.0, 20.0 },
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "NutritionFact",
                keyColumn: "ProductId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

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
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Spicy");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 50, 40, 725, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 50, 40, 725, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 28, 11, 50, 40, 725, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "638f17c2-5405-4e6f-b43e-40afd8788672", "AQAAAAIAAYagAAAAEGZSlN5nxCd8sK83PjOpgvl4b40ZeJCx1xW+aR/fFWV8pLR8dDRoNOaDxJZavTNNvA==", "6b578dd3-df4c-4127-8ae0-d0d54ec5416b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a72f432a-f664-4325-8345-0431082fd361", "AQAAAAIAAYagAAAAEA8fv8QkVOtD3q7Cp6miivxMbdK120K87FE6wyRNAlT9Jsn4TOi7ecoyVC+D8cIAtA==", "cab89db9-5c8e-46ec-950e-3a7a5c19b230" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cb84dc3-5896-4e1e-a7c6-2316ad75e105", "AQAAAAIAAYagAAAAENUrvD6hCU4iZYFVkxUBYsgC5pXGoeSS3FbHInQA/Ssv6aNDR0eK4gUQxjhGKRx17Q==", "778d11e5-2ef5-4e98-bd18-4b01ef2cfad5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e61cf8b8-2063-4009-81de-6c7d651e62ab", "AQAAAAIAAYagAAAAEItNfrzhNnX3r+NUNXLkxIbRD6TpT2pttqN3uDH88Pkm3w2wh5g5lijNF9JLWEib1w==", "da332dab-c7ba-49c8-b3d9-e959f488141c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "451d639a-1d86-4fc9-b049-515cb4a63934", "AQAAAAIAAYagAAAAEJUJAPgHj7qUh/mlRIKiotnWz9X7y5ayxaITGUv75W0c5vCMKqMT2mR3RZub9qMeHQ==", "17930c4b-5873-4665-bc04-325b7dc329cc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71ce686c-a356-4ca1-863a-27b9f11658ac", "AQAAAAIAAYagAAAAEH7E/cVnQRZiDy5tnqC1Qp+AuesCl/kSPnAvRDxcPqmVUelhyW5fHdxT5Iff/li09g==", "cba74f2b-f465-4987-8e7b-fc9cf4571626" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f155d7e4-cb7d-4ec6-bfc8-f336ce952db3", "AQAAAAIAAYagAAAAEHosHTvM+aREydkhTv8ZHnOaem+eNxNCem/sJjvpKfXUCIKaVT93R3pL/Pvy4MPtxQ==", "369f9d0a-f50f-4806-abf8-abd865ee62ff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8e54401-4023-4823-b19a-636b511e524a", "AQAAAAIAAYagAAAAEPzVPUtP69AXQSV0Lq8H/+8UsCRgzQRQ/tFQ7Vy+4Jv7cWeDjEIes0zijScHu1VgeQ==", "9ab226b0-5366-4c2d-81f1-368cdc8009d1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3117e11d-bd97-400a-8fe4-15737bcf517b", "AQAAAAIAAYagAAAAEMnb7r1EsvN1br0ZiA+gG81SBMX1csRU9aW43/022pajQu5oMNHBOSDdJPwZWhT+Aw==", "d2d19548-5b96-4f4c-a199-df8dc92e837a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77c908ab-3549-44ad-bef3-85ad016bbf72", "AQAAAAIAAYagAAAAEFe381muNntSkenCVNR2E9bSz74TXG9dHQZ/y3iMJiUhM5gKnITT9D+KgKBHuU4xcA==", "309cf38f-f927-4c38-a9b1-cfdbc82246e3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e80b6b9-5e3b-43d8-9a78-05c3e0c3528b", "AQAAAAIAAYagAAAAEML/mAvTvi+pgYMz+rYJM5ZSTiLfLVVZ4P3z+L711CkMNo94SJNtnAywh1f0DweLDg==", "d4243a69-483a-4d7b-a7a1-438f09df6477" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bce3609-abf2-4382-83b0-eb056e4daebd", "AQAAAAIAAYagAAAAEPjNx3uW4kzEN/kiWF3GohGOLnvtSwWUAPb132fnfwR0UgrnzxYfRgc7R6ENNGicNg==", "968981bd-6489-44f1-9ed4-26f526dfae29" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd187681-3902-4f9b-bc89-ea380c4e59a2", "AQAAAAIAAYagAAAAEMAGtO9+9YxCgw6OJAnC4n9CXu+yBQCroHfXpiipSyxjqN2a3CqAfj+AAphMFOhMRg==", "6374c13a-8a44-4135-9cfd-a7c6744f9404" });
        }
    }
}
