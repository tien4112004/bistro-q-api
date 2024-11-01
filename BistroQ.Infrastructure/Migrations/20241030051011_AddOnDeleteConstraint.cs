using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOnDeleteConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Order_ibfk_1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "OrderDetail_ibfk_1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "OrderDetail_ibfk_2",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "Product_ibfk_1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "Table_ibfk_1",
                table: "Table");

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

            migrationBuilder.AddForeignKey(
                name: "Order_ibfk_1",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "TableId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "OrderDetail_ibfk_1",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "OrderDetail_ibfk_2",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Product_ibfk_1",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "Table_ibfk_1",
                table: "Table",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Order_ibfk_1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "OrderDetail_ibfk_1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "OrderDetail_ibfk_2",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "Product_ibfk_1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "Table_ibfk_1",
                table: "Table");

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
                values: new object[] { "cebb5033-fcf0-4cbd-84d9-b4ba00a91d20", "AQAAAAIAAYagAAAAEOE1qegBsYW/LuHfXtj4jLYagS2SlFG7hrTziRV7AdUcfieW3o33WDEDUugju57rMQ==", "9b15f27a-a8c5-4298-9cd9-a163f5497ca8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c89a07c9-cfb5-40f7-a0ad-1d69a4cb7bc2", "AQAAAAIAAYagAAAAENuKG4cqOQeTHWAmSnk1WIqrEcBXI42oT8JPvhig7Rj7srIMv8lcaRUbtmHGLODuAA==", "5699b74a-2f0b-4de9-8a87-2de646cad84f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b7f764a-b504-48cf-9fca-a7b01fc63780", "AQAAAAIAAYagAAAAELPwcMF5AiZthQQ58cHawb2COKO1SZOiAo0JmKe5C2VYBcfF5wHAEzRVonFeskoZ2A==", "5d351854-b70a-4849-a7a0-bbccec9acae8" });

            migrationBuilder.AddForeignKey(
                name: "Order_ibfk_1",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "TableId");

            migrationBuilder.AddForeignKey(
                name: "OrderDetail_ibfk_1",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "OrderDetail_ibfk_2",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "Product_ibfk_1",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "Table_ibfk_1",
                table: "Table",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId");
        }
    }
}
