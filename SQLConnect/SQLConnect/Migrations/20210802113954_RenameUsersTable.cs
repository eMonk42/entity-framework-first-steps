using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLConnect.Migrations
{
    public partial class RenameUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "public",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "public",
                table: "users",
                newName: "first_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "public",
                table: "users",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "public",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "public",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
