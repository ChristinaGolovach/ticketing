using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.Orders.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "orders",
                table: "Orders",
                columns: new[] { "Id", "ActivityId", "Amount", "Created", "Status", "Updated", "UserId" },
                values: new object[,]
                {
                    { new Guid("283d9fcf-6b89-4747-a70f-91b3f3c9954f"), new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"), 50.5, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4242), 1, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4242), new Guid("3bb7f4ce-d6a7-48e4-bb71-e8e2268bd3e9") },
                    { new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), 1250.0, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4228), 1, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4229), new Guid("c4b4f2ba-67f7-4193-8406-89f269081b6c") }
                });

            migrationBuilder.InsertData(
                schema: "orders",
                table: "OrderItems",
                columns: new[] { "Id", "ActivitySeatId", "Amount", "Created", "OrderId", "Updated" },
                values: new object[,]
                {
                    { new Guid("314530bd-eddb-4753-aeda-6ff8d9aa4dd1"), new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"), 500.0, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4345), new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4345) },
                    { new Guid("542357cb-6caf-4316-9b54-e605fcc81bf5"), new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"), 50.5, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4347), new Guid("283d9fcf-6b89-4747-a70f-91b3f3c9954f"), new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4347) },
                    { new Guid("83e6feed-73e5-4db2-a192-97310ab2b8d5"), new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"), 250.0, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4343), new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4343) },
                    { new Guid("8c9922e2-98fa-4bfd-82bc-5930db899848"), new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"), 250.0, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4336), new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4337) },
                    { new Guid("b588359f-97c6-46fa-9c3d-e4f5098c0218"), new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"), 250.0, new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4340), new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"), new DateTime(2024, 10, 16, 10, 11, 25, 336, DateTimeKind.Utc).AddTicks(4340) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "orders",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("314530bd-eddb-4753-aeda-6ff8d9aa4dd1"));

            migrationBuilder.DeleteData(
                schema: "orders",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("542357cb-6caf-4316-9b54-e605fcc81bf5"));

            migrationBuilder.DeleteData(
                schema: "orders",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("83e6feed-73e5-4db2-a192-97310ab2b8d5"));

            migrationBuilder.DeleteData(
                schema: "orders",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("8c9922e2-98fa-4bfd-82bc-5930db899848"));

            migrationBuilder.DeleteData(
                schema: "orders",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("b588359f-97c6-46fa-9c3d-e4f5098c0218"));

            migrationBuilder.DeleteData(
                schema: "orders",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("283d9fcf-6b89-4747-a70f-91b3f3c9954f"));

            migrationBuilder.DeleteData(
                schema: "orders",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("43ae8ddc-0528-4d89-b947-08b12b688b89"));
        }
    }
}
