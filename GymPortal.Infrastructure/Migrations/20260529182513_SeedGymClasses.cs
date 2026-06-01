using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedGymClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GymClasses",
                columns: new[] { "Id", "Capacity", "Category", "Instructor", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, 20, "Mind", "Anna", "Yoga", new DateTime(2026, 5, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15, "Strength", "John", "Crossfit", new DateTime(2026, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GymClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GymClasses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
