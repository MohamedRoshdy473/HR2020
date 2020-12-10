using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrAPI.Migrations
{
    public partial class db6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "NeedsRequests");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "NeedRequestDTO");

            migrationBuilder.AddColumn<DateTime>(
                name: "NeedRequestDate",
                table: "NeedsRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NeedRequestDate",
                table: "NeedRequestDTO",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "NeedRequestDTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EvaluationProfessionDTO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationTypeID = table.Column<int>(nullable: false),
                    EvaluationTypeName = table.Column<string>(nullable: true),
                    ProfessionID = table.Column<int>(nullable: false),
                    ProfessionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationProfessionDTO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationProfessionDTO");

            migrationBuilder.DropColumn(
                name: "NeedRequestDate",
                table: "NeedsRequests");

            migrationBuilder.DropColumn(
                name: "NeedRequestDate",
                table: "NeedRequestDTO");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "NeedRequestDTO");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "NeedsRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "NeedRequestDTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
