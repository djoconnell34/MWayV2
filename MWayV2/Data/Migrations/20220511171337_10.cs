using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MWayV2.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "revenue",
                schema: "dbo",
                columns: table => new
                {
                    RevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Income = table.Column<double>(type: "float", nullable: true),
                    IncomeMonthlyYearly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHolder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenue", x => x.RevenueId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "revenue",
                schema: "dbo");

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
    }
}
