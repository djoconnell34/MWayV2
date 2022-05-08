using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MWayV2.Data.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressZip",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Identity",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkCity",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkStreet",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkZip",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressCity",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AddressZip",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkCity",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkStreet",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkZip",
                schema: "Identity",
                table: "User");
        }
    }
}
