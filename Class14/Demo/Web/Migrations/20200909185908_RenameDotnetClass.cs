using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class RenameDotnetClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: ".NET Core");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: ".NET");
        }
    }
}