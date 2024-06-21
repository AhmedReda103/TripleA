using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripleA.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class addColResponderToNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Responder",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responder",
                table: "Notifications");
        }
    }
}
