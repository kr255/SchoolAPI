using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class initialdata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "created_date", "email", "enroll_status", "name", "password", "section_enroll_key", "sys_role_id", "updated_date" },
                values: new object[] { 99, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStudent2@school.com", 1, "Test User 2", "TESTtest2", 0, 0, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 99);
        }
    }
}
