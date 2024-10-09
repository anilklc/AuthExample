using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthExample.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _09102024mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EndpointId",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endpoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoint_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_EndpointId",
                table: "AspNetRoles",
                column: "EndpointId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoint_MenuId",
                table: "Endpoint",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Endpoint_EndpointId",
                table: "AspNetRoles",
                column: "EndpointId",
                principalTable: "Endpoint",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Endpoint_EndpointId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Endpoint");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_EndpointId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "EndpointId",
                table: "AspNetRoles");
        }
    }
}
