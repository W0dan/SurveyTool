using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyTool.EntityFramework.Migrations
{
    public partial class CreateTable_Page : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_SurveyId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyPageId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SurveyPage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SurveyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyPage_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyPageId",
                table: "Question",
                column: "SurveyPageId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPage_SurveyId",
                table: "SurveyPage",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_SurveyPage_SurveyPageId",
                table: "Question",
                column: "SurveyPageId",
                principalTable: "SurveyPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_SurveyPage_SurveyPageId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "SurveyPage");

            migrationBuilder.DropIndex(
                name: "IX_Question_SurveyPageId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SurveyPageId",
                table: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyId",
                table: "Question",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Survey_SurveyId",
                table: "Question",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
