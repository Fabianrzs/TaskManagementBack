using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class changemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_IdManage",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_IdManage",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IdManage",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IdUser",
                table: "Projects",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_IdUser",
                table: "Projects",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_IdUser",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_IdUser",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "IdManage",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Owner = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => new { x.IdUser, x.IdProject });
                    table.ForeignKey(
                        name: "FK_Collaborators_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborators_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdManage",
                table: "Tasks",
                column: "IdManage");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_IdProject",
                table: "Collaborators",
                column: "IdProject");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_IdManage",
                table: "Tasks",
                column: "IdManage",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
