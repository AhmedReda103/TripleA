using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripleA.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class addquestionIqcolatnotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Notifications");
        }
    }
}
