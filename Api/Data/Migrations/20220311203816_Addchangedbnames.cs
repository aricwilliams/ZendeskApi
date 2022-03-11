using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Addchangedbnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Established",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Tickets",
                newName: "title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Tickets",
                newName: "State");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Established",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Tickets",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
