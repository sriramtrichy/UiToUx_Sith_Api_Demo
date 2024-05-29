using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UitoUx.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class hederandsubmenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HederMenu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HederName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HederMenu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "supMenus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<int>(type: "int", nullable: false),
                    SubMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_supMenus_HederMenu_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "HederMenu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supMenus_HeaderId",
                table: "supMenus",
                column: "HeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supMenus");

            migrationBuilder.DropTable(
                name: "HederMenu");
        }
    }
}
