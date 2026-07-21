using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncServer.Migrations
{
    /// <inheritdoc />
    public partial class IndexChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_topic",
                table: "topic");

            migrationBuilder.DropIndex(
                name: "IX_topic_Name",
                table: "topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dict",
                table: "Dict");

            migrationBuilder.DropIndex(
                name: "IX_Dict_DateRec",
                table: "Dict");

            migrationBuilder.DropIndex(
                name: "IX_Dict_Translation",
                table: "Dict");

            migrationBuilder.DropIndex(
                name: "IX_Dict_Word",
                table: "Dict");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "topic");

            migrationBuilder.DropColumn(
                name: "DBID",
                table: "Dict");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification_Time",
                table: "topic",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DBID",
                table: "topic",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification_Time",
                table: "Dict",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_topic",
                table: "topic",
                columns: new[] { "Modification_Time", "DBID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dict",
                table: "Dict",
                columns: new[] { "Modification_Time", "Number" });

            migrationBuilder.CreateIndex(
                name: "IX_topic_Modification_Time",
                table: "topic",
                column: "Modification_Time");

            migrationBuilder.CreateIndex(
                name: "IX_Dict_Modification_Time",
                table: "Dict",
                column: "Modification_Time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_topic",
                table: "topic");

            migrationBuilder.DropIndex(
                name: "IX_topic_Modification_Time",
                table: "topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dict",
                table: "Dict");

            migrationBuilder.DropIndex(
                name: "IX_Dict_Modification_Time",
                table: "Dict");

            migrationBuilder.AlterColumn<long>(
                name: "DBID",
                table: "topic",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification_Time",
                table: "topic",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "topic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification_Time",
                table: "Dict",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<long>(
                name: "DBID",
                table: "Dict",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_topic",
                table: "topic",
                columns: new[] { "Id", "DBID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dict",
                table: "Dict",
                columns: new[] { "Number", "DBID" });

            migrationBuilder.CreateIndex(
                name: "IX_topic_Name",
                table: "topic",
                column: "Name");

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
        }
    }
}
