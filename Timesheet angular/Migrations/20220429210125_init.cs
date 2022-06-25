using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_angular.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projectStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resourceTypes",
                columns: table => new
                {
                    ResourceTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resourceTypes", x => x.ResourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_ClientStatus_ClientStatusId",
                        column: x => x.ClientStatusId,
                        principalTable: "ClientStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectResources",
                columns: table => new
                {
                    ResourceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceTypeId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectResources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_projectResources_resourceTypes_ResourceTypeId1",
                        column: x => x.ResourceTypeId1,
                        principalTable: "resourceTypes",
                        principalColumn: "ResourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    EstimatedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectManagerId = table.Column<long>(type: "bigint", nullable: true),
                    EstimatedTotalHours = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true),
                    ActualTotalHours = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true),
                    EstimatedLaborCost = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true),
                    ActualLaborCost = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true),
                    EstimatedMaterialCost = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true),
                    ActualMaterialCost = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true),
                    ProjectStatusId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_projectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "projectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientStatusId",
                table: "Client",
                column: "ClientStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_projectResources_ResourceTypeId1",
                table: "projectResources",
                column: "ResourceTypeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "projectResources");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "projectStatus");

            migrationBuilder.DropTable(
                name: "resourceTypes");

            migrationBuilder.DropTable(
                name: "ClientStatus");
        }
    }
}
