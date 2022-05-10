using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MWayV2.Migrations
{
    public partial class _2FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "Identity",
                table: "budgets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_budgets_Id",
                schema: "Identity",
                table: "budgets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_budgets_User_Id",
                schema: "Identity",
                table: "budgets",
                column: "Id",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_budgets_User_Id",
                schema: "Identity",
                table: "budgets");

            migrationBuilder.DropIndex(
                name: "IX_budgets_Id",
                schema: "Identity",
                table: "budgets");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Identity",
                table: "budgets");
        }
    }
}
