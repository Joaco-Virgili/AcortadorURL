using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcortadorURL.Migrations
{
    public partial class AgregadoCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Urls",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Buscador");

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Entretenimiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Urls");
        }
    }
}
