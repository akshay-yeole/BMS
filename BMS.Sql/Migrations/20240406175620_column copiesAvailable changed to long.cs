using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMS.Sql.Migrations
{
    public partial class columncopiesAvailablechangedtolong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CopiesAvailable",
                table: "Books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CopiesAvailable",
                table: "Books",
                type: "bit",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
