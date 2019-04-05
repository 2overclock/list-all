using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class UpdateListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "ListItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "ListItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "ListItem");
        }
    }
}
