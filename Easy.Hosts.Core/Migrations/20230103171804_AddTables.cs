using Microsoft.EntityFrameworkCore.Migrations;

namespace Easy.Hosts.Core.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BOOKING",
                columns: table => new
                {
                    BOOKING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BOOKING", x => x.BOOKING_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_EVENT",
                columns: table => new
                {
                    EVENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EVENT", x => x.EVENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TYPE_BEDROOM",
                columns: table => new
                {
                    TYPE_BEDROOM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TYPE_BEDROOM", x => x.TYPE_BEDROOM_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BOOKING");

            migrationBuilder.DropTable(
                name: "TB_EVENT");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_TYPE_BEDROOM");
        }
    }
}
