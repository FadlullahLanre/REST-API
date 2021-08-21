using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIs_Tutorial.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamDetails",
                columns: table => new
                {
                    Examvenue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectFour = table.Column<string>(type: "nvarchar(max)", nullable: true), 
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamDetails", x => x.Examvenue);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamDetails");
        }
    }
}
