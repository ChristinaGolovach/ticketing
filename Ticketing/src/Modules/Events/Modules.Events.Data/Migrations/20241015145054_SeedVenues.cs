using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedVenues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "events",
                table: "Venues",
                columns: new[] { "Id", "BuildNumber", "City", "Country", "Created", "Name", "Street", "Updated" },
                values: new object[] { new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"), "15A", "Lodz", "Poland", new DateTime(2024, 10, 15, 14, 50, 53, 817, DateTimeKind.Utc).AddTicks(7655), "Arena", "Kolobzesk", new DateTime(2024, 10, 15, 14, 50, 53, 817, DateTimeKind.Utc).AddTicks(7656) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"));
        }
    }
}
