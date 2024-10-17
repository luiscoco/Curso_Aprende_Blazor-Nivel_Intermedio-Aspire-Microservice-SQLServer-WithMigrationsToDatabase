using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureSQLWebAPIMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExampleModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 16, 22, 9, 16, 756, DateTimeKind.Local).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "ExampleModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 16, 22, 9, 16, 756, DateTimeKind.Local).AddTicks(8175));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExampleModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 10, 22, 50, 19, 171, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "ExampleModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 10, 22, 50, 19, 171, DateTimeKind.Local).AddTicks(1946));
        }
    }
}
