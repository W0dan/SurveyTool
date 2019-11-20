using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyTool.EntityFramework.Migrations
{
    public partial class AddTypeToQuestionPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "QuestionPart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "QuestionPart");
        }
    }
}
