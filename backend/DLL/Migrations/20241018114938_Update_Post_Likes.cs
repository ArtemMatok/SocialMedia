using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Post_Likes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "273e3eb7-257d-4dea-b90b-44017f72c246");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af267b9-27ad-4feb-853a-ede4eee37466");

            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LikedPostsId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserLikePost",
                columns: table => new
                {
                    LikedPostsPostId = table.Column<int>(type: "int", nullable: false),
                    LikesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikePost", x => new { x.LikedPostsPostId, x.LikesId });
                    table.ForeignKey(
                        name: "FK_UserLikePost_AspNetUsers_LikesId",
                        column: x => x.LikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikePost_Posts_LikedPostsPostId",
                        column: x => x.LikedPostsPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68faad70-78ba-4b52-abb0-fd417b6f80d1", null, "User", "USER" },
                    { "e4aea9f4-95fa-4a61-82f6-0fa282998212", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikePost_LikesId",
                table: "UserLikePost",
                column: "LikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "UserLikePost");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68faad70-78ba-4b52-abb0-fd417b6f80d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4aea9f4-95fa-4a61-82f6-0fa282998212");

            migrationBuilder.AddColumn<string>(
                name: "LikesId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LikedPostsId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "273e3eb7-257d-4dea-b90b-44017f72c246", null, "User", "USER" },
                    { "9af267b9-27ad-4feb-853a-ede4eee37466", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
