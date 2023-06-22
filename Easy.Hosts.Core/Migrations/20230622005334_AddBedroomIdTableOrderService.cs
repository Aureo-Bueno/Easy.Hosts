using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddBedroomIdTableOrderService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BEDROOM_ID",
                table: "TB_ORDER_SERVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_SERVICE_BEDROOM_ID",
                table: "TB_ORDER_SERVICE",
                column: "BEDROOM_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ORDER_SERVICE_TB_BEDROOM_BEDROOM_ID",
                table: "TB_ORDER_SERVICE",
                column: "BEDROOM_ID",
                principalTable: "TB_BEDROOM",
                principalColumn: "BEDROOM_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ORDER_SERVICE_TB_BEDROOM_BEDROOM_ID",
                table: "TB_ORDER_SERVICE");

            migrationBuilder.DropIndex(
                name: "IX_TB_ORDER_SERVICE_BEDROOM_ID",
                table: "TB_ORDER_SERVICE");

            migrationBuilder.DropColumn(
                name: "BEDROOM_ID",
                table: "TB_ORDER_SERVICE");
        }
    }
}
