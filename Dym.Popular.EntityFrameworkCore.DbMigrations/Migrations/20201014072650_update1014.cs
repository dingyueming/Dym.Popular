using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_App_User",
                table: "App_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App_Role",
                table: "App_Role");

            migrationBuilder.DropColumn(
                name: "Modifier",
                table: "App_User");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "App_User");

            migrationBuilder.RenameTable(
                name: "App_User",
                newName: "App_Popular_User");

            migrationBuilder.RenameTable(
                name: "App_Role",
                newName: "App_Popular_Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App_Popular_User",
                table: "App_Popular_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App_Popular_Role",
                table: "App_Popular_Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "App_Mis_Driver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Sex = table.Column<int>(maxLength: 10, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdNo = table.Column<string>(maxLength: 18, nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    FileNo = table.Column<string>(maxLength: 12, nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    FirstIssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Mis_Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    License = table.Column<string>(maxLength: 20, nullable: false),
                    Color = table.Column<string>(maxLength: 10, nullable: true),
                    EngineNo = table.Column<string>(maxLength: 50, nullable: true),
                    Vin = table.Column<string>(maxLength: 50, nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Vehicle", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_Driver");

            migrationBuilder.DropTable(
                name: "App_Mis_Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App_Popular_User",
                table: "App_Popular_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App_Popular_Role",
                table: "App_Popular_Role");

            migrationBuilder.RenameTable(
                name: "App_Popular_User",
                newName: "App_User");

            migrationBuilder.RenameTable(
                name: "App_Popular_Role",
                newName: "App_Role");

            migrationBuilder.AddColumn<int>(
                name: "Modifier",
                table: "App_User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "App_User",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_App_User",
                table: "App_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App_Role",
                table: "App_Role",
                column: "Id");
        }
    }
}
