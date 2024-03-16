using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_UserID",
                table: "RealEstate",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_User_UserID",
                table: "RealEstate",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_User_UserID",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_UserID",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "RealEstate");
        }
    }
}
