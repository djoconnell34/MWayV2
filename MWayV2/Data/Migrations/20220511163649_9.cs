using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MWayV2.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Income",
                schema: "dbo",
                table: "budgets",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeMonthlyYearly",
                schema: "dbo",
                table: "budgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncomeName",
                schema: "dbo",
                table: "budgets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                schema: "dbo",
                table: "budgets");

            migrationBuilder.DropColumn(
                name: "IncomeMonthlyYearly",
                schema: "dbo",
                table: "budgets");

            migrationBuilder.DropColumn(
                name: "IncomeName",
                schema: "dbo",
                table: "budgets");
        }
    }
}
