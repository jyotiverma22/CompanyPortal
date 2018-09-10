using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLayer.Migrations
{
    public partial class CompanyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_BloodGroups_Id",
                table: "UserRegistration");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRegistration",
                newName: "RId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRegistration_Id",
                table: "UserRegistration",
                newName: "IX_UserRegistration_RId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BloodGroups",
                newName: "BId");

            migrationBuilder.AddColumn<int>(
                name: "BId",
                table: "UserRegistration",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DId",
                table: "UserRegistration",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dname = table.Column<string>(nullable: true),
                    Active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Attendence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: true),
                    LogInTime = table.Column<string>(nullable: true),
                    LogOutTime = table.Column<string>(nullable: true),
                    TotalTime = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Emp_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Attendence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Reportings",
                columns: table => new
                {
                    Emp_Rep_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Emp_ID = table.Column<int>(nullable: false),
                    Rep_Mgr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Reportings", x => x.Emp_Rep_Id);
                });

            migrationBuilder.CreateTable(
                name: "Project_Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Mgr_Id = table.Column<int>(nullable: false),
                    Team_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: true),
                    Mgr_Id = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true),
                    Active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_BId",
                table: "UserRegistration",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistration_DId",
                table: "UserRegistration",
                column: "DId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_BloodGroups_BId",
                table: "UserRegistration",
                column: "BId",
                principalTable: "BloodGroups",
                principalColumn: "BId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_Departments_DId",
                table: "UserRegistration",
                column: "DId",
                principalTable: "Departments",
                principalColumn: "DId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_Roles_RId",
                table: "UserRegistration",
                column: "RId",
                principalTable: "Roles",
                principalColumn: "RID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_BloodGroups_BId",
                table: "UserRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_Departments_DId",
                table: "UserRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistration_Roles_RId",
                table: "UserRegistration");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Emp_Attendence");

            migrationBuilder.DropTable(
                name: "Emp_Reportings");

            migrationBuilder.DropTable(
                name: "Project_Teams");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_UserRegistration_BId",
                table: "UserRegistration");

            migrationBuilder.DropIndex(
                name: "IX_UserRegistration_DId",
                table: "UserRegistration");

            migrationBuilder.DropColumn(
                name: "BId",
                table: "UserRegistration");

            migrationBuilder.DropColumn(
                name: "DId",
                table: "UserRegistration");

            migrationBuilder.RenameColumn(
                name: "RId",
                table: "UserRegistration",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserRegistration_RId",
                table: "UserRegistration",
                newName: "IX_UserRegistration_Id");

            migrationBuilder.RenameColumn(
                name: "BId",
                table: "BloodGroups",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistration_BloodGroups_Id",
                table: "UserRegistration",
                column: "Id",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
