using Microsoft.EntityFrameworkCore.Migrations;

namespace InlämningsUppgift_ApotekWebbsida.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Varumärke",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Varumärke",
                table: "Products");
        }
    }
}
