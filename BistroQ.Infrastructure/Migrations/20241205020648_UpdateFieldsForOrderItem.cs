using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldsForOrderItem : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItem",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItem",
                type: "datetime(6)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Order",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "1",
                columns: new[] { "Note", "StartTime" },
                values: new object[] { null, new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8406) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                columns: new[] { "Note", "StartTime" },
                values: new object[] { null, new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8551) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                columns: new[] { "Note", "StartTime" },
                values: new object[] { null, new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "4",
                column: "Note",
                value: null);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "5",
                column: "Note",
                value: null);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "6",
                column: "Note",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "101",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8246), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "102",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8267), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "103",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8273), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "104",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8279), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "105",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8284), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "106",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8290), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "107",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8296), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8297) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "108",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8303), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "201",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8308), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "202",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8315), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "203",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8321), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "204",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8329), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8329) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "205",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8337), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "301",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8343), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "302",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8351), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8360) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "401",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8383), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "501",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8391), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: "601",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8400), new DateTime(2024, 12, 5, 9, 6, 47, 728, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2604dd40-5b32-4a8e-a049-d317d328e4d1", "AQAAAAIAAYagAAAAEBJ+bkS1iIpInKNEKqrFOk1ZuJrDnb5qgVI62ZLl67av+9di3ofUqqJSvDX6F1a1Cg==", "b03ba9a0-240b-4094-9181-288c144dda66" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60ae42ec-6211-40cf-a715-0162fe574d1e", "AQAAAAIAAYagAAAAEH6I+u4efSPy2qKD8wWuKmliECYprIMjXJoZFfLgNAtIRktbI3JRWScAKUwskwqlVg==", "95fcc300-561d-4db1-8e08-ed4e85c125ff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20f8ca5b-b691-4dcd-8422-4f1dbc6d6fe0", "AQAAAAIAAYagAAAAECvSZ2CdgCV6fT/4QxnCBzxJ0oIGKgQUO39SD+/RVpmF8ChjS2KBXYNjMDe9ONYq7Q==", "460ed18d-be88-493b-a504-2bd16c34fded" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "254f82f6-609b-4e17-a0e9-904232fbf688", "AQAAAAIAAYagAAAAEJt4lpBfBVqepjwZ02QtSlSgELg7KuXKRzD1en2uFj2na+FzVHUW9UQy/P+m3itwyQ==", "f7965abb-e6d4-4b6d-9017-bb61487ac7ee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921c341e-6ec0-47b5-8ce1-529840de2340", "AQAAAAIAAYagAAAAEBDlOkzYqQRC37RGrCYm2yFUJkdrO6aUpnaZUZKFdtigNbeQDzCbrG4HPviv/NlQPg==", "68093440-dfc9-47e5-8e89-587ca47c48ce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5745efc-144c-47bf-9440-d06383276fef", "AQAAAAIAAYagAAAAEC2DphjrC+O1j0j1JDqxkWWYiUJYNG1p+Jkh1NTmtCrnInSMRC90a3qnOmqWeuJqaQ==", "b34b745c-ff18-41d9-9164-4857408e536b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3e83f45-09d0-4670-b00e-c53485918ade", "AQAAAAIAAYagAAAAENzSthG190oQyjJk+kKVntEITCLiSYfbt+rNK9EtoFlAFZvgDtT1jHu5qKRlX4KE/w==", "ff10dfa2-ad6e-442a-a202-cef146e0a684" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c23208f7-7e3b-4fda-92e1-901f37e30b92", "AQAAAAIAAYagAAAAECFfpGNFs+aZOOKP21dLcw/5hTnb5W0zMhwU2ItNcDs+YJlluC6j2bvixSdhSo817A==", "bb4bc98d-9b9e-44e2-96b5-ed34754cb250" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78e36084-2b75-4016-ad19-b0586e0742cc", "AQAAAAIAAYagAAAAEIgZKjYy6utwr1z0nmf36Xgg9PIqiKS6UPqmKgNRNURjPJooSChbfV4sFznt+Xjrkg==", "45e74c8e-12db-498d-937a-96ad5be11d44" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffb6923f-8d41-4323-92f3-b553950bb4dd", "AQAAAAIAAYagAAAAEE6jFecDAdnbh57wGsLbZaZra6wo6EnazBY4z07faCu6G6+symbJBFQ4vW52zbt12w==", "b20eb845-a2f2-48ef-b0bd-4d3927119034" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abeabd97-0e22-407d-aab9-5245c8c1e45c", "AQAAAAIAAYagAAAAEPBuQOSmLuovUHnj32jJ/IgYFKJ07Zy0aosOwAhRFBFEUoQ+mZxR3Kt5nj0f55JkXQ==", "16b65b98-6dbb-4fc2-87c3-2dd5b0760c2a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d9431d6-0645-41ff-8cbf-067c0cece236", "AQAAAAIAAYagAAAAEBk0LKE4veP4h507Y3k55Jl4rqOOgM/5ZG3W85BPTQmZIjw0CgLZuqj6T0NXW8tLIQ==", "9ecdf3d1-b88f-4cbc-8a02-dec80aef6b69" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6f13167-2387-461a-a543-1f508c472db3", "AQAAAAIAAYagAAAAEDQIWhjMMQBU8EiK89o+qwV7Xzm7Q12mDJ5TLYE15rSvgqWASi8t7/uq4dU8g/bXiw==", "df8deb9d-00ee-4821-9806-75768c204704" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Order");

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
    }
}
