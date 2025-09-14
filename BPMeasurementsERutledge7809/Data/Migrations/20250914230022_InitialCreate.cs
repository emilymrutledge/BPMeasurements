using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPMeasurementsERutledge7809.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BPMeasurements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Systolic = table.Column<int>(type: "INTEGER", nullable: false),
                    Diastolic = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PositionID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMeasurements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BPMeasurements_Positions_PositionID",
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
                table: "BPMeasurements",
                columns: new[] { "ID", "Diastolic", "MeasurementDate", "PositionID", "Systolic" },
                values: new object[,]
                {
                    { 1, 80, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "S", 120 },
                    { 2, 85, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "T", 130 },
                    { 3, 90, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "L", 140 },
                    { 4, 100, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "S", 160 },
                    { 5, 110, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "T", 180 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BPMeasurements_PositionID",
                table: "BPMeasurements",
                column: "PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPMeasurements");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
