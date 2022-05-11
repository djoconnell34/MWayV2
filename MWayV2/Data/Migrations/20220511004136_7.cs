using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MWayV2.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todo",
                schema: "Identity",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDoIsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo", x => x.ToDoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo",
                schema: "Identity");
        }
    }
}
