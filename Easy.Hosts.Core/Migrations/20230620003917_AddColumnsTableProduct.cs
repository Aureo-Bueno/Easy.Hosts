using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddColumnsTableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NAME_PRODUCT",
                table: "TB_PRODUCT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QUANTITY",
                table: "TB_PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAME_PRODUCT",
                table: "TB_PRODUCT");

            migrationBuilder.DropColumn(
                name: "QUANTITY",
                table: "TB_PRODUCT");
        }
    }
}
