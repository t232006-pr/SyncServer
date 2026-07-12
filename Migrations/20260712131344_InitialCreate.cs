using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dict",
                columns: table => new
                {
                    Number = table.Column<int>(type: "integer", nullable: false),
                    DBID = table.Column<long>(type: "bigint", nullable: false),
                    Word = table.Column<string>(type: "text", nullable: false),
                    Translation = table.Column<string>(type: "text", nullable: false),
                    Topic = table.Column<int>(type: "integer", nullable: true),
                    DateRec = table.Column<DateOnly>(type: "date", nullable: false),
                    Score = table.Column<byte>(type: "smallint", nullable: false),
                    Usersel = table.Column<bool>(type: "boolean", nullable: false),
                    Phrase = table.Column<bool>(type: "boolean", nullable: false),
                    Relevation = table.Column<byte>(type: "smallint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Modification_Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Spot = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dict", x => new { x.Number, x.DBID });
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DBID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Modification_Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => new { x.Id, x.DBID });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dict_DateRec",
                table: "Dict",
                column: "DateRec");

            migrationBuilder.CreateIndex(
                name: "IX_Dict_Translation",
                table: "Dict",
                column: "Translation");

            migrationBuilder.CreateIndex(
                name: "IX_Dict_Word",
                table: "Dict",
                column: "Word");

            migrationBuilder.CreateIndex(
                name: "IX_topic_Name",
                table: "topic",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dict");

            migrationBuilder.DropTable(
                name: "topic");
        }
    }
}
