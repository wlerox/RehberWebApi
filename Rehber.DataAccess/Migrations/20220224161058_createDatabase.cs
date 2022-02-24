using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.DataAccess.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoTypes",
                columns: table => new
                {
                    InfoTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoTypes", x => x.InfoTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoTypeID = table.Column<int>(type: "int", nullable: false),
                    InfoContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonUID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactInfoID);
                    table.ForeignKey(
                        name: "FK_ContactInfos_InfoTypes_InfoTypeID",
                        column: x => x.InfoTypeID,
                        principalTable: "InfoTypes",
                        principalColumn: "InfoTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Persons_PersonUID",
                        column: x => x.PersonUID,
                        principalTable: "Persons",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_InfoTypeID",
                table: "ContactInfos",
                column: "InfoTypeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_PersonUID",
                table: "ContactInfos",
                column: "PersonUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "InfoTypes");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
