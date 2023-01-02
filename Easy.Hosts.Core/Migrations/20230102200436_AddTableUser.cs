using Microsoft.EntityFrameworkCore.Migrations;

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.USER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
