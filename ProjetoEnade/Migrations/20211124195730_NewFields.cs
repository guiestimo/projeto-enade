using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEnade.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DificuldadeQuestao",
                table: "QuestaoGabarito",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoProva",
                table: "QuestaoGabarito",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DificuldadeQuestao",
                table: "QuestaoGabarito");

            migrationBuilder.DropColumn(
                name: "TipoProva",
                table: "QuestaoGabarito");
        }
    }
}
