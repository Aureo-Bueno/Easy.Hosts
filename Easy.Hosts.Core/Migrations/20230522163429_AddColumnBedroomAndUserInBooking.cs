using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddColumnBedroomAndUserInBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TB_TYPE_BEDROOM",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TB_TYPE_BEDROOM",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TB_PRODUCT",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TB_PRODUCT",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TB_EVENT",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TB_EVENT",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TB_BOOKING",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TB_BOOKING",
                newName: "CREATED_AT");

            migrationBuilder.AddColumn<string>(
                name: "BedroomId",
                table: "TB_BOOKING",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Checkin",
                table: "TB_BOOKING",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Checkout",
                table: "TB_BOOKING",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CodeBooking",
                table: "TB_BOOKING",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TB_BOOKING",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "TB_BOOKING",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TB_BOOKING",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_BOOKING_UserId",
                table: "TB_BOOKING",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_UserId",
                table: "TB_BOOKING",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_TB_BEDROOM_BOOKING_ID",
                table: "TB_BOOKING",
                column: "BOOKING_ID",
                principalTable: "TB_BEDROOM",
                principalColumn: "BEDROOM_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_UserId",
                table: "TB_BOOKING");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_TB_BEDROOM_BOOKING_ID",
                table: "TB_BOOKING");

            migrationBuilder.DropIndex(
                name: "IX_TB_BOOKING_UserId",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "BedroomId",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "Checkin",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "Checkout",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "CodeBooking",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "TB_BOOKING");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TB_BOOKING");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "TB_TYPE_BEDROOM",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "TB_TYPE_BEDROOM",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "TB_PRODUCT",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "TB_PRODUCT",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "TB_EVENT",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "TB_EVENT",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "TB_BOOKING",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "TB_BOOKING",
                newName: "CreatedAt");
        }
    }
}
