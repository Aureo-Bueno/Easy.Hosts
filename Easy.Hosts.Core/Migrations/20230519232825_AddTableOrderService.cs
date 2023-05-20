using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddTableOrderService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ORDER_SERVICE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRODUCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMPLOYEE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    ORDER_SERVICE_TYPE = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER_SERVICE", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_TB_ORDER_SERVICE_PRODUCT_ID",
                table: "TB_PRODUCT",
                column: "PRODUCT_ID",
                principalTable: "TB_ORDER_SERVICE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_TB_ORDER_SERVICE_PRODUCT_ID",
                table: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_ORDER_SERVICE");
        }
    }
}
