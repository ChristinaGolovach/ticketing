using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.Events.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivitySeatOfferId",
                schema: "events",
                table: "ActivitySeats");

            migrationBuilder.InsertData(
                schema: "events",
                table: "Activities",
                columns: new[] { "Id", "Created", "Date", "Name", "Updated", "VenueId" },
                values: new object[] { new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9094), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ram", new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9095), new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af") });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Sections",
                columns: new[] { "Id", "Created", "Number", "Updated", "VenueId" },
                values: new object[,]
                {
                    { new Guid("38dc4132-780d-4fc1-8f66-1badbd06e6f5"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8982), 2, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8982), new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af") },
                    { new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8978), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8978), new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af") }
                });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8872), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8874) });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Venues",
                columns: new[] { "Id", "BuildNumber", "City", "Country", "Created", "Name", "Street", "Updated" },
                values: new object[] { new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026"), "98", "Gdansk", "Poland", new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8888), "GHT Arena", "Opolska", new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8888) });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Activities",
                columns: new[] { "Id", "Created", "Date", "Name", "Updated", "VenueId" },
                values: new object[] { new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9096), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Circus", new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9097), new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026") });

            migrationBuilder.InsertData(
                schema: "events",
                table: "ActivityOffers",
                columns: new[] { "Id", "ActivityId", "Amount", "Created", "PriceType", "Updated" },
                values: new object[,]
                {
                    { new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), 800.0, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9117), 3, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9117) },
                    { new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), 500.0, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9115), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9115) },
                    { new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), 250.0, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9113), 2, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9113) }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Rows",
                columns: new[] { "Id", "Created", "Number", "SectionId", "Updated" },
                values: new object[,]
                {
                    { new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9001), 1, new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9001) },
                    { new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9004), 2, new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9004) },
                    { new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9006), 1, new Guid("38dc4132-780d-4fc1-8f66-1badbd06e6f5"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9006) }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Sections",
                columns: new[] { "Id", "Created", "Number", "Updated", "VenueId" },
                values: new object[] { new Guid("51440082-c6a0-43d9-8a92-c4e0318f24cd"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8984), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(8984), new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026") });

            migrationBuilder.InsertData(
                schema: "events",
                table: "ActivityOffers",
                columns: new[] { "Id", "ActivityId", "Amount", "Created", "PriceType", "Updated" },
                values: new object[,]
                {
                    { new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"), new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"), 50.5, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9119), 2, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9119) },
                    { new Guid("6b0514ab-1eac-41cd-89b5-f4d0660789b7"), new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"), 200.30000000000001, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9122), 3, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9122) },
                    { new Guid("edafbcfe-d72b-4b31-89ad-47cff341b8ee"), new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"), 100.5, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9120), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9121) }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Rows",
                columns: new[] { "Id", "Created", "Number", "SectionId", "Updated" },
                values: new object[] { new Guid("3421eb72-8ead-45f8-9204-975d00e3f030"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9007), 1, new Guid("51440082-c6a0-43d9-8a92-c4e0318f24cd"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Seats",
                columns: new[] { "Id", "Created", "Number", "RowId", "Updated" },
                values: new object[,]
                {
                    { new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9034), 1, new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9034) },
                    { new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9035), 2, new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9035) },
                    { new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9027), 2, new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9027) },
                    { new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9024), 1, new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9025) },
                    { new Guid("a336f3aa-f729-45c3-83be-db6825482152"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9032), 2, new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9032) },
                    { new Guid("f0b63081-812f-4901-8016-422ef2437cc9"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9028), 3, new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9029) },
                    { new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9030), 1, new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9030) }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "ActivitySeats",
                columns: new[] { "Id", "ActivityId", "Created", "SeatId", "State", "Updated" },
                values: new object[,]
                {
                    { new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9150), new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9150) },
                    { new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9143), new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9143) },
                    { new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9148), new Guid("f0b63081-812f-4901-8016-422ef2437cc9"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9148) },
                    { new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9153), new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9154) },
                    { new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9155), new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9155) },
                    { new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9151), new Guid("a336f3aa-f729-45c3-83be-db6825482152"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9152) },
                    { new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"), new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9145), new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9146) }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "Seats",
                columns: new[] { "Id", "Created", "Number", "RowId", "Updated" },
                values: new object[] { new Guid("60593976-4fd5-430b-8f59-e4b402f56f12"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9037), 1, new Guid("3421eb72-8ead-45f8-9204-975d00e3f030"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.InsertData(
                schema: "events",
                table: "ActivitySeats",
                columns: new[] { "Id", "ActivityId", "Created", "SeatId", "State", "Updated" },
                values: new object[] { new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"), new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"), new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9157), new Guid("60593976-4fd5-430b-8f59-e4b402f56f12"), 1, new DateTime(2024, 10, 15, 15, 48, 8, 189, DateTimeKind.Utc).AddTicks(9157) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("6b0514ab-1eac-41cd-89b5-f4d0660789b7"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("edafbcfe-d72b-4b31-89ad-47cff341b8ee"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("60593976-4fd5-430b-8f59-e4b402f56f12"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a336f3aa-f729-45c3-83be-db6825482152"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f0b63081-812f-4901-8016-422ef2437cc9"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3421eb72-8ead-45f8-9204-975d00e3f030"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("38dc4132-780d-4fc1-8f66-1badbd06e6f5"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("51440082-c6a0-43d9-8a92-c4e0318f24cd"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026"));

            migrationBuilder.AddColumn<Guid>(
                name: "ActivitySeatOfferId",
                schema: "events",
                table: "ActivitySeats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 14, 50, 53, 817, DateTimeKind.Utc).AddTicks(7655), new DateTime(2024, 10, 15, 14, 50, 53, 817, DateTimeKind.Utc).AddTicks(7656) });
        }
    }
}
