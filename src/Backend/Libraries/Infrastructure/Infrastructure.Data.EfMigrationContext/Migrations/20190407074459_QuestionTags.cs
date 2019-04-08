using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.EfMigrationContext.Migrations
{
    public partial class QuestionTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BodyText",
                table: "Questions",
                newName: "Body");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Questions",
                newName: "BodyText");
        }
    }
}
