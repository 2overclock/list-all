using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class ExpandList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "List",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_List_ParentId",
                table: "List",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_List_List_ParentId",
                table: "List",
                column: "ParentId",
                principalTable: "List",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_List_List_ParentId",
                table: "List");

            migrationBuilder.DropIndex(
                name: "IX_List_ParentId",
                table: "List");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "List");
        }
    }
}
