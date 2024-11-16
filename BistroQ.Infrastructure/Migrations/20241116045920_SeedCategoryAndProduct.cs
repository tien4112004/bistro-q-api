using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryAndProduct : Migration
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

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Product",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAtPurchase",
                table: "OrderDetail",
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3ef2281-df37-4a64-b8f9-1ab713d71798", "AQAAAAIAAYagAAAAEHdFQREXUkLofxywe1fAGCKbV3MeF75WhLp6OtjazMFq31mF1KWiixJOUaIIk+CUwA==", "a513467d-8efd-47d2-8d24-b7ee67e282e9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04485147-1268-4260-9204-1bfa39812a09", "AQAAAAIAAYagAAAAEDokM0Ce7PBg0gtsdz1CLFFSD5G59/ufYKa3HDe2YkJi4K9QskXuGXRG8bo9kRKxKA==", "a70a4f28-b337-4857-854c-6de562a28e6e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000e1975-130e-4f99-8d5c-25d623cf47e3", "AQAAAAIAAYagAAAAED4r0LVKODn34h9X5JkIij4Hi2M8QaF44Y+zP4hTVZEwHJKhjfYd8HoAevx5gPJKEQ==", "965f254b-8162-4c33-b49a-1361ab92c4a5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49ee197c-19d3-4645-94ad-cbf71c449e33", "AQAAAAIAAYagAAAAEAE04ga1Z/aCvlXcavLgxZUHBqpDvuVC7Y14e1YHIRkNPEIQRrbEdWQ3wFpkjahL5Q==", "f50522f1-d1dd-4ce4-ad38-e72828ec37a2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d3f97ee-5523-49ef-a952-275d80926abb", "AQAAAAIAAYagAAAAENfPak9OV4YGpNhYOMGGiu6IaNKRU/s7raY3FMSk4uNh9q6Fl0rGInNGciYuwU6WSQ==", "817bf9d6-f431-4522-b7f9-db33c67983ad" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ed68c0d-d4d9-4bba-a6cb-17878af03433", "AQAAAAIAAYagAAAAEH8GONJh5FbTMhz8dSBRhcu83ohFpcWkFaOiX/Y3dML69MevLJ5No8enoaAT2DPRHQ==", "8a8fabce-1c44-4556-926c-1e5e09c45f7d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dd12046-1feb-4433-9770-d322d79e61a4", "AQAAAAIAAYagAAAAEM9Eox5JvC7rqcEi+yWQn7i+dRoTEW4iAUJpjDMaVYdZMC5rfr3GMqRlX+8apU2Y5g==", "0b3ae0af-ce0b-4824-9032-d4f25195837c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e165a9ca-cf63-4b92-919e-80007c1169b7", "AQAAAAIAAYagAAAAED7oeUefuUE5vgxqo9MDBP52UELWXdtW0rjj+9qTu1E+E/LpQ2lxBMmJ8W22CHhvow==", "c2d60857-1573-4270-b3fc-1cb4ea26de58" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2786a7f-68f6-4535-8c1a-b12b99a61314", "AQAAAAIAAYagAAAAEN4408vG1mVAGO9hXCNahXxjD3W5tQeEADLSDCQjflRRGT73xLwPEJfxHsbmsbasEQ==", "c7f05d6d-88a5-49be-bf91-801eef9a5b2c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7838892-23dd-4bf5-8355-72e16e969880", "AQAAAAIAAYagAAAAEHkzLDILN4BE6zOzh2JvPEsy5EUHvDQn0q6bjxiaLdOFsmVSKlqO78r0LBGHkfTarA==", "7459e5ae-789d-462b-b8cb-11966c2cb2f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27a7a511-9fa6-4f81-8944-f8519ed42b4a", "AQAAAAIAAYagAAAAELXRVaaJtcqyOl+bi203Zh0EFw6jf9WBG/dkBOwJLGu+uWGg94ib6kB5spqEAvW2ww==", "200df536-15d8-415d-971a-471bacc6d7fc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "734bf784-91b2-4c1a-b963-09486e1e3344", "AQAAAAIAAYagAAAAEKCwOLjLALWJh9cjADYx97rviX68ODz+vZrCEmGLwfOAk6rkSv+PhxW9M58dQvwKRw==", "56ec0a90-467d-4eb6-be9b-120ca4f9dee2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eade640d-20cd-4ea4-8685-f15e9a42111b", "AQAAAAIAAYagAAAAEBhJGTFuwe8kLUWKZyG7VnCz9l/+A8uOoyRhuVluJ5xkUiyqsNYrQFa+uaQIjpvNwA==", "8dd2afae-42c7-47b3-ac9e-57bfbbab34ac" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Product_ImageId",
                table: "Product",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Product_ibfk_2",
                table: "Product",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Product_ibfk_2",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Product_ImageId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Product");

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
                table: "OrderDetail",
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
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed595309-814c-42de-b4bc-5ac14b698fd0", "AQAAAAIAAYagAAAAEDC+Mw4qvsh+kldPHwx3lmGq1uXNsUQqHSxbL+SVu71qSfFFROwtB2SCyjtnPXgrMQ==", "8f5553b9-4482-409e-a9e8-8acd80f06303" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3ea5f85-2c8f-4ad5-9e58-1b4f63fe8224", "AQAAAAIAAYagAAAAEJlVd/N/PhaRonZuudFVvlBYcRONKfql8dsKi4j8Zl59ZsOeUmXGdggbCVa/Q10g2w==", "71cff7a8-9e13-45f8-8b11-8e528e60e32c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e6e3098-3abb-4c2c-a835-fbcc2130b768", "AQAAAAIAAYagAAAAEFhtuqTz++J/fo56/oF+QMN2r/kztOHj7AdYpUDwN1vv5d7SteqsFQEonEwDtTOsfA==", "7da41a5c-21e3-4f6e-a7da-9b9f048e766d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34a49433-51ce-46b0-9824-6e04c9e91c0e", "AQAAAAIAAYagAAAAEM0Uod9CKp/Ofp5NTvYpaH067+NmYYj9yy1GInHkX2yDjrChyhB3nodC8UnutnOq0g==", "22b1dace-7e5f-45f0-b438-b82e7e2c15dc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5c3aff7-5a0f-480f-8cc5-15c3a2c61bf1", "AQAAAAIAAYagAAAAEC3H8vq3G4t0UyQoVvxIZwPiyLU2qOqC7Ofqwl23ynDyyBJw2RnVnjsqKNNqgsdK0Q==", "b129ed7c-d92b-4b18-bf6c-cd7c619712c4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a81c7ed-e427-4ca4-9df5-f7c53b845324", "AQAAAAIAAYagAAAAEAy5husKhkqBhxtVZqSKq92Uk/XPIqu/pQVfyPrjq0hQqXa5dxJ3OnrqicXoThDbJg==", "8290cb7b-7de3-429b-af24-8d4336e5c7f2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90b50e3b-8c3c-4c95-a265-9071d9cfeba4", "AQAAAAIAAYagAAAAEEWbEc5T86c7GtL1t0o3cxl7Rou1vFaHJr5sLaAZGFPa4hqN9JQb/2IzZDz+Z62T/w==", "6f1bd74e-60cc-4110-b4a8-195d06a551eb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d47c1fd-3f1c-4817-9b2a-7fa02fa27666", "AQAAAAIAAYagAAAAEIUZLD3PLKihgOQp2x9rJPJRKCQSu8C1Bx+qKDOEjf0a1qYpIxMXXsCtqHz6aOcVgg==", "b717e721-9ab2-4224-b52d-7f1c8995edb0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dafd1b6-cda5-4634-9569-65f86f142031", "AQAAAAIAAYagAAAAEJmK3bxRWJ2EDcWvW36NpQ3tiI1umCKlSW1lOuS93klFf4l/Uvv1XWKZd9z530lysQ==", "5bb34194-4c69-4c2c-ab43-9f2e27b91dae" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb6a48d9-980c-44e3-bcf2-d44906a66183", "AQAAAAIAAYagAAAAEPHYz1s4edyUbszPWoQgkjWUAo9zwhqdEfpVzxMn6ku55VkQ3bw9LcJzF9wlTpUu4A==", "5ab0d3da-f87a-45cc-b6d9-0e6ad44f80df" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd8630df-3663-481a-9433-c61bfac4adf7", "AQAAAAIAAYagAAAAEGmORxxT3gad8FZEeG6Y3jch8ch4CQ32G4kqyrsFkeC3MfxKE1D3aB6Q9aom2mM1Qg==", "db52ce87-c94c-4df0-aa9a-e5a8d1d5cce7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3946efcf-b4a9-47ff-bae3-f093827fbbfd", "AQAAAAIAAYagAAAAELOuqbKov4Y2XA4jBfiMLK9RYho79iQUhwOr5JRRgP1AayyeMErSdBuwnt+hlfugRA==", "85ae4640-99c4-4d74-93b1-c8b66adbdf78" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cca1cc3d-4f5d-48ae-a5a3-698987d9b521", "AQAAAAIAAYagAAAAEPySHT5pPExXbrtRiwQfQ6uTH2bEZbKMkfBUzXmR5Lqa/8bYYbDRh77+0I+sTJOsNw==", "95f25081-c810-4eb7-a82a-a63c2a4d0133" });
        }
    }
}
