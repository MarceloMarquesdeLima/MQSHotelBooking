using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adapter.SQL.Migrations
{
    public partial class AddValueObjectToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                table: "Roons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_Value",
                table: "Roons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Roons");

            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "Roons");
        }
    }
}
