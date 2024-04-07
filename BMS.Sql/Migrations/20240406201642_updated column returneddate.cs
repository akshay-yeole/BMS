using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMS.Sql.Migrations
{
    public partial class updatedcolumnreturneddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedDate",
                table: "LibraryTransactions",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedDate",
                table: "LibraryTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }
    }
}
