using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_ActivitySeat_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatOffers",
                schema: "events");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "events",
                table: "Seats");

            migrationBuilder.CreateTable(
                name: "ActivitySeats",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivitySeatOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySeats_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "events",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalSchema: "events",
                        principalTable: "Seats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivitySeatOffers",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivitySeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySeatOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySeatOffers_ActivityOffers_ActivityOfferId",
                        column: x => x.ActivityOfferId,
                        principalSchema: "events",
                        principalTable: "ActivityOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySeatOffers_ActivitySeats_ActivitySeatId",
                        column: x => x.ActivitySeatId,
                        principalSchema: "events",
                        principalTable: "ActivitySeats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySeatOffers_ActivityOfferId",
                schema: "events",
                table: "ActivitySeatOffers",
                column: "ActivityOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySeatOffers_ActivitySeatId",
                schema: "events",
                table: "ActivitySeatOffers",
                column: "ActivitySeatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySeats_ActivityId",
                schema: "events",
                table: "ActivitySeats",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySeats_SeatId",
                schema: "events",
                table: "ActivitySeats",
                column: "SeatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySeatOffers",
                schema: "events");

            migrationBuilder.DropTable(
                name: "ActivitySeats",
                schema: "events");

            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "events",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "SeatOffers",
                schema: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityOfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatOffers_ActivityOffers_ActivityOfferId",
                        column: x => x.ActivityOfferId,
                        principalSchema: "events",
                        principalTable: "ActivityOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatOffers_Seats_SeatId",
                        column: x => x.SeatId,
                        principalSchema: "events",
                        principalTable: "Seats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatOffers_ActivityOfferId",
                schema: "events",
                table: "SeatOffers",
                column: "ActivityOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatOffers_SeatId",
                schema: "events",
                table: "SeatOffers",
                column: "SeatId");
        }
    }
}
