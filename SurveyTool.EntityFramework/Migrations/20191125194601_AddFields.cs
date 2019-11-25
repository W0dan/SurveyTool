using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyTool.EntityFramework.Migrations
{
    public partial class AddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "QuestionPartAnswer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "QuestionPart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "QuestionPartAnswer");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "QuestionPart");
        }
    }
}
