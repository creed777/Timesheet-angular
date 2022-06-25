using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdatedDataAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ClientStatus_ClientStatusId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_projectStatus_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_resourceTypes_ResourceTypeId1",
                table: "ProjectResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_resourceTypes",
                table: "resourceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectStatus",
                table: "projectStatus");

            migrationBuilder.RenameTable(
                name: "resourceTypes",
                newName: "ResourceTypes");

            migrationBuilder.RenameTable(
                name: "projectStatus",
                newName: "ProjectStatus");

            migrationBuilder.RenameColumn(
                name: "ResourceTypeId1",
                table: "ProjectResources",
                newName: "ResourceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectResources_ResourceTypeId1",
                table: "ProjectResources",
                newName: "IX_ProjectResources_ResourceTypeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ResourceTypes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceId",
                table: "ProjectResources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ResourceStatusId",
                table: "ProjectResources",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "ProjectStatusId",
                table: "Project",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ClientStatusId",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTypes",
                table: "ResourceTypes",
                column: "ResourceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ResourceStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResources_ResourceStatusId",
                table: "ProjectResources",
                column: "ResourceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ClientStatus_ClientStatusId",
                table: "Client",
                column: "ClientStatusId",
                principalTable: "ClientStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "ProjectStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_ResourceStatus_ResourceStatusId",
                table: "ProjectResources",
                column: "ResourceStatusId",
                principalTable: "ResourceStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_ResourceTypes_ResourceTypeId",
                table: "ProjectResources",
                column: "ResourceTypeId",
                principalTable: "ResourceTypes",
                principalColumn: "ResourceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ClientStatus_ClientStatusId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_ResourceStatus_ResourceStatusId",
                table: "ProjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectResources_ResourceTypes_ResourceTypeId",
                table: "ProjectResources");

            migrationBuilder.DropTable(
                name: "ResourceStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTypes",
                table: "ResourceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_ProjectResources_ResourceStatusId",
                table: "ProjectResources");

            migrationBuilder.DropColumn(
                name: "ResourceStatusId",
                table: "ProjectResources");

            migrationBuilder.RenameTable(
                name: "ResourceTypes",
                newName: "resourceTypes");

            migrationBuilder.RenameTable(
                name: "ProjectStatus",
                newName: "projectStatus");

            migrationBuilder.RenameColumn(
                name: "ResourceTypeId",
                table: "ProjectResources",
                newName: "ResourceTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectResources_ResourceTypeId",
                table: "ProjectResources",
                newName: "IX_ProjectResources_ResourceTypeId1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "resourceTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResourceId",
                table: "ProjectResources",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProjectStatusId",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientStatusId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_resourceTypes",
                table: "resourceTypes",
                column: "ResourceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectStatus",
                table: "projectStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ClientStatus_ClientStatusId",
                table: "Client",
                column: "ClientStatusId",
                principalTable: "ClientStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_projectStatus_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "projectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectResources_resourceTypes_ResourceTypeId1",
                table: "ProjectResources",
                column: "ResourceTypeId1",
                principalTable: "resourceTypes",
                principalColumn: "ResourceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
