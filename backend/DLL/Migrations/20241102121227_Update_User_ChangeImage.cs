using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_User_ChangeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "08da6773-6c48-47dd-baa1-5be35d89cf0c", null, "User", "USER" },
                    { "c5de9713-d6e8-4eea-bc8c-37200096efab", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08da6773-6c48-47dd-baa1-5be35d89cf0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5de9713-d6e8-4eea-bc8c-37200096efab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "987d7a9b-78e2-4fa3-9f81-dcad78d16c49", null, "Admin", "ADMIN" },
                    { "ff1f3831-6d0d-4275-b0b6-3e2e7d7579d5", null, "User", "USER" }
                });
        }
    }
}
