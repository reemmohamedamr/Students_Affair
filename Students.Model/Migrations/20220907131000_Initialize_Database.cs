using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Model.Migrations
{
    public partial class Initialize_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    StudentClass_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentClass_Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => x.StudentClass_ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(maxLength: 250, nullable: true),
                    Subject_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Subject_ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentClass_ID = table.Column<int>(nullable: false),
                    Student_Name = table.Column<string>(maxLength: 250, nullable: true),
                    Student_Address = table.Column<string>(maxLength: 250, nullable: true),
                    Student_BirthDate = table.Column<DateTime>(nullable: false),
                    Student_EmailAddress = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_ID);
                    table.ForeignKey(
                        name: "FK_Student_StudentClass",
                        column: x => x.StudentClass_ID,
                        principalTable: "StudentClass",
                        principalColumn: "StudentClass_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_ID = table.Column<int>(nullable: false),
                    Subject_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student",
                        column: x => x.Student_ID,
                        principalTable: "Student",
                        principalColumn: "Student_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject",
                        column: x => x.Subject_ID,
                        principalTable: "Subject",
                        principalColumn: "Subject_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentClass_ID",
                table: "Student",
                column: "StudentClass_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_Student_ID",
                table: "StudentSubject",
                column: "Student_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_Subject_ID",
                table: "StudentSubject",
                column: "Subject_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "StudentClass");
        }
    }
}
