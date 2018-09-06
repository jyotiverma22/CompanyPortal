using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class databaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloodgroup",
                table: "UserRegistration");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRegistration",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BloodGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BloodGroupName = table.Column<string>(nullable: true),
                    Active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_Id",
                table: "UserRegistration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_BloodGroups_Id",
                table: "UserRegistration",
                column: "Id",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_BloodGroups_Id",
                table: "UserRegistration");

            migrationBuilder.DropTable(
                name: "BloodGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserRegistration_Id",
                table: "UserRegistration");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRegistration");

            migrationBuilder.AddColumn<string>(
                name: "Bloodgroup",
                table: "UserRegistration",
                nullable: true);
        }
    }
}
