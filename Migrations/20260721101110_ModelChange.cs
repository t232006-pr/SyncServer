using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncServer.Migrations
{
    /// <inheritdoc />
    public partial class ModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "dict");

            migrationBuilder.AddColumn<string>(
                name: "TopicName",
                table: "dict",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopicName",
                table: "dict");

            migrationBuilder.AddColumn<int>(
                name: "Topic",
                table: "dict",
                type: "integer",
                nullable: true);
        }
    }
}
