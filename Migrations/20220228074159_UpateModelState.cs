using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomRentalBackEnd.Migrations
{
    public partial class UpateModelState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerDataStatus",
                table: "OwnerModelTable",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerDataStatus",
                table: "OwnerModelTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
