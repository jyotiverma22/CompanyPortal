using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class techStackMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project_TechnologyStacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Technology = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_TechnologyStacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyStacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Technology = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyStacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_TechnologyStacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    technologyStackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_TechnologyStacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_TechnologyStacks_TechnologyStacks_technologyStackId",
                        column: x => x.technologyStackId,
                        principalTable: "TechnologyStacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TechnologyStacks_technologyStackId",
                table: "User_TechnologyStacks",
                column: "technologyStackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project_TechnologyStacks");

            migrationBuilder.DropTable(
                name: "User_TechnologyStacks");

            migrationBuilder.DropTable(
                name: "TechnologyStacks");
        }
    }
}
