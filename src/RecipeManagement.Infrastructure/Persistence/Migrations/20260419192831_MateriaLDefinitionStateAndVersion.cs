using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MateriaLDefinitionStateAndVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "MaterialDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "MaterialDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "MaterialDefinitions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "MaterialDefinitions");
        }
    }
}
