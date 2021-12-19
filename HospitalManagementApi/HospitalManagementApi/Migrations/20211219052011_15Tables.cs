using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementApi.Migrations
{
    public partial class _15Tables : Migration
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
                name: "PatientInfos",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NIDCardNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfos", x => x.PatientId);
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
                    table.ForeignKey(
                        name: "FK_AppoinmentInfos_DoctorsInfos_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorsInfos",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "InvoiceInfos",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PaitentTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatParcentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuePaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    ReportDeliveryChechBox = table.Column<int>(type: "int", nullable: false),
                    CommissionApplication = table.Column<int>(type: "int", nullable: false),
                    CommissionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInfos", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceInfos_PatientInfos_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAdmissionInfos",
                columns: table => new
                {
                    PatientAdmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TotalStayingDay = table.Column<int>(type: "int", nullable: false),
                    BedCharge = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    OthersCharge = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TotalCharge = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    PayableAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    RelaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicineCharge = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TestingCharge = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    ServiceChargePercentage = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TotalPaidAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TotalDueAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAdmissionInfos", x => x.PatientAdmissionId);
                    table.ForeignKey(
                        name: "FK_PatientAdmissionInfos_DoctorsInfos_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorsInfos",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAdmissionInfos_PatientInfos_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientId",
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

            migrationBuilder.CreateTable(
                name: "LabandTestEntryInfos",
                columns: table => new
                {
                    LabandTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sample = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabandTestEntryInfos", x => x.LabandTestId);
                    table.ForeignKey(
                        name: "FK_LabandTestEntryInfos_InvoiceInfos_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceInfos",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabandTestEntryInfos_TestInfos_TestId",
                        column: x => x.TestId,
                        principalTable: "TestInfos",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestReportInfos",
                columns: table => new
                {
                    TestReportInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Remarks = table.Column<int>(type: "int", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestReportInfos", x => x.TestReportInfoId);
                    table.ForeignKey(
                        name: "FK_TestReportInfos_InvoiceInfos_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceInfos",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestReportInfos_TestInfos_TestId",
                        column: x => x.TestId,
                        principalTable: "TestInfos",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicineInfos",
                columns: table => new
                {
                    PatientMedicineInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineNo = table.Column<int>(type: "int", nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PatientAddmissionId = table.Column<int>(type: "int", nullable: false),
                    MedicineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructionsForMedicine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicineInfos", x => x.PatientMedicineInfoId);
                    table.ForeignKey(
                        name: "FK_PatientMedicineInfos_PatientAdmissionInfos_PatientAddmissionId",
                        column: x => x.PatientAddmissionId,
                        principalTable: "PatientAdmissionInfos",
                        principalColumn: "PatientAdmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientOthersInfos",
                columns: table => new
                {
                    PatientOthersInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientAddmissionId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOthersInfos", x => x.PatientOthersInfoId);
                    table.ForeignKey(
                        name: "FK_PatientOthersInfos_PatientAdmissionInfos_PatientAddmissionId",
                        column: x => x.PatientAddmissionId,
                        principalTable: "PatientAdmissionInfos",
                        principalColumn: "PatientAdmissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientOthersInfos_PatientInfos_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "PatientTestingInfos",
                columns: table => new
                {
                    TestNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientAddmissionId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTestingInfos", x => x.TestNo);
                    table.ForeignKey(
                        name: "FK_PatientTestingInfos_PatientAdmissionInfos_PatientAddmissionId",
                        column: x => x.PatientAddmissionId,
                        principalTable: "PatientAdmissionInfos",
                        principalColumn: "PatientAdmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppoinmentInfos_DoctorId",
                table: "AppoinmentInfos",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BedInfos_WardNo",
                table: "BedInfos",
                column: "WardNo");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfos_PatientId",
                table: "InvoiceInfos",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LabandTestEntryInfos_InvoiceId",
                table: "LabandTestEntryInfos",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LabandTestEntryInfos_TestId",
                table: "LabandTestEntryInfos",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_OutDoorConsultancies_DoctorId",
                table: "OutDoorConsultancies",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdmissionInfos_DoctorId",
                table: "PatientAdmissionInfos",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdmissionInfos_PatientId",
                table: "PatientAdmissionInfos",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicineInfos_PatientAddmissionId",
                table: "PatientMedicineInfos",
                column: "PatientAddmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOthersInfos_PatientAddmissionId",
                table: "PatientOthersInfos",
                column: "PatientAddmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOthersInfos_PatientId",
                table: "PatientOthersInfos",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTestingInfos_PatientAddmissionId",
                table: "PatientTestingInfos",
                column: "PatientAddmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestReportInfos_InvoiceId",
                table: "TestReportInfos",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TestReportInfos_TestId",
                table: "TestReportInfos",
                column: "TestId");
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
                name: "LabandTestEntryInfos");

            migrationBuilder.DropTable(
                name: "OutDoorConsultancies");

            migrationBuilder.DropTable(
                name: "PatientMedicineInfos");

            migrationBuilder.DropTable(
                name: "PatientOthersInfos");

            migrationBuilder.DropTable(
                name: "PatientTestingInfos");

            migrationBuilder.DropTable(
                name: "TestReportInfos");

            migrationBuilder.DropTable(
                name: "WardInfos");

            migrationBuilder.DropTable(
                name: "PatientAdmissionInfos");

            migrationBuilder.DropTable(
                name: "InvoiceInfos");

            migrationBuilder.DropTable(
                name: "TestInfos");

            migrationBuilder.DropTable(
                name: "DoctorsInfos");

            migrationBuilder.DropTable(
                name: "PatientInfos");
        }
    }
}
