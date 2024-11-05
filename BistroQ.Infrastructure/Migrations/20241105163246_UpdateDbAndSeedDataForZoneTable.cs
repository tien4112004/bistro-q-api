using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbAndSeedDataForZoneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Users",
                type: "int",
                nullable: true);    

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4", null, "Client", "CLIENT" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "TableId" },
                values: new object[] { "ed595309-814c-42de-b4bc-5ac14b698fd0", "AQAAAAIAAYagAAAAEDC+Mw4qvsh+kldPHwx3lmGq1uXNsUQqHSxbL+SVu71qSfFFROwtB2SCyjtnPXgrMQ==", "8f5553b9-4482-409e-a9e8-8acd80f06303", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "TableId" },
                values: new object[] { "5a81c7ed-e427-4ca4-9df5-f7c53b845324", "AQAAAAIAAYagAAAAEAy5husKhkqBhxtVZqSKq92Uk/XPIqu/pQVfyPrjq0hQqXa5dxJ3OnrqicXoThDbJg==", "8290cb7b-7de3-429b-af24-8d4336e5c7f2", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "TableId" },
                values: new object[] { "90b50e3b-8c3c-4c95-a265-9071d9cfeba4", "AQAAAAIAAYagAAAAEEWbEc5T86c7GtL1t0o3cxl7Rou1vFaHJr5sLaAZGFPa4hqN9JQb/2IzZDz+Z62T/w==", "6f1bd74e-60cc-4110-b4a8-195d06a551eb", null });

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
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TableId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10", 0, "e3ea5f85-2c8f-4ad5-9e58-1b4f63fe8224", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAEJlVd/N/PhaRonZuudFVvlBYcRONKfql8dsKi4j8Zl59ZsOeUmXGdggbCVa/Q10g2w==", null, false, null, null, "71cff7a8-9e13-45f8-8b11-8e528e60e32c", 7, false, "client7" },
                    { "11", 0, "4e6e3098-3abb-4c2c-a835-fbcc2130b768", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAEFhtuqTz++J/fo56/oF+QMN2r/kztOHj7AdYpUDwN1vv5d7SteqsFQEonEwDtTOsfA==", null, false, null, null, "7da41a5c-21e3-4f6e-a7da-9b9f048e766d", 8, false, "client8" },
                    { "12", 0, "34a49433-51ce-46b0-9824-6e04c9e91c0e", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEM0Uod9CKp/Ofp5NTvYpaH067+NmYYj9yy1GInHkX2yDjrChyhB3nodC8UnutnOq0g==", null, false, null, null, "22b1dace-7e5f-45f0-b438-b82e7e2c15dc", 9, false, "client9" },
                    { "13", 0, "b5c3aff7-5a0f-480f-8cc5-15c3a2c61bf1", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEC3H8vq3G4t0UyQoVvxIZwPiyLU2qOqC7Ofqwl23ynDyyBJw2RnVnjsqKNNqgsdK0Q==", null, false, null, null, "b129ed7c-d92b-4b18-bf6c-cd7c619712c4", 10, false, "client10" },
                    { "4", 0, "7d47c1fd-3f1c-4817-9b2a-7fa02fa27666", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAEIUZLD3PLKihgOQp2x9rJPJRKCQSu8C1Bx+qKDOEjf0a1qYpIxMXXsCtqHz6aOcVgg==", null, false, null, null, "b717e721-9ab2-4224-b52d-7f1c8995edb0", 1, false, "client1" },
                    { "5", 0, "8dafd1b6-cda5-4634-9569-65f86f142031", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEJmK3bxRWJ2EDcWvW36NpQ3tiI1umCKlSW1lOuS93klFf4l/Uvv1XWKZd9z530lysQ==", null, false, null, null, "5bb34194-4c69-4c2c-ab43-9f2e27b91dae", 2, false, "client2" },
                    { "6", 0, "cb6a48d9-980c-44e3-bcf2-d44906a66183", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEPHYz1s4edyUbszPWoQgkjWUAo9zwhqdEfpVzxMn6ku55VkQ3bw9LcJzF9wlTpUu4A==", null, false, null, null, "5ab0d3da-f87a-45cc-b6d9-0e6ad44f80df", 3, false, "client3" },
                    { "7", 0, "bd8630df-3663-481a-9433-c61bfac4adf7", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAEGmORxxT3gad8FZEeG6Y3jch8ch4CQ32G4kqyrsFkeC3MfxKE1D3aB6Q9aom2mM1Qg==", null, false, null, null, "db52ce87-c94c-4df0-aa9a-e5a8d1d5cce7", 4, false, "client4" },
                    { "8", 0, "3946efcf-b4a9-47ff-bae3-f093827fbbfd", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAELOuqbKov4Y2XA4jBfiMLK9RYho79iQUhwOr5JRRgP1AayyeMErSdBuwnt+hlfugRA==", null, false, null, null, "85ae4640-99c4-4d74-93b1-c8b66adbdf78", 5, false, "client5" },
                    { "9", 0, "cca1cc3d-4f5d-48ae-a5a3-698987d9b521", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAEPySHT5pPExXbrtRiwQfQ6uTH2bEZbKMkfBUzXmR5Lqa/8bYYbDRh77+0I+sTJOsNw==", null, false, null, null, "95f25081-c810-4eb7-a82a-a63c2a4d0133", 6, false, "client6" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TableId",
                table: "Users",
                column: "TableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_TableId",
                table: "Order",
                column: "TableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Table_ibfk_2",
                table: "Users",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "TableId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Table_ibfk_2",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TableId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Order_TableId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "4" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Users");

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
                values: new object[] { "a7ad4b3e-975b-4ca9-ab2e-cb60e172310e", "AQAAAAIAAYagAAAAEGptHuTkMcdedhIGYIOW0qgid3zUlu8lRU2jH/rmjhOMhAmj1farU/wYVuDJj9F5dg==", "4534e820-9da2-49c9-b503-1694e5a87d5b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52b20da9-26e4-402c-a4fa-41b2571155e3", "AQAAAAIAAYagAAAAEC07LDYVg5AeZEfE2CEl3uDDnEwWmFh7lPc6OIplT8mEzFnsmhT7Qq3as8At+ZNraA==", "1e5b4104-d490-4e30-981e-27e596f48bf1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b030ba1d-560a-41db-96f2-b366a3ec4775", "AQAAAAIAAYagAAAAEHy4CwqGgtGxfM/UThMGamb8dEbF8XELW0bx04LrvLFSjiokd5oIkqNqt3nyko1OSw==", "d406f259-82a9-4ded-88bf-1eec595cb1ae" });
        }
    }
}