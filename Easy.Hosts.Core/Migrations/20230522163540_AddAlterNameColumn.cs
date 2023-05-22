using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddAlterNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TB_BOOKING",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "TB_BOOKING",
                newName: "TOTAL_VALUE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "TB_BOOKING",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TOTAL_VALUE",
                table: "TB_BOOKING",
                newName: "TotalValue");
        }
    }
}
