using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Initial : Migration
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
                name: "ProjectStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceStatus",
                columns: table => new
                {
                    ResourceStatusId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceStatus", x => x.ResourceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    ResourceTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.ResourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientSn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ResourceStatusId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceStatus_ResourceStatusId",
                        column: x => x.ResourceStatusId,
                        principalTable: "ResourceStatus",
                        principalColumn: "ResourceStatusId");
                    table.ForeignKey(
                        name: "FK_Resource_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "ResourceTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectSn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ProjectStatusId = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_ProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModelResourceModel",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelResourceModel", x => new { x.ProjectId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ProjectModelResourceModel_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelResourceModel_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskStatusId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<HierarchyId>(type: "hierarchyid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_Task_TaskStatus_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResourceModelTaskModel",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceModelTaskModel", x => new { x.ResourceId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_ResourceModelTaskModel_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceModelTaskModel_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskTime",
                columns: table => new
                {
                    TimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<decimal>(type: "decimal(7,4)", precision: 7, scale: 4, nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTime", x => x.TimeId);
                    table.ForeignKey(
                        name: "FK_TaskTime_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId");
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
                name: "IX_ProjectModelResourceModel_ResourceId",
                table: "ProjectModelResourceModel",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceStatusId",
                table: "Resource",
                column: "ResourceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceTypeId",
                table: "Resource",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceModelTaskModel_TaskId",
                table: "ResourceModelTaskModel",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskStatusId",
                table: "Task",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTime_TaskId",
                table: "TaskTime",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectModelResourceModel");

            migrationBuilder.DropTable(
                name: "ResourceModelTaskModel");

            migrationBuilder.DropTable(
                name: "TaskTime");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "ResourceStatus");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "ClientStatus");
        }
    }
}
