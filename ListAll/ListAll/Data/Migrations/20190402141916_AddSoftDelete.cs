using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class AddSoftDelete : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "List",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "List",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetUserTokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetUserLogins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_DeleteDate",
                table: "AspNetRoleClaims",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "_InsertDate",
                table: "AspNetRoleClaims",
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

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "List");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "List");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "_DeleteDate",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "_InsertDate",
                table: "AspNetRoleClaims");
        }
    }
}
