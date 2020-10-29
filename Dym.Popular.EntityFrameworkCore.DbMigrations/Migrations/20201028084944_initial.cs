using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Mis_Dict",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Dict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Mis_DictType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_DictType", x => x.Id);
                });

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
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Liaison = table.Column<string>(maxLength: 18, nullable: true),
                    Telephone = table.Column<string>(maxLength: 18, nullable: true),
                    VehicleCount = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Popular_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(maxLength: 20, nullable: false),
                    RoleDescription = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Popular_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Popular_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    RealName = table.Column<string>(maxLength: 20, nullable: true),
                    Telephone = table.Column<string>(maxLength: 11, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Popular_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Mis_Driver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Sex = table.Column<int>(maxLength: 10, nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Hiredate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(nullable: true),
                    IdNo = table.Column<string>(maxLength: 18, nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    FirstIssueDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_Driver_App_Mis_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "App_Mis_Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_Mis_Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDelete = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    License = table.Column<string>(nullable: true),
                    InteriorCode = table.Column<string>(nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(maxLength: 10, nullable: true),
                    EngineNo = table.Column<string>(maxLength: 50, nullable: true),
                    Vin = table.Column<string>(maxLength: 50, nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Displacement = table.Column<string>(maxLength: 10, nullable: true),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ActivationTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Mis_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Mis_Vehicle_App_Mis_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "App_Mis_Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_DictType_Name",
                table: "App_Mis_DictType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Driver_UnitId",
                table: "App_Mis_Driver",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Mis_Unit_Name",
                table: "App_Mis_Unit",
                column: "Name",
                unique: true);

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
                name: "IX_App_Mis_Vehicle_UnitId",
                table: "App_Mis_Vehicle",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Mis_Dict");

            migrationBuilder.DropTable(
                name: "App_Mis_DictType");

            migrationBuilder.DropTable(
                name: "App_Mis_Driver");

            migrationBuilder.DropTable(
                name: "App_Mis_Vehicle");

            migrationBuilder.DropTable(
                name: "App_Popular_Role");

            migrationBuilder.DropTable(
                name: "App_Popular_User");

            migrationBuilder.DropTable(
                name: "App_Mis_Unit");
        }
    }
}
