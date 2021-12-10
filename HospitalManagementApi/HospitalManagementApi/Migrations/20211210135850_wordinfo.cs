using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementApi.Migrations
{
    public partial class wordinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordInfos",
                columns: table => new
                {
                    WordNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordCost = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FloorNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordInfos", x => x.WordNo);
                });

            migrationBuilder.CreateTable(
                name: "BedInfo",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedInfo", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_BedInfo_WordInfos_WordNo",
                        column: x => x.WordNo,
                        principalTable: "WordInfos",
                        principalColumn: "WordNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedInfo_WordNo",
                table: "BedInfo",
                column: "WordNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedInfo");

            migrationBuilder.DropTable(
                name: "WordInfos");
        }
    }
}
