using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class update1120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Mis_Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    InsureName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsureCompany = table.Column<string>(nullable: true),
                    InsureType = table.Column<string>(nullable: true),
                    InsureNote = table.Column<string>(type: "longtext", nullable: true),
                    Expend = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Insurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_Insurance_App_Mis_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "App_Mis_Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Insurance_VehicleId",
                table: "App_Mis_Insurance",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_Insurance");
        }
    }
}
