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
                values: new object[] { "ab810800-2485-4137-bc87-d57308b16d3b", "AQAAAAIAAYagAAAAEGn1OYJmMzA4X1omXhWjpCnLbpPy9DNXwbmWCszu+l24lxC4Mb0WSWcjzLfxHiApag==", "7371c4ee-df2a-472b-af84-c0d699a8dddb", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "TableId" },
                values: new object[] { "358a9203-9e7a-47fb-a0b6-b5be5fb73e0d", "AQAAAAIAAYagAAAAEAzbX384ujejBIIcbtmqXSkj3NQjSZFb6tczRvBpw8TcRiA149Gf/8VBKYLIqSmvSw==", "9c9e7944-7322-4383-90f6-ab6eb1b989f6", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "TableId" },
                values: new object[] { "d9def1b4-94b5-4038-a7d5-44a6021e350d", "AQAAAAIAAYagAAAAED9kQ9Q78HxucartuHSmmTO3Z9X4kYb/f9bW5K3rkMCLzaqCdl9ET6jDoK0aRznzqQ==", "fbe7c0ad-1a77-4ecb-9351-0457769b4950", null });

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
                    { "10", 0, "5e4458f8-c639-4fa7-8acf-732896d24a5a", "client7@gmail.com", false, false, null, "CLIENT7@GMAIL.COM", "CLIENT7", "AQAAAAIAAYagAAAAEL9u/QPU1C1XIKoHq0fBVem9Vc24SJfgt7y1WWJywjAMFNPqQ8xvKHHCt1gfKL9b1w==", null, false, null, null, "a21f3212-243b-40b8-bbe3-1cfcd1d7b044", 7, false, "client7" },
                    { "11", 0, "bab4f860-f6be-4a2a-ad1b-ba58f514d567", "client8@gmail.com", false, false, null, "CLIENT8@GMAIL.COM", "CLIENT8", "AQAAAAIAAYagAAAAEGnFqivveEy2L/VtU6vrUxWEtG751jVWswJeLilghPbVfgJLD8AkO+wx5+mtLlIK9A==", null, false, null, null, "4164302c-09fa-4f03-93b3-5e66f1e6c5a0", 8, false, "client8" },
                    { "12", 0, "d0176211-75c0-42ce-b01f-c8c39341a7f9", "client9@gmail.com", false, false, null, "CLIENT9@GMAIL.COM", "CLIENT9", "AQAAAAIAAYagAAAAEG05YVNl1AmOKSvsPBulEnVdjGkabRvvNFBBTA2RcAv5ZJf7FcwRY7CFbtOeOw8J5w==", null, false, null, null, "08a021f2-1974-405e-a806-ea55f3f68898", 9, false, "client9" },
                    { "13", 0, "a1b4742f-68a6-48c0-a534-2b74a8a2365f", "client10@gmail.com", false, false, null, "CLIENT10@GMAIL.COM", "CLIENT10", "AQAAAAIAAYagAAAAEH5/Bmt6Fyi+b+pivCK5ENHSyHwRtcvyWu/lbl/RDCITiY/Tl6eaCW7hl81tvWoTcg==", null, false, null, null, "768f2280-4b8e-437d-8c0a-dbb0a661ca8f", 10, false, "client10" },
                    { "4", 0, "c5a69136-b9bf-4598-a54e-150c537fc88a", "client1@gmail.com", false, false, null, "CLIENT1@GMAIL.COM", "CLIENT1", "AQAAAAIAAYagAAAAEOnlIUgGKUagSnNjzSXZaj+LlbU0vUn35A/3McDgXnTK4NLskq/Ar6c8eyVI8Kc+Ew==", null, false, null, null, "2fad3466-890a-4de6-93eb-bb800280ffa4", 1, false, "client1" },
                    { "5", 0, "d494c94d-ec59-407d-8586-0b4829c2e513", "client2@gmail.com", false, false, null, "CLIENT2@GMAIL.COM", "CLIENT2", "AQAAAAIAAYagAAAAEKbN2bEpnpWrhKEVo9Mt5/VEEUuRUkv9t5ph4LL34Ca3bSbwFl+Uh4Xoj5aShVxAng==", null, false, null, null, "b5822d91-4b50-452b-95b2-e41790cf0ae2", 2, false, "client2" },
                    { "6", 0, "725c667c-addd-4ec7-b9fa-2434e7a36ec9", "client3@gmail.com", false, false, null, "CLIENT3@GMAIL.COM", "CLIENT3", "AQAAAAIAAYagAAAAEEjk3I3zxFd1bO0DIEaD+Hiq3SDhDu9r/saRFuvkGZhpOhnoCKJGBa+/E/hAZ6f3AQ==", null, false, null, null, "26fd3f78-f88a-4190-ba0d-450824b0015d", 3, false, "client3" },
                    { "7", 0, "916862e3-1bf0-46b2-a1f0-0b5623ca9a3b", "client4@gmail.com", false, false, null, "CLIENT4@GMAIL.COM", "CLIENT4", "AQAAAAIAAYagAAAAEKWpgXpRag+i6eVgjiyTf00Omta0Ty9uPPzJwM2+TjFH9DvGOrgbcBt6X1vUJmbMQA==", null, false, null, null, "2d986923-afed-47b4-a526-233b081b162d", 4, false, "client4" },
                    { "8", 0, "d0212b8e-27f6-499f-9ac8-0eaa7013ea8e", "client5@gmail.com", false, false, null, "CLIENT5@GMAIL.COM", "CLIENT5", "AQAAAAIAAYagAAAAEO6RZV4DVKSlrst8VyHW5xWjpwcnUx1ZzBZrbDXXgM1XcZsRWuuFPz78zfkmZZPNmQ==", null, false, null, null, "43a63466-de01-432f-9fbf-92552e46b817", 5, false, "client5" },
                    { "9", 0, "657f5f1e-aaff-4b7d-8e61-ea781fd9d751", "client6@gmail.com", false, false, null, "CLIENT6@GMAIL.COM", "CLIENT6", "AQAAAAIAAYagAAAAENuLieXMkV1+nuz0wxMRQMCo9YVlytr9rrRoBvk6tVXdN0hWgbDd1vfA9/fCSCLfWw==", null, false, null, null, "b0549e3d-0f4a-4256-a715-60187066a5eb", 6, false, "client6" }
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
                keyValues: new object[] { "4", "10" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "11" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "12" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "13" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "4" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "5" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "6" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "7" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "8" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "9" });

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4");

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
                keyValue: "4");

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
                table: "Table",
                keyColumn: "TableId",
                keyValue: 1);

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
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "ZoneId",
                keyValue: 3);

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
