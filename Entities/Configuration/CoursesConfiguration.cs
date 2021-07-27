using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class CoursesConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasData
            (
                new Courses 
                { 
                    course_id = 999,
                    course_name = "Test Course",
                    course_description = "Test Course Description"
                },
                new Courses
                {
                    course_id = 99,
                    course_name = "Test Course",
                    course_description = "Test Course Description"
                },
                new Courses
                {
                    course_id = 9,
                    course_name = "Test Course",
                    course_description = "Test Course Description"
                }
            );
        }
    }
}
