using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyTool.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SurveyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SurveyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionPart_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: true),
                    SurveyAnswerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_SurveyAnswer_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionPartAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionPartId = table.Column<Guid>(nullable: true),
                    QuestionAnswerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPartAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionPartAnswer_QuestionAnswer_QuestionAnswerId",
                        column: x => x.QuestionAnswerId,
                        principalTable: "QuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionPartAnswer_QuestionPart_QuestionPartId",
                        column: x => x.QuestionPartId,
                        principalTable: "QuestionPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyId",
                table: "Question",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_SurveyAnswerId",
                table: "QuestionAnswer",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPart_QuestionId",
                table: "QuestionPart",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPartAnswer_QuestionAnswerId",
                table: "QuestionPartAnswer",
                column: "QuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPartAnswer_QuestionPartId",
                table: "QuestionPartAnswer",
                column: "QuestionPartId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_SurveyId",
                table: "SurveyAnswer",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionPartAnswer");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "QuestionPart");

            migrationBuilder.DropTable(
                name: "SurveyAnswer");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Survey");
        }
    }
}
