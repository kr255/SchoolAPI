using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class initData : Migration
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
                name: "SectionEnrolls",
                columns: table => new
                {
                    section_enroll_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    se_created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionEnrolls", x => x.section_enroll_key);
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
                name: "CourseSections",
                columns: table => new
                {
                    course_section_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cs_create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.course_section_id);
                    table.ForeignKey(
                        name: "FK_CourseSections_Courses_courseid",
                        column: x => x.courseid,
                        principalTable: "Courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSectionEnroll",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    section_key = table.Column<int>(type: "int", nullable: false),
                    SectionEnrollsection_key = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSectionEnroll", x => new { x.UserId, x.section_key });
                    table.ForeignKey(
                        name: "FK_StudentSectionEnroll_SectionEnrolls_SectionEnrollsection_key",
                        column: x => x.SectionEnrollsection_key,
                        principalTable: "SectionEnrolls",
                        principalColumn: "section_enroll_key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSectionEnroll_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    course_assignment_title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ca_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => x.course_assignment_title);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_CourseSections_cs_id",
                        column: x => x.cs_id,
                        principalTable: "CourseSections",
                        principalColumn: "course_section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesSectionEnroll",
                columns: table => new
                {
                    cs_id = table.Column<int>(type: "int", nullable: false),
                    section_key = table.Column<int>(type: "int", nullable: false),
                    CourseSectioncs_id = table.Column<int>(type: "int", nullable: true),
                    SectionEnrollsection_key = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesSectionEnroll", x => new { x.cs_id, x.section_key });
                    table.ForeignKey(
                        name: "FK_CoursesSectionEnroll_CourseSections_CourseSectioncs_id",
                        column: x => x.CourseSectioncs_id,
                        principalTable: "CourseSections",
                        principalColumn: "course_section_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursesSectionEnroll_SectionEnrolls_SectionEnrollsection_key",
                        column: x => x.SectionEnrollsection_key,
                        principalTable: "SectionEnrolls",
                        principalColumn: "section_enroll_key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "course_id", "course_created_date", "course_description", "course_name", "course_updated_date" },
                values: new object[,]
                {
                    { 999, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Course Description", "Test Course", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Course Description", "Test Course", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Course Description", "Test Course", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SectionEnrolls",
                columns: new[] { "section_enroll_key", "se_created_date", "se_end_date", "se_start_date", "se_updated_date" },
                values: new object[] { 9, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "created_date", "email", "enroll_status", "name", "password", "sys_role_id", "updated_date" },
                values: new object[,]
                {
                    { 999, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStudent@school.com", 0, "Test User", "TESTtest", 0, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStudent2@school.com", 1, "Test User 2", "TESTtest2", 0, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CourseSections",
                columns: new[] { "course_section_id", "courseid", "cs_create_date", "cs_end_date", "cs_start_date", "cs_update_date" },
                values: new object[] { 999, 99, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "course_assignment_title", "ca_description", "cs_id" },
                values: new object[] { "Testing Title Man", "Description of Title", 999 });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_cs_id",
                table: "CourseAssignments",
                column: "cs_id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_courseid",
                table: "CourseSections",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSectionEnroll_CourseSectioncs_id",
                table: "CoursesSectionEnroll",
                column: "CourseSectioncs_id");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSectionEnroll_SectionEnrollsection_key",
                table: "CoursesSectionEnroll",
                column: "SectionEnrollsection_key");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSectionEnroll_SectionEnrollsection_key",
                table: "StudentSectionEnroll",
                column: "SectionEnrollsection_key");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "CoursesSectionEnroll");

            migrationBuilder.DropTable(
                name: "StudentSectionEnroll");

            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropTable(
                name: "SectionEnrolls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
