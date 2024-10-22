using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Events.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_ActivitySeatOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5056), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5056) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5054), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5076), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5077) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5074), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5078), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5078) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("6b0514ab-1eac-41cd-89b5-f4d0660789b7"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5082), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5072), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5073) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("edafbcfe-d72b-4b31-89ad-47cff341b8ee"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5080), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5117), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5109), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5102), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5103) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5107), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5108) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5113), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5113) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5115), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5115) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5111), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5105), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3421eb72-8ead-45f8-9204-975d00e3f030"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5002), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4995), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4995) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4999), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4999) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5001), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5001) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5031), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5031) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5032), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5024), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5024) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("60593976-4fd5-430b-8f59-e4b402f56f12"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5034), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5034) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5022), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5022) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a336f3aa-f729-45c3-83be-db6825482152"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5029), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f0b63081-812f-4901-8016-422ef2437cc9"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5026), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5026) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5027), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5028) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("38dc4132-780d-4fc1-8f66-1badbd06e6f5"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4972), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("51440082-c6a0-43d9-8a92-c4e0318f24cd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4975), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4975) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4969), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4848), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4877), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(4878) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9096), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9097) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9094), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9095) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9117), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9117) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9115), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9115) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9119), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9119) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("6b0514ab-1eac-41cd-89b5-f4d0660789b7"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9122), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9122) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9113), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("edafbcfe-d72b-4b31-89ad-47cff341b8ee"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9120), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9121) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9157), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9157) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9150), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9143), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9143) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9148), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9148) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9153), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9154) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9155), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9155) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9151), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9152) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9145), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9146) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3421eb72-8ead-45f8-9204-975d00e3f030"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9007), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9001), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9001) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9004), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9004) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9006), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9034), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9034) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9035), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9035) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9027), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9027) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("60593976-4fd5-430b-8f59-e4b402f56f12"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9037), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9024), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9025) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a336f3aa-f729-45c3-83be-db6825482152"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9032), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9032) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f0b63081-812f-4901-8016-422ef2437cc9"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9028), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9029) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9030), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9030) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("38dc4132-780d-4fc1-8f66-1badbd06e6f5"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8982), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8982) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("51440082-c6a0-43d9-8a92-c4e0318f24cd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8984), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8984) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8978), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8872), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8874) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8888), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8888) });
        }
    }
}
