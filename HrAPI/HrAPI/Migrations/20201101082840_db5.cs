using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrAPI.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationProfessions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionID = table.Column<int>(nullable: true),
                    EvaluationTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationProfessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvaluationProfessions_EvaluationTypes_EvaluationTypeID",
                        column: x => x.EvaluationTypeID,
                        principalTable: "EvaluationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EvaluationProfessions_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: true),
                    EvaluationProfessionID = table.Column<int>(nullable: true),
                    EvaluationDegreee = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
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
                        name: "FK_Evaluation_EvaluationProfessions_EvaluationProfessionID",
                        column: x => x.EvaluationProfessionID,
                        principalTable: "EvaluationProfessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
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
                name: "IX_EvaluationProfessions_EvaluationTypeID",
                table: "EvaluationProfessions",
                column: "EvaluationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationProfessions_ProfessionID",
                table: "EvaluationProfessions",
                column: "ProfessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "EvaluationProfessions");

            migrationBuilder.DropTable(
                name: "EvaluationTypes");
        }
    }
}
