using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLConnect.Migrations
{
    public partial class UniqueKeyForNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TelephoneNumber_number",
                table: "TelephoneNumber",
                column: "number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TelephoneNumber_number",
                table: "TelephoneNumber");
        }
    }
}
