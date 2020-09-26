using Microsoft.EntityFrameworkCore.Migrations;

namespace MPACore.PhoneBook.Migrations
{
    public partial class addPersonAndPhoneNumber2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "PB",
                table: "Person",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "PB",
                table: "Person",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);
        }
    }
}
