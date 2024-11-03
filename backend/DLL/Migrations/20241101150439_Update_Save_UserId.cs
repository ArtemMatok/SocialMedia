using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Save_UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_AspNetUsers_AppUserId",
                table: "Saves");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "205091ab-1d78-47ff-9924-7f203a67707e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74051a82-9ba6-4ab7-8f67-b53ed885c46a");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Saves",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Saves_AppUserId",
                table: "Saves",
                newName: "IX_Saves_UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27abd2f6-988a-4be3-aae6-f38bec7d5db1", null, "User", "USER" },
                    { "6c19d09f-fff0-4bba-92de-6f0530c2d72e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_AspNetUsers_UserId",
                table: "Saves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_AspNetUsers_UserId",
                table: "Saves");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27abd2f6-988a-4be3-aae6-f38bec7d5db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c19d09f-fff0-4bba-92de-6f0530c2d72e");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Saves",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Saves_UserId",
                table: "Saves",
                newName: "IX_Saves_AppUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "205091ab-1d78-47ff-9924-7f203a67707e", null, "User", "USER" },
                    { "74051a82-9ba6-4ab7-8f67-b53ed885c46a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_AspNetUsers_AppUserId",
                table: "Saves",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
