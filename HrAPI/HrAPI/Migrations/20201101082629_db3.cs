using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrAPI.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationProfession",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationTypeID = table.Column<int>(type: "int", nullable: false),
                    ProfessionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationProfession", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvaluationProfession_EvaluationType_EvaluationTypeID",
                        column: x => x.EvaluationTypeID,
                        principalTable: "EvaluationType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationProfession_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EvaluationDegreee = table.Column<int>(type: "int", nullable: false),
                    EvaluationProfessionID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evaluation_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_EvaluationProfession_EvaluationProfessionID",
                        column: x => x.EvaluationProfessionID,
                        principalTable: "EvaluationProfession",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_EmployeeID",
                table: "Evaluation",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_EvaluationProfessionID",
                table: "Evaluation",
                column: "EvaluationProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationProfession_EvaluationTypeID",
                table: "EvaluationProfession",
                column: "EvaluationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationProfession_ProfessionID",
                table: "EvaluationProfession",
                column: "ProfessionID");
        }
    }
}
