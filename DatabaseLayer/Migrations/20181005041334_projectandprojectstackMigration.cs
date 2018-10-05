using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class projectandprojectstackMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "Project_TechnologyStacks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_TechnologyStacks_projectId",
                table: "Project_TechnologyStacks",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_TechnologyStacks_Projects_projectId",
                table: "Project_TechnologyStacks",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "PID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_TechnologyStacks_Projects_projectId",
                table: "Project_TechnologyStacks");

            migrationBuilder.DropIndex(
                name: "IX_Project_TechnologyStacks_projectId",
                table: "Project_TechnologyStacks");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "Project_TechnologyStacks");
        }
    }
}
