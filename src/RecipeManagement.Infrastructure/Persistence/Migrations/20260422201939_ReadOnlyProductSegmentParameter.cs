using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReadOnlyProductSegmentParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "ProductSegmentParameters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "ProductSegmentParameters");
        }
    }
}
