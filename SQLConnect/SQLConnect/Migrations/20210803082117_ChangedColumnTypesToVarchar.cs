using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLConnect.Migrations
{
    public partial class ChangedColumnTypesToVarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelephoneNumber_users_UserId",
                table: "TelephoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TelephoneNumber",
                table: "TelephoneNumber");

            migrationBuilder.RenameTable(
                name: "TelephoneNumber",
                newName: "telephone_numbers",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Age",
                schema: "public",
                table: "users",
                newName: "age");

            migrationBuilder.RenameIndex(
                name: "IX_TelephoneNumber_UserId",
                schema: "public",
                table: "telephone_numbers",
                newName: "IX_telephone_numbers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TelephoneNumber_number",
                schema: "public",
                table: "telephone_numbers",
                newName: "IX_telephone_numbers_number");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "users",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "users",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                schema: "public",
                table: "telephone_numbers",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                schema: "public",
                table: "telephone_numbers",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_telephone_numbers",
                schema: "public",
                table: "telephone_numbers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_telephone_numbers_users_UserId",
                schema: "public",
                table: "telephone_numbers",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_telephone_numbers_users_UserId",
                schema: "public",
                table: "telephone_numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_telephone_numbers",
                schema: "public",
                table: "telephone_numbers");

            migrationBuilder.RenameTable(
                name: "telephone_numbers",
                schema: "public",
                newName: "TelephoneNumber");

            migrationBuilder.RenameColumn(
                name: "age",
                schema: "public",
                table: "users",
                newName: "Age");

            migrationBuilder.RenameIndex(
                name: "IX_telephone_numbers_UserId",
                table: "TelephoneNumber",
                newName: "IX_TelephoneNumber_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_telephone_numbers_number",
                table: "TelephoneNumber",
                newName: "IX_TelephoneNumber_number");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "TelephoneNumber",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "TelephoneNumber",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TelephoneNumber",
                table: "TelephoneNumber",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TelephoneNumber_users_UserId",
                table: "TelephoneNumber",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
