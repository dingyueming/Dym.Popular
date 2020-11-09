using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Mis_Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CostTypeId = table.Column<int>(maxLength: 20, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Expend = table.Column<double>(type: "double", nullable: false),
                    RecordTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_Maintenance_App_Mis_Dict_CostTypeId",
                        column: x => x.CostTypeId,
                        principalTable: "App_Mis_Dict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Mis_Maintenance_App_Mis_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "App_Mis_Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Maintenance_CostTypeId",
                table: "App_Mis_Maintenance",
                column: "CostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Maintenance_VehicleId",
                table: "App_Mis_Maintenance",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_Maintenance");
        }
    }
}
