using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "App_Mis_Vehicle",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationTime",
                table: "App_Mis_Vehicle",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Displacement",
                table: "App_Mis_Vehicle",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InteriorCode",
                table: "App_Mis_Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "App_Mis_Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Purpose",
                table: "App_Mis_Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "App_Mis_Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "App_Mis_Driver",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Hiredate",
                table: "App_Mis_Driver",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "App_Mis_Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "App_Mis_Driver",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "App_Mis_Driver",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "App_Mis_Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InteriorCode = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Liaison = table.Column<string>(maxLength: 18, nullable: false),
                    Telephone = table.Column<string>(maxLength: 18, nullable: false),
                    VehicleCount = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Unit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Vehicle_InteriorCode",
                table: "App_Mis_Vehicle",
                column: "InteriorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Vehicle_License",
                table: "App_Mis_Vehicle",
                column: "License",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Unit_Name",
                table: "App_Mis_Unit",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_Unit");

            migrationBuilder.DropIndex(
                name: "IX_App_Mis_Vehicle_InteriorCode",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_App_Mis_Vehicle_License",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "ActivationTime",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "Displacement",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "InteriorCode",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "App_Mis_Vehicle");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "App_Mis_Driver");

            migrationBuilder.DropColumn(
                name: "Hiredate",
                table: "App_Mis_Driver");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "App_Mis_Driver");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "App_Mis_Driver");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "App_Mis_Driver");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "App_Mis_Vehicle",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
