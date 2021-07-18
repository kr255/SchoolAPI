using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    course_updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "CourseSections",
                columns: table => new
                {
                    cs_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    cs_create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.cs_id);
                });

            migrationBuilder.CreateTable(
                name: "SectionEnrolls",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    se_created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enroll_status = table.Column<int>(type: "int", nullable: false),
                    sys_role_id = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    ca_title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ca_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    cs_id = table.Column<int>(type: "int", nullable: false),
                    CourseSectioncs_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => x.ca_title);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_CourseSections_CourseSectioncs_id",
                        column: x => x.CourseSectioncs_id,
                        principalTable: "CourseSections",
                        principalColumn: "cs_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseSectioncs_id",
                table: "CourseAssignments",
                column: "CourseSectioncs_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SectionEnrolls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CourseSections");
        }
    }
}
