using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maido.Migrations
{
    /// <inheritdoc />
    public partial class ActivaMesastable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activa",
                table: "Mesas",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activa",
                table: "Mesas");
        }
    }
}
