using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyTool.EntityFramework.Migrations
{
    public partial class Add_DescriptionAndLogo_To_Survey_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Survey",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoImage",
                table: "Survey",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "LogoImage",
                table: "Survey");
        }
    }
}
