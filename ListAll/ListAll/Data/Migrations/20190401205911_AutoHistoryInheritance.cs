using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class AutoHistoryInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AutoHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AutoHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "AutoHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListItem_Name",
                table: "AutoHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AutoHistory",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AutoHistory_ListId",
                table: "AutoHistory",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoHistory_AutoHistory_ListId",
                table: "AutoHistory",
                column: "ListId",
                principalTable: "AutoHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoHistory_AutoHistory_ListId",
                table: "AutoHistory");

            migrationBuilder.DropIndex(
                name: "IX_AutoHistory_ListId",
                table: "AutoHistory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AutoHistory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AutoHistory");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "AutoHistory");

            migrationBuilder.DropColumn(
                name: "ListItem_Name",
                table: "AutoHistory");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AutoHistory");

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ListId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListItem_List_ListId",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListId",
                table: "ListItem",
                column: "ListId");
        }
    }
}
