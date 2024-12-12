using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksTrackingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Workspaces_WorkspaceId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Cards_WorkspaceId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "WorkspaceId",
                table: "Cards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cards",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ListCardId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CardLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkspaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardLists_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ListCardId",
                table: "Cards",
                column: "ListCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardLists_WorkspaceId",
                table: "CardLists",
                column: "WorkspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardLists_ListCardId",
                table: "Cards",
                column: "ListCardId",
                principalTable: "CardLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardLists_ListCardId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CardLists");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ListCardId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ListCardId",
                table: "Cards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cards",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkspaceId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_Cards_ListId",
                        column: x => x.ListId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_WorkspaceId",
                table: "Cards",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_ListId",
                table: "Columns",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Workspaces_WorkspaceId",
                table: "Cards",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id");
        }
    }
}
