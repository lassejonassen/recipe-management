using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MateriaLDefinitionStateAndVersionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "MaterialDefinitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Draft",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "MaterialDefinitions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Draft");
        }
    }
}
