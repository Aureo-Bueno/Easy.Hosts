using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddAlterNameColumnBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_UserId",
                table: "TB_BOOKING");

            migrationBuilder.RenameColumn(
                name: "Checkout",
                table: "TB_BOOKING",
                newName: "CHECKOUT");

            migrationBuilder.RenameColumn(
                name: "Checkin",
                table: "TB_BOOKING",
                newName: "CHECKIN");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TB_BOOKING",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "CodeBooking",
                table: "TB_BOOKING",
                newName: "CODE_BOOKING");

            migrationBuilder.RenameColumn(
                name: "BedroomId",
                table: "TB_BOOKING",
                newName: "BEDROOM_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TB_BOOKING_UserId",
                table: "TB_BOOKING",
                newName: "IX_TB_BOOKING_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_USER_ID",
                table: "TB_BOOKING",
                column: "USER_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_USER_ID",
                table: "TB_BOOKING");

            migrationBuilder.RenameColumn(
                name: "CHECKOUT",
                table: "TB_BOOKING",
                newName: "Checkout");

            migrationBuilder.RenameColumn(
                name: "CHECKIN",
                table: "TB_BOOKING",
                newName: "Checkin");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "TB_BOOKING",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CODE_BOOKING",
                table: "TB_BOOKING",
                newName: "CodeBooking");

            migrationBuilder.RenameColumn(
                name: "BEDROOM_ID",
                table: "TB_BOOKING",
                newName: "BedroomId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_BOOKING_USER_ID",
                table: "TB_BOOKING",
                newName: "IX_TB_BOOKING_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BOOKING_AspNetUsers_UserId",
                table: "TB_BOOKING",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
