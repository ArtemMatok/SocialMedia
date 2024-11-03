using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_User_MakeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27abd2f6-988a-4be3-aae6-f38bec7d5db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c19d09f-fff0-4bba-92de-6f0530c2d72e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "987d7a9b-78e2-4fa3-9f81-dcad78d16c49", null, "Admin", "ADMIN" },
                    { "ff1f3831-6d0d-4275-b0b6-3e2e7d7579d5", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "987d7a9b-78e2-4fa3-9f81-dcad78d16c49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff1f3831-6d0d-4275-b0b6-3e2e7d7579d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27abd2f6-988a-4be3-aae6-f38bec7d5db1", null, "User", "USER" },
                    { "6c19d09f-fff0-4bba-92de-6f0530c2d72e", null, "Admin", "ADMIN" }
                });
        }
    }
}
