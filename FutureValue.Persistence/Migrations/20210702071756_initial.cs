using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureValue.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FutureValues",
                columns: table => new
                {
                    FutureValuesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresentValue = table.Column<double>(type: "Float", nullable: false),
                    LowerBoundInterest = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    UpperBoundInterest = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    IncrementalRate = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    MaturityYears = table.Column<int>(type: "int", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureValues", x => x.FutureValuesId);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionDetails",
                columns: table => new
                {
                    ExecutionDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "Float", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    FutureValue = table.Column<double>(type: "Float", nullable: false),
                    FutureValuesId = table.Column<int>(type: "int", nullable: true),
                    FutureValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionDetails", x => x.ExecutionDetailsId);
                    table.ForeignKey(
                        name: "FK_ExecutionDetails_FutureValues_FutureValuesId",
                        column: x => x.FutureValuesId,
                        principalTable: "FutureValues",
                        principalColumn: "FutureValuesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionDetails_FutureValuesId",
                table: "ExecutionDetails",
                column: "FutureValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExecutionDetails");

            migrationBuilder.DropTable(
                name: "FutureValues");
        }
    }
}
