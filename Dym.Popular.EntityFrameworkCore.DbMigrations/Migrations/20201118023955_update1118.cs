using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Mis_Violation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TookDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fine = table.Column<double>(type: "double", nullable: false),
                    Indemnity = table.Column<double>(type: "double", nullable: false),
                    MaintenanceCost = table.Column<double>(type: "double", nullable: false),
                    IsOutDanger = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Violation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_Violation_App_Mis_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "App_Mis_Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Violation_VehicleId",
                table: "App_Mis_Violation",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_Violation");
        }
    }
}
