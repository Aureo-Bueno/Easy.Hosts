using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AlterTableOrderService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_TB_ORDER_SERVICE_PRODUCT_ID",
                table: "TB_PRODUCT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_SERVICE_PRODUCT_ID",
                table: "TB_ORDER_SERVICE",
                column: "PRODUCT_ID",
                unique: true,
                filter: "[PRODUCT_ID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ORDER_SERVICE_TB_PRODUCT_PRODUCT_ID",
                table: "TB_ORDER_SERVICE",
                column: "PRODUCT_ID",
                principalTable: "TB_PRODUCT",
                principalColumn: "PRODUCT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ORDER_SERVICE_TB_PRODUCT_PRODUCT_ID",
                table: "TB_ORDER_SERVICE");

            migrationBuilder.DropIndex(
                name: "IX_TB_ORDER_SERVICE_PRODUCT_ID",
                table: "TB_ORDER_SERVICE");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_TB_ORDER_SERVICE_PRODUCT_ID",
                table: "TB_PRODUCT",
                column: "PRODUCT_ID",
                principalTable: "TB_ORDER_SERVICE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
