using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Mis_OilCost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CardNo = table.Column<string>(maxLength: 20, nullable: false),
                    OilTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Expend = table.Column<double>(type: "double", nullable: false),
                    RefuelingTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Balance = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_OilCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_OilCost_App_Mis_Dict_OilTypeId",
                        column: x => x.OilTypeId,
                        principalTable: "App_Mis_Dict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Mis_OilCost_App_Mis_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "App_Mis_Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_OilCost_OilTypeId",
                table: "App_Mis_OilCost",
                column: "OilTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_OilCost_VehicleId",
                table: "App_Mis_OilCost",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_OilCost");
        }
    }
}
