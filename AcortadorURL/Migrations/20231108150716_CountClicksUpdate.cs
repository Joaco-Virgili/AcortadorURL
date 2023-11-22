using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcortadorURL.Migrations
{
    public partial class CountClicksUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountClicks",
                table: "Urls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CountClicks",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CountClicks",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountClicks",
                table: "Urls");
        }
    }
}
