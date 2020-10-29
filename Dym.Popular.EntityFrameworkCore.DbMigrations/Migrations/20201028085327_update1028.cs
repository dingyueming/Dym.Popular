using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1028 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Dict_DictTypeEntityId",
                table: "App_Mis_Dict",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_App_Mis_Dict_App_Mis_DictType_DictTypeEntityId",
                table: "App_Mis_Dict",
                column: "TypeId",
                principalTable: "App_Mis_DictType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App_Mis_Dict_App_Mis_DictType_DictTypeEntityId",
                table: "App_Mis_Dict");

            migrationBuilder.DropIndex(
                name: "IX_App_Mis_Dict_DictTypeEntityId",
                table: "App_Mis_Dict");

            migrationBuilder.DropColumn(
                name: "DictTypeEntityId",
                table: "App_Mis_Dict");
        }
    }
}
