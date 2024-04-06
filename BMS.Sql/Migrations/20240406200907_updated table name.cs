using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMS.Sql.Migrations
{
    public partial class updatedtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_libraryTransactions",
                table: "libraryTransactions");

            migrationBuilder.RenameTable(
                name: "libraryTransactions",
                newName: "LibraryTransactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryTransactions",
                table: "LibraryTransactions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryTransactions",
                table: "LibraryTransactions");

            migrationBuilder.RenameTable(
                name: "LibraryTransactions",
                newName: "libraryTransactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_libraryTransactions",
                table: "libraryTransactions",
                column: "Id");
        }
    }
}
