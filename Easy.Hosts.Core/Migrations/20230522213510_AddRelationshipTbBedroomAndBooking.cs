using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddRelationshipTbBedroomAndBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_TB_BEDROOM_BOOKING_ID",
                table: "TB_BOOKING");

            migrationBuilder.AlterColumn<Guid>(
                name: "BEDROOM_ID",
                table: "TB_BOOKING",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_BOOKING_BEDROOM_ID",
                table: "TB_BOOKING",
                column: "BEDROOM_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_TB_BEDROOM_BEDROOM_ID",
                table: "TB_BOOKING",
                column: "BEDROOM_ID",
                principalTable: "TB_BEDROOM",
                principalColumn: "BEDROOM_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_TB_BEDROOM_BEDROOM_ID",
                table: "TB_BOOKING");

            migrationBuilder.DropIndex(
                name: "IX_TB_BOOKING_BEDROOM_ID",
                table: "TB_BOOKING");

            migrationBuilder.AlterColumn<string>(
                name: "BEDROOM_ID",
                table: "TB_BOOKING",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_TB_BEDROOM_BOOKING_ID",
                table: "TB_BOOKING",
                column: "BOOKING_ID",
                principalTable: "TB_BEDROOM",
                principalColumn: "BEDROOM_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
