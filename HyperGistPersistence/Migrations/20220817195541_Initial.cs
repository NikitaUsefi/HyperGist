using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HyperGistPersistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abbreviationLinkCounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastCount = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperGistDomain.AbbreviatedLinkCounterId", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AbbreviationLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortLink = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FullLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperGistDomain.AbbreviatedLinkId", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbbreviatedLink_ShortLink",
                table: "AbbreviationLinks",
                column: "ShortLink",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abbreviationLinkCounters");

            migrationBuilder.DropTable(
                name: "AbbreviationLinks");
        }
    }
}
