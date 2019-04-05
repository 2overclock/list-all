using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAll.Data.Migrations
{
    public partial class CreateListSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoryChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowId = table.Column<string>(maxLength: 50, nullable: true),
                    TableName = table.Column<string>(maxLength: 128, nullable: true),
                    Change = table.Column<string>(nullable: true),
                    EntityState = table.Column<int>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false)
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
                    _InsertDate = table.Column<DateTime>(nullable: false),
                    _DeleteDate = table.Column<DateTime>(nullable: true)
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
                    Discriminator = table.Column<string>(nullable: false),
                    Uri = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
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
        }
    }
}
