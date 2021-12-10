using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementApi.Migrations
{
    public partial class StartAgain : Migration
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

            migrationBuilder.CreateTable(
                name: "DoctorsInfos",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DutyStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DutyEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CommissionStatus = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsInfos", x => x.DoctorId);
                });

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
                name: "BedInfos",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedInfos", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_BedInfos_WordInfos_WordNo",
                        column: x => x.WordNo,
                        principalTable: "WordInfos",
                        principalColumn: "WordNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedInfos_WordNo",
                table: "BedInfos",
                column: "WordNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedInfos");

            migrationBuilder.DropTable(
                name: "CabinInfos");

            migrationBuilder.DropTable(
                name: "DoctorsInfos");

            migrationBuilder.DropTable(
                name: "WordInfos");
        }
    }
}
