using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Mis_VehicleMileage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(maxLength: 20, nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_VehicleMileage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_VehicleMileage_App_Mis_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "App_Mis_Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_VehicleMileage_VehicleId",
                table: "App_Mis_VehicleMileage",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_VehicleMileage");
        }
    }
}
