using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "App_Mis_Driver",
                newName: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Driver_ClassId",
                table: "App_Mis_Driver",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Driver_StatusId",
                table: "App_Mis_Driver",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_App_Mis_Driver_App_Mis_Dict_ClassId",
                table: "App_Mis_Driver",
                column: "ClassId",
                principalTable: "App_Mis_Dict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_App_Mis_Driver_App_Mis_Dict_StatusId",
                table: "App_Mis_Driver",
                column: "StatusId",
                principalTable: "App_Mis_Dict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App_Mis_Driver_App_Mis_Dict_ClassId",
                table: "App_Mis_Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_App_Mis_Driver_App_Mis_Dict_StatusId",
                table: "App_Mis_Driver");

            migrationBuilder.DropIndex(
                name: "IX_App_Mis_Driver_ClassId",
                table: "App_Mis_Driver");

            migrationBuilder.DropIndex(
                name: "IX_App_Mis_Driver_StatusId",
                table: "App_Mis_Driver");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "App_Mis_Driver",
                newName: "Status");
        }
    }
}
