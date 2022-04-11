using Microsoft.EntityFrameworkCore.Migrations;

namespace SoproWA.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRole_Persons_Personid",
                table: "PersonRole");

            migrationBuilder.DropIndex(
                name: "IX_PersonRole_Personid",
                table: "PersonRole");

            migrationBuilder.DropColumn(
                name: "Personid",
                table: "PersonRole");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPersonRole");

            migrationBuilder.AddColumn<int>(
                name: "Personid",
                table: "PersonRole",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_Personid",
                table: "PersonRole",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRole_Persons_Personid",
                table: "PersonRole",
                column: "Personid",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
