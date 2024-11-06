using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
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
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Drink" },
                    { 2, "Food" },
                    { 3, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "EndTime", "StartTime", "TableId", "TotalAmount" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 30m },
                    { "2", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 30m },
                    { "3", new DateTime(2024, 10, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 200m },
                    { "4", null, new DateTime(2024, 11, 6, 18, 20, 45, 508, DateTimeKind.Local).AddTicks(5591), 2, 80m },
                    { "5", null, new DateTime(2024, 11, 6, 18, 20, 45, 508, DateTimeKind.Local).AddTicks(5621), 3, 40m },
                    { "6", null, new DateTime(2024, 11, 6, 18, 20, 45, 508, DateTimeKind.Local).AddTicks(5632), 4, 30m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d7bda6b-1c42-445e-98e1-736130c623c8", "AQAAAAIAAYagAAAAECjlCOu1PLhX6h4OeeVGb6soFEqj5EnZCF8d+Qg3ApSRpaJSo4TdR3qbgwAQXR7VMg==", "f785e0e4-8822-47c5-ac8d-2ec9b03bb99b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7342df21-35bd-47f0-adf6-b8ed96c64cfd", "AQAAAAIAAYagAAAAENErMFrMNAWIw9F1UCVuXQmgiqLBUCqTCQ/AL4gZES9qa3LylEdz4MEZOdilXJQPow==", "db429311-13fd-4c8a-87b6-b5abb2e2e2b7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78111c53-8530-4567-98bc-13c3ffb5d90b", "AQAAAAIAAYagAAAAEIv9YqCi0b5WfTL+ejkbZj3i7sAThnGJZinqBgRAX/2A0iExngh0kCfjftTOH7AhYA==", "f2207c13-f3e1-429d-ba55-e931dcdb6a69" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f4d1d6f-ccc8-439d-a867-18b4800a07a1", "AQAAAAIAAYagAAAAEKUNbxjwfHl8WFw2p/hcH7GDQOHdfOim1A/+EPaLom2bL60nb07SyhLlpL99HCjVSA==", "863b327b-d505-4102-85e2-a32c1ea8d3a7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "643145a8-5fbd-4138-8d76-a97edecbac47", "AQAAAAIAAYagAAAAELYzLUF0zrCcSghhZT7ZIR4xUTP1w5vBSnRee16DPdzFv5wun2gy2moM+CkQAps0OQ==", "9043edbb-1975-494d-ad94-cae8c59d4d2e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27b7e5ae-2deb-4678-9df6-dcf3e3483343", "AQAAAAIAAYagAAAAEAs1L2EcWhbU5lEKMbJq/Z7X1rXAYWh8PxMjaAqpkrFvUbmxVu/K7LDI99dklMID9A==", "c61eff19-95a4-499a-9968-d615c3b66a5e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83c181f4-c006-4449-b121-b129af99313c", "AQAAAAIAAYagAAAAEHdY5Utz0+zlyGbo98Xv1rRoE7H6jG5XuyNb7wCOwaPapOLcdrruxtG7TgSqdlFkXA==", "aa110b2b-e1b6-450b-bd1b-ac14fc1d81e8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f0d514b-b100-4878-b9d5-14bda117bd01", "AQAAAAIAAYagAAAAEDnOL+kz36gYy3xl/KSI30AvqRcMOseP4dyHxndUACKE18iT062RKBJntK4fFZpiog==", "c6a5e322-8b40-4c75-8774-aed27d81be5e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2600a768-9479-4fc8-85c3-d19b25bb2a7d", "AQAAAAIAAYagAAAAEFXMlCJ42rwcofZkEJ0ZNTbhxafkBAnGmxE8FNOfIs1LOwicgSg1VjnepHABDwmHoA==", "c4250479-e24e-49f7-a8ec-0d098bf766cd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921d7547-34fa-48a8-99eb-d02c93c2bd29", "AQAAAAIAAYagAAAAEBGl3+LPu3422zFqrCCYS5FibpRfS7VRXSzt6Ei4ThkvTdgcV8gQ0fA0UocYuEj/Gw==", "c5b5bc0b-3859-4ac7-b358-8302a0b36d44" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb692f6a-e3db-4fd7-9615-aab89c4828d5", "AQAAAAIAAYagAAAAEK8gOG1yREAeemFPUlyPBy+6e1Ej9RVUZNIPIy6NQeEleGHQgQwVj2xCWywNhXVViQ==", "cf2c36a4-4ee9-4b7e-b84e-e780d9581c9d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b2448b6-ccb8-419c-8e18-8862dfdf8973", "AQAAAAIAAYagAAAAEFjTtoOuzkDUMZztuovFuMs6Rud+DuyRgdJsd84h9pFLyuWJLof3Y74y7fV+ExUcFQ==", "4fc5e3ff-7985-451b-a724-e588dcf56d70" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bef03fea-a6b6-42c0-8274-11546d981337", "AQAAAAIAAYagAAAAEORsaObJujoEfwCMJz+p0Tb3EiuO2HZPUM7q9nYiUg3oSMDBGqSzdncp9fUtQ6XS2w==", "085e1871-b9da-40d5-9f97-a8b8f2bcb1b2" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "DiscountPrice", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, 1, null, "Coca Cola", 10m, "Can" },
                    { 2, 1, null, "Pepsi", 10m, "Can" },
                    { 3, 1, null, "Fanta", 10m, "Can" },
                    { 4, 2, null, "Pizza", 100m, "Piece" },
                    { 5, 2, null, "Hamburger", 50m, "Piece" },
                    { 6, 2, null, "Spaghetti", 80m, "Plate" },
                    { 7, 3, null, "Ice Cream", 20m, "Cup" },
                    { 8, 3, null, "Cake", 30m, "Piece" },
                    { 9, 3, null, "Pudding", 25m, "Cup" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderDetailId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "1", "1", 10m, 1, 2 },
                    { "2", "1", 10m, 2, 1 },
                    { "3", "2", 10m, 3, 3 },
                    { "4", "3", 100m, 4, 1 },
                    { "5", "3", 50m, 5, 2 },
                    { "6", "4", 80m, 6, 1 },
                    { "7", "5", 20m, 7, 2 },
                    { "8", "6", 30m, 8, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "OrderDetailId",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "6");

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
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

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
                values: new object[] { "ab810800-2485-4137-bc87-d57308b16d3b", "AQAAAAIAAYagAAAAEGn1OYJmMzA4X1omXhWjpCnLbpPy9DNXwbmWCszu+l24lxC4Mb0WSWcjzLfxHiApag==", "7371c4ee-df2a-472b-af84-c0d699a8dddb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e4458f8-c639-4fa7-8acf-732896d24a5a", "AQAAAAIAAYagAAAAEL9u/QPU1C1XIKoHq0fBVem9Vc24SJfgt7y1WWJywjAMFNPqQ8xvKHHCt1gfKL9b1w==", "a21f3212-243b-40b8-bbe3-1cfcd1d7b044" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bab4f860-f6be-4a2a-ad1b-ba58f514d567", "AQAAAAIAAYagAAAAEGnFqivveEy2L/VtU6vrUxWEtG751jVWswJeLilghPbVfgJLD8AkO+wx5+mtLlIK9A==", "4164302c-09fa-4f03-93b3-5e66f1e6c5a0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0176211-75c0-42ce-b01f-c8c39341a7f9", "AQAAAAIAAYagAAAAEG05YVNl1AmOKSvsPBulEnVdjGkabRvvNFBBTA2RcAv5ZJf7FcwRY7CFbtOeOw8J5w==", "08a021f2-1974-405e-a806-ea55f3f68898" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1b4742f-68a6-48c0-a534-2b74a8a2365f", "AQAAAAIAAYagAAAAEH5/Bmt6Fyi+b+pivCK5ENHSyHwRtcvyWu/lbl/RDCITiY/Tl6eaCW7hl81tvWoTcg==", "768f2280-4b8e-437d-8c0a-dbb0a661ca8f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "358a9203-9e7a-47fb-a0b6-b5be5fb73e0d", "AQAAAAIAAYagAAAAEAzbX384ujejBIIcbtmqXSkj3NQjSZFb6tczRvBpw8TcRiA149Gf/8VBKYLIqSmvSw==", "9c9e7944-7322-4383-90f6-ab6eb1b989f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9def1b4-94b5-4038-a7d5-44a6021e350d", "AQAAAAIAAYagAAAAED9kQ9Q78HxucartuHSmmTO3Z9X4kYb/f9bW5K3rkMCLzaqCdl9ET6jDoK0aRznzqQ==", "fbe7c0ad-1a77-4ecb-9351-0457769b4950" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5a69136-b9bf-4598-a54e-150c537fc88a", "AQAAAAIAAYagAAAAEOnlIUgGKUagSnNjzSXZaj+LlbU0vUn35A/3McDgXnTK4NLskq/Ar6c8eyVI8Kc+Ew==", "2fad3466-890a-4de6-93eb-bb800280ffa4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d494c94d-ec59-407d-8586-0b4829c2e513", "AQAAAAIAAYagAAAAEKbN2bEpnpWrhKEVo9Mt5/VEEUuRUkv9t5ph4LL34Ca3bSbwFl+Uh4Xoj5aShVxAng==", "b5822d91-4b50-452b-95b2-e41790cf0ae2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "725c667c-addd-4ec7-b9fa-2434e7a36ec9", "AQAAAAIAAYagAAAAEEjk3I3zxFd1bO0DIEaD+Hiq3SDhDu9r/saRFuvkGZhpOhnoCKJGBa+/E/hAZ6f3AQ==", "26fd3f78-f88a-4190-ba0d-450824b0015d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "916862e3-1bf0-46b2-a1f0-0b5623ca9a3b", "AQAAAAIAAYagAAAAEKWpgXpRag+i6eVgjiyTf00Omta0Ty9uPPzJwM2+TjFH9DvGOrgbcBt6X1vUJmbMQA==", "2d986923-afed-47b4-a526-233b081b162d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0212b8e-27f6-499f-9ac8-0eaa7013ea8e", "AQAAAAIAAYagAAAAEO6RZV4DVKSlrst8VyHW5xWjpwcnUx1ZzBZrbDXXgM1XcZsRWuuFPz78zfkmZZPNmQ==", "43a63466-de01-432f-9fbf-92552e46b817" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "657f5f1e-aaff-4b7d-8e61-ea781fd9d751", "AQAAAAIAAYagAAAAENuLieXMkV1+nuz0wxMRQMCo9YVlytr9rrRoBvk6tVXdN0hWgbDd1vfA9/fCSCLfWw==", "b0549e3d-0f4a-4256-a715-60187066a5eb" });
        }
    }
}
