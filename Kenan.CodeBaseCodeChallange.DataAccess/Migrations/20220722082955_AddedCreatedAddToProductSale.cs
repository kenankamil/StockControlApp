using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenan.CodeBaseCodeChallange.DataAccess.Migrations
{
    public partial class AddedCreatedAddToProductSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductSales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 11, 29, 55, 612, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 22, 11, 29, 55, 611, DateTimeKind.Local).AddTicks(8827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProductSales");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 22, 11, 29, 55, 611, DateTimeKind.Local).AddTicks(8827));
        }
    }
}
