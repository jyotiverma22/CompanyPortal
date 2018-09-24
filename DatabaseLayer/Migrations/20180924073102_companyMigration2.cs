using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class companyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_UserRegistration_Rep_MgrSno",
                table: "UserRegistration");

            migrationBuilder.DropIndex(
                name: "IX_UserRegistration_Rep_MgrSno",
                table: "UserRegistration");

            migrationBuilder.DropColumn(
                name: "Rep_MgrSno",
                table: "UserRegistration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rep_MgrSno",
                table: "UserRegistration",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_Rep_MgrSno",
                table: "UserRegistration",
                column: "Rep_MgrSno");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_UserRegistration_Rep_MgrSno",
                table: "UserRegistration",
                column: "Rep_MgrSno",
                principalTable: "UserRegistration",
                principalColumn: "Sno",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
