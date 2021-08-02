﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.CourseAssignment", b =>
                {
                    b.Property<string>("ca_title")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("course_assignment_title");

                    b.Property<string>("ca_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cs_id")
                        .HasColumnType("int");

                    b.HasKey("ca_title");

                    b.HasIndex("cs_id");

                    b.ToTable("CourseAssignments");

                    b.HasData(
                        new
                        {
                            ca_title = "Testing Title Man",
                            ca_description = "Description of Title",
                            cs_id = 999
                        });
                });

            modelBuilder.Entity("Entities.Models.CourseSection", b =>
                {
                    b.Property<int>("cs_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("course_section_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<DateTime>("cs_create_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("cs_end_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("cs_start_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("cs_update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("cs_id");

                    b.HasIndex("courseid");

                    b.ToTable("CourseSections");

                    b.HasData(
                        new
                        {
                            cs_id = 999,
                            courseid = 99,
                            cs_create_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            cs_end_date = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            cs_start_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            cs_update_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entities.Models.Courses", b =>
                {
                    b.Property<int>("courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("course_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("course_created_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("course_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("course_updated_date")
                        .HasColumnType("datetime2");

                    b.HasKey("courseid");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            courseid = 999,
                            course_created_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            course_description = "Test Course Description",
                            course_name = "Test Course",
                            course_updated_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            courseid = 99,
                            course_created_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            course_description = "Test Course Description",
                            course_name = "Test Course",
                            course_updated_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            courseid = 9,
                            course_created_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            course_description = "Test Course Description",
                            course_name = "Test Course",
                            course_updated_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entities.Models.CoursesSectionEnroll", b =>
                {
                    b.Property<int>("cs_id")
                        .HasColumnType("int");

                    b.Property<int>("section_key")
                        .HasColumnType("int");

                    b.Property<int?>("CourseSectioncs_id")
                        .HasColumnType("int");

                    b.Property<int?>("SectionEnrollsection_key")
                        .HasColumnType("int");

                    b.HasKey("cs_id", "section_key");

                    b.HasIndex("CourseSectioncs_id");

                    b.HasIndex("SectionEnrollsection_key");

                    b.ToTable("CoursesSectionEnroll");
                });

            modelBuilder.Entity("Entities.Models.SectionEnroll", b =>
                {
                    b.Property<int>("section_key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("section_enroll_key")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("se_created_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("se_end_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("se_start_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("se_updated_date")
                        .HasColumnType("datetime2");

                    b.HasKey("section_key");

                    b.ToTable("SectionEnrolls");

                    b.HasData(
                        new
                        {
                            section_key = 9,
                            se_created_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            se_end_date = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            se_start_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            se_updated_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entities.Models.StudentSectionEnroll", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("section_key")
                        .HasColumnType("int");

                    b.Property<int?>("SectionEnrollsection_key")
                        .HasColumnType("int");

                    b.HasKey("UserId", "section_key");

                    b.HasIndex("SectionEnrollsection_key");

                    b.ToTable("StudentSectionEnroll");
                });

            modelBuilder.Entity("Entities.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("enroll_status")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sys_role_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 999,
                            created_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "testStudent@school.com",
                            enroll_status = 0,
                            name = "Test User",
                            password = "TESTtest",
                            sys_role_id = 0,
                            updated_date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            UserId = 99,
                            created_date = new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "testStudent2@school.com",
                            enroll_status = 1,
                            name = "Test User 2",
                            password = "TESTtest2",
                            sys_role_id = 0,
                            updated_date = new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entities.Models.CourseAssignment", b =>
                {
                    b.HasOne("Entities.Models.CourseSection", "CourseSection")
                        .WithMany()
                        .HasForeignKey("cs_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSection");
                });

            modelBuilder.Entity("Entities.Models.CourseSection", b =>
                {
                    b.HasOne("Entities.Models.Courses", "course")
                        .WithMany()
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("Entities.Models.CoursesSectionEnroll", b =>
                {
                    b.HasOne("Entities.Models.CourseSection", "CourseSection")
                        .WithMany("CoursesSectionEnroll")
                        .HasForeignKey("CourseSectioncs_id");

                    b.HasOne("Entities.Models.SectionEnroll", "SectionEnroll")
                        .WithMany("CoursesSectionEnroll")
                        .HasForeignKey("SectionEnrollsection_key");

                    b.Navigation("CourseSection");

                    b.Navigation("SectionEnroll");
                });

            modelBuilder.Entity("Entities.Models.StudentSectionEnroll", b =>
                {
                    b.HasOne("Entities.Models.SectionEnroll", "SectionEnroll")
                        .WithMany("StudentSectionEnroll")
                        .HasForeignKey("SectionEnrollsection_key");

                    b.HasOne("Entities.Models.Users", "User")
                        .WithMany("StudentSectionEnroll")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SectionEnroll");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.CourseSection", b =>
                {
                    b.Navigation("CoursesSectionEnroll");
                });

            modelBuilder.Entity("Entities.Models.SectionEnroll", b =>
                {
                    b.Navigation("CoursesSectionEnroll");

                    b.Navigation("StudentSectionEnroll");
                });

            modelBuilder.Entity("Entities.Models.Users", b =>
                {
                    b.Navigation("StudentSectionEnroll");
                });
#pragma warning restore 612, 618
        }
    }
}
