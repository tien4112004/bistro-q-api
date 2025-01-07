using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiscountPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

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
                value: new DateTime(2025, 1, 7, 16, 47, 31, 946, DateTimeKind.Local).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "2",
                column: "StartTime",
                value: new DateTime(2025, 1, 7, 16, 47, 31, 946, DateTimeKind.Local).AddTicks(9904));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: "3",
                column: "StartTime",
                value: new DateTime(2025, 1, 7, 16, 47, 31, 946, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "DiscountPrice",
                value: 45000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "DiscountPrice",
                value: 22000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "DiscountPrice",
                value: 37000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "DiscountPrice",
                value: 23000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "DiscountPrice",
                value: 37000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "DiscountPrice",
                value: 42000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "DiscountPrice",
                value: 59000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 15,
                column: "DiscountPrice",
                value: 75000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "DiscountPrice",
                value: 52000m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 19,
                column: "DiscountPrice",
                value: 39000m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a7a5fd6-1193-4e54-8e1b-505278e65831", "AQAAAAIAAYagAAAAEKEr2HIfaJCrWN16VnAOgCdmXYxjGSPnAzO3+X9AywKqJWvRwWx6nb7MgKTu2918xw==", "70e2328e-ec90-42b3-ac25-a74772ceca5e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ee88da6-7f32-4463-a3ba-93428fabc899", "AQAAAAIAAYagAAAAEC9LYCDwwJb/Bojp/vQEX85xBfA8WfMZ/Mzx1/C3b7d8Au+WQh0T4V/OR57OGn1GlA==", "a2d00759-20ab-4b12-86cc-0c04129c9f41" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a061b48-abee-4ac3-b334-72856a585f31", "AQAAAAIAAYagAAAAEHOTb8SKmDkdlzQDVhaii0Xc1RNjGoBk4Op/r2uzmmZG4T1wM7Y/4rjedf0mxEdLvA==", "e271119e-1395-4ff5-bf16-003154bfaa54" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ce6624b-99c3-47c3-88aa-7f3596860778", "AQAAAAIAAYagAAAAEPXT8iPz46xTMPQKphshTDiRTgDAWEw6rWpKeRdqrjG+m4qKUwyM2f1UBy2u79GlNw==", "a345281b-ec34-467d-8bd2-7f36da17c093" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a1e41dc-a05f-4c4a-ac65-d69f3dd22727", "AQAAAAIAAYagAAAAEEZYlLh4/8UJLht56t0Wktz4T8SiYUqM65SU/B8dQYJ27pvT9DklG5lT0iknQoOKwA==", "0f5baabd-50f9-4a97-b10d-5c74b876fb67" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab7fc249-71b1-4882-ad5c-e4e9a4b4884d", "AQAAAAIAAYagAAAAEG63E/YwJsg8r0nG0AeexxfeEAJ60GLp5cgZgSpC98CL3+HAUIyJar8Xi7zl38/t7Q==", "b33f70ce-8d6d-4f20-bfa3-2283fe3ac93b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7cdcca6-904d-47c2-be53-4d49a55bd9b9", "AQAAAAIAAYagAAAAEOdbrzEecahNZz8Mpnykhe0cBodVDMyTTserhR4xGWcN998r83m7Bp1I1bXoilBt/w==", "e909ce26-43b5-4522-a0ca-139ee6b2de53" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "783a8fc4-fe13-4fe1-bc89-176e54976426", "AQAAAAIAAYagAAAAEAFoTCnKuxFk+wlQnXRdCKLLSzUZzJA+p5/Bz3s82KjiGv2UxyQopoX6bJ1at5oKDw==", "988e2a9c-7513-4747-a443-4102897b233e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffc73607-4491-4207-9632-f178b7b4c14c", "AQAAAAIAAYagAAAAEMEj1UjlXp2E2qDZoRruftUWSPJDfGrGuWD8c6OZg+ADHBPEXCiC/m6/LZLHiyUmvQ==", "28250322-0539-4b76-9506-e0211592b953" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91bff642-5d51-4e7f-a5ad-18f3e94cb0ab", "AQAAAAIAAYagAAAAEJR3nq/WvuvfAKtHJY0eaoOFThlwZIRY6rpVkHwt+ktal1kQjuaP+rYRrLORfuH8zQ==", "10049a27-5874-4c3b-aa97-d28c1647894b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fef0f12-40ed-499a-a915-52b6816a7421", "AQAAAAIAAYagAAAAENINJROM1QGgW4plvtzLQL/iJfGp45aksTx3j3yBeg+ek0/IwKxbkRSqx3lzGo4EaQ==", "43db9469-749d-4f70-b634-50a8291fe130" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bf8f00d-edb0-46f6-a583-6c4d58110fc1", "AQAAAAIAAYagAAAAEIYKV0G13tuxdi75Bx8jM/4iM9XaBDWv9xS45tNG1EvquhluU+uijSH0wDJauKvIzA==", "57479e34-b2a8-46a0-80ad-3bb1620c6dfb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c9791bb-bd40-49d1-80cc-44bdb7903ca3", "AQAAAAIAAYagAAAAEHVHCSq61b5AlWQqcbWrfB+D1jEzFtHno44GLIhftE9rrKHzNyyoaBkiDgDWulbjXA==", "4b34bf93-2786-42c4-8b2d-958c523ea06b" });
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

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ContentType", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), "image/jpeg", "french-onion-soup.jpg" });

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
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 15,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "DiscountPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 19,
                column: "DiscountPrice",
                value: 0m);

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
                values: new object[] { 14, 2, 0m, new Guid("00000000-0000-0000-0000-000000000014"), "French Onion Soup", 70000m, "Bowl" });
        }
    }
}
