using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Column_to_ActivitySeatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatId",
                schema: "orders",
                table: "OrderItems",
                newName: "ActivitySeatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivitySeatId",
                schema: "orders",
                table: "OrderItems",
                newName: "SeatId");
        }
    }
}
