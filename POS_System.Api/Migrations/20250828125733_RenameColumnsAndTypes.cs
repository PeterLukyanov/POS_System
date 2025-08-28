using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS_System.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsAndTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "Persons",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuPositions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuPositions_OrderId",
                table: "MenuPositions",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPositions_Orders_OrderId",
                table: "MenuPositions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPositions_Orders_OrderId",
                table: "MenuPositions");

            migrationBuilder.DropIndex(
                name: "IX_MenuPositions_OrderId",
                table: "MenuPositions");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MenuPositions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
