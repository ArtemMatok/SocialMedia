using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialScape.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_PostLikes_MediaAccounts_MediaAccountId",
                        column: x => x.MediaAccountId,
                        principalTable: "MediaAccounts",
                        principalColumn: "MediaAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_MediaAccountId",
                table: "PostLikes",
                column: "MediaAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostLikes");
        }
    }
}
