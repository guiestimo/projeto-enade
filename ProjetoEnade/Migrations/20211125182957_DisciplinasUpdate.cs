using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEnade.Migrations
{
    public partial class DisciplinasUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestoesDisciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdQuestao = table.Column<int>(type: "int", nullable: false),
                    IdDisciplina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestoesDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestoesDisciplinas_Disciplinas_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestoesDisciplinas_QuestaoGabarito_IdQuestao",
                        column: x => x.IdQuestao,
                        principalTable: "QuestaoGabarito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestoesDisciplinas_IdDisciplina",
                table: "QuestoesDisciplinas",
                column: "IdDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_QuestoesDisciplinas_IdQuestao",
                table: "QuestoesDisciplinas",
                column: "IdQuestao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestoesDisciplinas");
        }
    }
}
