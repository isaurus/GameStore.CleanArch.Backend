using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.CleanArch.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLogicalRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                table: "Game",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Game",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Game");
        }
    }
}
