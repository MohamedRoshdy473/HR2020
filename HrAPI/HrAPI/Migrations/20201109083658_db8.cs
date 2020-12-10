using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrAPI.Migrations
{
    public partial class db8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "EvaluationDegreee",
                table: "Evaluation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "EvaluationDTO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: true),
                    EvaluationProfessionID = table.Column<int>(nullable: false),
                    EvaluationTypeName = table.Column<string>(nullable: true),
                    ProfessionName = table.Column<string>(nullable: true),
                    ProfessionID = table.Column<int>(nullable: false),
                    EvaluationTypeID = table.Column<int>(nullable: false),
                    EvaluationDegreee = table.Column<decimal>(nullable: false),
                    EvaluationDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationDTO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationDTO");

            migrationBuilder.AlterColumn<int>(
                name: "EvaluationDegreee",
                table: "Evaluation",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
