using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "ca_title", "CourseSectioncs_id", "ca_description", "course_id", "cs_id" },
                values: new object[] { "Testing Title Man", null, "Description of Title", 999, 999 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "created_date", "email", "enroll_status", "name", "password", "sys_role_id", "updated_date" },
                values: new object[] { 999, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStudent@school.com", 0, "Test User", "TESTtest", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseAssignments",
                keyColumn: "ca_title",
                keyValue: "Testing Title Man");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 999);
        }
    }
}
