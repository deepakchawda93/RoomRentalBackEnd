using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomRentalBackEnd.Migrations
{
    public partial class changemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "OwnerModelTable");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "OwnerModelTable");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OwnerModelTable");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OwnerModelTable",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OwnerModelTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OwnerModelTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "OwnerModelTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OwnerModelTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
