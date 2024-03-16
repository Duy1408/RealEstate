using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propertie",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RealEstateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propertie", x => x.PID);
                    table.ForeignKey(
                        name: "FK_Propertie_RealEstate_RealEstateID",
                        column: x => x.RealEstateID,
                        principalTable: "RealEstate",
                        principalColumn: "RealEstateID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propertie_RealEstateID",
                table: "Propertie",
                column: "RealEstateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propertie");
        }
    }
}
