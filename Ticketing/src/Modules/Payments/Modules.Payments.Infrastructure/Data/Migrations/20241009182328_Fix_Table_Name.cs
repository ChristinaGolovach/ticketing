using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Payments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Table_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "payments",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "payments",
                newName: "Payments",
                newSchema: "payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                schema: "payments",
                table: "Payments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                schema: "payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "payments",
                newName: "Orders",
                newSchema: "payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "payments",
                table: "Orders",
                column: "Id");
        }
    }
}
