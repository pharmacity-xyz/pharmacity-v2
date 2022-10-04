using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Members_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Freight",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ShippedDate",
                table: "Orders",
                newName: "ShipDate");

            migrationBuilder.RenameColumn(
                name: "RequiredDate",
                table: "Orders",
                newName: "OrderedDate");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderDetails",
                newName: "Price");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Members");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "ShipDate",
                table: "Orders",
                newName: "ShippedDate");

            migrationBuilder.RenameColumn(
                name: "OrderedDate",
                table: "Orders",
                newName: "RequiredDate");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetails",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Freight",
                table: "Orders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "OrderDetails",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Members_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Members",
                principalColumn: "UserId");
        }
    }
}
