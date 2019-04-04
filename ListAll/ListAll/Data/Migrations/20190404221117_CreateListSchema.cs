using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class CreateListSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "HistoryChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowId = table.Column<string>(maxLength: 50, nullable: true),
                    TableName = table.Column<string>(maxLength: 128, nullable: true),
                    Changed = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false),
                    _DeleteDate = table.Column<DateTime>(nullable: true),
                    _InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryChanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    _DeleteDate = table.Column<DateTime>(nullable: true),
                    _InsertDate = table.Column<DateTime>(nullable: false)
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
                    ListId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    _DeleteDate = table.Column<DateTime>(nullable: true),
                    _InsertDate = table.Column<DateTime>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryChanges");

            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "List");

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
