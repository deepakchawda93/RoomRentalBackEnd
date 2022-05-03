using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomRentalBackEnd.Migrations
{
    public partial class addnewModelFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OwnerModelTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OwnerDataStatus",
                table: "OwnerModelTable",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OwnerModelTable");

            migrationBuilder.DropColumn(
                name: "OwnerDataStatus",
                table: "OwnerModelTable");
        }
    }
}
