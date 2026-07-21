using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncServer.Migrations
{
    /// <inheritdoc />
    public partial class IndexChange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dict",
                table: "Dict");

            migrationBuilder.RenameTable(
                name: "Dict",
                newName: "dict");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "dict",
                newName: "DBID");

            migrationBuilder.RenameIndex(
                name: "IX_Dict_Modification_Time",
                table: "dict",
                newName: "IX_dict_Modification_Time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dict",
                table: "dict",
                columns: new[] { "Modification_Time", "DBID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dict",
                table: "dict");

            migrationBuilder.RenameTable(
                name: "dict",
                newName: "Dict");

            migrationBuilder.RenameColumn(
                name: "DBID",
                table: "Dict",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_dict_Modification_Time",
                table: "Dict",
                newName: "IX_Dict_Modification_Time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dict",
                table: "Dict",
                columns: new[] { "Modification_Time", "Number" });
        }
    }
}
