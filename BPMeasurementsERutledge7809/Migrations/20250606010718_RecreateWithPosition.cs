using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPMeasurementsERutledge7809.Migrations
{
    /// <inheritdoc />
    public partial class RecreateWithPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Measurements_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "L", "Lying Down" },
                    { "S", "Sitting" },
                    { "T", "Standing" }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "ID", "Diastolic", "Date Taken", "PositionID", "Systolic" },
                values: new object[,]
                {
                    { 1, 80, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "S", 120 },
                    { 2, 85, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "T", 130 },
                    { 3, 90, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "L", 140 },
                    { 4, 100, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "S", 160 },
                    { 5, 110, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "T", 180 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_PositionID",
                table: "Measurements",
                column: "PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
