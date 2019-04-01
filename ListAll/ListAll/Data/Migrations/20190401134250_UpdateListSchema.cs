using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class UpdateListSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ListItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ListItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "ListItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "ListItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "ListItem");
        }
    }
}
