using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.CleanArch.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedIsEnabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Game",
                newName: "IsEnabled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEnabled",
                table: "Game",
                newName: "IsDeleted");
        }
    }
}
