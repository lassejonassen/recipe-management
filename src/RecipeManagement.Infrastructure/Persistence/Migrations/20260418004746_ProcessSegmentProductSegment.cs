using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProcessSegmentProductSegment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessSegments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Draft"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessSegments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessSegmentParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProcessSegmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessSegmentParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessSegmentParameters_ProcessSegments_ProcessSegmentId",
                        column: x => x.ProcessSegmentId,
                        principalTable: "ProcessSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSegments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessSegmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Draft"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSegments_MaterialDefinitions_MaterialDefinitionId",
                        column: x => x.MaterialDefinitionId,
                        principalTable: "MaterialDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSegments_ProcessSegments_ProcessSegmentId",
                        column: x => x.ProcessSegmentId,
                        principalTable: "ProcessSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSegmentParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProcessSegmentParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSegmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSegmentParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSegmentParameters_ProcessSegmentParameters_ProcessSegmentParameterId",
                        column: x => x.ProcessSegmentParameterId,
                        principalTable: "ProcessSegmentParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSegmentParameters_ProductSegments_ProductSegmentId",
                        column: x => x.ProductSegmentId,
                        principalTable: "ProductSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessSegmentParameters_ProcessSegmentId",
                table: "ProcessSegmentParameters",
                column: "ProcessSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSegmentParameters_ProcessSegmentParameterId",
                table: "ProductSegmentParameters",
                column: "ProcessSegmentParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSegmentParameters_ProductSegmentId",
                table: "ProductSegmentParameters",
                column: "ProductSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSegments_MaterialDefinitionId",
                table: "ProductSegments",
                column: "MaterialDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSegments_ProcessSegmentId",
                table: "ProductSegments",
                column: "ProcessSegmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSegmentParameters");

            migrationBuilder.DropTable(
                name: "ProcessSegmentParameters");

            migrationBuilder.DropTable(
                name: "ProductSegments");

            migrationBuilder.DropTable(
                name: "ProcessSegments");
        }
    }
}
