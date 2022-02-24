using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.DataAccess.Migrations
{
    public partial class iniDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InfoTypes",
                columns: new[] { "InfoTypeID", "InfoTypeName" },
                values: new object[] { 1, "Phone Number" });

            migrationBuilder.InsertData(
                table: "InfoTypes",
                columns: new[] { "InfoTypeID", "InfoTypeName" },
                values: new object[] { 2, "E-Mail" });

            migrationBuilder.InsertData(
                table: "InfoTypes",
                columns: new[] { "InfoTypeID", "InfoTypeName" },
                values: new object[] { 3, "Location" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InfoTypes",
                keyColumn: "InfoTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InfoTypes",
                keyColumn: "InfoTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InfoTypes",
                keyColumn: "InfoTypeID",
                keyValue: 3);
        }
    }
}
