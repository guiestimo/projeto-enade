using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEnade.Migrations
{
    public partial class ImagesMigrationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RespostaAImage",
                table: "QuestaoGabarito",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RespostaBImage",
                table: "QuestaoGabarito",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RespostaCImage",
                table: "QuestaoGabarito",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RespostaDImage",
                table: "QuestaoGabarito",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RespostaEImage",
                table: "QuestaoGabarito",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaAImage",
                table: "QuestaoGabarito");

            migrationBuilder.DropColumn(
                name: "RespostaBImage",
                table: "QuestaoGabarito");

            migrationBuilder.DropColumn(
                name: "RespostaCImage",
                table: "QuestaoGabarito");

            migrationBuilder.DropColumn(
                name: "RespostaDImage",
                table: "QuestaoGabarito");

            migrationBuilder.DropColumn(
                name: "RespostaEImage",
                table: "QuestaoGabarito");
        }
    }
}
