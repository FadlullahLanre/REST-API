using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIs_Tutorial.Migrations
{
    public partial class createlast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectOne = table.Column<int>(type: "int", nullable: false),
                    SubjectTwo = table.Column<int>(type: "int", nullable: false),
                    SubjectThree = table.Column<int>(type: "int", nullable: false),
                    SubjectFour = table.Column<int>(type: "int", nullable: false),
                    Aggregate = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)


                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.StudentID);
                });
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Results");


        }
    }
}

