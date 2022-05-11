using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MWayV2.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressState",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkState",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressState",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkState",
                schema: "Identity",
                table: "User");
        }
    }
}
