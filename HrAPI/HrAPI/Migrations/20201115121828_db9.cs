using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrAPI.Migrations
{
    public partial class db9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationDTO");

            migrationBuilder.DropTable(
                name: "EvaluationProfessionDTO");

            migrationBuilder.DropTable(
                name: "NeedRequestDTO");

            migrationBuilder.DropTable(
                name: "SubCategoriesDTO");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    HiringDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    TrainingTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_courses_TrainingTypes_TrainingTypeID",
                        column: x => x.TrainingTypeID,
                        principalTable: "TrainingTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProfessions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionID = table.Column<int>(nullable: true),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProfessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingProfessions_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TrainingProfessions_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Certified = table.Column<string>(nullable: true),
                    TrainingPlace = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    InstructorID = table.Column<int>(nullable: false),
                    TrainingProfessionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainings_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingProfessions_TrainingProfessionID",
                        column: x => x.TrainingProfessionID,
                        principalTable: "TrainingProfessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_TrainingTypeID",
                table: "courses",
                column: "TrainingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProfessions_CourseID",
                table: "TrainingProfessions",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProfessions_ProfessionID",
                table: "TrainingProfessions",
                column: "ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_EmployeeID",
                table: "Trainings",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_InstructorID",
                table: "Trainings",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingProfessionID",
                table: "Trainings",
                column: "TrainingProfessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "TrainingProfessions");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "TrainingTypes");

            migrationBuilder.CreateTable(
                name: "EvaluationDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationDegreee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EvaluationProfessionID = table.Column<int>(type: "int", nullable: false),
                    EvaluationTypeID = table.Column<int>(type: "int", nullable: false),
                    EvaluationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionID = table.Column<int>(type: "int", nullable: false),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationProfessionDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationTypeID = table.Column<int>(type: "int", nullable: false),
                    EvaluationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionID = table.Column<int>(type: "int", nullable: false),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationProfessionDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NeedRequestDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedRequestDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoriesDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoriesDTO", x => x.ID);
                });
        }
    }
}
