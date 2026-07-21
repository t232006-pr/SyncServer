using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncServer.Migrations
{
    /// <inheritdoc />
    public partial class migr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_topic",
                table: "topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dict",
                table: "dict");

            migrationBuilder.AddPrimaryKey(
                name: "PK_topic",
                table: "topic",
                columns: new[] { "DBID", "Modification_Time" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_dict",
                table: "dict",
                columns: new[] { "DBID", "Modification_Time" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_topic",
                table: "topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dict",
                table: "dict");

            migrationBuilder.AddPrimaryKey(
                name: "PK_topic",
                table: "topic",
                columns: new[] { "Modification_Time", "DBID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_dict",
                table: "dict",
                columns: new[] { "Modification_Time", "DBID" });
        }
    }
}
