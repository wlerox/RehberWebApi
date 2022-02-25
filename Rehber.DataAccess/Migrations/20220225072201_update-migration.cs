using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.DataAccess.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_InfoTypeID",
                table: "ContactInfos");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_InfoTypeID",
                table: "ContactInfos",
                column: "InfoTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_InfoTypeID",
                table: "ContactInfos");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_InfoTypeID",
                table: "ContactInfos",
                column: "InfoTypeID",
                unique: true);
        }
    }
}
