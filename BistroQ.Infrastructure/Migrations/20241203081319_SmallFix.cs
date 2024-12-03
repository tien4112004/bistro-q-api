using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SmallFix : Migration
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
                value: new DateTime(2024, 12, 3, 15, 13, 17, 787, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 12, 3, 15, 13, 17, 787, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 12, 3, 15, 13, 17, 787, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b005686-16a7-4e15-a7c6-4362b7d4fd38", "AQAAAAIAAYagAAAAEDJkXWTvd7tgraGFWEeGJ0do/fe8FmYLXD02XB4OplfPUxE9/i6Kh8/RiATtqE3CqQ==", "4d1144b9-2c53-45b7-8ed1-00c616f1e2a2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "995b0989-a779-4463-ae24-247f3c145b63", "AQAAAAIAAYagAAAAEH3Onidji5hwpHY+jWL7YUiuUcddDKTvK7GSwmZ12lKC5hqRxmJTFZOTsnxekDMB9w==", "ec54dd79-a7dc-4bc9-ac66-57050b5f2cfa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5729292e-5fcd-4395-a1a7-0ddaae448eb5", "AQAAAAIAAYagAAAAELyy9bllbgGxy1b6JydZ5tqLO0sLS8lDS7iriF6AkH/yonV8sETh734nV9MxMysvSQ==", "03e6d609-4f19-4baf-9039-fd9d2d88a67f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "052de722-733c-4406-88f1-1aa3b0fb27ae", "AQAAAAIAAYagAAAAEMuqgeC54fd+aXCExz2i18ciAHz9SUpp96tQxCKfWYYtMV3yoVxPGyDHTGom2HcVew==", "fe0e611d-661e-43fd-b3a3-8b3090370053" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09b9d794-15f0-42f1-b14a-1440824f91c0", "AQAAAAIAAYagAAAAEPdNay0jpp/uTSU3U7a56bTEuNwm3LTbkWO5Fv5i7Y0CPw9y1ruZCc5YdZcddgHyKA==", "a9d50b6f-be5d-476a-a5fd-624b922a96bf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eff7af99-a1be-444c-b09d-35253eb4186c", "AQAAAAIAAYagAAAAECgabnCOdC2DV1vieAwQM241RBUWTgr1ylV+iidG2BLxmh3H7Lt758WGbt55Kzu0Sg==", "7cfde48a-4c7e-4f12-aad2-507f7464f190" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f56da55-6980-4b49-9a28-119151f7379d", "AQAAAAIAAYagAAAAEDF9chYqFV6TYoSOiJY/s+5dG8JJN1K/+SgJPqc7xjrzN9OIG3QEJpto6WH0Znl57w==", "3fcab44f-15ed-4c0b-bfde-bada4ddf637b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86a9c220-dfa5-4ee0-aa04-8dd12458d343", "AQAAAAIAAYagAAAAEKGXS44NypHSGrkCBzovGujhsRgdw+oiFvISU2YrruOlY+foI6YQWdc/4+DrT083Yw==", "d4820224-1a92-4349-8cf7-ea7b6953c285" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28e298b8-3e1d-428d-9d6d-17277aebe0ea", "AQAAAAIAAYagAAAAEH4LJix4zqAdhtEEZymE3WSncvpJPkeKrGXgXeUj4dDucgniOSMMmGOq5O/HR3tqbg==", "54f53555-3db2-46f8-af3f-7fbc2e64fa3b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f54d17ed-63ed-4d22-ab98-3f8164ff9c10", "AQAAAAIAAYagAAAAEPfBcK4i2Leu3uiGFHukMcCBHrBUZl1Npqf3ilOptj/Hdv1UlIujm+GNOhw9fWqwhg==", "936ceabd-dca8-4d8d-9e17-3a4f49f6dd45" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6a030c0-fee4-433d-bdfc-09dd518ce141", "AQAAAAIAAYagAAAAEDm+F9N6wHDy94yFXePrO5WyN8DFNCXItMLc+k/muFjhFKLJ+A2+a88r9ste9ZaNUA==", "cef3f75e-53fc-41d0-aaf1-82c914e74c17" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59db3917-3984-49c0-b530-ef58a027e8ce", "AQAAAAIAAYagAAAAENURK6u6TZ/M42peq920AATeLlOV+pnUyAwZhG0KbVp25WxhjftwBGv84IjI6ULSsw==", "7a9397c0-f46f-417f-8951-bb90ca943dae" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b84b9af-df11-460f-90be-32e894c9ab16", "AQAAAAIAAYagAAAAEPZA68XbgxoGeWboDeVIUVrwjc7PcxQ2iU027cwCxzcF99Rval4kfcbkUyj1pOKhnQ==", "9e762ebf-4b75-45af-970f-ef14e5f86825" });
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
                value: new DateTime(2024, 11, 23, 13, 29, 32, 857, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2024, 11, 23, 13, 29, 32, 857, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2024, 11, 23, 13, 29, 32, 857, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcf53321-77e2-421a-a9d7-24545db984ab", "AQAAAAIAAYagAAAAEOFBcKKHqanfV5CdOZJwZb1bIBAU6eXiq3c2AK0Gh4GPxq6rneAV3dKf2NcBJtsGlw==", "155c00a6-546d-49ac-85fa-c0cf557b851b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d744fead-418c-41b4-9588-8abed9d88763", "AQAAAAIAAYagAAAAEKVn4wCDgxaPjZgpqoZVP8YlR37ubn+wTkwu7Aomzj9H0ntUaGtbg9hyDnuSayheUQ==", "bc69656f-92e7-4e62-a46e-b3883bc934e4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0655542b-0d5d-4272-8124-c923b4da61cc", "AQAAAAIAAYagAAAAEA9szq4RrnTj2cUrUejqXNvpHB5mZX51xZ9snP8zTwbIAM1MnJCZXyvdbV72ElUnmg==", "dca7ce28-a8c9-4759-aac0-87a350497c07" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a67955a0-914e-4ce3-8329-e482d9f8968c", "AQAAAAIAAYagAAAAEEFGvrvJKCMCH19D2hxoPmfNynTVjamAYMzhot2MEgxro0HCOZDKH8i5eluPzqxigw==", "ddc42576-b0ea-4b8b-9878-a45e2c16c390" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc4c5ac-fc63-45b0-b081-27130d45cbc5", "AQAAAAIAAYagAAAAEDD+lsXNYaP7Y77/Ea3a8xHZeRWhFwXHNPRPqAFgVZTnH0boZEI4RDEJa3v39WARDw==", "b7fa8609-f780-4fa8-adc3-367383de3503" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397ca3be-ffc8-4408-88bf-01b2f580326a", "AQAAAAIAAYagAAAAEAdIzz45N7L5H0E//gSBBRtT2Y+f1rbjuV5b+oDRoZse/Ex4M+zKeK9M+Py/1COsmA==", "b05778f8-0f1a-4fc3-a60e-584c026af420" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03465457-cf48-4a35-8637-b98978530b9b", "AQAAAAIAAYagAAAAELQ0B18pcbEW9dFAbL01+LydaO+9CN+j1XRXokEmQZKHf2mPUCcuLQoz4gN2J8medA==", "af8d94d9-27ce-44b2-9bb1-00b6e331b8b5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c10edde-3b67-4bad-aa70-23e7b486eb1a", "AQAAAAIAAYagAAAAENa8CWutoNM1El6nLt0qbfJXqareRFloGQg/bESByNOWzlk8cJ0sywf4XdpDspAL1A==", "f6b2298c-088b-49e9-b114-88e3fe087eca" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be9a0bd0-c4c3-488e-ae59-fc16d8327aa5", "AQAAAAIAAYagAAAAEP3WNapmRSSdpzNxFKj96l8SC1K9jPVrkCmMAi4HUt5IoZigQeHqNAHaPgOYhfv6ng==", "7d1cd2a4-cace-4385-83f3-d800fd8485ce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ce245d9-fe13-4c3b-9f6e-0b298b4154db", "AQAAAAIAAYagAAAAEMQW3zlGr0ma5X9D/BkfccKV0L+42y84x6o55zHOokGOreN1aHU8rlSyD9NFu7u0gw==", "50b2b925-84ed-4282-89f3-50bc0883ad3c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c90fdc7-41f2-4f31-aa30-ccf77e235952", "AQAAAAIAAYagAAAAEO/F1pnlG0cZ0iwrkjbVPFI6tjIlOktfVaAC6MPxzgG2VpisiAWxcobfTRSh/aLdyg==", "fbcf96fe-1171-4c92-85e8-2492fd98d0ef" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0918fbb-ff71-4c59-b6f7-c814597f3f89", "AQAAAAIAAYagAAAAEOzIZJgpT7MdSwKjj2Q4dvdrTvfiXajdeYfCA15nutFP18ukKeHOEdT1zb5XikrxCQ==", "67d1b8bb-07d0-4db8-8e57-4667986dae4a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3501d27-10c3-42cb-9150-1a7dd35927d2", "AQAAAAIAAYagAAAAEOlgIYu4qmPwb96XSt9dIupqseMMiLDEzujpYkdFmORGrck0zUkDoMmxXvlvTTkKPw==", "d8e1473c-47bc-48e8-9987-a42a83f07fe5" });
        }
    }
}
