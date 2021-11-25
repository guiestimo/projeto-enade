using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEnade.Migrations
{
    public partial class RespostaDissertativa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RespostaDissertativa",
                table: "QuestaoGabarito",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaDissertativa",
                table: "QuestaoGabarito");
        }
    }
}
