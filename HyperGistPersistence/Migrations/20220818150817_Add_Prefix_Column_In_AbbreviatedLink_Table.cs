using Microsoft.EntityFrameworkCore.Migrations;

namespace HyperGistPersistence.Migrations
{
    public partial class Add_Prefix_Column_In_AbbreviatedLink_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "abbreviationLinkCounters",
                newName: "AbbreviationLinkCounters");

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "AbbreviationLinks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "AbbreviationLinks");

            migrationBuilder.RenameTable(
                name: "AbbreviationLinkCounters",
                newName: "abbreviationLinkCounters");
        }
    }
}
