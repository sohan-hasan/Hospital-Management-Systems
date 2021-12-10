using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementApi.Migrations
{
    public partial class initws : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabinInfos",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CabinType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CabinSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FloorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CabinDirection = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinInfos", x => x.CabinId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinInfos");
        }
    }
}
