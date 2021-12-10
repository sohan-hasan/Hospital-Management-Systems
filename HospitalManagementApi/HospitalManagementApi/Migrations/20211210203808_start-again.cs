using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementApi.Migrations
{
    public partial class startagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppoinmentInfos",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextAppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppoinmentInfos", x => x.AppointmentId);
                });

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
                name: "TestInfos",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TestCost = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PercentangeToDoctor = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CashToDoctor = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestInfos", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "WardInfos",
                columns: table => new
                {
                    WardNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardCost = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FloorNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardInfos", x => x.WardNo);
                });

            migrationBuilder.CreateTable(
                name: "OutDoorConsultancies",
                columns: table => new
                {
                    OutDoorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Testifications = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutDoorConsultancies", x => x.OutDoorId);
                    table.ForeignKey(
                        name: "FK_OutDoorConsultancies_DoctorsInfos_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorsInfos",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BedInfos",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedInfos", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_BedInfos_WardInfos_WardNo",
                        column: x => x.WardNo,
                        principalTable: "WardInfos",
                        principalColumn: "WardNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BedInfos_WardNo",
                table: "BedInfos",
                column: "WardNo");

            migrationBuilder.CreateIndex(
                name: "IX_OutDoorConsultancies_DoctorId",
                table: "OutDoorConsultancies",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppoinmentInfos");

            migrationBuilder.DropTable(
                name: "BedInfos");

            migrationBuilder.DropTable(
                name: "CabinInfos");

            migrationBuilder.DropTable(
                name: "OutDoorConsultancies");

            migrationBuilder.DropTable(
                name: "TestInfos");

            migrationBuilder.DropTable(
                name: "WardInfos");

            migrationBuilder.DropTable(
                name: "DoctorsInfos");
        }
    }
}
