using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrAPI.Migrations
{
    public partial class db : Migration
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
                    ConcurrencyStamp = table.Column<string>(nullable: true)
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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeavesTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavesTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NeedRequestDTO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true),
                    CategotyName = table.Column<string>(nullable: true),
                    SubCategoryName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedRequestDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NeedsCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedsCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoriesDTO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoriesDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                name: "SubCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategories_NeedsCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "NeedsCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Certificate = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Compensations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compensations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    evaluation = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Excuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Approved = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    LeaveTypeID = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    AlternativeEmpID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    AlternativeAddress = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeavesTypes_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "LeavesTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction,onUpdate:ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LeaveFiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    LeaveRequestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaveFiles_LeaveRequests_LeaveRequestID",
                        column: x => x.LeaveRequestID,
                        principalTable: "LeaveRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionRequests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NeedsRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    SubCategoryID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedsRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NeedsRequests_NeedsCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "NeedsCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NeedsRequests_SubCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction,onUpdate:ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ManagerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CV_Bank",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProfessionID = table.Column<int>(nullable: false),
                    CV = table.Column<string>(nullable: true),
                    Accepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV_Bank", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CV_Bank_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction,onUpdate:ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ProfessionID = table.Column<int>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: true),
                    GraduatioYear = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RelevantPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true),
                    HiringDateHiringDate = table.Column<DateTime>(nullable: false),
                    AllowedLeaveDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Attendance_EmployeeID",
                table: "Attendance",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_EmployeeID",
                table: "Certificates",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Compensations_EmployeeID",
                table: "Compensations",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CV_Bank_ProfessionID",
                table: "CV_Bank",
                column: "ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProfessionID",
                table: "Employees",
                column: "ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_EmployeeID",
                table: "Evaluation",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Excuses_EmployeeID",
                table: "Excuses",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveFiles_LeaveRequestID",
                table: "LeaveFiles",
                column: "LeaveRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_AlternativeEmpID",
                table: "LeaveRequests",
                column: "AlternativeEmpID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeID",
                table: "LeaveRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeID",
                table: "LeaveRequests",
                column: "LeaveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MissionRequests_EmployeeID",
                table: "MissionRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_NeedsRequests_CategoryID",
                table: "NeedsRequests",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NeedsRequests_EmployeeID",
                table: "NeedsRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_NeedsRequests_SubCategoryID",
                table: "NeedsRequests",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_ManagerID",
                table: "Professions",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employees_EmployeeID",
                table: "Attendance",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Employees_EmployeeID",
                table: "Certificates",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compensations_Employees_EmployeeID",
                table: "Compensations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Employees_EmployeeID",
                table: "Evaluation",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Excuses_Employees_EmployeeID",
                table: "Excuses",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_AlternativeEmpID",
                table: "LeaveRequests",
                column: "AlternativeEmpID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeID",
                table: "LeaveRequests",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction,onUpdate:ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionRequests_Employees_EmployeeID",
                table: "MissionRequests",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NeedsRequests_Employees_EmployeeID",
                table: "NeedsRequests",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction,onUpdate:ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_Employees_ManagerID",
                table: "Professions",
                column: "ManagerID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction,onUpdate:ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professions_Employees_ManagerID",
                table: "Professions");

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
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Compensations");

            migrationBuilder.DropTable(
                name: "CV_Bank");

            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Excuses");

            migrationBuilder.DropTable(
                name: "LeaveFiles");

            migrationBuilder.DropTable(
                name: "MissionRequests");

            migrationBuilder.DropTable(
                name: "NeedRequestDTO");

            migrationBuilder.DropTable(
                name: "NeedsRequests");

            migrationBuilder.DropTable(
                name: "SubCategoriesDTO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "LeavesTypes");

            migrationBuilder.DropTable(
                name: "NeedsCategory");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
