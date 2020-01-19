using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoEHEMIS.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Institution = table.Column<int>(nullable: true),
                    College = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    BandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.BandId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetDescription",
                columns: table => new
                {
                    BudgetDescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BudgetCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDescription", x => x.BudgetDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    InstanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.InstanceId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Abbrivation = table.Column<string>(nullable: true),
                    InstanceId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                    table.ForeignKey(
                        name: "FK_Institutions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institutions_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    CollegeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitutionId = table.Column<int>(nullable: true),
                    BandId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.CollegeId);
                    table.ForeignKey(
                        name: "FK_College_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_College_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_College_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagementData",
                columns: table => new
                {
                    ManagementDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitutionId = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    NumberOfPositionRequired = table.Column<int>(nullable: true),
                    CurrentlyAssigned = table.Column<int>(nullable: true),
                    NumberOfFemales = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementData", x => x.ManagementDataId);
                    table.ForeignKey(
                        name: "FK_ManagementData_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnjustifiableExpense",
                columns: table => new
                {
                    UnjustifiableExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitutionId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnjustifiableExpense", x => x.UnjustifiableExpenseId);
                    table.ForeignKey(
                        name: "FK_UnjustifiableExpense_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeStaffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    IsExpatriate = table.Column<bool>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Ded = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Employment = table.Column<int>(nullable: false),
                    ServiceYear = table.Column<int>(nullable: false),
                    AdministrativeStaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    collegeId = table.Column<int>(nullable: true),
                    AcademicLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeStaffs", x => x.AdministrativeStaffId);
                    table.ForeignKey(
                        name: "FK_AdministrativeStaffs_College_collegeId",
                        column: x => x.collegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: true),
                    Allocated = table.Column<decimal>(nullable: false),
                    Additional = table.Column<decimal>(nullable: false),
                    Utilized = table.Column<decimal>(nullable: false),
                    BudgetType = table.Column<int>(nullable: false),
                    BudgetDescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_BudgetDescription_BudgetDescriptionId",
                        column: x => x.BudgetDescriptionId,
                        principalTable: "BudgetDescription",
                        principalColumn: "BudgetDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budgets_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingDatas",
                columns: table => new
                {
                    BuildingDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: true),
                    NameOrCodeOfBuilding = table.Column<string>(nullable: true),
                    IsForAdmin = table.Column<bool>(nullable: false),
                    IsForClassRooms = table.Column<bool>(nullable: false),
                    IsForLibrary = table.Column<bool>(nullable: false),
                    IsForDormitories = table.Column<bool>(nullable: false),
                    IsForStaffResidence = table.Column<bool>(nullable: false),
                    IsForWorkshop = table.Column<bool>(nullable: false),
                    IsForLaboratories = table.Column<bool>(nullable: false),
                    IsForCafetaria = table.Column<bool>(nullable: false),
                    IsForOtherPurpose = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    NameOfContractor = table.Column<string>(nullable: true),
                    NameOfConsultant = table.Column<string>(nullable: true),
                    Status = table.Column<decimal>(nullable: false),
                    BudgetAllocated = table.Column<decimal>(nullable: false),
                    FinancialStatus = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingDatas", x => x.BuildingDataId);
                    table.ForeignKey(
                        name: "FK_BuildingDatas_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostSharingReport",
                columns: table => new
                {
                    CostSharingReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    FieldOfStudy = table.Column<string>(nullable: true),
                    ClearanceDate = table.Column<DateTime>(nullable: false),
                    TutionFee = table.Column<decimal>(nullable: false),
                    FoodExpense = table.Column<decimal>(nullable: false),
                    DormitoryExpense = table.Column<decimal>(nullable: false),
                    PrePayment = table.Column<decimal>(nullable: false),
                    ReciptNumber = table.Column<string>(nullable: true),
                    Unpaid = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostSharingReport", x => x.CostSharingReportId);
                    table.ForeignKey(
                        name: "FK_CostSharingReport_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostSharingReportFiles",
                columns: table => new
                {
                    CostSharingReportFileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostSharingReportFiles", x => x.CostSharingReportFileId);
                    table.ForeignKey(
                        name: "FK_CostSharingReportFiles_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CollegeId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternalRevenues",
                columns: table => new
                {
                    InternalRevenueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: true),
                    Income = table.Column<decimal>(nullable: false),
                    Expense = table.Column<decimal>(nullable: false),
                    Revenue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalRevenues", x => x.InternalRevenueId);
                    table.ForeignKey(
                        name: "FK_InternalRevenues_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    InvestmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: true),
                    CostIncurred = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    InvestmentTitle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.InvestmentId);
                    table.ForeignKey(
                        name: "FK_Investments_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicStaffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    IsExpatriate = table.Column<bool>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AcademicLevel = table.Column<int>(nullable: false),
                    Ded = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Employment = table.Column<int>(nullable: false),
                    ServiceYear = table.Column<int>(nullable: false),
                    AcademicStaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    departmentId = table.Column<int>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true),
                    TeachingLoad = table.Column<int>(nullable: false),
                    TeachingLoadRemark = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    CollegeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicStaffs", x => x.AcademicStaffId);
                    table.ForeignKey(
                        name: "FK_AcademicStaffs_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicStaffs_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompletionRates",
                columns: table => new
                {
                    CompletionRateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    FirstToSecond = table.Column<double>(nullable: true),
                    SecondToThird = table.Column<double>(nullable: true),
                    ThirdToFourth = table.Column<double>(nullable: true),
                    FourthToFifth = table.Column<double>(nullable: true),
                    FifthToSixth = table.Column<double>(nullable: true),
                    SixthToSeventh = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletionRates", x => x.CompletionRateId);
                    table.ForeignKey(
                        name: "FK_CompletionRates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisabledStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StudentInstitutionId = table.Column<string>(nullable: true),
                    Bithdate = table.Column<DateTime>(type: "Date", nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    DisabledStudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Disability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabledStudents", x => x.DisabledStudentId);
                    table.ForeignKey(
                        name: "FK_DisabledStudents_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EconomicalDisadvantagedAttrition",
                columns: table => new
                {
                    economicalDisadvantagedAttritionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Quintal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicalDisadvantagedAttrition", x => x.economicalDisadvantagedAttritionId);
                    table.ForeignKey(
                        name: "FK_EconomicalDisadvantagedAttrition_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EconomicalDisadvantagedEnrollment",
                columns: table => new
                {
                    EconomicalDisadvantagedEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Males = table.Column<int>(nullable: false),
                    Femals = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Quintile = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicalDisadvantagedEnrollment", x => x.EconomicalDisadvantagedEnrollmentId);
                    table.ForeignKey(
                        name: "FK_EconomicalDisadvantagedEnrollment_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EconomicalDisadvantagedGraduate",
                columns: table => new
                {
                    EconomicalDisadvantagedGraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Quintile = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicalDisadvantagedGraduate", x => x.EconomicalDisadvantagedGraduateId);
                    table.ForeignKey(
                        name: "FK_EconomicalDisadvantagedGraduate_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergingRegionAttritions",
                columns: table => new
                {
                    emergingRegionAttritionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergingRegionAttritions", x => x.emergingRegionAttritionId);
                    table.ForeignKey(
                        name: "FK_EmergingRegionAttritions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergingRegionEnrollments",
                columns: table => new
                {
                    EmergingRegionEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Femals = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Region = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergingRegionEnrollments", x => x.EmergingRegionEnrollmentId);
                    table.ForeignKey(
                        name: "FK_EmergingRegionEnrollments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentByAges",
                columns: table => new
                {
                    EnrollmentByAgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    AgeRange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentByAges", x => x.EnrollmentByAgeId);
                    table.ForeignKey(
                        name: "FK_EnrollmentByAges_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Males = table.Column<int>(nullable: false),
                    Femals = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FieldOfSpecialization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expatriates",
                columns: table => new
                {
                    ExpatriateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    SubjectOfSpecialization = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    StudyLevel = table.Column<int>(nullable: false),
                    Passport = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expatriates", x => x.ExpatriateId);
                    table.ForeignKey(
                        name: "FK_Expatriates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignerStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StudentInstitutionId = table.Column<string>(nullable: true),
                    Bithdate = table.Column<DateTime>(type: "Date", nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ForeignerStudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nationality = table.Column<string>(nullable: true),
                    YearsInEthiopia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignerStudents", x => x.ForeignerStudentId);
                    table.ForeignKey(
                        name: "FK_ForeignerStudents_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Graduates",
                columns: table => new
                {
                    GraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduates", x => x.GraduateId);
                    table.ForeignKey(
                        name: "FK_Graduates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduatesTotalExitExamination",
                columns: table => new
                {
                    GraduatesTotalExitExaminationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Program = table.Column<int>(nullable: false),
                    AgeRange = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: true),
                    Females = table.Column<int>(nullable: true),
                    GeographicalLocation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduatesTotalExitExamination", x => x.GraduatesTotalExitExaminationId);
                    table.ForeignKey(
                        name: "FK_GraduatesTotalExitExamination_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduatesTotalExitExaminationByDisability",
                columns: table => new
                {
                    GraduatesTotalExitExaminationByDisabilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Program = table.Column<int>(nullable: false),
                    AgeRange = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: true),
                    Females = table.Column<int>(nullable: true),
                    GeographicalLocation = table.Column<int>(nullable: false),
                    Disability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduatesTotalExitExaminationByDisability", x => x.GraduatesTotalExitExaminationByDisabilityId);
                    table.ForeignKey(
                        name: "FK_GraduatesTotalExitExaminationByDisability_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduatesTotalExitExaminationByEconomy",
                columns: table => new
                {
                    GraduatesTotalExitExaminationByEconomyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Program = table.Column<int>(nullable: false),
                    AgeRange = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: true),
                    Females = table.Column<int>(nullable: true),
                    GeographicalLocation = table.Column<int>(nullable: false),
                    Quintal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduatesTotalExitExaminationByEconomy", x => x.GraduatesTotalExitExaminationByEconomyId);
                    table.ForeignKey(
                        name: "FK_GraduatesTotalExitExaminationByEconomy_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntakeCapacity",
                columns: table => new
                {
                    IntakeCapacityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntakeCapacity", x => x.IntakeCapacityId);
                    table.ForeignKey(
                        name: "FK_IntakeCapacity_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    InternshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    NumberOfIndustriesLinked = table.Column<int>(nullable: false),
                    TrainingArea = table.Column<string>(nullable: true),
                    NumberOfStudentsOnInternship_2ndYear = table.Column<int>(nullable: true),
                    NumberOfStudentsOnInternship_3rdYear = table.Column<int>(nullable: true),
                    NumberOfStudentsOnInternship_4thYear = table.Column<int>(nullable: true),
                    NumberOfStudentsOnInternship_5thYear = table.Column<int>(nullable: true),
                    NumberOfStudentsOnInternship_6thYear = table.Column<int>(nullable: true),
                    NumberOfStudentsOnInternship_7thYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.InternshipId);
                    table.ForeignKey(
                        name: "FK_Internships_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewEnrollments",
                columns: table => new
                {
                    NewEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Males = table.Column<int>(nullable: false),
                    Femals = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewEnrollments", x => x.NewEnrollmentId);
                    table.ForeignKey(
                        name: "FK_NewEnrollments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PastoralRegionEnrollments",
                columns: table => new
                {
                    PastoralRegionEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Femals = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Region = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastoralRegionEnrollments", x => x.PastoralRegionEnrollmentId);
                    table.ForeignKey(
                        name: "FK_PastoralRegionEnrollments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostGraduateResearchPublication",
                columns: table => new
                {
                    PostGraduateResearchPublicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Publication = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGraduateResearchPublication", x => x.PostGraduateResearchPublicationId);
                    table.ForeignKey(
                        name: "FK_PostGraduateResearchPublication_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProspectiveGraduates",
                columns: table => new
                {
                    ProspectiveGraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectiveGraduates", x => x.ProspectiveGraduateId);
                    table.ForeignKey(
                        name: "FK_ProspectiveGraduates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchPapers",
                columns: table => new
                {
                    ResearchPaperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    NumberOfResearchPapersCompleted = table.Column<int>(nullable: false),
                    NumberOfMaleTeachersParticipated = table.Column<int>(nullable: false),
                    NumberOfFemaleTeachersParticipated = table.Column<int>(nullable: false),
                    NumberOfFemaleLeads = table.Column<int>(nullable: false),
                    NumberOfMaleTeachersFromOtherInstituteParticipated = table.Column<int>(nullable: false),
                    NumberOfFemaleTeachersFromOtherInstituteParticipated = table.Column<int>(nullable: false),
                    BudgetAllocated = table.Column<int>(nullable: false),
                    BudgetFromExternalFund = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchPapers", x => x.ResearchPaperId);
                    table.ForeignKey(
                        name: "FK_ResearchPapers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RuralAttrition",
                columns: table => new
                {
                    RuralAttritionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuralAttrition", x => x.RuralAttritionId);
                    table.ForeignKey(
                        name: "FK_RuralAttrition_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RuralEnrollment",
                columns: table => new
                {
                    RuralEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Males = table.Column<int>(nullable: false),
                    Femals = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuralEnrollment", x => x.RuralEnrollmentId);
                    table.ForeignKey(
                        name: "FK_RuralEnrollment_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RuralGraduate",
                columns: table => new
                {
                    RuralGraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuralGraduate", x => x.RuralGraduateId);
                    table.ForeignKey(
                        name: "FK_RuralGraduate_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialNeedAttrition",
                columns: table => new
                {
                    specialNeedAttritionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Disability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialNeedAttrition", x => x.specialNeedAttritionId);
                    table.ForeignKey(
                        name: "FK_SpecialNeedAttrition_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialNeedGraduate",
                columns: table => new
                {
                    SpecialNeedGraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialNeedGraduate", x => x.SpecialNeedGraduateId);
                    table.ForeignKey(
                        name: "FK_SpecialNeedGraduate_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffPrograms",
                columns: table => new
                {
                    StaffProgramId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPrograms", x => x.StaffProgramId);
                    table.ForeignKey(
                        name: "FK_StaffPrograms_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffPrograms_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffTrainings",
                columns: table => new
                {
                    StaffTrainingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CollegeId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTrainings", x => x.StaffTrainingId);
                    table.ForeignKey(
                        name: "FK_StaffTrainings_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffTrainings_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttritions",
                columns: table => new
                {
                    StudentAttritionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Males = table.Column<int>(nullable: false),
                    Females = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Program = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttritions", x => x.StudentAttritionId);
                    table.ForeignKey(
                        name: "FK_StudentAttritions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportiveStaffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    IsExpatriate = table.Column<bool>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Ded = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Employment = table.Column<int>(nullable: false),
                    ServiceYear = table.Column<int>(nullable: false),
                    SupportiveStaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    collegeId = table.Column<int>(nullable: true),
                    AcademicLevel = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportiveStaffs", x => x.SupportiveStaffId);
                    table.ForeignKey(
                        name: "FK_SupportiveStaffs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportiveStaffs_College_collegeId",
                        column: x => x.collegeId,
                        principalTable: "College",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalStaffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    IsExpatriate = table.Column<bool>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AcademicLevel = table.Column<int>(nullable: false),
                    Ded = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Employment = table.Column<int>(nullable: false),
                    ServiceYear = table.Column<int>(nullable: false),
                    TechnicalStaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    departmentId = table.Column<int>(nullable: true),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalStaffs", x => x.TechnicalStaffId);
                    table.ForeignKey(
                        name: "FK_TechnicalStaffs_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffPublication",
                columns: table => new
                {
                    StaffPublicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicStaffId = table.Column<int>(nullable: false),
                    Publication = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPublication", x => x.StaffPublicationId);
                    table.ForeignKey(
                        name: "FK_StaffPublication_AcademicStaffs_AcademicStaffId",
                        column: x => x.AcademicStaffId,
                        principalTable: "AcademicStaffs",
                        principalColumn: "AcademicStaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffPublication_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStaffs_CollegeId",
                table: "AcademicStaffs",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStaffs_departmentId",
                table: "AcademicStaffs",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeStaffs_collegeId",
                table: "AdministrativeStaffs",
                column: "collegeId");

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
                name: "IX_Budgets_BudgetDescriptionId",
                table: "Budgets",
                column: "BudgetDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CollegeId",
                table: "Budgets",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingDatas_CollegeId",
                table: "BuildingDatas",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_College_ApplicationUserId",
                table: "College",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_College_BandId",
                table: "College",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_College_InstitutionId",
                table: "College",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletionRates_DepartmentId",
                table: "CompletionRates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSharingReport_CollegeId",
                table: "CostSharingReport",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSharingReportFiles_CollegeId",
                table: "CostSharingReportFiles",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ApplicationUserId",
                table: "Departments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CollegeId",
                table: "Departments",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstitutionId",
                table: "Departments",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledStudents_DepartmentId",
                table: "DisabledStudents",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicalDisadvantagedAttrition_DepartmentId",
                table: "EconomicalDisadvantagedAttrition",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicalDisadvantagedEnrollment_DepartmentId",
                table: "EconomicalDisadvantagedEnrollment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EconomicalDisadvantagedGraduate_DepartmentId",
                table: "EconomicalDisadvantagedGraduate",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergingRegionAttritions_DepartmentId",
                table: "EmergingRegionAttritions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergingRegionEnrollments_DepartmentId",
                table: "EmergingRegionEnrollments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentByAges_DepartmentId",
                table: "EnrollmentByAges",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_DepartmentId",
                table: "Enrollments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Expatriates_DepartmentId",
                table: "Expatriates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignerStudents_DepartmentId",
                table: "ForeignerStudents",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_DepartmentId",
                table: "Graduates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduatesTotalExitExamination_DepartmentId",
                table: "GraduatesTotalExitExamination",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduatesTotalExitExaminationByDisability_DepartmentId",
                table: "GraduatesTotalExitExaminationByDisability",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduatesTotalExitExaminationByEconomy_DepartmentId",
                table: "GraduatesTotalExitExaminationByEconomy",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_ApplicationUserId",
                table: "Institutions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_InstanceId",
                table: "Institutions",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_IntakeCapacity_DepartmentId",
                table: "IntakeCapacity",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalRevenues_CollegeId",
                table: "InternalRevenues",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_DepartmentId",
                table: "Internships",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_CollegeId",
                table: "Investments",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementData_InstitutionId",
                table: "ManagementData",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewEnrollments_DepartmentId",
                table: "NewEnrollments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PastoralRegionEnrollments_DepartmentId",
                table: "PastoralRegionEnrollments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGraduateResearchPublication_DepartmentId",
                table: "PostGraduateResearchPublication",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectiveGraduates_DepartmentId",
                table: "ProspectiveGraduates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchPapers_DepartmentId",
                table: "ResearchPapers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RuralAttrition_DepartmentId",
                table: "RuralAttrition",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RuralEnrollment_DepartmentId",
                table: "RuralEnrollment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RuralGraduate_DepartmentId",
                table: "RuralGraduate",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedAttrition_DepartmentId",
                table: "SpecialNeedAttrition",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedGraduate_DepartmentId",
                table: "SpecialNeedGraduate",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPrograms_CollegeId",
                table: "StaffPrograms",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPrograms_DepartmentId",
                table: "StaffPrograms",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPublication_AcademicStaffId",
                table: "StaffPublication",
                column: "AcademicStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPublication_DepartmentId",
                table: "StaffPublication",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTrainings_CollegeId",
                table: "StaffTrainings",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTrainings_DepartmentId",
                table: "StaffTrainings",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttritions_DepartmentId",
                table: "StudentAttritions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportiveStaffs_DepartmentId",
                table: "SupportiveStaffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportiveStaffs_collegeId",
                table: "SupportiveStaffs",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalStaffs_departmentId",
                table: "TechnicalStaffs",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UnjustifiableExpense_InstitutionId",
                table: "UnjustifiableExpense",
                column: "InstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrativeStaffs");

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
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "BuildingDatas");

            migrationBuilder.DropTable(
                name: "CompletionRates");

            migrationBuilder.DropTable(
                name: "CostSharingReport");

            migrationBuilder.DropTable(
                name: "CostSharingReportFiles");

            migrationBuilder.DropTable(
                name: "DisabledStudents");

            migrationBuilder.DropTable(
                name: "EconomicalDisadvantagedAttrition");

            migrationBuilder.DropTable(
                name: "EconomicalDisadvantagedEnrollment");

            migrationBuilder.DropTable(
                name: "EconomicalDisadvantagedGraduate");

            migrationBuilder.DropTable(
                name: "EmergingRegionAttritions");

            migrationBuilder.DropTable(
                name: "EmergingRegionEnrollments");

            migrationBuilder.DropTable(
                name: "EnrollmentByAges");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Expatriates");

            migrationBuilder.DropTable(
                name: "ForeignerStudents");

            migrationBuilder.DropTable(
                name: "Graduates");

            migrationBuilder.DropTable(
                name: "GraduatesTotalExitExamination");

            migrationBuilder.DropTable(
                name: "GraduatesTotalExitExaminationByDisability");

            migrationBuilder.DropTable(
                name: "GraduatesTotalExitExaminationByEconomy");

            migrationBuilder.DropTable(
                name: "IntakeCapacity");

            migrationBuilder.DropTable(
                name: "InternalRevenues");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "ManagementData");

            migrationBuilder.DropTable(
                name: "NewEnrollments");

            migrationBuilder.DropTable(
                name: "PastoralRegionEnrollments");

            migrationBuilder.DropTable(
                name: "PostGraduateResearchPublication");

            migrationBuilder.DropTable(
                name: "ProspectiveGraduates");

            migrationBuilder.DropTable(
                name: "ResearchPapers");

            migrationBuilder.DropTable(
                name: "RuralAttrition");

            migrationBuilder.DropTable(
                name: "RuralEnrollment");

            migrationBuilder.DropTable(
                name: "RuralGraduate");

            migrationBuilder.DropTable(
                name: "SpecialNeedAttrition");

            migrationBuilder.DropTable(
                name: "SpecialNeedGraduate");

            migrationBuilder.DropTable(
                name: "StaffPrograms");

            migrationBuilder.DropTable(
                name: "StaffPublication");

            migrationBuilder.DropTable(
                name: "StaffTrainings");

            migrationBuilder.DropTable(
                name: "StudentAttritions");

            migrationBuilder.DropTable(
                name: "SupportiveStaffs");

            migrationBuilder.DropTable(
                name: "TechnicalStaffs");

            migrationBuilder.DropTable(
                name: "UnjustifiableExpense");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BudgetDescription");

            migrationBuilder.DropTable(
                name: "AcademicStaffs");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Instances");
        }
    }
}
