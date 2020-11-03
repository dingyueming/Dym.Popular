using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "App_Mis_Driver",
                newName: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "App_Mis_Driver",
                newName: "Class");
        }
    }
}
