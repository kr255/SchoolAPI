using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class initialData2 : Migration
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
                    cs_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cs_create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    course_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.cs_id);
                    table.ForeignKey(
                        name: "FK_CourseSections_Courses_course_id1",
                        column: x => x.course_id1,
                        principalTable: "Courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    ca_title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ca_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    cs_id = table.Column<int>(type: "int", nullable: false),
                    sectioncs_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => x.ca_title);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_CourseSections_sectioncs_id",
                        column: x => x.sectioncs_id,
                        principalTable: "CourseSections",
                        principalColumn: "cs_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionEnrolls",
                columns: table => new
                {
                    section_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    se_created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    se_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionEnrolls", x => x.section_key);
                    table.ForeignKey(
                        name: "FK_SectionEnrolls_CourseSections_cs_id",
                        column: x => x.cs_id,
                        principalTable: "CourseSections",
                        principalColumn: "cs_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSectionEnroll",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    section_key = table.Column<int>(type: "int", nullable: false),
                    user_id1 = table.Column<int>(type: "int", nullable: true),
                    section_key1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSectionEnroll", x => new { x.user_id, x.section_key });
                    table.ForeignKey(
                        name: "FK_StudentSectionEnroll_SectionEnrolls_section_key1",
                        column: x => x.section_key1,
                        principalTable: "SectionEnrolls",
                        principalColumn: "section_key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSectionEnroll_Users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "ca_title", "ca_description", "course_id", "cs_id", "sectioncs_id" },
                values: new object[] { "Testing Title Man", "Description of Title", 999, 999, null });

            migrationBuilder.InsertData(
                table: "CourseSections",
                columns: new[] { "cs_id", "course_id", "course_id1", "cs_create_date", "cs_end_date", "cs_start_date", "cs_update_date" },
                values: new object[] { 999, 999, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                table: "Users",
                columns: new[] { "user_id", "created_date", "email", "enroll_status", "name", "password", "sys_role_id", "updated_date" },
                values: new object[] { 999, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStudent@school.com", 0, "Test User", "TESTtest", 0, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SectionEnrolls",
                columns: new[] { "section_key", "cs_id", "se_created_date", "se_end_date", "se_start_date", "se_updated_date", "user_id" },
                values: new object[] { 9, 999, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 999 });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_sectioncs_id",
                table: "CourseAssignments",
                column: "sectioncs_id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_course_id1",
                table: "CourseSections",
                column: "course_id1");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolls_cs_id",
                table: "SectionEnrolls",
                column: "cs_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSectionEnroll_section_key1",
                table: "StudentSectionEnroll",
                column: "section_key1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSectionEnroll_user_id1",
                table: "StudentSectionEnroll",
                column: "user_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "StudentSectionEnroll");

            migrationBuilder.DropTable(
                name: "SectionEnrolls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
