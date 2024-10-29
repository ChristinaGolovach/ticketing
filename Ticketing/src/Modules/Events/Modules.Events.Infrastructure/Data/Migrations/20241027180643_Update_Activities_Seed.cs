using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modules.Events.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Activities_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"),
                columns: new[] { "Created", "Date", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7128), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7129), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7128) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"),
                columns: new[] { "Created", "Date", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7125), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7125) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7150), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7148), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7152), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7152) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("6b0514ab-1eac-41cd-89b5-f4d0660789b7"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7156), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7156) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7145), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7146) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivityOffers",
                keyColumn: "Id",
                keyValue: new Guid("edafbcfe-d72b-4b31-89ad-47cff341b8ee"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7154), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7154) });

            migrationBuilder.InsertData(
                schema: "events",
                table: "ActivitySeatOffers",
                columns: new[] { "Id", "ActivityOfferId", "ActivitySeatId", "Created", "Updated" },
                values: new object[,]
                {
                    { new Guid("2b6de77f-4970-42e8-b8e6-e1335e870da7"), new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"), new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7229), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7229) },
                    { new Guid("6a1adaa4-3cd9-417f-ae02-53a5f2887e81"), new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"), new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7225), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7225) },
                    { new Guid("6a2ed8c8-61c3-4de7-a840-6e79011f481c"), new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"), new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7227), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7227) },
                    { new Guid("7c0c96fb-1a79-49c3-837e-21992973603f"), new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"), new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7216), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7216) },
                    { new Guid("a45516ba-9bd0-43d5-a591-284c34fe914b"), new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"), new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7218), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7219) },
                    { new Guid("cb0b008c-6a1e-45a5-81a0-87c46f899a77"), new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"), new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7231), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7231) },
                    { new Guid("d59b9cc7-efae-4c7f-9349-865127dd7bfb"), new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"), new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7221), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7221) },
                    { new Guid("e6b4879e-947d-46d9-8189-c6a820d1ff8a"), new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"), new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7223), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7223) }
                });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("087b509d-1ada-492e-a9c7-ed3e917bb2fb"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7195), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7185), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7186) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7178), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7178) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7183), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7190), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7192), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7187), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "ActivitySeats",
                keyColumn: "Id",
                keyValue: new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7181), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7181) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3421eb72-8ead-45f8-9204-975d00e3f030"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7064), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7065) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7056), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7057) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7060), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7062), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7062) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7097), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7097) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7099), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7099) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7089), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7089) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("60593976-4fd5-430b-8f59-e4b402f56f12"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7101), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7101) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7086), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7087) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a336f3aa-f729-45c3-83be-db6825482152"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7095), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7096) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f0b63081-812f-4901-8016-422ef2437cc9"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7091), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7092) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7093), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7094) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("38dc4132-780d-4fc1-8f66-1badbd06e6f5"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7006), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7007) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("51440082-c6a0-43d9-8a92-c4e0318f24cd"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7008), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7009) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("b6a3c9e9-b7f5-425d-a716-d2d7f788f423"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7003), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(7003) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(6862), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(6878), new DateTime(2024, 10, 27, 18, 6, 43, 462, DateTimeKind.Utc).AddTicks(6878) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("2b6de77f-4970-42e8-b8e6-e1335e870da7"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("6a1adaa4-3cd9-417f-ae02-53a5f2887e81"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("6a2ed8c8-61c3-4de7-a840-6e79011f481c"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("7c0c96fb-1a79-49c3-837e-21992973603f"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("a45516ba-9bd0-43d5-a591-284c34fe914b"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("cb0b008c-6a1e-45a5-81a0-87c46f899a77"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("d59b9cc7-efae-4c7f-9349-865127dd7bfb"));

            migrationBuilder.DeleteData(
                schema: "events",
                table: "ActivitySeatOffers",
                keyColumn: "Id",
                keyValue: new Guid("e6b4879e-947d-46d9-8189-c6a820d1ff8a"));

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7933e0d3-4905-4d2c-b9a1-c20ead197883"),
                columns: new[] { "Created", "Date", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5056), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5056) });

            migrationBuilder.UpdateData(
                schema: "events",
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8b5fa894-dfcf-4bb4-a605-5f99985c3805"),
                columns: new[] { "Created", "Date", "Updated" },
                values: new object[] { new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5054), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 15, 15, 51, 25, 183, DateTimeKind.Utc).AddTicks(5054) });

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
    }
}
