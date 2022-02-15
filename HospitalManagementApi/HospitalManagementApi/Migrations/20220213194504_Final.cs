using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementApi.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabinTypeInfos",
                columns: table => new
                {
                    CabinTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinTypeName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinTypeInfos", x => x.CabinTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
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
                    Qualification = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DutyStartTime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DutyEndTime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    JoinDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ResignDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DoctorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NidCardNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsAdmit = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfos", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "TestCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "WardInfos",
                columns: table => new
                {
                    WardNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WardCost = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    FloorNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardInfos", x => x.WardNo);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinInfos",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CabinTypeId = table.Column<int>(type: "int", nullable: false),
                    CabinSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FloorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    CabinDirection = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinInfos", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_CabinInfos_CabinTypeInfos_CabinTypeId",
                        column: x => x.CabinTypeId,
                        principalTable: "CabinTypeInfos",
                        principalColumn: "CabinTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Maritaltatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PesentAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JoinDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShiftTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    HouseRent = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Medical = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TerminationDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BirthID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppoinmentInfos",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    AppointmentTime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NextAppointmentDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
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
                    EntryDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Testifications = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    InvoiceDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PaitentTotalAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    VatParcentage = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DueAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DuePaid = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DuePaidDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    ReportDeliveryChechBox = table.Column<int>(type: "int", nullable: false),
                    CommissionApplication = table.Column<int>(type: "int", nullable: false),
                    CommissionPercentage = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    CommissionAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DiscountDue = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
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
                    AdmissionDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CabinTypeId = table.Column<int>(type: "int", nullable: false),
                    CabinTypeName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    CabinName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WardNo = table.Column<int>(type: "int", nullable: false),
                    WardName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BedId = table.Column<int>(type: "int", nullable: false),
                    BedNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PurchaseDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    SalesUnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestInfos",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TestCost = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PercentangeToDoctor = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CashToDoctor = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestInfos", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_TestInfos_TestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TestCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BedInfos",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WardNo = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false)
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
                name: "Educations",
                columns: table => new
                {
                    EducationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Institution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PasingYear = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Result = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Educations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsOfExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FinishDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experiences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
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
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    VoucherDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
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
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientAdmissionId = table.Column<int>(type: "int", nullable: false),
                    Date_Of_Order = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrderDeatils = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalesUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_PatientAdmissionInfos_PatientAdmissionId",
                        column: x => x.PatientAdmissionId,
                        principalTable: "PatientAdmissionInfos",
                        principalColumn: "PatientAdmissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicineInfos",
                columns: table => new
                {
                    PatientMedicineInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PatientAdmissionId = table.Column<int>(type: "int", nullable: false),
                    MedicineDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionsForMedicine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicineInfos", x => x.PatientMedicineInfoId);
                    table.ForeignKey(
                        name: "FK_PatientMedicineInfos_PatientAdmissionInfos_PatientAdmissionId",
                        column: x => x.PatientAdmissionId,
                        principalTable: "PatientAdmissionInfos",
                        principalColumn: "PatientAdmissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicineInfos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
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
                    ReceiveDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DeliveryDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Samples = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                name: "PatientTestingInfos",
                columns: table => new
                {
                    TestNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    TestDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PatientAdmissionId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    PatientInfoPatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTestingInfos", x => x.TestNo);
                    table.ForeignKey(
                        name: "FK_PatientTestingInfos_PatientAdmissionInfos_PatientAdmissionId",
                        column: x => x.PatientAdmissionId,
                        principalTable: "PatientAdmissionInfos",
                        principalColumn: "PatientAdmissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTestingInfos_PatientInfos_PatientInfoPatientId",
                        column: x => x.PatientInfoPatientId,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTestingInfos_TestInfos_TestId",
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
                    Result = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
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
                name: "Product_In_The_Orders",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_In_The_Orders", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_Product_In_The_Orders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_In_The_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppoinmentInfos_DoctorId",
                table: "AppoinmentInfos",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BedInfos_WardNo",
                table: "BedInfos",
                column: "WardNo");

            migrationBuilder.CreateIndex(
                name: "IX_CabinInfos_CabinTypeId",
                table: "CabinInfos",
                column: "CabinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EmployeeId",
                table: "Educations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_EmployeeId",
                table: "Experiences",
                column: "EmployeeId");

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
                name: "IX_Orders_PatientAdmissionId",
                table: "Orders",
                column: "PatientAdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

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
                name: "IX_PatientMedicineInfos_PatientAdmissionId",
                table: "PatientMedicineInfos",
                column: "PatientAdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicineInfos_ProductId",
                table: "PatientMedicineInfos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOthersInfos_PatientAddmissionId",
                table: "PatientOthersInfos",
                column: "PatientAddmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOthersInfos_PatientId",
                table: "PatientOthersInfos",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTestingInfos_PatientAdmissionId",
                table: "PatientTestingInfos",
                column: "PatientAdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTestingInfos_PatientInfoPatientId",
                table: "PatientTestingInfos",
                column: "PatientInfoPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTestingInfos_TestId",
                table: "PatientTestingInfos",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_In_The_Orders_OrderId",
                table: "Product_In_The_Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_In_The_Orders_ProductId",
                table: "Product_In_The_Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TestInfos_CategoryId",
                table: "TestInfos",
                column: "CategoryId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BedInfos");

            migrationBuilder.DropTable(
                name: "CabinInfos");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

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
                name: "Product_In_The_Orders");

            migrationBuilder.DropTable(
                name: "TestReportInfos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WardInfos");

            migrationBuilder.DropTable(
                name: "CabinTypeInfos");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "InvoiceInfos");

            migrationBuilder.DropTable(
                name: "TestInfos");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "PatientAdmissionInfos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TestCategories");

            migrationBuilder.DropTable(
                name: "DoctorsInfos");

            migrationBuilder.DropTable(
                name: "PatientInfos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
