using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalForSchool.Migrations
{
    public partial class AddBirthdayDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthdayDate",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthdayDate",
                table: "Students");
        }
    }
}
