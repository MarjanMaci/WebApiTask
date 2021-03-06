using Microsoft.EntityFrameworkCore.Migrations;

namespace SoproWA.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPersonRole");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.AddColumn<int>(
                name: "PersonRole",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonRole",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PersonPersonRole",
                columns: table => new
                {
                    Peopleid = table.Column<int>(type: "int", nullable: false),
                    PersonRolesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPersonRole", x => new { x.Peopleid, x.PersonRolesid });
                    table.ForeignKey(
                        name: "FK_PersonPersonRole_PersonRole_PersonRolesid",
                        column: x => x.PersonRolesid,
                        principalTable: "PersonRole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPersonRole_Persons_Peopleid",
                        column: x => x.Peopleid,
                        principalTable: "Persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPersonRole_PersonRolesid",
                table: "PersonPersonRole",
                column: "PersonRolesid");
        }
    }
}
