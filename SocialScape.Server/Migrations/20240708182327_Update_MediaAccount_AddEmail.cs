using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialScape.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update_MediaAccount_AddEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MediaAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "MediaAccounts");
        }
    }
}
